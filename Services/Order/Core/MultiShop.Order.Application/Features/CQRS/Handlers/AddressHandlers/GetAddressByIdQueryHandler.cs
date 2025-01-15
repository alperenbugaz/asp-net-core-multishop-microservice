using MultiShop.Order.Core.Application.Features.CQRS.Queries.AddressQueries;
using MultiShop.Order.Core.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Core.Application.Interfaces;
using MultiShop.Order.Core.Domain.Entities;

namespace MultiShop.Order.Core.Application.Features.CQRS.Handlers.AddressHandlers;

public class GetAddressByIdQueryHandler
{
    private readonly IRepository<Address> _repository;

    public GetAddressByIdQueryHandler(IRepository<Address> addressRepository)
    {
        _repository = addressRepository;
    }

    public async Task<GetAdressByIdQueryResult> Handle(GetAddressByIdQuery request)
    {
        var values = await _repository.GetByIdAsync(request.Id);
        return new GetAdressByIdQueryResult
        {
            AddressId = values.AddressId,
            UserId = values.UserId,
            District = values.District,
            City = values.City,
            Detail = values.Detail
        };
    }
}