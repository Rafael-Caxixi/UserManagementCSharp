using OrderManagement.Api.Dto;

namespace OrderManagement.Application.Services.Interface.Client
{
    public interface IUserClient
    {
        Task<UsuarioDtoClient?> GetUserByIdAsync(long userId);
    }
}
