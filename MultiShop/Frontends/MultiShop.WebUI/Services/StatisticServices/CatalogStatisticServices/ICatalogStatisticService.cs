namespace MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices
{
    public interface ICatalogStatisticService
    {
        Task<long> GetProductCount();
        Task<long> GetCategoryCount();
        Task<long> GetBrandCount();

        Task<decimal> GetProductAvgPrice();
        Task<string> GetMaxPriceProductName();
        Task<string> GetMinPriceProductName();
    }
}
