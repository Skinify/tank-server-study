namespace Base
{
    public class BaseHandler
    {
        protected readonly IServiceProvider _serviceProvider;

        public BaseHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public int HandlerCode { get; private set; }

        public object? User { get; set; } = null;

    }
}
