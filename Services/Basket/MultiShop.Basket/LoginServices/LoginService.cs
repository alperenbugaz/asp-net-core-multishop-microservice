using System.Security.Claims;

namespace MultiShop.Basket.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LoginService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId
        {
            get
            {
                var httpContext = _httpContextAccessor.HttpContext;
                if (httpContext == null)
                {
                    Console.WriteLine("HttpContext NULL!");
                    throw new UnauthorizedAccessException("HttpContext not found.");
                }

                var user = httpContext.User;
                if (user == null || !user.Identity.IsAuthenticated)
                {
                    Console.WriteLine("\"User is unauthenticated or user is null!");
                    throw new UnauthorizedAccessException("No authentication has been made.");
                }

                // Mevcut tüm claim'leri logla
                Console.WriteLine("User claims:");
                foreach (var claim in user.Claims)
                {
                    Console.WriteLine($"{claim.Type} = {claim.Value}");
                }

                // sub claim'ini bulmaya çalış
                var claimSub = user.FindFirst("sub");
                if (claimSub == null)
                {
                    claimSub = user.FindFirst(ClaimTypes.NameIdentifier); // Alternatif kontrol
                }

                if (claimSub == null)
                {
                    throw new UnauthorizedAccessException("User ID not found.");
                }

                return claimSub.Value;
            }
        }




    }
}
