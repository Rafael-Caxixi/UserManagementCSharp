using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.DTOs.Response;
using UserManagement.Application.Services.Interfaces;
using UserManagement.Domain.Entities.Usuario;
using UserManagement.Infrastructure.Persistence;

namespace UserManagement.Infrastructure.Repositories.Impl
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
            try
            {
                _dbContext.Add(usuarioEntity);
                await _dbContext.SaveChangesAsync();
                return usuarioEntity;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task DeletarUsuarioPorIdAsync(long id)
        {
            var usuarioExistente = await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
            if(usuarioExistente == null)
                throw new InvalidOperationException("Usuário não encontrado.");
            _dbContext.Usuarios.Remove(usuarioExistente);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<UsuarioEntity> GetByLoginAsync(string login)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.Login.Equals(login));
        }

        public async Task<UsuarioDtoClient> ListarUsuarioPorIdAsync(long id)
        {
            return await _dbContext.Usuarios
                .AsNoTracking()
                .Where(u => u.Id == id)
                .Select(u => new UsuarioDtoClient
                {
                    Id = u.Id,
                    Login = u.Login,
                })
                .FirstOrDefaultAsync();
        }

        public async Task<UsuarioEntity> ListarUsuarioPorLoginAsync(string login)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.Login == login);
        }

        public async Task<IEnumerable<UsuarioEntity>> ListarUsuariosAsync()
        {
            return await _dbContext.Usuarios
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
