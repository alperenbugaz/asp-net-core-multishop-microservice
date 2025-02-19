
namespace MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices
{
    public class CatalogStatisticService : ICatalogStatisticService
    {   
        private readonly HttpClient _client;

        public CatalogStatisticService(HttpClient client)
        {
            _client = client;
        }
        public async Task<long> GetBrandCount()
        {
            var responseMessage = await _client.GetAsync("statistic/GetBrandCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<long>();
            return values;
        }

        public async Task<long> GetCategoryCount()
        {
            var responseMessage = await _client.GetAsync("statistic/GetCategoryCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<long>();
            return values;
        }

        public async Task<string> GetMaxPriceProductName()
        {
            var responseMessage = await _client.GetAsync("statistic/GetMaxPriceProductName");
            var values = await responseMessage.Content.ReadAsStringAsync();
            return values;
        }

        public async Task<string> GetMinPriceProductName()
        {
            var responseMessage = await _client.GetAsync("statistic/GetMinPriceProductName");
            var values = await responseMessage.Content.ReadAsStringAsync();
            return values;
        }

        public async Task<decimal> GetProductAvgPrice()
        {
            var responseMessage = await _client.GetAsync("statistic/GetProductAvgPrice");
            var values = await responseMessage.Content.ReadFromJsonAsync<decimal>();
            return values;
        }

        public async Task<long> GetProductCount()
        {
            var responseMessage = await _client.GetAsync("statistic/GetProductCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<long>();
            return values;
        }
    }
}
