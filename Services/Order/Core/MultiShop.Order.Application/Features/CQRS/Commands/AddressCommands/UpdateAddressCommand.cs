namespace MultiShop.Order.Core.Application.Features.CQRS.Commands.AddressQueries.AddressCommands
{
    public class UpdateAddressCommand 
    {   
        public int AddressId { get; set; }
        public string UserId { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Detail { get; set; }

    }
}