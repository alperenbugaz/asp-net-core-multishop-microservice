using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MultiShop.Order.Core.Application.Features.CQRS.Queries.AddressQueries;
using MultiShop.Order.Core.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Core.Application.Interfaces;
using MultiShop.Order.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery request)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetOrderDetailByIdQueryResult
            {
                OrderDetailId = values.OrderDetailId,
                ProductId = values.ProductId,
                ProductName = values.ProductName,
                ProductPrice = values.ProductPrice,
                ProductAmount = values.ProductAmount,
                ProductTotalPrice = values.ProductTotalPrice,
                OrderingId = values.OrderingId

            };
        }
    }
}
