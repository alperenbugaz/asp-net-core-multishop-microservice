
namespace MultiShop.WebUI.Services.StatisticServices.DiscountStatisticServices
{
    public class DiscountStatisticService : IDiscountStatisticService
    {   
        private readonly HttpClient _client;

        public DiscountStatisticService(HttpClient client)
        {
            _client = client;
        }
        public async Task<int> GetDiscountCouponCount()
        {
            var responseMessage = await _client.GetAsync("discount/GetDiscountCouponCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;

        }
    }
}
