using InventoryWorker;
using InventoryWorker.Infrastructure.RabbitMQConsumo;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

builder.Services.Configure<RabbitMqSettings>(
    builder.Configuration.GetSection("RabbitMq"));


builder.Services.AddHostedService<OrderCreatedConsumer>();


var host = builder.Build();
host.Run();
