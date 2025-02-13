using MultiShop.DtoLayer.OrderDtos.OrderAddressDtos;

namespace MultiShop.WebUI.Services.OrderServices.OrderAddressServices
{  
    public class OrderAddressService : IOrderAddressService
    {
        private readonly HttpClient _client;

        public OrderAddressService(HttpClient client)
        {
            _client = client;
        }
        public async Task CreateOrderAddressAsync(CreateOrderAddressDto createOrderAddressDto)
        {
            await _client.PostAsJsonAsync<CreateOrderAddressDto>("address", createOrderAddressDto);
        }
    }
}
