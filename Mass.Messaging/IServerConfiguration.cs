namespace Mass.Messaging
{
    public interface IServerConfiguration
    {
        string Uri { get; set; }
        string Username { get; set; }
        string Password { get; set; }
    }
}
