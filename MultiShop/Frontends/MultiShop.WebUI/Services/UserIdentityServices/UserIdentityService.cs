using MultiShop.DtoLayer.IdentityDtos.UserDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.UserIdentityServices
{
    public class UserIdentityService : IUserIdentityService
    {
        private readonly HttpClient _httpClient;

        public UserIdentityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<ResultUserDto>> GetAllUserListAsync()
        {
            var response = await _httpClient.GetAsync("http://localhost:5001/api/user/getalluserlist");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ResultUserDto>>(jsonData);
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
