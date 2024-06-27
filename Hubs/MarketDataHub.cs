using Microsoft.AspNetCore.SignalR;

namespace Inspect.Market.Hubs
{
    public class MarketDataHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var symbol = httpContext.Request.Query["symbol"].ToString();

            if (string.IsNullOrEmpty(symbol))
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, "general");
            }
            else
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, symbol);
            }

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var httpContext = Context.GetHttpContext();
            var symbol = httpContext.Request.Query["symbol"].ToString();

            if (string.IsNullOrEmpty(symbol))
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, "general");
            }
            else
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, symbol);
            }

            await base.OnDisconnectedAsync(exception);
        }
    }
}
