using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CommentServices;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.MessageServices;
using MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices;

namespace MultiShop.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutHeaderComponentPartial : ViewComponent
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;
        private readonly ICommentStatisticService _commentService;

        public _AdminLayoutHeaderComponentPartial(IMessageService messageService, IUserService userService, ICommentStatisticService commentService)
        {
            _messageService = messageService;
            _userService = userService;
            _commentService = commentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userService.GetUserInfo();
            int totalMessageCount = await _messageService.GetTotalMessageCountyByReceiverId(user.Id);
            ViewBag.TotalMessageCount = totalMessageCount;

            ViewBag.Name = user.Name;
            ViewBag.Surname = user.Surname;
            ViewBag.Email = user.Email;

            int totalCommentCount = await _commentService.GetCommentCount();
            ViewBag.TotalCommentCount = totalCommentCount;
            return View();
        }
    }
}
