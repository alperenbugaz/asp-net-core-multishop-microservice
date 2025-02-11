using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.BrandServices
{
    public class BrandService : IBrandService
    {
        private readonly HttpClient _client;

        public BrandService(HttpClient client)
        {
            _client = client;
        }

        public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
        {
            await _client.PostAsJsonAsync<CreateBrandDto>("Brand", createBrandDto);
        }

        public async Task DeleteBrandAsync(string id)
        {
            await _client.DeleteAsync("Brand?id=" + id);
        }

        public async Task<UpdateBrandDto> GetByIdBrandAsync(string id)
        {
            var responseMessage = await _client.GetAsync($"Brand/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<UpdateBrandDto>();
            return value;
        }

        public async Task<List<ResultBrandDto>> GetAllBrandAsync()
        {
            var responseMessage = await _client.GetAsync("Brand");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
            return values;
        }

        public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
        {
            await _client.PutAsJsonAsync<UpdateBrandDto>("Brand", updateBrandDto);

        }
    }
}
