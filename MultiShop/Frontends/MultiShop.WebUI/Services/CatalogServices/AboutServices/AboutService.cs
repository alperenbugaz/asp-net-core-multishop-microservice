using MultiShop.DtoLayer.CatalogDtos.AboutDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly HttpClient _client;

        public AboutService(HttpClient client)
        {
            _client = client;
        }

        public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            await _client.PostAsJsonAsync<CreateAboutDto>("About", createAboutDto);
        }

        public async Task DeleteAboutAsync(string id)
        {
            await _client.DeleteAsync("About?id=" + id);
        }

        public async Task<UpdateAboutDto> GetByIdAboutAsync(string id)
        {
            var responseMessage = await _client.GetAsync($"About/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<UpdateAboutDto>();
            return value;
        }

        public async Task<List<ResultAboutDto>> GetAllAboutAsync()
        {
            var responseMessage = await _client.GetAsync("About");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
            return values;
        }

        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            await _client.PutAsJsonAsync<UpdateAboutDto>("About", updateAboutDto);

        }
    }
}
