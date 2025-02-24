using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Context;

namespace MultiShop.Comment.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentStatisticController : ControllerBase
    {   
        private readonly CommentContext _context;

        public CommentStatisticController(CommentContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetCommentCount()
        {
            int values = await _context.UserComments.CountAsync();
            return Ok(values);
        }
    }
}
