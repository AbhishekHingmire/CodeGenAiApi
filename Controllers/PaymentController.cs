using CodeGeneratorApi.Data;
using Microsoft.AspNetCore.Mvc;
using CodeGeneratorApi.Models;
using System.Linq;

namespace CodeGeneratorApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PaymentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("complete/{userId}")]
        public IActionResult CompletePayment(int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null) return NotFound("User not found");

            user.PaymentDone = true;
            _context.SaveChanges();

            return Ok("Payment marked as completed.");
        }

        [HttpGet("status/{userId}")]
        public IActionResult CheckPaymentStatus(int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null) return NotFound("User not found");

            return Ok(new { PaymentDone = user.PaymentDone });
        }
    }
}
