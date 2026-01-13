using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.DTOs.Response;
using UserManagement.Application.Services.Interfaces;

namespace UserManagement.Infrastructure.Security
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _userRepository; // seu repo de usuários
        private readonly IConfiguration _configuration;

        public AuthService(IUsuarioRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<LoginResponseDTO?> LoginAsync(string login, string password)
        {
            var user = await _userRepository.GetByLoginAsync(login);
            if (user == null) return null;

            // Verifica senha com BCrypt
            if (!BCrypt.Net.BCrypt.Verify(password, user.Senha))
                return null;

            // Gera token JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Login)
            }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new LoginResponseDTO
            {
                Token = tokenHandler.WriteToken(token),
                Expiration = tokenDescriptor.Expires.Value
            };
        }

    }
}
