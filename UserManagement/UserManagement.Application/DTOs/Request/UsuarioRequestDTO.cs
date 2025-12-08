using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Application.DTOs.Request
{
    public class UsuarioRequestDTO
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Cpf { get; set; }
    }
}
