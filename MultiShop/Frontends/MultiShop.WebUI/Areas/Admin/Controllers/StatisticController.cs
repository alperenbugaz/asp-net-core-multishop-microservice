using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.DiscountStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.UserStatisticServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatisticController : Controller
    {
        private readonly ICatalogStatisticService _catalogStatisticService;
        private readonly IUserStatisticService _userStatisticService;
        private readonly ICommentStatisticService _commentStatisticService;
        private readonly IDiscountStatisticService _discountStatisticService;
        private readonly IMessageStatisticService _messageStatisticService;

        public StatisticController(IMessageStatisticService messageStatisticService, ICatalogStatisticService catalogStatisticService, IUserStatisticService userStatisticService, IDiscountStatisticService discountStatisticService, ICommentStatisticService commentStatisticService)
        {
            _catalogStatisticService = catalogStatisticService;
            _userStatisticService = userStatisticService;
            _commentStatisticService = commentStatisticService;
            _discountStatisticService = discountStatisticService;
            _messageStatisticService = messageStatisticService;
        }
        public async Task<IActionResult> Index()
        {   
            var brandCount = await _catalogStatisticService.GetBrandCount();
            var categoryCount = await _catalogStatisticService.GetCategoryCount();
            var productCount = await _catalogStatisticService.GetProductCount();
            //var productAvgPrice = await _catalogStatisticService.GetProductAvgPrice();
            var maxPriceProductName = await _catalogStatisticService.GetMaxPriceProductName();
            var minPriceProductName = await _catalogStatisticService.GetMinPriceProductName();
            ViewBag.ProductCount = productCount.ToString();
            ViewBag.CategoryCount = categoryCount.ToString();
            //ViewBag.ProductAvgPrice = productAvgPrice.ToString();

            ViewBag.MaxPriceProductName = maxPriceProductName;
            ViewBag.MinPriceProductName = minPriceProductName;
            ViewBag.BrandCount = brandCount.ToString();

            ViewBag.CommentCount = await _commentStatisticService.GetCommentCount();
            ViewBag.ActiveCommentCount = await _commentStatisticService.GetActiveCommentCount();
            ViewBag.PassiveCommentCount = await _commentStatisticService.GetPassiveCommentCount();

            ViewBag.DiscountCouponCount = await _discountStatisticService.GetDiscountCouponCount();

            ViewBag.UserCount = await _userStatisticService.GetUserCount();

            ViewBag.MessageCount = await _messageStatisticService.GetMessageCount();

            return View();
        }
    }
}
