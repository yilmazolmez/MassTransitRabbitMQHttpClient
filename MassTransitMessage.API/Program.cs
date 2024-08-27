using MassTransit;
using MassTransitMessage.Contract;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(builder.Configuration.GetValue<string>("RabbitMQSettings:RabbitMQUri"), configurator =>
        {
            configurator.Username(builder.Configuration.GetValue<string>("RabbitMQSettings:RabbitMQUserName"));
            configurator.Password(builder.Configuration.GetValue<string>("RabbitMQSettings:RabbitMQPassword"));
        });

    });


    x.AddHttpClient<IMessageCommand>();
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
