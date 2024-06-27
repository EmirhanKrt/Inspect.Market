using Inspect.Market.Areas.Admin.Models.ViewModels;
using Inspect.Market.Context;
using Inspect.Market.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inspect.Market.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    [Authorize(Roles ="Administrator")]
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
            var cryptosByWatchlist = await _context.Cryptocurrencies
                .Select(c => new CryptoWatchlistViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Symbol = c.Symbol,
                    Slug = c.Slug,
                    WatchlistCount = _context.Watchlists.Count(w => w.CryptocurrencyId == c.Id)
                })
                .OrderByDescending(c => c.WatchlistCount)
                .ToListAsync();

            var cryptosByPortfolio = await _context.Cryptocurrencies
                .Select(c => new CryptoPortfolioViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Symbol = c.Symbol,
                    Slug = c.Slug,
                    PortfolioCount = _context.Holdings.Count(h => h.CryptocurrencyId == c.Id)
                })
                .OrderByDescending(c => c.PortfolioCount)
                .ToListAsync();

            var cryptosByTradeCount = await _context.Cryptocurrencies
                .Select(c => new CryptoTradeCountViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Symbol = c.Symbol,
                    Slug = c.Slug,
                    TradeCount = _context.Transactions.Count(t => t.CryptocurrencyId == c.Id)
                })
                .OrderByDescending(c => c.TradeCount)
                .ToListAsync();

            var viewModel = new AnalyticsViewModel
            {
                CryptosByWatchlist = cryptosByWatchlist,
                CryptosByPortfolio = cryptosByPortfolio,
                CryptosByTradeCount = cryptosByTradeCount,
            };

            return View(viewModel);
        }
    }
}
