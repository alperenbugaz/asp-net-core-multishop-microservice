using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Core.Application.Interfaces;
using MultiShop.Order.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> OrderDetailRepository)
        {
            _repository = OrderDetailRepository;
        }

        public async Task Handle(UpdateOrderDetailCommand request)
        {
            var value = await _repository.GetByIdAsync(request.OrderDetailId);
            value.ProductId = request.ProductId;
            value.ProductName = request.ProductName;
            value.ProductPrice = request.ProductPrice;
            value.ProductAmount = request.ProductAmount;
            value.ProductTotalPrice = request.ProductTotalPrice;
            value.OrderingId = request.OrderingId;

            await _repository.UpdateAsync(value);
        }
    }
}
