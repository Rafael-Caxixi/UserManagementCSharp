using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Application.DTOs.Request
{
    public class UsuarioRequestDTO
    {
        [Required(ErrorMessage = "Login é necessário")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Senha é necessária")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "CPF é necessário")]
        public string Cpf { get; set; }

        public UsuarioRequestDTO(string login, string senha, string cpf)
        {
            Login = login;
            Senha = senha;
            Cpf = cpf;
        }
    }
}
