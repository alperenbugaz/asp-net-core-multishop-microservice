using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Basket.Dtos;
using MultiShop.Basket.LoginServices;
using MultiShop.Basket.Services;

namespace MultiShop.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService _loginService;
        public BasketController(IBasketService basketService,ILoginService loginService)
        {
            _basketService = basketService;
            _loginService = loginService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {

            var user = User.Claims;
            var userId = _loginService.GetUserId;
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("Kullanıcı kimliği alınamadı.");
            }
            var values = await _basketService.GetBasket(_loginService.GetUserId);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> SaveBasket(BasketTotalDto basketTotalDto)
        {
            try
            {
                var userId = _loginService.GetUserId;
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized("Kullanıcı kimliği alınamadı.");
                }

                basketTotalDto.UserId = userId;
                await _basketService.SaveBasket(basketTotalDto);
                return Ok("Sepetteki değişiklikler kaydedildi");
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            await _basketService.DeleteBasket(_loginService.GetUserId);
            return Ok("Sepet silindi");
        }
    }
}
