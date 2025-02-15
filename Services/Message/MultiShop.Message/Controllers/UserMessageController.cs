using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Message.Dtos;
using MultiShop.Message.Services;

namespace MultiShop.Message.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMessageController : ControllerBase
    {   
        private readonly IUserMessageService _userMessageService;

        public UserMessageController(IUserMessageService userMessageService)
        {
            _userMessageService = userMessageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMessage()
        {
            var value = await _userMessageService.GetAllUserMessagesAsync();
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageDto createUserMessageDto)
        {
            await _userMessageService.CreateMessageAsync(createUserMessageDto);
            return Ok("Message Created");
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            await _userMessageService.DeleteUserMessageAsync(id);
            return Ok("Message Deleted");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMessage(UpdateMessageDto updateUserMessageDto)
        {
            await _userMessageService.UpdateMessageAsync(updateUserMessageDto);
            return Ok("Message Updated");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdMessage(int id)
        {
            var value = await _userMessageService.GetByIdMessageAsync(id);
            return Ok(value);
        }

        [HttpGet("GetMessageSendBox")]
        public async Task<IActionResult> GetMessageSendBox(string id)
        {
            var value = await _userMessageService.GetSendBoxMessageAsync(id);
            return Ok(value);
        }

        [HttpGet("GetMessageInBox")]
        public async Task<IActionResult> GetMessageInBox(string id)
        {
            var value = await _userMessageService.GetInBoxMessageAsync(id);
            return Ok(value);
        }


    }
}
