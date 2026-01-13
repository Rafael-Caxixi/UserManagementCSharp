using Microsoft.EntityFrameworkCore;
using OrderManagement.Api.Client.Impl;
using OrderManagement.Application.Services.Impl;
using OrderManagement.Application.Services.Interface;
using OrderManagement.Application.Services.Interface.Client;
using OrderManagement.Application.Services.Interface.RabbitMQEnvio;
using OrderManagement.Application.Services.Interface.Repositories;
using OrderManagement.Infrastructure.Persistence;
using OrderManagement.Infrastructure.Persistence.Repositories;
using OrderManagement.Infrastructure.RabbitMQEnvio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPedidoService, PedidoService>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();

builder.Services.AddScoped<IOrderPublisher, OrderPublisher>();
builder.Services.AddScoped<IEventPublisher, RabbitMqPublisher>();

builder.Services.Configure<RabbitMqSettings>(
    builder.Configuration.GetSection("RabbitMQ"));



//builder.Services.AddScoped<IUserClient, UserClient>();

//builder.Services.AddHttpClient<IUserClient, UserClient>(client =>
//{
//    client.BaseAddress = new Uri("https://localhost:8080"); // UserManagement service URL
//    client.Timeout = TimeSpan.FromSeconds(5);
//});
builder.Services.AddHttpClient<IUserClient, UserClient>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["UserApi:BaseUrl"]);
});



var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}


// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
