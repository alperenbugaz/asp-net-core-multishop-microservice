using MultiShop.DtoLayer.CargoDtos.CargoCompanyDtos;

namespace MultiShop.WebUI.Services.CargoServices.CargoCompanyServices
{
    public class CargoCompanyService : ICargoCompanyService
    {   
        private readonly HttpClient _httpClient;

        public CargoCompanyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateCargoCompanyAsync(CreateCargoCompanyDto createAboutDto)
        {
            await _httpClient.PostAsJsonAsync<CreateCargoCompanyDto>("cargocompany", createAboutDto);
        }

        public async Task DeleteCargoCompanyAsync(int id)
        {
            await _httpClient.DeleteAsync("cargocompany?id="+ id);
        }

        public async Task<List<ResultCargoCompanyDto>> GetAllCargoCompanyAsync()
        {
            var responseMessage = await _httpClient.GetAsync("cargocompany");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCargoCompanyDto>>();
            return values;

        }

        public async Task<UpdateCargoCompanyDto> GetByIdCargoCompanyAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("cargocompany/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateCargoCompanyDto>();
            return values;
        }

        public async Task UpdateCargoCompanyAsync(UpdateCargoCompanyDto updateAboutDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateCargoCompanyDto>("cargocompany", updateAboutDto);

        }
    }
}
