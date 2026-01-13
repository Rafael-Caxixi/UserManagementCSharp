using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<PedidoEntity> Pedidos { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);

            // Aplica naming convention para todas as propriedades
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                // Colunas
                foreach (var property in entity.GetProperties())
                {
                    var currentName = property.GetColumnName();
                    var newName = char.ToLower(currentName[0]) + currentName.Substring(1);
                    property.SetColumnName(newName);
                }

                // Nomes de tabelas (opcional)
                var tableName = entity.GetTableName();
                entity.SetTableName(char.ToLower(tableName[0]) + tableName.Substring(1));
            }

        }

    }
}
