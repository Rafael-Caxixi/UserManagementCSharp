using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Infrastructure.Persistence.Configurations
{
    public class PedidoConfiguration : IEntityTypeConfiguration<PedidoEntity>
    {
        public void Configure(EntityTypeBuilder<PedidoEntity> builder)
        {
            builder.ToTable("tblPedidos");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(u => u.IdUsuario)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.DataPedido)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(u => u.Status)
                   .IsRequired()
                   .HasMaxLength(150);
        }
    }
}
