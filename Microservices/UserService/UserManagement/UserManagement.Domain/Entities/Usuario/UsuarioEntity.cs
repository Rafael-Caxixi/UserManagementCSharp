using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Domain.Entities.Usuario
{
    public class UsuarioEntity
    {
        [Column("id")]
        [Key]
        public long Id { get; set; }
        [Column("login")]
        public string Login { get; set; }
        [Column("senha")]
        public string Senha { get; set; }
        [Column("cpf")]
        public string Cpf { get; set; }
        [Column("dataCriacao")]

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
