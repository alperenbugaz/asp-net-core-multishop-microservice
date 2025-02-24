using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Interfaces;

namespace MultiShop.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutSideBarComponentPartial : ViewComponent
    {
        private readonly IUserService _userService;

        public _AdminLayoutSideBarComponentPartial(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userService.GetUserInfo();
            ViewBag.UserName = user.UserName;
            ViewBag.Name = user.Name;
            ViewBag.Surname = user.Surname;

            return View();
        }
    }
}
