using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Comment.Context;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CommentController : ControllerBase
    {
        private readonly CommentContext _context;

        public CommentController(CommentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _context.UserComments.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateComment(UserComment comment)
        {
            _context.UserComments.Add(comment);
            _context.SaveChanges();
            return Ok("Comment added");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id)
        {
            var comment = _context.UserComments.Find(id);
            _context.UserComments.Remove(comment);
            _context.SaveChanges();
            return Ok("Comment deleted");
        }

        [HttpPut]
        public IActionResult UpdateComment(UserComment comment)
        {
            _context.UserComments.Update(comment);
            _context.SaveChanges();
            return Ok("Comment updated");
        }

        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var comment = _context.UserComments.Find(id);
            return Ok(comment);

        }

        [HttpGet("CommentsListByProductId/{productId}")]
        public IActionResult CommentsListByProductId(string productId)
        {
            var values = _context.UserComments.Where(x => x.ProductId == productId).ToList();
            return Ok(values);
        }

    }
}
