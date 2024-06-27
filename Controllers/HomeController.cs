using Inspect.Market.Areas.Api.Models.DTO;
using Inspect.Market.Context;
using Inspect.Market.Models;
using Inspect.Market.Models.ViewModels;
using Inspect.Market.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace Inspect.Market.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly MarketDataService _marketDataService;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, MarketDataService marketDataService)
        {
            _logger = logger;
            _context = context;
            _marketDataService = marketDataService;
        }

        public async Task<IActionResult> Index()
        {
            var marketData = _marketDataService.GetAllMarketData();
            var sortedMarketData = marketData.OrderByDescending(pair => pair.MarketCap).ToList();

            var viewModel = new HomeViewModel
            {
                MarketData = sortedMarketData.ToList(),
                Watchlist = new List<Watchlist>(),
                Portfolio = new List<PortfolioDto>(),
            };

            if (User.Identity.IsAuthenticated)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var watchlists = await _context.Watchlists.Where(w => w.UserId == userId)
                    .Select(w => new Watchlist
                    {
                        Id = w.Id,
                        UserId = w.UserId,
                        CryptocurrencyId = w.CryptocurrencyId,
                    })
                    .ToListAsync();
                viewModel.Watchlist = watchlists;

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
                viewModel.Portfolio = portfolios;
            }

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
