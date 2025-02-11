using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly HttpClient _client;

        public ProductDetailService(HttpClient client)
        {
            _client = client;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            await _client.PostAsJsonAsync<CreateProductDetailDto>("ProductDetail", createProductDetailDto);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _client.DeleteAsync("ProductDetail?id=" + id);
        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            var responseMessage = await _client.GetAsync($"ProductDetail/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductDetailDto>();
            return value;
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var responseMessage = await _client.GetAsync("ProductDetail");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDetailDto>>(jsonData);
            return values;
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            await _client.PutAsJsonAsync<UpdateProductDetailDto>("ProductDetail", updateProductDetailDto);

        }

        public async Task<GetByIdProductDetailDto> GetByProductIdProductDetailAsync(string id)
        {
            var responseMessage = await _client.GetAsync($"ProductDetail/GetByProductIdProductDetail/" + id);
            var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductDetailDto>();
            return value;
        }
    }
}
