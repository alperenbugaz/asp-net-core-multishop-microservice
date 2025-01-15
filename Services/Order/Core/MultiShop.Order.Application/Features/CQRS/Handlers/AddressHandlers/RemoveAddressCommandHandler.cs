using MultiShop.Order.Core.Application.Features.CQRS.Commands.AddressQueries.AddressCommands;
using MultiShop.Order.Core.Application.Interfaces;
using MultiShop.Order.Core.Domain.Entities;

namespace MultiShop.Order.Core.Application.Features.CQRS.Handlers.AddressHandlers;

public class RemoveAddressCommandHandler
{
    private readonly IRepository<Address> _repository;

    public RemoveAddressCommandHandler(IRepository<Address> addressRepository)
    {
        _repository = addressRepository;
    }

    public async Task Handle(RemoveAddressCommand request)
    {
       var value = await _repository.GetByIdAsync(request.Id);
         await _repository.DeleteAsync(value);
         
    }
}