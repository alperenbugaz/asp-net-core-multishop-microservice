using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly HttpClient _client;

        public SpecialOfferService(HttpClient client)
        {
            _client = client;
        }

        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _client.PostAsJsonAsync<CreateSpecialOfferDto>("SpecialOffer", createSpecialOfferDto);
        }

        public async Task DeleteSpecialOfferAsync(string id)
        {
            await _client.DeleteAsync("SpecialOffer/" + id);
        }

        public async Task<UpdateSpecialOfferDto> GetByIdSpecialOfferAsync(string id)
        {
            var responseMessage = await _client.GetAsync($"SpecialOffer/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<UpdateSpecialOfferDto>();
            return value;
        }

        public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync()
        {
            var responseMessage = await _client.GetAsync("SpecialOffer");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsonData);
            return values;
        }

        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _client.PutAsJsonAsync<UpdateSpecialOfferDto>("SpecialOffer", updateSpecialOfferDto);

        }
    }
}
