using MultiShop.Catalog.Dtos.FeatureDtos;

namespace MultiShop.Catalog.Services.FeatureServices
{
    public interface IFeatureService
    {
        Task CreateFeature(CreateFeatureDto createFeatureDto);
        Task UpdateFeature(UpdateFeatureDto updateFeatureDto);
        Task DeleteFeature(string id);
        Task<List<ResultFeatureDto>> GetAllFeatureAsync();
        Task<GetByIdFeatureDto> GetByIdFeatureAsync(string id);

    }
}
