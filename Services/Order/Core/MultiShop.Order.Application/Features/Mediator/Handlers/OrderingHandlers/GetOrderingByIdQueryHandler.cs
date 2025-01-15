using MediatR;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MultiShop.Order.Application.Features.Mediator.Results.OrderingResults;
using MultiShop.Order.Core.Application.Interfaces;
using MultiShop.Order.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingByIdQueryHandler : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult>
    {   
        private readonly IRepository<Ordering> _repository;
        public GetOrderingByIdQueryHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }
        public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetOrderingByIdQueryResult
            {
                OrderingId = values.OrderingId,
                UserId = values.UserId,
                OrderDate = values.OrderDate,
                TotalPrice = values.TotalPrice,
            };
        }
    }
}
