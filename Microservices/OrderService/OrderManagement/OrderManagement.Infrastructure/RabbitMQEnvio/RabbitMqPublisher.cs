using Microsoft.Extensions.Options;
using OrderManagement.Application.Services.Interface.RabbitMQEnvio;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace OrderManagement.Infrastructure.RabbitMQEnvio
{
    public class RabbitMqPublisher : IEventPublisher, IDisposable
    {
        private readonly RabbitMqSettings _settings;
        private readonly IConnection _connection;

        public RabbitMqPublisher(IOptions<RabbitMqSettings> options)
        {
            _settings = options.Value;

            var factory = new ConnectionFactory
            {
                HostName = _settings.Host,
                Port = _settings.Port,
                UserName = _settings.Username,
                Password = _settings.Password
            };

            _connection = factory.CreateConnection();
        }

        public void Dispose()
        {
            if (_connection.IsOpen)
                _connection.Close();

            _connection.Dispose();
        }

        public void Publish<T>(T message)
        {
            using var channel = _connection.CreateModel();

            // Exchange
            channel.ExchangeDeclare(
                exchange: _settings.Exchange,
                type: ExchangeType.Direct,
                durable: true
            );

            var body = Encoding.UTF8.GetBytes(
                JsonSerializer.Serialize(message)
            );

            var properties = channel.CreateBasicProperties();
            properties.Persistent = true; // evita perda de mensagem

            channel.BasicPublish(
                exchange: _settings.Exchange,
                routingKey: _settings.RoutingKey,
                basicProperties: properties,
                body: body
            );
        }
        //public void Publish<T>(T message)
        //{
        //    using var channel = _connection.CreateModel();

        //    channel.ExchangeDeclare(
        //        exchange: _settings.Exchange,
        //        type: ExchangeType.Direct,
        //        durable: true
        //    );

        //    var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

        //    channel.BasicPublish(
        //        exchange: _settings.Exchange,
        //        routingKey: _settings.RoutingKey,
        //        basicProperties: null,
        //        body: body
        //    );
        //}
    }
}
