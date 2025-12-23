using OrderManagement.Application.Services.Interface.Repositories;
using OrderManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Infrastructure.Persistence.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _dbContext;

        public PedidoRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PedidoEntity> CadastrarPedidoAsync(PedidoEntity pedidoEntity)
        {
            _dbContext.Pedidos.Add(pedidoEntity);
            await _dbContext.SaveChangesAsync();
            return pedidoEntity;
        }
    }
}
