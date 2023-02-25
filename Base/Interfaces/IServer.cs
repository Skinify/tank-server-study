namespace Base.Interface
{
    public interface IServer
    {
        public Task Start();
        public Task Stop(CancellationToken cancellationToken);
    }
}
