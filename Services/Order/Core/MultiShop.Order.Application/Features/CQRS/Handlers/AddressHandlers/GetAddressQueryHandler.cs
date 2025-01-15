using MultiShop.Order.Core.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Core.Application.Interfaces;
using MultiShop.Order.Core.Domain.Entities;

namespace MultiShop.Order.Core.Application.Features.CQRS.Handlers.AddressHandlers;

public class GetAddressQueryHandler
{
    private readonly IRepository<Address> _repository;

    public GetAddressQueryHandler(IRepository<Address> addressRepository)
    {
        _repository = addressRepository;
    }

    public async Task<List<GetAddressQueryResult>> Handle()
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x => new GetAddressQueryResult
        {
            AddressId = x.AddressId,
            UserId = x.UserId,
            District = x.District,
            City = x.City,
            Detail = x.Detail
        }).ToList();
    }
}