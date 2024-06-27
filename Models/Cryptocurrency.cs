namespace Inspect.Market.Models
{
    public class Cryptocurrency
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Symbol { get; set; }
        public required string Slug { get; set; }
        public decimal CirculationSupply { get; set; }
        public decimal TotalSupply { get; set; }
        public decimal? MaxSupply { get; set; }
        public int DecimalCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
