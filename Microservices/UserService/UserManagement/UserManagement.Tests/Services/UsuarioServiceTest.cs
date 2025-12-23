using FluentAssertions;
using Moq;
using UserManagement.Application.DTOs.Request;
using UserManagement.Application.Security;
using UserManagement.Application.Services.Interfaces;
using UserManagement.Application.Services.Usuario;
using UserManagement.Domain.Entities.Usuario;
using Xunit;

namespace UserManagement.Tests.Services
{
    public class UsuarioServiceTest
    {
        private readonly Mock<IUsuarioRepository> _usuarioRepositoryMock;
        private readonly Mock<IPasswordHasher> _passwordMock;
        private readonly UsuarioService _usuarioService;

        public UsuarioServiceTest()
        {
            _usuarioRepositoryMock = new Mock<IUsuarioRepository>();
            _usuarioService = new UsuarioService(_usuarioRepositoryMock.Object, _passwordMock.Object);
        }

        [Fact]
        public async Task Deve_Criar_Usuario_Com_Sucesso()
        {
            _usuarioRepositoryMock.Setup(r => r.ListarUsuarioPorLoginAsync("user")).ReturnsAsync((UsuarioEntity)null);

            var id = 1;
            _usuarioRepositoryMock.Setup(r => r.CriarUsuarioAsync(It.IsAny<UsuarioEntity>()))
                .ReturnsAsync(new UsuarioEntity("user", "senha", "12345678909")
                {
                    Id = id
                });

            var dto = new UsuarioRequestDTO("user", "senha", "12345678909");
            var resultado = await _usuarioService.CriarUsuarioUseCase(dto);

            // Assert
            resultado.Id.Should().Be(id);
            resultado.Login.Should().Be("user");
            _usuarioRepositoryMock.Verify(r => r.CriarUsuarioAsync(It.IsAny<UsuarioEntity>()), Times.Once);
        }

        [Fact]
        public async Task Deve_Lancar_Erro_Ao_Criar_Usuario_Com_Login_Existente()
        {
            _usuarioRepositoryMock.Setup(r => r.ListarUsuarioPorLoginAsync("user")).ReturnsAsync(new UsuarioEntity("user", "senha", "12345678909"));

            var dto = new UsuarioRequestDTO("user", "senha", "12345678909");
            Func<Task> resultado = async () => await _usuarioService.CriarUsuarioUseCase(dto);

            // Assert
            await resultado.Should().ThrowAsync<InvalidOperationException>();
        }

        [Fact]
        public async Task Deve_Lancar_Erro_Ao_Criar_Usuario_Com_Campos_Vazios()
        {
            _usuarioRepositoryMock.Setup(r => r.ListarUsuarioPorLoginAsync("user")).ReturnsAsync(new UsuarioEntity("user", "senha", "12345678909"));

            var dto = new UsuarioRequestDTO("user", "senha", "12345678909");
            Func<Task> resultado = async () => await _usuarioService.CriarUsuarioUseCase(dto);

            // Assert
            await resultado.Should().ThrowAsync<InvalidOperationException>();
        }

    }
}
