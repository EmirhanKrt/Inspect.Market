using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inspect.Market.Context;
using Inspect.Market.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Inspect.Market.Areas.Api.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Inspect.Market.Areas.Api.Controllers
{
    [Area("Api")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransactionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransactionController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTransactions()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var transaction = await _context.Transactions
                .Include(t => t.Cryptocurrency)
                .Include(t => t.Holding)
                .Where(t => t.Holding.Portfolio.UserId == userId)
                .Select(t => new TransactionDto
                {
                    Id = t.Id,
                    TransactionPrice = t.TransactionPrice,
                    TransactionAmount = t.TransactionAmount,
                    TransactionType = t.TransactionType,
                    CryptocurrencyId = t.CryptocurrencyId,
                    CreatedAt = t.CreatedAt,
                    UpdatedAt = t.UpdatedAt,
                    HoldingId = t.HoldingId,
                    Holding = new HoldingDto
                    {
                        Id = t.Holding.Id,
                        CryptocurrencyId = t.Holding.CryptocurrencyId,
                        CryptocurrencyAmount = t.Holding.CryptocurrencyAmount,
                        CryptocurrencyCost = t.Holding.CryptocurrencyCost,
                        CreatedAt = t.Holding.CreatedAt,
                        UpdatedAt = t.Holding.UpdatedAt,
                    },
                })
                .ToListAsync();

            if (transaction == null)
            {
                return NotFound();
            }

            return Ok(transaction);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransaction(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var transaction = await _context.Transactions
                .Include(t => t.Cryptocurrency)
                .Include(t => t.Holding)
                .Where(t => t.Id == id && t.Holding.Portfolio.UserId == userId)
                .Select(t=> new TransactionDto
                {
                    Id = t.Id,
                    TransactionPrice = t.TransactionPrice,
                    TransactionAmount = t.TransactionAmount,
                    TransactionType = t.TransactionType,
                    CryptocurrencyId = t.CryptocurrencyId,
                    CreatedAt = t.CreatedAt,
                    UpdatedAt = t.UpdatedAt,
                    HoldingId = t.HoldingId,
                    Holding = new HoldingDto
                    {
                        Id = t.Holding.Id,
                        CryptocurrencyId = t.Holding.CryptocurrencyId,
                        CryptocurrencyAmount = t.Holding.CryptocurrencyAmount,
                        CryptocurrencyCost = t.Holding.CryptocurrencyCost,
                        CreatedAt = t.Holding.CreatedAt,
                        UpdatedAt = t.Holding.UpdatedAt,
                    },
                })
                .FirstOrDefaultAsync();

            if (transaction == null)
            {
                return NotFound();
            }

            return Ok(transaction);
        }

        [HttpGet("holding/{holdingId}")]
        public async Task<IActionResult> GetTransactionsByHoldingId(int holdingId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var transactions = await _context.Transactions
                .Include(t => t.Cryptocurrency)
                .Include(t => t.Holding)
                .Where(t => t.Holding.Portfolio.UserId == userId && t.HoldingId == holdingId)
                .Select(t => new TransactionDto
                {
                    Id = t.Id,
                    TransactionPrice = t.TransactionPrice,
                    TransactionAmount = t.TransactionAmount,
                    TransactionType = t.TransactionType,
                    CryptocurrencyId = t.CryptocurrencyId,
                    CreatedAt = t.CreatedAt,
                    UpdatedAt = t.UpdatedAt,
                    HoldingId = t.HoldingId,
                    Holding = new HoldingDto
                    {
                        Id = t.Holding.Id,
                        CryptocurrencyId = t.Holding.CryptocurrencyId,
                        CryptocurrencyAmount = t.Holding.CryptocurrencyAmount,
                        CryptocurrencyCost = t.Holding.CryptocurrencyCost,
                        CreatedAt = t.Holding.CreatedAt,
                        UpdatedAt = t.Holding.UpdatedAt,
                    },
                })
                .ToListAsync();

            if (transactions == null || !transactions.Any())
            {
                return NotFound();
            }

            return Ok(transactions);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromBody] TransactionPostDto transactionPostDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (transactionPostDto.TransactionAmount <= 0)
            {
                return BadRequest("Transaction amount must be positive.");
            }

            if (transactionPostDto.TransactionPrice <= 0)
            {
                return BadRequest("Transaction price must be positive.");
            }

            if (transactionPostDto.TransactionType != "Buy" && transactionPostDto.TransactionType != "Sell")
            {
                return BadRequest("Transaction type must be Buy or Sell.");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var holding = await _context.Holdings
                .Include(h => h.Cryptocurrency)
                .Include(h => h.Portfolio)
                .FirstOrDefaultAsync(h => h.PortfolioId == transactionPostDto.PortfolioId && h.CryptocurrencyId == transactionPostDto.CryptocurrencyId && h.Portfolio.UserId == userId);

            if (holding == null)
            {
                holding = new Holding
                {
                    PortfolioId = transactionPostDto.PortfolioId,
                    CryptocurrencyAmount = transactionPostDto.TransactionType == "Buy" ? transactionPostDto.TransactionAmount : -transactionPostDto.TransactionAmount,
                    CryptocurrencyCost = transactionPostDto.TransactionType == "Buy" ? transactionPostDto.TransactionPrice : 0,
                    CryptocurrencyId = transactionPostDto.CryptocurrencyId,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    UserId = userId
                };

                _context.Holdings.Add(holding);
                await _context.SaveChangesAsync();
            }
            else
            {
                if (transactionPostDto.TransactionType == "Buy")
                {
                    var totalAmount = holding.CryptocurrencyAmount + transactionPostDto.TransactionAmount;
                    holding.CryptocurrencyCost = ((holding.CryptocurrencyCost * holding.CryptocurrencyAmount) + (transactionPostDto.TransactionPrice * transactionPostDto.TransactionAmount)) / totalAmount;
                    holding.CryptocurrencyAmount = totalAmount;
                }
                else
                {
                    var totalAmount = holding.CryptocurrencyAmount - transactionPostDto.TransactionAmount;
                    holding.CryptocurrencyAmount = totalAmount;
                }

                holding.UpdatedAt = DateTime.UtcNow;
                _context.Holdings.Update(holding);
                await _context.SaveChangesAsync();
            }

            var transaction = new Transaction
            {
                TransactionPrice = transactionPostDto.TransactionPrice,
                TransactionAmount = transactionPostDto.TransactionAmount,
                TransactionType = transactionPostDto.TransactionType,
                CryptocurrencyId = transactionPostDto.CryptocurrencyId,
                HoldingId = holding.Id,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            var response = new TransactionDto
            {
                Id = transaction.Id,
                TransactionPrice = transaction.TransactionPrice,
                TransactionAmount = transaction.TransactionAmount,
                TransactionType = transaction.TransactionType,
                CryptocurrencyId = transaction.CryptocurrencyId,
                CreatedAt = transaction.CreatedAt,
                UpdatedAt = transaction.UpdatedAt,
                HoldingId = transaction.HoldingId,
                Holding = new HoldingDto
                {
                    Id = holding.Id,
                    CryptocurrencyId = holding.CryptocurrencyId,
                    CryptocurrencyAmount = holding.CryptocurrencyAmount,
                    CryptocurrencyCost = holding.CryptocurrencyCost,
                    CreatedAt = holding.CreatedAt,
                    UpdatedAt = holding.UpdatedAt,
                },
            };

            return CreatedAtAction(nameof(GetTransaction), new { id = transaction.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransaction(int id, [FromBody] TransactionPostDto transactionPostDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (transactionPostDto.TransactionAmount <= 0)
            {
                return BadRequest("Transaction amount must be positive.");
            }

            if (transactionPostDto.TransactionPrice <= 0)
            {
                return BadRequest("Transaction price must be positive.");
            }

            if (transactionPostDto.TransactionType != "Buy" && transactionPostDto.TransactionType != "Sell")
            {
                return BadRequest("Transaction type must be Buy or Sell.");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var transaction = await _context.Transactions
                .Include(t => t.Holding)
                .ThenInclude(h => h.Cryptocurrency)
                .Include(t => t.Holding)
                .ThenInclude(h => h.Portfolio)
                .FirstOrDefaultAsync(t => t.Id == id && t.Holding.Portfolio.UserId == userId);

            if (transaction == null)
            {
                return NotFound();
            }

            var holding = transaction.Holding;
            var originalAmount = transaction.TransactionAmount;
            var originalType = transaction.TransactionType;

            if (originalType == "Buy")
            {
                var totalAmount = holding.CryptocurrencyAmount - originalAmount;
                if (totalAmount != 0)
                {
                    holding.CryptocurrencyCost = ((holding.CryptocurrencyCost * holding.CryptocurrencyAmount) - (transaction.TransactionPrice * originalAmount)) / totalAmount;
                }
                else
                {
                    holding.CryptocurrencyCost = 0;
                }
                holding.CryptocurrencyAmount = totalAmount;
            }
            else
            {
                holding.CryptocurrencyAmount += originalAmount;
            }

            if (transactionPostDto.TransactionType == "Buy")
            {
                var totalAmount = holding.CryptocurrencyAmount + transactionPostDto.TransactionAmount;
                holding.CryptocurrencyCost = ((holding.CryptocurrencyCost * holding.CryptocurrencyAmount) + (transactionPostDto.TransactionPrice * transactionPostDto.TransactionAmount)) / totalAmount;
                holding.CryptocurrencyAmount = totalAmount;
            }
            else
            {
                holding.CryptocurrencyAmount -= transactionPostDto.TransactionAmount;
            }

            holding.UpdatedAt = DateTime.UtcNow;
            _context.Holdings.Update(holding);
            await _context.SaveChangesAsync();

            transaction.TransactionPrice = transactionPostDto.TransactionPrice;
            transaction.TransactionAmount = transactionPostDto.TransactionAmount;
            transaction.TransactionType = transactionPostDto.TransactionType;
            transaction.CryptocurrencyId = transactionPostDto.CryptocurrencyId;
            transaction.UpdatedAt = DateTime.UtcNow;

            _context.Entry(transaction).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            var response = new TransactionDto
            {
                Id = transaction.Id,
                TransactionPrice = transaction.TransactionPrice,
                TransactionAmount = transaction.TransactionAmount,
                TransactionType = transaction.TransactionType,
                CryptocurrencyId = transaction.CryptocurrencyId,
                CreatedAt = transaction.CreatedAt,
                UpdatedAt = transaction.UpdatedAt,
                HoldingId = transaction.HoldingId,
                Holding = new HoldingDto
                {
                    Id = holding.Id,
                    CryptocurrencyId = holding.CryptocurrencyId,
                    CryptocurrencyAmount = holding.CryptocurrencyAmount,
                    CryptocurrencyCost = holding.CryptocurrencyCost,
                    CreatedAt = holding.CreatedAt,
                    UpdatedAt = holding.UpdatedAt,
                },
            };

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var transaction = await _context.Transactions
                .Include(t => t.Holding)
                .ThenInclude(h => h.Cryptocurrency)
                .Include(t => t.Holding)
                .ThenInclude(h => h.Portfolio)
                .FirstOrDefaultAsync(t => t.Id == id && t.Holding.Portfolio.UserId == userId);

            if (transaction == null)
            {
                return NotFound();
            }

            var holding = transaction.Holding;
            var transactionAmount = transaction.TransactionAmount;
            var transactionPrice = transaction.TransactionPrice;

            if (transaction.TransactionType == "Buy")
            {
                var totalAmount = holding.CryptocurrencyAmount - transactionAmount;
                if (totalAmount != 0)
                {
                    holding.CryptocurrencyCost = ((holding.CryptocurrencyCost * holding.CryptocurrencyAmount) - (transactionPrice * transactionAmount)) / totalAmount;
                }
                else
                {
                    holding.CryptocurrencyCost = 0;
                }
                holding.CryptocurrencyAmount = totalAmount;
            }
            else
            {
                holding.CryptocurrencyAmount += transactionAmount;
            }

            holding.UpdatedAt = DateTime.UtcNow;
            _context.Holdings.Update(holding);
            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();

            var response = new TransactionDto
            {
                Id = transaction.Id,
                TransactionPrice = transaction.TransactionPrice,
                TransactionAmount = transaction.TransactionAmount,
                TransactionType = transaction.TransactionType,
                CryptocurrencyId = transaction.CryptocurrencyId,
                CreatedAt = transaction.CreatedAt,
                UpdatedAt = transaction.UpdatedAt,
                HoldingId = transaction.HoldingId,
                Holding = new HoldingDto
                {
                    Id = holding.Id,
                    CryptocurrencyId = holding.CryptocurrencyId,
                    CryptocurrencyAmount = holding.CryptocurrencyAmount,
                    CryptocurrencyCost = holding.CryptocurrencyCost,
                    CreatedAt = holding.CreatedAt,
                    UpdatedAt = holding.UpdatedAt,
                },
            };

            return Ok(response);
        }
    }
}
