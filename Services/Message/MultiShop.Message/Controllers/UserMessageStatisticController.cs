using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Message.Services;

namespace MultiShop.Message.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController] 
    public class UserMessageStatisticController : ControllerBase
    {
        private readonly IUserMessageService _userMessageService;

        public UserMessageStatisticController(IUserMessageService userMessageService)
        {
            _userMessageService = userMessageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMessageCount()
        {
            int values = await _userMessageService.GetMessageCount();
            return Ok(values);
        }


    }
}
