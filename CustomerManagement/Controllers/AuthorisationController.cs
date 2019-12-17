using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorisationController : Controller
    {
        private readonly ILogger<AuthorisationController> _logger;
        private readonly CustomerContext _context;

        public AuthorisationController(ILogger<AuthorisationController> logger, CustomerContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Authorise(Customer customer)
        {

           Authorisation Auth = _context.Authenticate(customer.userName,customer.password);

           
           
            return Ok(Auth);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Customer> users = _context.customers.ToList();
            return Ok(users);
        }

    }
}
