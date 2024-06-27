namespace Inspect.Market.Areas.Api.Models.DTO
{
    public class PortfolioDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UserId { get; set; }
        public List<HoldingDto> Holdings { get; set; }
    }
}
