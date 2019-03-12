namespace Mass.Messaging.RabbitMQ
{
    public class ServerConfiguration : IServerConfiguration
    {
        public string Uri { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
