using Base;
using System.Net.WebSockets;

namespace RoadService.Connectors
{
    public class FightConnector : BaseConnector
    {
        public FightConnector(ClientWebSocket clientWebSocket, IServiceProvider serviceProvider, CancellationTokenSource cancellationToken) : base(clientWebSocket, serviceProvider, cancellationToken)
        {
        }
    }
}
