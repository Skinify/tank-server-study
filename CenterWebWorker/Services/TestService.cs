namespace CenterWorker.Services
{
    public class TestService
    {
        private readonly List<string> _list;

        public TestService()
        {
            _list = new List<string>();
        }

        public bool AddServer(string serverIp)
        {
            if (_list.Contains(serverIp))
                return false;
            
            _list.Add(serverIp);
            return true;
        }

        public List<string> GetServers()
        {
            return _list;
        }
    }
}
