namespace MultiShop.Catalog.Services.StatisticServices
{
    public interface IStatisticService
    {
        Task<long> GetProductCount();
        Task<long> GetCategoryCount();
        Task<long> GetBrandCount();

        Task<decimal> GetProductAvgPrice();
        Task<string> GetMaxPriceProductName();
        Task<string> GetMinPriceProductName();

    }
}
