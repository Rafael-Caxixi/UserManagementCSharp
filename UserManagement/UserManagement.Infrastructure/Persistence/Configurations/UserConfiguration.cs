using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Entities.Usuario;

namespace UserManagement.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UsuarioEntity>
    {
        public void Configure(EntityTypeBuilder<UsuarioEntity> builder)
        {
            builder.ToTable("tblUsuarios");

            builder.HasKey(u => u.Id);

            //builder.Property(u => u.Login)
            //    .IsRequired()
            //    .HasMaxLength(255);

            builder.Property(u => u.Senha)
                .IsRequired()
                .HasMaxLength(255); 

            //builder.Property(u => u.Cpf)
            //    .IsRequired()
            //    .HasMaxLength(11);

        }
    }
}
