using MultiShop.Catalog.Dtos.ProductDtos;

namespace MultiShop.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GettAllProductAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);
        Task<GetByIdProductDto> GetByIdProductAsync(string id);
        Task<List<ResultProductWithCategory>> GetProductByCategoryAsync();

        Task<List<ResultProductWithCategory>> GetProductWithCategoryByCategoryIdAsync(string categoryId);

        Task<List<ResultProductDto>> GetProductWithQueryParam(string query);
    }
}