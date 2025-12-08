using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.DTOs.Request;
using UserManagement.Application.Services.Usuario;
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
                return Ok(usuarioRetorno);
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


        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeletarUsuarioPorId(Guid id)
        {
            await _usuarioService.DeletarUsuarioPorIdUseCase(id);
            return NoContent();
        }
    }
}
