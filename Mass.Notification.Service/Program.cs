using Mass.Infra;
using Mass.Messaging.MaasTransit;
using Mass.Messaging.RabbitMQ;
using Mass.Notification.Shared;
using MassTransit;
using System;
using System.Drawing;
using Console = Colorful.Console;

namespace Mass.Notification.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            var appConfigurationRoot = new AppConfigurationRootProvider().Get();
            var serverConfigurationHelper = new ServerConfigurationHelper(appConfigurationRoot);
            var bus = new BusConfigurator(serverConfigurationHelper).ConfigureBus((cfg, host) =>
            {
                cfg.ReceiveEndpoint(host, OrderNotificationConstants.OrderNotificationServiceQueue, e =>
                {
                    e.Consumer<OrderNotificationConsumer>();
                });
            });

            bus.Start();

            Console.WriteLine("Listening...", Color.Cyan);

            Console.ReadKey();

            bus.Stop();
        }
    }
}
