namespace Mass.Messaging
{
    public interface IServerConfigurationHelper<T> where T : IServerConfiguration
    {
        T Get();
    }
}
