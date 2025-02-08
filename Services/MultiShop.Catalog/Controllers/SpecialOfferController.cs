using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Services.SpecialOfferServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]

    [Route("api/[controller]")]
    [ApiController]
    public class SpecialOfferController : ControllerBase
    {
        private readonly ISpecialOfferService _specialOfferService;
        public SpecialOfferController(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSpecialOffer()
        {
            var result = await _specialOfferService.GettAllSpecialOffertAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdSpecialOffer(string id)
        {
            var result = await _specialOfferService.GetByIdSpecialOffertAsync(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _specialOfferService.CreateSpecialOffertAsync(createSpecialOfferDto);
            return Ok("Special Offer Created Successfuly");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _specialOfferService.UpdateProductAsync(updateSpecialOfferDto);
            return Ok("Special Offer Updated Successfuly");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            await _specialOfferService.DeleteProductAsync(id);
            return Ok("Special Offer Deleted Successfuly");
        }

    }
}
