using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement.Application.DTOs.Response
{
    public class UsuarioDtoClient
    {
        public long Id { get; set; }
        public string Login { get; set; }
    }
}
