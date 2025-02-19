
namespace MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices
{
    public class CommentStatisticService : ICommentStatisticService
    {
        private readonly HttpClient _client;

        public CommentStatisticService(HttpClient client)
        {
            _client = client;
        }

        public async Task<int> GetActiveCommentCount()
        {
            var responseMessage = await _client.GetAsync("comment/GetActiveCommentCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }

        public async Task<int> GetCommentCount()
        {
            var responseMessage = await _client.GetAsync("comment/GetCommentCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }

        public async Task<int> GetPassiveCommentCount()
        {
            var responseMessage = await _client.GetAsync("comment/GetPassiveCommentCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }
    }
}
