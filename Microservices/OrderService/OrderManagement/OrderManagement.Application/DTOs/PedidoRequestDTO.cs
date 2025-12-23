using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Application.DTOs
{
    public class PedidoRequestDTO
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "O id do usuário deve ser maior que 0.")]
        public long IdUsuario { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade de itens deve ser maior que 0.")]
        public int QuantidadeItens { get; set; }

    }
}