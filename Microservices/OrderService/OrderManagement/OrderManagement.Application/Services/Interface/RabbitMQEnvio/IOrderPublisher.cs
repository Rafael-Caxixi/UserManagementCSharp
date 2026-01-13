using OrderManagement.Application.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.Services.Interface.RabbitMQEnvio
{
    public interface IOrderPublisher
    {
        void PublishOrderCreatedEvent(OrderCreatedEvent evento);
    }
}
