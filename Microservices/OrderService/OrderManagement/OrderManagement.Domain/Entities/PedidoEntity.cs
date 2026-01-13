using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Domain.Entities
{
    public class PedidoEntity
    {

        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("idUsuario")]
        public long IdUsuario { get; set; }

        [Column("dataPedido")]
        public DateTime DataPedido { get; set; }

        [Column("status")]
        public string Status { get; set; }

        [Column("quantidadeItens")]
        public int QuantidadeItens { get; set; }
        public PedidoEntity()
        {
        }

        public PedidoEntity(long idUsuario, int quantidadeItens)
        {
            IdUsuario = idUsuario;
            DataPedido = DateTime.Now;
            Status = "Pendente";
            QuantidadeItens = quantidadeItens;
        }
    }
}
