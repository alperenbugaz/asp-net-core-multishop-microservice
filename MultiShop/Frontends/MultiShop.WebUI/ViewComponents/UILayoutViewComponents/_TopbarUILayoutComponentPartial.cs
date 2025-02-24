using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.IdentityDtos.LoginDtos;
using MultiShop.WebUI.Services.Interfaces;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _TopbarUILayoutComponentPartial : ViewComponent
    {
        private readonly IUserService _userService;
        public _TopbarUILayoutComponentPartial(IUserService userService)
        {
            _userService = userService;

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userService.GetUserInfo();
            ViewBag.UserName = values.UserName;
            ViewBag.NameSurname = values.Name + " " +values.Surname;
            
            return View();
        }
    }
}
