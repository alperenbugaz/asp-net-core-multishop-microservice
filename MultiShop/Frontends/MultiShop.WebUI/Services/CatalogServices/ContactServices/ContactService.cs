using MultiShop.DtoLayer.CatalogDtos.ContactDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _client;

        public ContactService(HttpClient client)
        {
            _client = client;
        }

        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            await _client.PostAsJsonAsync<CreateContactDto>("Contact", createContactDto);
        }

        public async Task DeleteContactAsync(string id)
        {
            await _client.DeleteAsync("Contact?id=" + id);
        }

        public async Task<GetByIdContactDto> GetByIdContactAsync(string id)
        {
            var responseMessage = await _client.GetAsync($"Contact/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdContactDto>();
            return value;
        }

        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            var responseMessage = await _client.GetAsync("Contact");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
            return values;
        }

        public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            await _client.PutAsJsonAsync<UpdateContactDto>("Contact", updateContactDto);

        }

    }
}
