using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly HttpClient _client;

        public FeatureService(HttpClient client)
        {
            _client = client;
        }

        public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        {
            await _client.PostAsJsonAsync<CreateFeatureDto>("Feature", createFeatureDto);
        }

        public async Task DeleteFeatureAsync(string id)
        {
            await _client.DeleteAsync("Feature/" + id);
        }

        public async Task<UpdateFeatureDto> GetByIdFeatureAsync(string id)
        {
            var responseMessage = await _client.GetAsync($"Feature/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<UpdateFeatureDto>();
            return value;
        }

        public async Task<List<ResultFeatureDto>> GetAllFeatureAsync()
        {
            var responseMessage = await _client.GetAsync("Feature");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
            return values;
        }

        public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
        {
            await _client.PutAsJsonAsync<UpdateFeatureDto>("Feature", updateFeatureDto);

        }
    }
}
