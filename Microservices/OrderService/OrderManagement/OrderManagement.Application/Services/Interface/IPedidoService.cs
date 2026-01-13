using OrderManagement.Api.DTOs;
using OrderManagement.Application.DTOs;

namespace OrderManagement.Application.Services.Interface
{
    public interface IPedidoService
    {
        Task<PedidoResponseDTO> CadastrarPedido(PedidoRequestDTO pedidoRequestDTO);
        Task<List<PedidoResponseDTO>> ListarPedidos();
    }
}