using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryWorker.Application.Events
{
    public class OrderCreatedEvent
    {
        public long Id { get; set; }
        public long IdUsuario { get; set; }
        public DateTime DataPedido { get; set; }
        public string Status{ get; set; }

        public int QuantidadeItens { get; set; }

        public OrderCreatedEvent(long idUsuario, int quantidadeItens, DateTime dataPedido)
        {
            IdUsuario = idUsuario;
            DataPedido = dataPedido;
            Status = "Pendente";
            QuantidadeItens = quantidadeItens;
        }
    }
}
