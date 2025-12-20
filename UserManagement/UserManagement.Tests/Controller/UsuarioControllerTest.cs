using FluentAssertions;
using System.Net;
using System.Net.Http.Json;
using UserManagement.Application.DTOs.Request;
using UserManagement.Application.DTOs.Response;
using Xunit;

namespace UserManagement.Tests.Controller
{
    public class UsuarioControllerTest
            : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _httpClient;

        public UsuarioControllerTest(CustomWebApplicationFactory factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task Deve_Criar_Usuario_Com_Sucesso()
        {
            // Arrange
            var request = new UsuarioRequestDTO(
                login: "login",
                senha: "123456",
                cpf: "12345678909"
            );

            // Act
            var response = await _httpClient.PostAsJsonAsync("/usuarios", request);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            var body = await response.Content.ReadFromJsonAsync<UsuarioResponseDTO>();

            body.Should().NotBeNull();
            body!.Login.Should().Be("login");
            body.Id.Should().NotBe(default(long));
        }

        [Fact]
        public async Task Deve_Lancar_Erro_Com_Usuario_Vazio()
        {
            // Arrange
            var request = new UsuarioRequestDTO(
                login: "",
                senha: "",
                cpf: ""
            );

            // Act
            var response = await _httpClient.PostAsJsonAsync("/usuarios", request);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}
