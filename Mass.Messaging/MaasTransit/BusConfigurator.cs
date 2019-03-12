using Mass.Infra;
using Mass.Messaging.RabbitMQ;
using MassTransit;
using MassTransit.RabbitMqTransport;
using System;

namespace Mass.Messaging.MaasTransit
{
    public class BusConfigurator
    {
        public ServerConfigurationHelper ServerConfigurationHelper { get; set; }

        public BusConfigurator(ServerConfigurationHelper serverConfigurationHelper)
        {
            ServerConfigurationHelper = serverConfigurationHelper;
        }

        public IBusControl ConfigureBus(Action<IRabbitMqBusFactoryConfigurator, IRabbitMqHost> registrationAction = null)
        {
            var appConfigurationRoot = new AppConfigurationRootProvider();

            var mqServerConfiguration = ServerConfigurationHelper.Get();

            var busFactory = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri(mqServerConfiguration.Uri), hst =>
                {
                    hst.Username(mqServerConfiguration.Username);
                    hst.Password(mqServerConfiguration.Password);
                });

                registrationAction?.Invoke(cfg, host);
            });

            return busFactory;
        }
    }
}
