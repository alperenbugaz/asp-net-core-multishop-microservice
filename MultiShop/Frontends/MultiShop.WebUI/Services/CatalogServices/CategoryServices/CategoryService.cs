using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using Newtonsoft.Json;
using System.Net.Http;

namespace MultiShop.WebUI.Services.CatalogServices.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _client;

        public CategoryService(HttpClient client)
        {
            _client = client;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            await _client.PostAsJsonAsync<CreateCategoryDto>("category", createCategoryDto);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _client.DeleteAsync("category?id=" + id);
        }

        public async Task<EditCategoryDto> GetByIdCategoryAsync(string id)
        {
            var responseMessage = await _client.GetAsync($"category/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<EditCategoryDto>();
            return value;
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var responseMessage = await _client.GetAsync("category");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            return values;
        }

        public async Task UpdateCategoryAsync(EditCategoryDto updateCategoryDto)
        {
            await _client.PutAsJsonAsync<EditCategoryDto>("category", updateCategoryDto);

        }
    }
}
