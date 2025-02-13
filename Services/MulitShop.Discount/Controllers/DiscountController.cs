using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> CouponList()
        {
            var coupons = await _discountService.GetAllCouponsAsync();
            return Ok(coupons);
        }

        [HttpGet("{couponId}")]
        public async Task<IActionResult> GetCouponById(int couponId)
        {
            var coupon = await _discountService.GetCouponByIdAsync(couponId);
            return Ok(coupon);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoupon(CreateCouponDto createCouponDto)
        {
            await _discountService.CreateCouponAsync(createCouponDto);
            return Ok("Coupon created successfully");
        }

        [HttpDelete("{couponId}")]
        public async Task<IActionResult> DeleteCoupon(int couponId)
        {
            await _discountService.DeleteCouponAsync(couponId);
            return Ok("Coupon deleted successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCoupon(UpdateCouponDto updateCouponDto)
        {
            await _discountService.UpdateCouponAsync(updateCouponDto);
            return Ok("Coupon updated successfully");
        }

        [HttpGet("GetCodeDetailByCodeAsync")]
        public async Task<IActionResult> GetCodeDetailByCodeAsync(string code)
        {
            var coupon = await _discountService.GetCodeDetailByCodeAsync(code);
            return Ok(coupon);
        }

        [HttpGet("GetDiscountCouponCountRate")]
        public async Task<IActionResult> GetDiscountCouponCountRate(string code)
        {
            var rate = _discountService.GetDiscountCouponCountRate(code);
            return Ok(rate);
        }

    }
}