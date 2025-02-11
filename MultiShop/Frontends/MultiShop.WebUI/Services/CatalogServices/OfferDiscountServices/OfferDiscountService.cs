using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices
{
    public class OfferDiscountService : IOfferDiscountService
    {
        private readonly HttpClient _client;

        public OfferDiscountService(HttpClient client)
        {
            _client = client;
        }

        public async Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto)
        {
            await _client.PostAsJsonAsync<CreateOfferDiscountDto>("OfferDiscount", createOfferDiscountDto);
        }

        public async Task DeleteOfferDiscountAsync(string id)
        {
            await _client.DeleteAsync("OfferDiscount/"+ id);
        }

        public async Task<UpdateOfferDiscountDto> GetByIdOfferDiscountAsync(string id)
        {
            var responseMessage = await _client.GetAsync($"OfferDiscount/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<UpdateOfferDiscountDto>();
            return value;
        }

        public async Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync()
        {
            var responseMessage = await _client.GetAsync("OfferDiscount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultOfferDiscountDto>>(jsonData);
            return values;
        }

        public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await _client.PutAsJsonAsync<UpdateOfferDiscountDto>("OfferDiscount", updateOfferDiscountDto);

        }
    }
}
