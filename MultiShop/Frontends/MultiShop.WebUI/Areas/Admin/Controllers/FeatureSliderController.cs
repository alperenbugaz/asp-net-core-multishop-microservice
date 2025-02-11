using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using Newtonsoft.Json;
using System.Text;
using MultiShop.WebUI.Services.CatalogServices.SliderServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/FeatureSlider")]
    [AllowAnonymous]
    public class FeatureSliderController : Controller
    {
        private readonly ISliderService _SliderService;
        public FeatureSliderController(ISliderService SliderService)
        {
            _SliderService = SliderService;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Slider";
            ViewBag.v3 = "Slider List";
            ViewBag.v0 = "Slider";

            var values = await _SliderService.GetAllSliderAsync();
            return View(values);

        }

        [Route("CreateFeatureSlider")]
        [HttpGet]
        public async Task<IActionResult> CreateFeatureSlider()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Slider";
            ViewBag.v3 = "Create Slider";
            ViewBag.v0 = "Slider";
            return View();
        }

        [HttpPost]
        [Route("CreateFeatureSlider")]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createSliderDto)
        {
            await _SliderService.CreateSliderAsync(createSliderDto);
            return RedirectToAction("Index");
        }

        [Route("DeleteFeatureSlider/{id}")]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            await _SliderService.DeleteSliderAsync(id);

            return RedirectToAction("Index");
        }

        [Route("EditFeatureSlider/{id}")]
        [HttpGet]
        public async Task<IActionResult> EditFeatureSlider(string id)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Slider";
            ViewBag.v3 = "Edit Slider";

            var value = await _SliderService.GetByIdSliderAsync(id);


            return View(value);
        }

        [HttpPost]
        [Route("EditFeatureSlider/{id}")]
        public async Task<IActionResult> EditFeatureSlider(EditFeatureSliderDto editSliderDto)
        {

            await _SliderService.UpdateSliderAsync(editSliderDto);
            return RedirectToAction("Index");


        }

    }
}
