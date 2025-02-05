using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.OfferDiscountDtos;
using MultiShop.Catalog.Services.OfferDiscountServices;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class OfferDiscountController : ControllerBase
    {
        private readonly IOfferDiscountService _offerDiscountService;
        private readonly IMapper _mapper;
        public OfferDiscountController(IOfferDiscountService offerDiscountService)
        {
            _offerDiscountService = offerDiscountService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto)
        {
            await _offerDiscountService.CreateOfferDiscountAsync(createOfferDiscountDto);
            return Ok("OfferDiscount Successfully Created");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOfferDiscountyAsync(string id)
        {
            await _offerDiscountService.DeleteOfferDiscountyAsync(id);
            return Ok("OfferDiscount Successfully Deleted");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOfferDiscountAsync()
        {
            var values = await _offerDiscountService.GetAllOfferDiscountAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdOfferDiscountAsync(string id)
        {
            var values = await _offerDiscountService.GetByIdOfferDiscountAsync(id);
            return Ok(values);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOfferDiscountyAsync(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await _offerDiscountService.UpdateOfferDiscountyAsync(updateOfferDiscountDto);
            return Ok("OfferDiscount Successfully Updated");
        }

    }
}
