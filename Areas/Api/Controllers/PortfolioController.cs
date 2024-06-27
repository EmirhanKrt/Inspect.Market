using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inspect.Market.Context;
using Inspect.Market.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Inspect.Market.Areas.Api.Models.DTO;

namespace Inspect.Market.Areas.Api.Controllers
{
    [Area("Api")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PortfolioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PortfolioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Api/Portfolio
        [HttpGet]
        public async Task<IActionResult> GetPortfolios()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var portfolios = await _context.Portfolios
                .Include(p => p.Holdings)
                .ThenInclude(h => h.Cryptocurrency)
                .Where(w => w.UserId == userId)
                .Select(p => new PortfolioDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt,
                    UserId = p.UserId,
                    Holdings = p.Holdings.Select(h => new HoldingDto
                    {
                        Id = h.Id,
                        CryptocurrencyId = h.CryptocurrencyId,
                        CryptocurrencyAmount = h.CryptocurrencyAmount,
                        CryptocurrencyCost = h.CryptocurrencyCost,
                        CreatedAt = h.CreatedAt,
                        UpdatedAt = h.UpdatedAt
                    }).ToList()
                })
                .ToListAsync();

            return Ok(portfolios);
        }

        // GET: Api/Portfolio/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPortfolio(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var portfolio = await _context.Portfolios
                .Include(p => p.Holdings)
                .ThenInclude(h => h.Cryptocurrency)
                .Where(p => p.Id == id && p.UserId == userId)
                .Select(p => new PortfolioDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt,
                    UserId = p.UserId,
                    Holdings = p.Holdings.Select(h => new HoldingDto
                    {
                        Id = h.Id,
                        CryptocurrencyId = h.CryptocurrencyId,
                        CryptocurrencyAmount = h.CryptocurrencyAmount,
                        CryptocurrencyCost = h.CryptocurrencyCost,
                        CreatedAt = h.CreatedAt,
                        UpdatedAt = h.UpdatedAt
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            if (portfolio == null)
            {
                return NotFound();
            }

            return Ok(portfolio);
        }

        // POST: Api/Portfolio
        [HttpPost]
        public async Task<IActionResult> CreatePortfolio([FromBody] PortfolioPostDto portfolioPostDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var portfolio = new Portfolio
            {
                UserId = userId,
                Name = portfolioPostDto.Name,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Holdings = new List<Holding>()
            };

            _context.Portfolios.Add(portfolio);
            await _context.SaveChangesAsync();

            var portfolioDto = new PortfolioDto
            {
                Id = portfolio.Id,
                UserId = portfolio.UserId,
                Name = portfolio.Name,
                CreatedAt = portfolio.CreatedAt,
                UpdatedAt = portfolio.UpdatedAt,
                Holdings = portfolio.Holdings.Select(h => new HoldingDto
                {
                    Id = h.Id,
                    CryptocurrencyId = h.CryptocurrencyId,
                    CryptocurrencyAmount = h.CryptocurrencyAmount,
                    CryptocurrencyCost = h.CryptocurrencyCost,
                    CreatedAt = h.CreatedAt,
                    UpdatedAt = h.UpdatedAt
                }).ToList()
            };

            return CreatedAtAction(nameof(GetPortfolio), new { id = portfolio.Id }, portfolioDto);
        }

        // PUT: Api/Portfolio/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePortfolio(int id, [FromBody] PortfolioPostDto portfolioPostDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var portfolio = await _context.Portfolios
                .Include(p => p.Holdings)
                .Where(w => w.Id == id && w.UserId == userId)
                .FirstOrDefaultAsync();

            if (portfolio == null)
            {
                return NotFound();
            }

            portfolio.Name = portfolioPostDto.Name;
            portfolio.UpdatedAt = DateTime.UtcNow;

            _context.Entry(portfolio).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            var portfolioDto = new PortfolioDto
            {
                Id = portfolio.Id,
                UserId = portfolio.UserId,
                Name = portfolio.Name,
                CreatedAt = portfolio.CreatedAt,
                UpdatedAt = portfolio.UpdatedAt,
                Holdings = portfolio.Holdings.Select(h => new HoldingDto
                {
                    Id = h.Id,
                    CryptocurrencyId = h.CryptocurrencyId,
                    CryptocurrencyAmount = h.CryptocurrencyAmount,
                    CryptocurrencyCost = h.CryptocurrencyCost,
                    CreatedAt = h.CreatedAt,
                    UpdatedAt = h.UpdatedAt
                }).ToList()
            };

            return Ok(portfolioDto);
        }

        // DELETE: Api/Portfolio/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePortfolio(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var portfolio = await _context.Portfolios
                .Include(p => p.Holdings)
                .ThenInclude(h => h.Transactions)
                .Where(w => w.Id == id && w.UserId == userId)
                .FirstOrDefaultAsync();

            if (portfolio == null)
            {
                return NotFound();
            }

            // Remove related transactions
            foreach (var holding in portfolio.Holdings)
            {
                _context.Transactions.RemoveRange(holding.Transactions);
            }

            // Remove holdings
            _context.Holdings.RemoveRange(portfolio.Holdings);

            // Remove portfolio
            _context.Portfolios.Remove(portfolio);

            await _context.SaveChangesAsync();

            var portfolioDto = new PortfolioDto
            {
                Id = portfolio.Id,
                UserId = portfolio.UserId,
                Name = portfolio.Name,
                CreatedAt = portfolio.CreatedAt,
                UpdatedAt = portfolio.UpdatedAt,
                Holdings = portfolio.Holdings.Select(h => new HoldingDto
                {
                    Id = h.Id,
                    CryptocurrencyId = h.CryptocurrencyId,
                    CryptocurrencyAmount = h.CryptocurrencyAmount,
                    CryptocurrencyCost = h.CryptocurrencyCost,
                    CreatedAt = h.CreatedAt,
                    UpdatedAt = h.UpdatedAt
                }).ToList()
            };

            return Ok(portfolioDto);
        }
    }
}
