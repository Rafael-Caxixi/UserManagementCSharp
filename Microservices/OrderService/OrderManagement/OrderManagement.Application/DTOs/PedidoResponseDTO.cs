namespace OrderManagement.Api.DTOs
{
    public class PedidoResponseDTO
    {
        public long Id { get; set; }
        public DateTime DataPedido { get; set; }
        public string Status { get; set; }
        public int QuantidadeItens { get; set; }

    }
}
