namespace Inspect.Market.Models
{
    public class Holding
    {
        public int Id { get; set; }
        public decimal CryptocurrencyAmount { get; set; }
        public decimal CryptocurrencyCost { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int PortfolioId { get; set; }
        public virtual Portfolio Portfolio { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int CryptocurrencyId { get; set; }
        public virtual Cryptocurrency Cryptocurrency { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
