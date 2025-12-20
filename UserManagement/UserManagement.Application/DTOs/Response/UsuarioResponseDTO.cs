using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Application.DTOs.Response
{
    public class UsuarioResponseDTO
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string Cpf { get; set; }
        public DateTime DataCriacao { get; set; }

        public UsuarioResponseDTO(long id, string login, string cpf, DateTime dataCriacao)
        {
            Id = id;
            Login = login;
            Cpf = cpf;
            DataCriacao = dataCriacao;
        }
    }
}
