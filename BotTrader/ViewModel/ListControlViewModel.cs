using Binance.Spot;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace BotTrader.ViewModel
{
    public partial class ListControlViewModel
    {
        private ObservableCollection<String> ListData { get; set; } = new();

        public ListControlViewModel() 
        {
            _ = EngageWebSocketAsync();
        }

        private async Task EngageWebSocketAsync()
        {
            var websocket = new MarketDataWebSocket("btcusdt@aggTrade");

            websocket.OnMessageReceived(
            (data) => {
                ListData.Add(data);
                return Task.CompletedTask;
            },
            CancellationToken.None);

            await websocket.ConnectAsync(CancellationToken.None);
        }
    }
}
