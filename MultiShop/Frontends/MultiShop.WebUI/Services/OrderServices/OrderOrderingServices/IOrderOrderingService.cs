using MultiShop.DtoLayer.OrderDtos.OrderOrderingDtos;

namespace MultiShop.WebUI.Services.OrderServices.OrderOrderingServices
{
    public interface IOrderOrderingService
    {
        Task <List<ResultOrderingByUserIdDto>> OrderOrderingByUserId(string userId);
    }
}
