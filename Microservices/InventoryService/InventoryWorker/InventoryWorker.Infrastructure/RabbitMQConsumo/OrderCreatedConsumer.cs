using InventoryWorker.Application.Events;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace InventoryWorker.Infrastructure.RabbitMQConsumo
{
    public class OrderCreatedConsumer : BackgroundService
    {
        private readonly RabbitMqSettings _settings;
        private IConnection _connection = null!;
        private IModel _channel = null!;

        public OrderCreatedConsumer(IOptions<RabbitMqSettings> options)
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
            _channel = _connection.CreateModel();

            // Exchange
            _channel.ExchangeDeclare(
                exchange: _settings.Exchange,
                type: ExchangeType.Direct,
                durable: true
            );

            // Queue
            _channel.QueueDeclare(
                queue: _settings.Queue,
                durable: true,
                exclusive: false,
                autoDelete: false
            );

            // Bind
            _channel.QueueBind(
                queue: _settings.Queue,
                exchange: _settings.Exchange,
                routingKey: _settings.RoutingKey
            );

            // Evita flood
            _channel.BasicQos(0, 1, false);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (sender, args) =>
            {
                try
                {
                    var json = Encoding.UTF8.GetString(args.Body.ToArray());
                    var message = JsonSerializer.Deserialize<OrderCreatedEvent>(json);

                    Console.WriteLine($"[Consumer] Pedido recebido: {message?.Id}");

                    // REGRA DE NEGÓCIO AQUI
                    // ProcessPayment(message);

                    _channel.BasicAck(args.DeliveryTag, false);
                }
                catch (Exception)
                {
                    // erro → volta pra fila
                    _channel.BasicNack(args.DeliveryTag, false, true);
                }
            };

            _channel.BasicConsume(
                queue: _settings.Queue,
                autoAck: false,
                consumer: consumer
            );

            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            _channel?.Close();
            _connection?.Close();
            base.Dispose();
        }
    }
}
