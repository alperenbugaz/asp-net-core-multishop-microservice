using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices;


namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/OfferDiscount")]

    public class OfferDiscountController : Controller
    {
        private readonly IOfferDiscountService _OfferDiscountService;
        public OfferDiscountController(IOfferDiscountService OfferDiscountService)
        {
            _OfferDiscountService = OfferDiscountService;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "OfferDiscount";
            ViewBag.v3 = "OfferDiscount List";
            ViewBag.v0 = "OfferDiscount";

            var values = await _OfferDiscountService.GetAllOfferDiscountAsync();
            return View(values);

        }

        [Route("CreateOfferDiscount")]
        [HttpGet]
        public async Task<IActionResult> CreateOfferDiscount()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "OfferDiscount";
            ViewBag.v3 = "Create OfferDiscount";
            ViewBag.v0 = "OfferDiscount";
            return View();
        }

        [HttpPost]
        [Route("CreateOfferDiscount")]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {
            await _OfferDiscountService.CreateOfferDiscountAsync(createOfferDiscountDto);
            return RedirectToAction("Index");
        }

        [Route("DeleteOfferDiscount/{id}")]
        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            await _OfferDiscountService.DeleteOfferDiscountAsync(id);

            return RedirectToAction("Index");
        }

        [Route("EditOfferDiscount/{id}")]
        [HttpGet]
        public async Task<IActionResult> EditOfferDiscount(string id)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "OfferDiscount";
            ViewBag.v3 = "Edit OfferDiscount";

            var value = await _OfferDiscountService.GetByIdOfferDiscountAsync(id);


            return View(value);
        }

        [HttpPost]
        [Route("EditOfferDiscount/{id}")]
        public async Task<IActionResult> EditOfferDiscount(UpdateOfferDiscountDto editOfferDiscountDto)
        {

            await _OfferDiscountService.UpdateOfferDiscountAsync(editOfferDiscountDto);
            return RedirectToAction("Index");


        }
    }
}
