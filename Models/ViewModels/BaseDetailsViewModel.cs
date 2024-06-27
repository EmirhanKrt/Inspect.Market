using Inspect.Market.Areas.Api.Models.DTO;

namespace Inspect.Market.Models.ViewModels
{
    public class BaseDetailsViewModel
    {
        public required List<MarketData> MarketData { get; set; }
        public required List<PortfolioDto> Portfolio { get; set; }

    }
}
