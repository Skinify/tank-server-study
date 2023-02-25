using System.Net.Sockets;

namespace Extensions
{
    public static class SocketExtensions
    {
        public static bool IsSocketConnected(this Socket s)
        {
            return !((s.Poll(1000, SelectMode.SelectRead) && (s.Available == 0)) || !s.Connected);
        }

        public static string? GetClientIp(this Socket client)
        {
            if (client.RemoteEndPoint is null)
                return null;

            return client.RemoteEndPoint.ToString();
        }
    }
}
