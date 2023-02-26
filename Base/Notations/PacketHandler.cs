namespace Base.Notations
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PacketHandler : Attribute
    {
        public int HandlerCode { get; private set; }
        public string? HandlerDescription { get; private set; }
        public PacketHandler(int handlerCode, string desc)
        {
            HandlerCode = handlerCode;
            HandlerDescription = desc;
        }

        public PacketHandler(int handlerCode)
        {
            HandlerCode = handlerCode;
        }
    }
}
