using Inspect.Market.Models;

namespace Inspect.Market.Areas.Api.Models.DTO
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public decimal TransactionPrice { get; set; }
        public decimal TransactionAmount { get; set; } 
        public required string TransactionType { get; set; }
        public int CryptocurrencyId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int HoldingId { get; set; }
        public virtual HoldingDto Holding { get; set; }
    }
}
