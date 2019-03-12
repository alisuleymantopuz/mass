using Mass.Notification.Shared;
using Mass.Registration.Shared;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace Mass.Registration.Service
{
    public class RegisterOrderCommandConsumer : IConsumer<RegisterOrder>
    {
        public async Task Consume(ConsumeContext<RegisterOrder> context)
        {
            var command = context.Message;

            await Console.Out.WriteLineAsync($"Message has been received for {command.Name}");

            var orderNotification = new OrderNotification(context.Message.Name, context.Message.Email);

            await context.Publish(orderNotification);
        }
    }
}