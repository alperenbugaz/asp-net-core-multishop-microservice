using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;

namespace MultiShop.Catalog.Services.FeatureSliderServices
{
    public interface IFeatureSliderService
    {
        Task<List<ResultFeatureSliderDto>> GetAllFeatureAsync();
        Task CreateFeatureAsync(CreateFeatureSliderDto createFeatureSliderDto);
        Task UpdateFeatureyAsync(UpdateFeatureSliderDto updateFeatureDto);
        Task DeleteFeatureyAsync(string id);
        Task<GetByIdFeatureSliderDto> GetByIdFeatureAsync(string id);
        Task FeatureSliderChangeStatusToTrueAsync(string id);
        Task FeatureSliderChangeStatusToFalseAsync(string id);
    }
}
