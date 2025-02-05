using MultiShop.Catalog.Dtos.OfferDiscountDtos;

namespace MultiShop.Catalog.Services.OfferDiscountServices
{
    public interface IOfferDiscountService
    {
        Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync();
        Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto);
        Task UpdateOfferDiscountyAsync(UpdateOfferDiscountDto updateOfferDiscountDto);
        Task DeleteOfferDiscountyAsync(string id);
        Task<GetByIdOfferDiscountDto> GetByIdOfferDiscountAsync(string id);
    }
}
