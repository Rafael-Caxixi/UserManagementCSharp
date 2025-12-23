using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using UserManagement.Application.DTOs.Request;
using UserManagement.Application.Services.Interfaces;
using UserManagement.Domain.Entities.Usuario;

namespace UserManagement.Controllers
{
    [ApiController]
    [Route("usuarios")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> CriarUsuario([FromBody] UsuarioRequestDTO usuarioRequestDTO)
        {
            try
            {
                var usuarioRetorno = await _usuarioService.CriarUsuarioUseCase(usuarioRequestDTO);
                return Created($"usuarios/{usuarioRetorno.Id}", usuarioRetorno);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ListarUsuarios()
        {
            try
            {
                var listaUsuarios = await _usuarioService.ListarUsuariosUseCase();
                return Ok(listaUsuarios);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet("{login}")]
        public async Task<IActionResult> ListarUsuarioPorLogin(string login)
        {
            var usuario = await _usuarioService.ListarUsuarioPorLoginUseCase(login);

            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeletarUsuarioPorId(long id)
        {
            await _usuarioService.DeletarUsuarioPorIdUseCase(id);
            return NoContent();
        }

        //Retorna usuario caso exista (está sendo usado no HttpClient do Pedido)
        [HttpGet("{userId:long}")]
        public async Task<IActionResult> GetUserByIdAsync(long userId)
        {
            var user = await _usuarioService.ListarUsuarioPorIdUseCase(userId);

            if (user == null)
                return NotFound();

            return Ok(user);
        }
    }
}
