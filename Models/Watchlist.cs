namespace Inspect.Market.Models
{
    public class Watchlist
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int CryptocurrencyId { get; set; }
        public virtual Cryptocurrency Cryptocurrency { get; set; }
    }
}
