using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Services.FeatureSliderServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]

    [Route("api/[controller]")]
    [ApiController]
    public class FeatureSliderController : ControllerBase
    {
        private readonly IFeatureSliderService _featureSliderService;
        private readonly IMapper _mapper;
        public FeatureSliderController(IFeatureSliderService featureSliderService, IMapper mapper)
        {
            _featureSliderService = featureSliderService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeatureAsync(CreateFeatureSliderDto createFeatureSliderDto)
        {
            await _featureSliderService.CreateFeatureAsync(createFeatureSliderDto);
            return Ok("Feature Successfully Created");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeatureyAsync(string id)
        {
            await _featureSliderService.DeleteFeatureyAsync(id);
            return Ok("Feature Successfully Deleted");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFeatureAsync()
        {
            var values = await _featureSliderService.GetAllFeatureAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdFeatureAsync(string id)
        {
            var values = await _featureSliderService.GetByIdFeatureAsync(id);
            return Ok(values);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFeatureyAsync(UpdateFeatureSliderDto updateFeatureDto)
        {
            await _featureSliderService.UpdateFeatureyAsync(updateFeatureDto);
            return Ok("Feature Successfully Updated");
        }
    }
}
