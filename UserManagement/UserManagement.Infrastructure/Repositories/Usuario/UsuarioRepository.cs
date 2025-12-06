using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Entities.Usuario;
using UserManagement.Infrastructure.Persistence;

namespace UserManagement.Infrastructure.Repositories.Usuario
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly AppDbContext _dbContext;

        public UsuarioRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UsuarioEntity> CriarUsuarioAsync(UsuarioEntity usuarioEntity)
        {
            _dbContext.Add(usuarioEntity);
            await _dbContext.SaveChangesAsync();
            return usuarioEntity;
        }
    }
}
