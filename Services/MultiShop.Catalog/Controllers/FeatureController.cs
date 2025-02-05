using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Services.FeatureServices;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        {
            await _featureService.CreateFeature(createFeatureDto);
            return Ok("Feature Successfully Created");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeatureyAsync(string id)
        {
            await _featureService.DeleteFeature(id);
            return Ok("Feature Successfully Deleted");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFeatureAsync()
        {
            var values = await _featureService.GetAllFeatureAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdFeatureAsync(string id)
        {
            var values = await _featureService.GetByIdFeatureAsync(id);
            return Ok(values);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFeatureyAsync(UpdateFeatureDto updateFeatureDto)
        {
            await _featureService.UpdateFeature(updateFeatureDto);
            return Ok("Feature Successfully Updated");
        }


    }
}
