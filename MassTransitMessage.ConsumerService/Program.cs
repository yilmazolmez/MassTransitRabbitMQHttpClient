using MassTransit;
using MassTransitMessage.ConsumerService;
using System.Reflection;

var host = Host.CreateDefaultBuilder(args).ConfigureServices((hostContext, services) =>
{
    services.AddMassTransit(x =>
    {

        x.AddConsumer<MessageConsumer>();

        //var entryAssembly = Assembly.GetEntryAssembly();

        //x.AddConsumers(entryAssembly);

        x.UsingRabbitMq((context, cfg) =>
        {
            cfg.Host(hostContext.Configuration.GetValue<string>("RabbitMQSettings:RabbitMQUri"), configurator =>
            {
                configurator.Username(hostContext.Configuration.GetValue<string>("RabbitMQSettings:RabbitMQUserName"));
                configurator.Password(hostContext.Configuration.GetValue<string>("RabbitMQSettings:RabbitMQPassword"));
            });

            cfg.ReceiveEndpoint("MessageConsumerQueue", ep =>
            {
                ep.ConfigureConsumer<MessageConsumer>(context);
            });

            //cfg.ConfigureEndpoints(context);
        });
    });

}).Build();



host.Run();
