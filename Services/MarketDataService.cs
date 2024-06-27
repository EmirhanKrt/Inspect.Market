using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;
using System.Net.WebSockets;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Websocket.Client;
using Inspect.Market.Models;
using Inspect.Market.Context;
using Inspect.Market.Hubs;

namespace Inspect.Market.Services
{
    public class MarketDataService : BackgroundService
    {
        private readonly ILogger<MarketDataService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IServiceProvider _serviceProvider;
        private readonly ConcurrentDictionary<string, MarketData> _marketData;
        private WebsocketClient _webSocketClient;
        private readonly IHubContext<MarketDataHub> _hubContext;

        const string USDTSymbol = "USDT";

        public MarketDataService(ILogger<MarketDataService> logger, IHttpClientFactory httpClientFactory, IServiceProvider serviceProvider, IHubContext<MarketDataHub> hubContext)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _serviceProvider = serviceProvider;
            _marketData = new ConcurrentDictionary<string, MarketData>();
            _hubContext = hubContext;
        }

        public IEnumerable<MarketData> GetAllMarketData()
        {
            return _marketData.Values;
        }

        public MarketData? GetMarketData(string symbol)
        {
            _marketData.TryGetValue(symbol, out var data);
            return data;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("MarketDataService is starting.");

            stoppingToken.Register(() => _logger.LogInformation("MarketDataService is stopping."));

            await InitializeMarketData(stoppingToken);

            /* 
             * Official Binance API Dökümantasyonu
             * https://binance-docs.github.io/apidocs/spot/en/#all-market-tickers-stream
            */
            var url = new Uri("wss://stream.binance.com:9443/ws/!ticker@arr");
            _webSocketClient = new WebsocketClient(url);

            _webSocketClient.MessageReceived.Subscribe(async msg => await WebSocket_OnMessage(msg.Text));

            _webSocketClient.Start();

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }

            _webSocketClient.Stop(WebSocketCloseStatus.NormalClosure, "Service stopping");
            _logger.LogInformation("MarketDataService has stopped.");
        }

        public async Task InitializeMarketData(CancellationToken stoppingToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var cryptocurrencies = await dbContext.Cryptocurrencies.ToListAsync(stoppingToken);

                var symbols = string.Join(",", cryptocurrencies.Where(c => c.Symbol != USDTSymbol).Select(c => $"\"{c.Symbol}{USDTSymbol}\""));

                try
                {
                    /* 
                     * Official Binance API Dökümantasyonu
                     * https://binance-docs.github.io/apidocs/spot/en/#symbol-order-book-ticker
                    */ 
                    var response = await _httpClientFactory.CreateClient().GetAsync($"https://api.binance.com/api/v3/ticker/24hr?symbols=[{symbols}]", stoppingToken);
                    response.EnsureSuccessStatusCode();

                    var content = await response.Content.ReadAsStringAsync(stoppingToken);
                    var tickers = JArray.Parse(content);

                    foreach (var ticker in tickers)
                    {
                        var symbol = ticker.Value<string>("symbol").Replace(USDTSymbol, "");
                        var cryptocurrency = cryptocurrencies.FirstOrDefault(c => c.Symbol == symbol);

                        if (cryptocurrency != null)
                        {
                            var marketData = new MarketData
                            {
                                Cryptocurrency = cryptocurrency,
                                Price = ticker.Value<decimal>("lastPrice"),
                                DailyLowPrice = ticker.Value<decimal>("lowPrice"),
                                DailyHighPrice = ticker.Value<decimal>("highPrice"),
                                Change24h = ticker.Value<decimal>("priceChangePercent"),
                                Volume24h = ticker.Value<decimal>("quoteVolume"),
                                CirculationSupply = cryptocurrency.CirculationSupply,
                                MarketCap = cryptocurrency.CirculationSupply * ticker.Value<decimal>("lastPrice")
                            };

                            _marketData[cryptocurrency.Symbol] = marketData;
                        }
                    }

                    _marketData[USDTSymbol] = new MarketData
                    {
                        Cryptocurrency = cryptocurrencies.FirstOrDefault(c => c.Symbol == USDTSymbol)!,
                        Price = 1,
                        DailyLowPrice = 1,
                        DailyHighPrice = 1,
                        Change24h = 0,
                        Volume24h = 0,
                        CirculationSupply = cryptocurrencies.FirstOrDefault(c => c.Symbol == USDTSymbol)!.CirculationSupply,
                        MarketCap = cryptocurrencies.FirstOrDefault(c => c.Symbol == USDTSymbol)!.CirculationSupply
                    };
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error initializing market data.");
                }
            }
        }

        private async Task WebSocket_OnMessage(string message)
        {
            try
            {
                var tickers = JArray.Parse(message);
                var generalData = new List<object>();

                foreach (var ticker in tickers)
                {
                    var symbol = ticker.Value<string>("s").Replace(USDTSymbol, "");

                    if (_marketData.TryGetValue(symbol, out var marketData))
                    {
                        marketData.Price = ticker.Value<decimal>("c");
                        marketData.DailyLowPrice = ticker.Value<decimal>("l");
                        marketData.DailyHighPrice = ticker.Value<decimal>("h");
                        marketData.Volume24h = ticker.Value<decimal>("q");
                        marketData.Change24h = ticker.Value<decimal>("P");
                        marketData.Volume24h = ticker.Value<decimal>("q");
                        marketData.MarketCap = ticker.Value<decimal>("c") * marketData.CirculationSupply;

                        var marketDataUpdate = new
                        {
                            Symbol = symbol,
                            Price = marketData.Price,
                            DailyLowPrice = marketData.DailyLowPrice,
                            DailyHighPrice = marketData.DailyHighPrice,
                            Change24h = marketData.Change24h,
                            Volume24h = marketData.Volume24h,
                            MarketCap = marketData.MarketCap,
                        };

                        /* Symbol ile ilgili WebSocket odasına mesajları gönderen yapı */
                    await _hubContext.Clients.Group(symbol).SendAsync("ReceiveMarketData", marketDataUpdate);
                        generalData.Add(marketDataUpdate);
                    }
                }

                /* General WebSocket odasına mesajları gönderen yapı */
                await _hubContext.Clients.Group("general").SendAsync("ReceiveMarketData", generalData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing WebSocket message.");
            }
        }
    }
}
