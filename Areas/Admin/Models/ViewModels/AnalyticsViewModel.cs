namespace Inspect.Market.Areas.Admin.Models.ViewModels
{
    public class AnalyticsViewModel
    {
        public List<CryptoWatchlistViewModel> CryptosByWatchlist { get; set; }
        public List<CryptoPortfolioViewModel> CryptosByPortfolio { get; set; }
        public List<CryptoTradeCountViewModel> CryptosByTradeCount { get; set; }
    }
}
