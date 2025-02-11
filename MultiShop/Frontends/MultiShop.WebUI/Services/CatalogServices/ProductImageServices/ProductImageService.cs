using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly HttpClient _client;

        public ProductImageService(HttpClient client)
        {
            _client = client;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            await _client.PostAsJsonAsync<CreateProductImageDto>("ProductImage", createProductImageDto);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _client.DeleteAsync("ProductImage?id=" + id);
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
        {
            var responseMessage = await _client.GetAsync($"ProductImage/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductImageDto>();
            return value;
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            var responseMessage = await _client.GetAsync("ProductImage");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductImageDto>>(jsonData);
            return values;
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            await _client.PutAsJsonAsync<UpdateProductImageDto>("ProductImage", updateProductImageDto);

        }


        public async Task<GetByIdProductImageDto> GetByProductIdProductImageAsync(string id)
        {
            var responseMessage = await _client.GetAsync($"ProductImage/ProductImagesByProductId/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductImageDto>();
            return value;
        }
    }
}
