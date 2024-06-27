namespace Inspect.Market.Areas.Admin.Models.ViewModels
{
    public class CryptoPortfolioViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Slug { get; set; }
        public int PortfolioCount { get; set; }
    }
}
