using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.User.ViewComponents.UserLayoutViewComponents
{
    public class _UserLayoutHeaderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
