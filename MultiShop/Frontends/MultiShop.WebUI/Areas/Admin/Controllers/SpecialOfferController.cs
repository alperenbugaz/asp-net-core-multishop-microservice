using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/SpecialOffer")]
    public class SpecialOfferController : Controller
    {
        private readonly ISpecialOfferService _SpecialOfferService;
        public SpecialOfferController(ISpecialOfferService SpecialOfferService)
        {
            _SpecialOfferService = SpecialOfferService;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "SpecialOffer";
            ViewBag.v3 = "SpecialOffer List";
            ViewBag.v0 = "SpecialOffer";

            var values = await _SpecialOfferService.GetAllSpecialOfferAsync();
            return View(values);

        }

        [Route("CreateSpecialOffer")]
        [HttpGet]
        public async Task<IActionResult> CreateSpecialOffer()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "SpecialOffer";
            ViewBag.v3 = "Create SpecialOffer";
            ViewBag.v0 = "SpecialOffer";
            return View();
        }

        [HttpPost]
        [Route("CreateSpecialOffer")]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _SpecialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);
            return RedirectToAction("Index");
        }

        [Route("DeleteSpecialOffer/{id}")]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            await _SpecialOfferService.DeleteSpecialOfferAsync(id);

            return RedirectToAction("Index");
        }

        [Route("EditSpecialOffer/{id}")]
        [HttpGet]
        public async Task<IActionResult> EditSpecialOffer(string id)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "SpecialOffer";
            ViewBag.v3 = "Edit SpecialOffer";

            var value = await _SpecialOfferService.GetByIdSpecialOfferAsync(id);


            return View(value);
        }

        [HttpPost]
        [Route("EditSpecialOffer/{id}")]
        public async Task<IActionResult> EditSpecialOffer(UpdateSpecialOfferDto editSpecialOfferDto)
        {

            await _SpecialOfferService.UpdateSpecialOfferAsync(editSpecialOfferDto);
            return RedirectToAction("Index");


        }

    }
}
