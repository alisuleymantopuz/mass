using Microsoft.Extensions.Configuration;
using System;

namespace Mass.Messaging.RabbitMQ
{
    public class ServerConfigurationHelper : IServerConfigurationHelper<IServerConfiguration>
    {
        public IConfiguration Configuration { get; set; }

        public ServerConfigurationHelper(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IServerConfiguration Get()
        {
            var configuration = new ServerConfiguration()
            {
                Uri = Configuration[Constants.ServerConfigurationKeys.UriKey],
                Username = Configuration[Constants.ServerConfigurationKeys.UsernameKey],
                Password = Configuration[Constants.ServerConfigurationKeys.PasswordKey],
            };

            return configuration;
        }

        public Uri GetUri(string queue = "")
        {
            var configuration = Get();

            return new Uri($"{configuration.Uri + queue}");
        }
    }
}
