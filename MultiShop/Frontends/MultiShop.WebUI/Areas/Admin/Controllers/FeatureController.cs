using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using MultiShop.WebUI.Services.CatalogServices.FeatureServices;


namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Feature")]
    public class FeatureController : Controller
    {
        private readonly IFeatureService _FeatureService;
        public FeatureController(IFeatureService FeatureService)
        {
            _FeatureService = FeatureService;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Feature";
            ViewBag.v3 = "Feature List";
            ViewBag.v0 = "Feature";

            var values = await _FeatureService.GetAllFeatureAsync();
            return View(values);

        }

        [Route("CreateFeature")]
        [HttpGet]
        public async Task<IActionResult> CreateFeature()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Feature";
            ViewBag.v3 = "Create Feature";
            ViewBag.v0 = "Feature";
            return View();
        }

        [HttpPost]
        [Route("CreateFeature")]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            await _FeatureService.CreateFeatureAsync(createFeatureDto);
            return RedirectToAction("Index");
        }

        [Route("DeleteFeature/{id}")]
        public async Task<IActionResult> DeleteFeature(string id)
        {
            await _FeatureService.DeleteFeatureAsync(id);

            return RedirectToAction("Index");
        }

        [Route("EditFeature/{id}")]
        [HttpGet]
        public async Task<IActionResult> EditFeature(string id)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Feature";
            ViewBag.v3 = "Edit Feature";

            var value = await _FeatureService.GetByIdFeatureAsync(id);


            return View(value);
        }

        [HttpPost]
        [Route("EditFeature/{id}")]
        public async Task<IActionResult> EditFeature(UpdateFeatureDto editFeatureDto)
        {

            await _FeatureService.UpdateFeatureAsync(editFeatureDto);
            return RedirectToAction("Index");


        }




    }
}
