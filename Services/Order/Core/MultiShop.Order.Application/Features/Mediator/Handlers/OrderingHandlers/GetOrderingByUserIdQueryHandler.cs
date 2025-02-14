using MediatR;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MultiShop.Order.Application.Features.Mediator.Results.OrderingResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Core.Application.Interfaces;
using MultiShop.Order.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingByUserIdQueryHandler : IRequestHandler<GetOrderingByUserIdQuery, List<GetOrderingByUserIdQueryResult>>
    {   
        private readonly IOrderingRepository _repository;

        public GetOrderingByUserIdQueryHandler(IOrderingRepository repository)
        {
            _repository = repository;
        }


        public async Task<List<GetOrderingByUserIdQueryResult>> Handle(GetOrderingByUserIdQuery request, CancellationToken cancellationToken)
        {
            var values =  _repository.GetOrderingsByUserId(request.Id);
            return values.Select(x => new GetOrderingByUserIdQueryResult
            {
                OrderDate = x.OrderDate,
                OrderingId = x.OrderingId,
                UserId = x.UserId,
                TotalPrice = x.TotalPrice

            }).ToList();
        }
    }
}
