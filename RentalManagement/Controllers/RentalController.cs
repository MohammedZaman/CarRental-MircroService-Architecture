using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RentalManagement.Models;

namespace RentalManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentalController : ControllerBase
    {


        private readonly ILogger<RentalController> _logger;
        private readonly RentalContext _context;

        public RentalController(ILogger<RentalController> logger, RentalContext context)
        {
            _context = context;
            _logger = logger;
        }


        [HttpPost]
        public IActionResult AddRental(Rental rental)
        {

                _context.addRentals(rental);
                _context.SaveChanges();
                return Ok(rental);
           

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Rental> rentals = _context.rentals.ToList();
            return Ok(rentals);
        }

        [HttpGet("{id}")]
        public IActionResult GetWithId(String refNum)
        {
            Rental temp = _context.findWithReference(refNum);
            if (temp != null) {
                Ok(temp);
            }
            return NotFound("Not Rentals Found");
        }

        [HttpPut("{id}")]
        public IActionResult updateRental(long id, Rental rental)
        {
            Rental temp = _context.find(id);
            if (temp != null)
            {
                temp.refNum = rental.refNum;
                temp.rentalDate = rental.rentalDate;
                temp.vehicleId = rental.vehicleId;
                temp.isReturned = rental.isReturned;
                temp.customerId = rental.customerId;
                _context.updateRental(temp);
                _context.SaveChanges();
                return Ok("Rental Updated");
            }
            return NotFound("Rental Does Not Exist");
        }




    }
}
