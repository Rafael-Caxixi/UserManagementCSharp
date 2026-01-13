using OrderManagement.Application.Events;
using OrderManagement.Application.Services.Interface.RabbitMQEnvio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Infrastructure.RabbitMQEnvio
{
    public class OrderPublisher : IOrderPublisher
    {
        private readonly IEventPublisher _publisher;

        public OrderPublisher(IEventPublisher publisher)
        {
            _publisher = publisher;
        }
        public void PublishOrderCreatedEvent(OrderCreatedEvent evento)
        {
            _publisher.Publish(evento);
        }
    }
}
