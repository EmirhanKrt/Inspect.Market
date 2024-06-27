namespace Inspect.Market.Areas.Admin.Models.ViewModels
{
    public class CryptoWatchlistViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Slug { get; set; }
        public int WatchlistCount { get; set; }
    }
}
