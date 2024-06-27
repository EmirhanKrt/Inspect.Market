namespace Inspect.Market.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public decimal TransactionPrice { get; set; }
        public decimal TransactionAmount { get; set; }
        public required string TransactionType { get; set; } // "Buy" or "Sell"
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int HoldingId { get; set; }
        public virtual Holding Holding { get; set; }

        public int CryptocurrencyId { get; set; }
        public virtual Cryptocurrency Cryptocurrency { get; set; }
    }
}
