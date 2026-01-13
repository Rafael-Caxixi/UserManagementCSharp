using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.DTOs.Response;

namespace UserManagement.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDTO?> LoginAsync(string email, string password);
    }
}
