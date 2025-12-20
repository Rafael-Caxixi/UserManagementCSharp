using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.DTOs.Request;
using UserManagement.Application.DTOs.Response;
using UserManagement.Domain.Entities.Usuario;

namespace UserManagement.Application.Services.Usuario
{
    public interface IUsuarioService
    {
        public Task<UsuarioResponseDTO> CriarUsuarioUseCase(UsuarioRequestDTO usuarioEntity);
        public Task<IEnumerable<UsuarioResponseDTO>> ListarUsuariosUseCase();
        public Task<UsuarioResponseDTO> ListarUsuarioPorLoginUseCase(string login);
        public Task DeletarUsuarioPorIdUseCase(long id);
    }
}
