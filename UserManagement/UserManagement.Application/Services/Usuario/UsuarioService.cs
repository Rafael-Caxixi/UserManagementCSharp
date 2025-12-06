using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Entities.Usuario;
using UserManagement.Infrastructure.Repositories.Usuario;

namespace UserManagement.Application.Services.Usuario
{
    public class UsuarioService : IUsuarioService
    {

        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task CriarUsuarioUseCase(UsuarioEntity usuarioEntity)
        {
            await _usuarioRepository.CriarUsuarioAsync(usuarioEntity);
        }
    }
}
