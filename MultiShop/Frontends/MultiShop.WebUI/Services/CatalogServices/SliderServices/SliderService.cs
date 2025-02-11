using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.SliderServices
{
    public class SliderService : ISliderService
    {
        private readonly HttpClient _client;

        public SliderService(HttpClient client)
        {
            _client = client;
        }

        public async Task CreateSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
        {
            await _client.PostAsJsonAsync<CreateFeatureSliderDto>("FeatureSlider", createFeatureSliderDto);
        }

        public async Task DeleteSliderAsync(string id)
        {
            await _client.DeleteAsync("FeatureSlider/" + id);
        }

        public async Task<EditFeatureSliderDto> GetByIdSliderAsync(string id)
        {
            var responseMessage = await _client.GetAsync($"FeatureSlider/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<EditFeatureSliderDto>();
            return value;
        }

        public async Task<List<ResultSliderDto>> GetAllSliderAsync()
        {
            var responseMessage = await _client.GetAsync("FeatureSlider");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultSliderDto>>(jsonData);
            return values;
        }

        public async Task UpdateSliderAsync(EditFeatureSliderDto updateFeatureSliderDto)
        {
            await _client.PutAsJsonAsync<EditFeatureSliderDto>("FeatureSlider", updateFeatureSliderDto);

        }
    }
}
