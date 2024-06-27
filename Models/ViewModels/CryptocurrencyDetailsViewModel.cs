namespace Inspect.Market.Models.ViewModels
{
    public class CryptocurrencyDetailsViewModel : BaseDetailsViewModel
    {
        public required MarketData ActiveMarketData { get; set; }
        public Watchlist Watchlist { get; set; }

    }
}
