
namespace MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices
{
    public class MessageStatisticService : IMessageStatisticService
    {
        private readonly HttpClient _client;
        public MessageStatisticService(HttpClient client)
        {
            _client = client;
        }
        public async Task<int> GetMessageCount()
        {
            var responseMessage = await _client.GetAsync("UserMessage/GetMessageCount");

            if (!responseMessage.IsSuccessStatusCode)
            {
                return 0;
            }

            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }
    }
}
