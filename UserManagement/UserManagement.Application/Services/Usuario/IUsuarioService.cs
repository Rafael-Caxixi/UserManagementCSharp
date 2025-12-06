using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Entities.Usuario;

namespace UserManagement.Application.Services.Usuario
{
    public interface IUsuarioService
    {
        public Task CriarUsuarioUseCase(UsuarioEntity usuarioEntity);
    }
}
