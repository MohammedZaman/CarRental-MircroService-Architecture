using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReviewManagement.Models;

namespace ReviewManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReviewController : ControllerBase
    {


        private readonly ILogger<ReviewController> _logger;
        private readonly ReviewContext _context;

        public ReviewController(ILogger<ReviewController> logger, ReviewContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Review> users = _context.reviews.ToList();
            return Ok(users);
        }

        [HttpPost]
        public IActionResult AddReview(Review review)
        {
                _context.addReview(review);
                _context.SaveChanges();
                return Ok(review);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(long id)
        {
            Review temp = new Review();
            temp.customerId = id;
            var review = _context.find(id);
            if (review == null)
            {
                return NotFound();
            }

            _context.Remove(review);
            await _context.SaveChangesAsync();

            return Ok("review Deleted");
        }

    }
}
