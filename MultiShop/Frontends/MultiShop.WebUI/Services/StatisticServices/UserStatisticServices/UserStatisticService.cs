
namespace MultiShop.WebUI.Services.StatisticServices.UserStatisticServices
{
    public class UserStatisticService : IUserStatisticService
    {
        private readonly HttpClient _client;

        public UserStatisticService(HttpClient client)
        {
            _client = client;
        }
        public async Task<int> GetUserCount()
        {
            var responseMessage = await _client.GetAsync("api/statistic");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }
    }
}
