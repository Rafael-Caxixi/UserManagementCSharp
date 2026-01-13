using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.DTOs.Response;
using UserManagement.Domain.Entities.Usuario;

namespace UserManagement.Application.Services.Interfaces;

public interface IUsuarioRepository
{
    Task<UsuarioEntity> CriarUsuarioAsync(UsuarioEntity usuarioEntity);
    Task<IEnumerable<UsuarioEntity>> ListarUsuariosAsync();
    Task<UsuarioEntity> ListarUsuarioPorLoginAsync(string login);
    Task DeletarUsuarioPorIdAsync(long id);
    Task<UsuarioDtoClient> ListarUsuarioPorIdAsync(long id);
}
