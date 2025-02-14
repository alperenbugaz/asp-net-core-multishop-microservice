using MultiShop.DtoLayer.OrderDtos.OrderOrderingDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.OrderServices.OrderOrderingServices
{
    public class OrderOrderingService : IOrderOrderingService
    {
        private readonly HttpClient _client;

        public OrderOrderingService(HttpClient client)
        {
            _client = client;
        }
        public async Task<List<ResultOrderingByUserIdDto>> OrderOrderingByUserId(string userId)
        {
            var responseMessage = await _client.GetAsync($"Ordering/GetOrderingByUserId?userId={userId}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultOrderingByUserIdDto>>(jsonData);
            return values;

        }
    }
}
