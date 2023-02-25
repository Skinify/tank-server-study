namespace Base.Config
{
    public static class GameProperties
    {
        public static int SpaPriRoomContinueTime { get; internal set; } = 60;
        public static int ScanAuctionInterval { get; internal set; } = 30;

        public static void InitializeGameProperties(IDictionary<string, object> values)
        {
            Type type = typeof(GameProperties);
            type.GetProperties().ToList().ForEach(prop =>
            {
                if (!prop.CanWrite)
                    return;

                if (values.TryGetValue(prop.Name, out var value))
                    prop.SetValue(null, value);    
            });
        }
    }
}
