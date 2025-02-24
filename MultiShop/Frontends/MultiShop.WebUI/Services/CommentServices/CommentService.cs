using MultiShop.DtoLayer.CommentDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly HttpClient _client;

        public CommentService(HttpClient client)
        {
            _client = client;
        }

        public async Task CreateCommentAsync(CreateCommentDto createCommentDto)
        {
            await _client.PostAsJsonAsync<CreateCommentDto>("Comment", createCommentDto);
        }

        public async Task DeleteCommentAsync(string id)
        {
            await _client.DeleteAsync("Comment?id=" + id);
        }

        public async Task<UpdateCommentDto> GetByIdCommentAsync(string id)
        {
            var responseMessage = await _client.GetAsync($"Comment/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<UpdateCommentDto>();
            return value;
        }

        public async Task<List<ResultCommentDto>> GetAllCommentAsync()
        {
            var responseMessage = await _client.GetAsync("Comment");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
            return values;
        }

        public async Task UpdateCommentAsync(UpdateCommentDto updateCommentDto)
        {
            await _client.PutAsJsonAsync<UpdateCommentDto>("Comment", updateCommentDto);

        }

        public async Task<List<ResultCommentDto>> CommentListGetByProductId(string id)
        {
            var responseMessage = await _client.GetAsync("Comment/CommentsListByProductId/" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
            return values;
        }


    }
}
