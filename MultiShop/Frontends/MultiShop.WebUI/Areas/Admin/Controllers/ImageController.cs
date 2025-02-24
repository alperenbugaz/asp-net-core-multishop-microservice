using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.ImageDtos;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    public class ImageController : Controller
    {

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ImageDriveDtos imageDriveDtos)
        {   


            return View();
        }

    }
}
