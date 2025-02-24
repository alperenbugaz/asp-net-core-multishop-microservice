using Newtonsoft.Json;
using System.Net.Http;

namespace MultiShop.SignalRRealTimeApi.Services.SignalRCommentServices
{
    public class SignalRCommentService : ISignalRCommentService
    {
        private readonly HttpClient _httpClient;

        private readonly IHttpClientFactory _httpClientFactory;
        public SignalRCommentService(HttpClient httpClient, IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClient;

            _httpClientFactory = httpClientFactory;
        }
        public async Task<int> GetCommentCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7075/api/CommentStatistic");
            var data = await responseMessage.Content.ReadAsStringAsync();
            var commentCount = JsonConvert.DeserializeObject<int>(data);

            return commentCount;
        }
    }
}
