using Mass.Notification.Shared;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace Mass.Notification.Service
{
    public class OrderNotificationConsumer : IConsumer<OrderNotification>
    {
        public async Task Consume(ConsumeContext<OrderNotification> context)
        {
            //Save to db
            await Console.Out.WriteLineAsync($"New order received: Order id {context.Message.Name}");
        }
    }
}
