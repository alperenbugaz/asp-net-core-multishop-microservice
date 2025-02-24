using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Images.Dtos;
using MultiShop.Images.Services;

namespace MultiShop.Images.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class DriveImageUploadController : ControllerBase
    {
        private readonly ICloudStorageService _cloudStorageService;
        public DriveImageUploadController(ICloudStorageService cloudStorageService)
        {
            _cloudStorageService = cloudStorageService;
        }
        public async Task Create(ImageDriveDtos imageDriveDtos)
        {
            if (imageDriveDtos != null)
            {
                imageDriveDtos.SavedFileName = GenerateFileNameToSave(imageDriveDtos.Photo.FileName);
                imageDriveDtos.SavedUrl = await _cloudStorageService.UploadFileAsync(imageDriveDtos.Photo, imageDriveDtos.SavedFileName);
            }
        }

        private string GenerateFileNameToSave(string incomingFileName)
        {
            var fileName = Path.GetFileNameWithoutExtension(incomingFileName);
            var extension = Path.GetExtension(incomingFileName);

            return fileName + "_" + Guid.NewGuid().ToString() + extension;
        }
    }
}
