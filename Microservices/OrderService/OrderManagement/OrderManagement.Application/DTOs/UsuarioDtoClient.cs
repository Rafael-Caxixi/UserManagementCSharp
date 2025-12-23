using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagement.Api.Dto
{
    public class UsuarioDtoClient
    {
        public long Id { get; set; }
        public string Login { get; set; }
    }
}
