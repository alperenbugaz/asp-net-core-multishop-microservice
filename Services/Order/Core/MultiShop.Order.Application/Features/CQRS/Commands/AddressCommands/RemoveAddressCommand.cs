namespace MultiShop.Order.Core.Application.Features.CQRS.Commands.AddressQueries.AddressCommands
{
    public class RemoveAddressCommand 
    {   
        public int Id { get; set; }

        public RemoveAddressCommand(int id)
        {
            Id = id;
        }

    }
}