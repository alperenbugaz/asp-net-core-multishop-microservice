using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;

namespace MultiShop.Catalog.Services.SpecialOfferServices
{
    public interface ISpecialOfferService
    {
        Task<List<ResultSpecialOfferDto>> GettAllSpecialOffertAsync();
        Task CreateSpecialOffertAsync(CreateSpecialOfferDto createProductDto);
        Task UpdateProductAsync(UpdateSpecialOfferDto updateSpecialOfferDto);
        Task DeleteProductAsync(string id);
        Task<GetByIdSpecialOfferDto> GetByIdSpecialOffertAsync(string id);
    }
}
