using MultiShop.Order.Core.Application.Features.CQRS.Commands.AddressQueries.AddressCommands;
using MultiShop.Order.Core.Application.Interfaces;
using MultiShop.Order.Core.Domain.Entities;

namespace MultiShop.Order.Core.Application.Features.CQRS.Handlers.AddressHandlers;

public class UpdateAddressCommandHandler
{
    private readonly IRepository<Address> _repository;

    public UpdateAddressCommandHandler(IRepository<Address> addressRepository)
    {
        _repository = addressRepository;
    }

    public async Task Handle(UpdateAddressCommand request)
    {
        var value = await _repository.GetByIdAsync(request.AddressId);
        value.UserId = request.UserId;
        value.District = request.District;
        value.City = request.City;
        value.Detail = request.Detail;
        await _repository.UpdateAsync(value);
    }
}