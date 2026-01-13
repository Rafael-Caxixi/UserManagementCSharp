using OrderManagement.Api.DTOs;
using OrderManagement.Application.DTOs;
using OrderManagement.Application.Events;
using OrderManagement.Application.Services.Interface;
using OrderManagement.Application.Services.Interface.Client;
using OrderManagement.Application.Services.Interface.RabbitMQEnvio;
using OrderManagement.Application.Services.Interface.Repositories;
using OrderManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.Services.Impl
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IUserClient _userClient;
        private readonly IOrderPublisher _orderPublisher;

        public PedidoService(IPedidoRepository pedidoRepository, IUserClient userClient, IOrderPublisher orderPublisher)
        {
            _pedidoRepository = pedidoRepository;
            _userClient = userClient;
            _orderPublisher = orderPublisher;
        }


        public async Task<PedidoResponseDTO> CadastrarPedido(PedidoRequestDTO pedidoRequestDTO)
        {
            try
            {
                //Checar se o usuário existe
                var userExists = await _userClient.GetUserByIdAsync(pedidoRequestDTO.IdUsuario);

                if (userExists == null) throw new Exception("Usuário não encontrado.");

                PedidoEntity resultado = await _pedidoRepository.CadastrarPedidoAsync(new PedidoEntity(userExists.Id, pedidoRequestDTO.QuantidadeItens));

                //Enviando via kafka
                OrderCreatedEvent orderCreatedEvent = new OrderCreatedEvent(
                    resultado.Id,
                     resultado.IdUsuario,
                    resultado.QuantidadeItens,
                     resultado.DataPedido);
                Console.WriteLine("Enviando evento no RabbitMQ");
                _orderPublisher.PublishOrderCreatedEvent(orderCreatedEvent);

                //Retorno
                return new PedidoResponseDTO
                {
                    Id = resultado.Id,
                    DataPedido = resultado.DataPedido,
                    Status = resultado.Status,
                    QuantidadeItens = resultado.QuantidadeItens
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar pedido: " + ex.Message);
            }

        }
        public async Task<List<PedidoResponseDTO>> ListarPedidos()
        {
            var lista = await _pedidoRepository.ListarPedidosAsync();

            var listaDto = lista.Select(p => new PedidoResponseDTO
            {
                Id = p.Id,
                DataPedido = p.DataPedido,
                Status = p.Status,
                QuantidadeItens = p.QuantidadeItens
            }).ToList();

            return listaDto;
        }


    }
}
