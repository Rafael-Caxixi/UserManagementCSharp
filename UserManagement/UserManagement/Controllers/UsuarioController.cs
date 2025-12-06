using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.Services.Usuario;
using UserManagement.Domain.Entities.Usuario;

namespace UserManagement.Controllers
{
    [ApiController]
    [Route("usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<string> CriarUsuario([FromBody] UsuarioEntity usuarioEntity)
        {
            await _usuarioService.CriarUsuarioUseCase(usuarioEntity);
            return "Usuario criado com sucesso";
        }

    }
}
