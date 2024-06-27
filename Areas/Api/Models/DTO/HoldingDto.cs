namespace Inspect.Market.Areas.Api.Models.DTO
{
    public class HoldingDto
    {
        public int Id { get; set; }
        public int CryptocurrencyId { get; set; }
        public decimal CryptocurrencyAmount { get; set; }
        public decimal CryptocurrencyCost { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}
