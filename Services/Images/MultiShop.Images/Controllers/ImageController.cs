using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Images.Services;

namespace MultiShop.Images.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ICloudStorageService _cloudStorageService;

        public ImageController(ICloudStorageService cloudStorageService)
        {
            _cloudStorageService = cloudStorageService;
        }


    }
}
