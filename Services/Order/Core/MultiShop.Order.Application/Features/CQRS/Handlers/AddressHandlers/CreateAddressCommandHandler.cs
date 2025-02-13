using MultiShop.Order.Core.Application.Features.CQRS.Commands.AddressQueries.AddressCommands;
using MultiShop.Order.Core.Application.Interfaces;
using MultiShop.Order.Core.Domain.Entities;

namespace MultiShop.Order.Core.Application.Features.CQRS.Handlers.AddressHandlers;

public class CreateAddressCommandHandler 
{
    private readonly IRepository<Address> _repository;

    public CreateAddressCommandHandler(IRepository<Address> addressRepository)
    {
        _repository = addressRepository;
    }

    public async Task Handle(CreateAddressCommand request)
    {
        await _repository.CreateAsync(new Address
        {
            UserId = request.UserId,
            District = request.District,
            City = request.City,
            Detail1 = request.Detail1,
            Detail2 = request.Detail2,
            Country = request.Country,
            Description = request.Description,
            Email = request.Email,
            Name = request.Name,
            Phone = request.Phone,
            Surname = request.Surname,
            ZipCode = request.ZipCode



        });
    }
}