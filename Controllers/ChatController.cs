
using Microsoft.AspNetCore.Mvc;
using CodeGeneratorApi.Data;
using CodeGeneratorApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace CodeGeneratorApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ChatController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("save")]
        public IActionResult SaveMessage(ChatMessage msg)
        {
            msg.CreatedAt = DateTime.Now;
            _context.ChatMessages.Add(msg);
            _context.SaveChanges();
            return Ok(msg);
        }

        [HttpGet("get/{userId}")]
        public ActionResult<List<ChatMessage>> GetMessages(int userId)
        {
            return _context.ChatMessages.Where(m => m.UserId == userId).ToList();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var msg = _context.ChatMessages.Find(id);
            if (msg == null) return NotFound();
            _context.ChatMessages.Remove(msg);
            _context.SaveChanges();
            return Ok("Deleted");
        }
    }
}
