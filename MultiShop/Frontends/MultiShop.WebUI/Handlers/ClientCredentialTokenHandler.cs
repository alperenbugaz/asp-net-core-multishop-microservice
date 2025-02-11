using MultiShop.WebUI.Services.Interfaces;
using System.Net;
using System.Net.Http.Headers;

namespace MultiShop.WebUI.Handlers
{
    public class ClientCredentialTokenHandler : DelegatingHandler
    {
        private readonly IClientCredentialTokenService _clientCredentialTokenService;

        public ClientCredentialTokenHandler(IClientCredentialTokenService clientCredentialTokenService)
        {
            _clientCredentialTokenService = clientCredentialTokenService;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Dinamik olarak token al
            var token = await _clientCredentialTokenService.GetToken();

            // Header'a ekle
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!
            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                Console.WriteLine("Yetkilendirme hatası: Token geçersiz olabilir!");
                // Burada token yenileme veya loglama işlemi yapabilirsin.
            }

            return response;
        }

    }
}
