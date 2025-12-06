using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Domain.Entities.Usuario
{
    public class UsuarioEntity
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Cpf { get; set; }

        public DateTime DataCriacao { get; set; }

        public UsuarioEntity()
        {
        }

        public UsuarioEntity(string login, string senha, string cpf)
        {
            Login = login;
            Senha = senha;
            Cpf = cpf;
            DataCriacao = DateTime.Now;
        }

    }
}
