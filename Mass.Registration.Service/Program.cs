using Mass.Infra;
using Mass.Messaging.MaasTransit;
using Mass.Messaging.RabbitMQ;
using Mass.Registration.Shared;
using MassTransit;
using System.Drawing;
using Console = Colorful.Console;

namespace Mass.Registration.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            var appConfigurationRoot = new AppConfigurationRootProvider().Get();
            var serverConfigurationHelper = new ServerConfigurationHelper(appConfigurationRoot);
            var bus = new BusConfigurator(serverConfigurationHelper).ConfigureBus((cfg, host) =>
            {
                cfg.ReceiveEndpoint(host, RegisterOrderConstants.RegisterOrderServiceQueue, e =>
                {
                    e.Consumer<RegisterOrderCommandConsumer>();
                });
            });

            bus.Start();

            Console.WriteLine("Listening...", Color.Cyan);

            Console.ReadKey();

            bus.Stop();
        }
    }
}
