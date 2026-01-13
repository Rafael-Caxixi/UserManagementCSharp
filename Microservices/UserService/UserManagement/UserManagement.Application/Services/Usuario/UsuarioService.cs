using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.DTOs.Request;
using UserManagement.Application.DTOs.Response;
using UserManagement.Application.Security;
using UserManagement.Application.Services.Interfaces;
using UserManagement.Domain.Entities.Usuario;

namespace UserManagement.Application.Services.Usuario
{
    public class UsuarioService : IUsuarioService
    {

        private IUsuarioRepository _usuarioRepository;
        private IPasswordHasher _passwordHasher;

        public UsuarioService(IUsuarioRepository usuarioRepository, IPasswordHasher passwordHasher)
        {
            _usuarioRepository = usuarioRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<UsuarioResponseDTO> CriarUsuarioUseCase(UsuarioRequestDTO request)
        {
            var usuarioExistente = await _usuarioRepository
                .ListarUsuarioPorLoginAsync(request.Login);

            if (usuarioExistente != null)
                throw new InvalidOperationException("Usuário já existe.");

            var novoUsuario = new UsuarioEntity(
                request.Login,
                _passwordHasher.Hash(request.Senha),
                request.Cpf
            );

            var retorno = await _usuarioRepository.CriarUsuarioAsync(novoUsuario);

            return new UsuarioResponseDTO(
                retorno.Id,
                retorno.Login,
                retorno.Cpf,
                retorno.DataCriacao
            );
        }

        public async Task DeletarUsuarioPorIdUseCase(long id)
        {
            await _usuarioRepository.DeletarUsuarioPorIdAsync(id);
        }

        public async Task<UsuarioDtoClient> ListarUsuarioPorIdUseCase(long id)
        {
            return await _usuarioRepository.ListarUsuarioPorIdAsync(id);
        }

        public async Task<UsuarioResponseDTO> ListarUsuarioPorLoginUseCase(string login)
        {
            var retorno = await _usuarioRepository.ListarUsuarioPorLoginAsync(login);
            if (retorno == null)
                return null;
            return new UsuarioResponseDTO(
                retorno.Id,
                retorno.Login,
                retorno.Cpf,
                retorno.DataCriacao
                );
        }

        public async Task<IEnumerable<UsuarioResponseDTO>> ListarUsuariosUseCase()
        {
            var listaUsuarios = await _usuarioRepository.ListarUsuariosAsync();
            var listarDto = listaUsuarios.Select(u => new UsuarioResponseDTO(
                u.Id,
                u.Login,
                u.Cpf,
                u.DataCriacao
                ));
            return listarDto;
        }


    }
}
