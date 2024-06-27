namespace Inspect.Market.Models
{
    public class MarketData
    {
        public decimal Price { get; set; }
        public decimal DailyLowPrice { get; set; }
        public decimal DailyHighPrice { get; set; }
        public decimal Change24h { get; set; }
        public decimal Volume24h { get; set; }
        public decimal MarketCap { get; set; }
        public decimal CirculationSupply { get; set; }
        public virtual required Cryptocurrency Cryptocurrency { get; set; }
    }
}
