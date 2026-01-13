using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Application.DTOs.Request
{
    public class LoginRequestDTO
    {
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
