using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VehicleManagement.Models;

namespace VehicleManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly ILogger<VehicleController> _logger;
        private readonly VehicleContext _context;

        public VehicleController(ILogger<VehicleController> logger, VehicleContext context)
        {
            _context = context;
            _logger = logger;
        }


        [HttpPost]
        public IActionResult AddVehicle(Vehicle vehicle)
        {

            _context.addVehicle(vehicle);
            _context.SaveChanges();
            return Ok(vehicle);


        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Vehicle> vehicles = _context.vehicles.ToList();
            return Ok(vehicles);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRental(long id ,Vehicle vehicle)
        {
            Vehicle temp = _context.find(id);
            if (temp != null) {
                temp.make = vehicle.make;
                temp.model = vehicle.model;
                temp.isAvailable = vehicle.isAvailable;
                _context.updateVehicle(temp);
                _context.SaveChanges();
                return Ok("Vehicle Updated");
            }
            return NotFound("Vehicle Does Not Exist");
        }
    }
}
