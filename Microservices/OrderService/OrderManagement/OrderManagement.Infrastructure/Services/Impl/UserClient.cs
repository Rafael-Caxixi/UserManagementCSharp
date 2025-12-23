using OrderManagement.Api.Dto;
using OrderManagement.Application.Services.Interface.Client;
using System.Net;
using System.Net.Http.Json;

namespace OrderManagement.Api.Client.Impl
{
    public class UserClient : IUserClient
    {
        private readonly HttpClient _httpClient;

        public UserClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UsuarioDtoClient?> GetUserByIdAsync(long userId)
        {
            var response = await _httpClient.GetAsync($"/usuarios/{userId}");


            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<UsuarioDtoClient>();
        }
    }

}
