namespace Inspect.Market.Areas.Api.Models.DTO
{
    public class TransactionPostDto
    {
        public decimal TransactionPrice { get; set; }
        public decimal TransactionAmount { get; set; }
        public required string TransactionType { get; set; } // "Buy" or "Sell"
        public int PortfolioId { get; set; }
        public int CryptocurrencyId { get; set; }
    }
}
