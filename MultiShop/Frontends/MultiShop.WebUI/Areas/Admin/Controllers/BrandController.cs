using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using MultiShop.WebUI.Services.CatalogServices.BrandServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Brand")]
    public class BrandController : Controller
    {
        private readonly IBrandService _BrandService;
        public BrandController(IBrandService BrandService)
        {
            _BrandService = BrandService;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Brand";
            ViewBag.v3 = "Brand List";
            ViewBag.v0 = "Brand";

            var values = await _BrandService.GetAllBrandAsync();
            return View(values);

        }

        [Route("CreateBrand")]
        [HttpGet]
        public async Task<IActionResult> CreateBrand()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Brand";
            ViewBag.v3 = "Create Brand";
            ViewBag.v0 = "Brand";
            return View();
        }

        [HttpPost]
        [Route("CreateBrand")]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
            await _BrandService.CreateBrandAsync(createBrandDto);
            return RedirectToAction("Index");
        }

        [Route("DeleteBrand/{id}")]
        public async Task<IActionResult> DeleteBrand(string id)
        {
            await _BrandService.DeleteBrandAsync(id);

            return RedirectToAction("Index");
        }

        [Route("EditBrand/{id}")]
        [HttpGet]
        public async Task<IActionResult> EditBrand(string id)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Brand";
            ViewBag.v3 = "Edit Brand";

            var value = await _BrandService.GetByIdBrandAsync(id);


            return View(value);
        }

        [HttpPost]
        [Route("EditBrand/{id}")]
        public async Task<IActionResult> EditBrand(UpdateBrandDto editBrandDto)
        {

            await _BrandService.UpdateBrandAsync(editBrandDto);
            return RedirectToAction("Index");


        }
    }
}
