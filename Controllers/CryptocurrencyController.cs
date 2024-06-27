using Inspect.Market.Context;
using Inspect.Market.Models.ViewModels;
using Inspect.Market.Models;
using Inspect.Market.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Inspect.Market.Areas.Api.Models.DTO;

namespace Inspect.Market.Controllers
{
    [Authorize]
    public class CryptocurrencyController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly MarketDataService _marketDataService;

        public CryptocurrencyController(ApplicationDbContext context, MarketDataService marketDataService)
        {
            _context = context;
            _marketDataService = marketDataService;
        }

        // GET: /cryptocurrency/{cryptocurrencySlug}
        public async Task<IActionResult> Details(string cryptocurrencySlug)
        {
            if (string.IsNullOrEmpty(cryptocurrencySlug))
            {
                return View(null);
            }

            var cryptocurrency = await _context.Cryptocurrencies
                .FirstOrDefaultAsync(c => c.Slug == cryptocurrencySlug);

            if (cryptocurrency == null)
            {
                return View(null);
            }

            var activeMarketData = _marketDataService.GetMarketData(cryptocurrency.Symbol);
            if (activeMarketData == null)
            {
                return View(null);
            }

            var marketData = _marketDataService.GetAllMarketData();
            var sortedMarketData = marketData.OrderByDescending(pair => pair.MarketCap).ToList();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var watchlist = await _context.Watchlists.FirstOrDefaultAsync(w => w.UserId == userId && w.CryptocurrencyId == cryptocurrency.Id);
            
            var viewModel = new CryptocurrencyDetailsViewModel
            {
                ActiveMarketData = activeMarketData,
                MarketData = sortedMarketData.ToList(),
                Watchlist = watchlist,
                Portfolio = new List<PortfolioDto>(),
            };

            var portfolio = await _context.Portfolios
                .Include(p => p.Holdings)
                .ThenInclude(h => h.Cryptocurrency)
                .Where(p => p.UserId == userId && p.Holdings.Any(h => h.CryptocurrencyId == cryptocurrency.Id))
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
            viewModel.Portfolio = portfolio;

            return View(viewModel);
        }
    }
}
