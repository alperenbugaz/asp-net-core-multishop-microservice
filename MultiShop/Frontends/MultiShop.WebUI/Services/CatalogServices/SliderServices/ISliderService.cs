using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;

namespace MultiShop.WebUI.Services.CatalogServices.SliderServices
{
    public interface ISliderService
    {
        Task<List<ResultSliderDto>> GetAllSliderAsync();
        Task CreateSliderAsync(CreateFeatureSliderDto createSliderServiceDto);
        Task UpdateSliderAsync(EditFeatureSliderDto updateSliderServiceDto);
        Task DeleteSliderAsync(string id);
        Task<EditFeatureSliderDto> GetByIdSliderAsync(string id);
    }
}
