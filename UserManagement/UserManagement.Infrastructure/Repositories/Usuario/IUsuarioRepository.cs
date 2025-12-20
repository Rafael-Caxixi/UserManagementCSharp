using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Entities.Usuario;

namespace UserManagement.Infrastructure.Repositories.Usuario
{
    public interface IUsuarioRepository
    {
        Task<UsuarioEntity> CriarUsuarioAsync(UsuarioEntity usuarioEntity);
        Task<IEnumerable<UsuarioEntity>> ListarUsuariosAsync();
        Task<UsuarioEntity> ListarUsuarioPorLoginAsync(string login);
        Task DeletarUsuarioPorIdAsync(long id);
    }
}
