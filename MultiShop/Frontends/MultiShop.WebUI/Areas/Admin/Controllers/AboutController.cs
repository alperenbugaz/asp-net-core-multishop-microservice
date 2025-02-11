using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.AboutDtos;
using MultiShop.WebUI.Services.CatalogServices.AboutServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/About")]
    public class AboutController : Controller
    {
        private readonly IAboutService _AboutService;
        public AboutController(IAboutService AboutService)
        {
            _AboutService = AboutService;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "About";
            ViewBag.v3 = "About List";
            ViewBag.v0 = "About";

            var values = await _AboutService.GetAllAboutAsync();
            return View(values);

        }

        [Route("CreateAbout")]
        [HttpGet]
        public async Task<IActionResult> CreateAbout()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "About";
            ViewBag.v3 = "Create About";
            ViewBag.v0 = "About";
            return View();
        }

        [HttpPost]
        [Route("CreateAbout")]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            await _AboutService.CreateAboutAsync(createAboutDto);
            return RedirectToAction("Index");
        }

        [Route("DeleteAbout/{id}")]
        public async Task<IActionResult> DeleteAbout(string id)
        {
            await _AboutService.DeleteAboutAsync(id);

            return RedirectToAction("Index");
        }

        [Route("EditAbout/{id}")]
        [HttpGet]
        public async Task<IActionResult> EditAbout(string id)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "About";
            ViewBag.v3 = "Edit About";

            var value = await _AboutService.GetByIdAboutAsync(id);


            return View(value);
        }

        [HttpPost]
        [Route("EditAbout/{id}")]
        public async Task<IActionResult> EditAbout(UpdateAboutDto editAboutDto)
        {

            await _AboutService.UpdateAboutAsync(editAboutDto);
            return RedirectToAction("Index");


        }
    }
}
