using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Infrastructure.RabbitMQEnvio
{
    public class RabbitMqSettings
    {
        public string Host { get; set; } = null!;
        public int Port { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Exchange { get; set; } = null!;
        public string RoutingKey { get; set; } = null!;
        public string Queue { get; set; } = null!;
    }
}

