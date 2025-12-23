using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.DTOs;
using OrderManagement.Application.Services.Interface;

namespace OrderManagement.Api.Controllers
{
    [ApiController]
    [Route("/pedidos")]  
    public class PedidoController : ControllerBase
    {

        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpPost("cadastrar-pedido")]
        public async Task<IActionResult> CadastrarPedido([FromBody] PedidoRequestDTO pedidoRequestDTO)
        {
            try
            {
                var resultado = await _pedidoService.CadastrarPedido(pedidoRequestDTO);
                return Created($"pedidos/{resultado.Id}", resultado);
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

    }
}
