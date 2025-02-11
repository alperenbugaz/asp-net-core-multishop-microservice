using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;

namespace MultiShop.WebUI.Services.CatalogServices.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(EditCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(string id);
        Task<EditCategoryDto> GetByIdCategoryAsync(string id);
    }
}
