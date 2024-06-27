namespace Inspect.Market.Models
{
    public class Portfolio
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public string UserId { get; set; }
        public virtual ICollection<Holding> Holdings { get; set; }
    }
}
