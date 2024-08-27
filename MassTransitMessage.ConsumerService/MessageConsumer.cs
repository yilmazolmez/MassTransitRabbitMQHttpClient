using MassTransit;
using MassTransitMessage.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTransitMessage.ConsumerService
{
    public class MessageConsumer : IConsumer<IMessageCommand>
    {
        public  async Task Consume(ConsumeContext<IMessageCommand> context)
        {
            Console.WriteLine("Mesajımız okundu...");


            await context.RespondAsync(new MessageCommandResponse() { Message = "Mesaj başarıyla işlendi ve geriye değer dönüldü." });

            //return Task.CompletedTask;
        }
    }
}
