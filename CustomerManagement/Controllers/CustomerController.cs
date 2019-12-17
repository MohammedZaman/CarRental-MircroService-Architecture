using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomerManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
     

        private readonly ILogger<CustomerController> _logger;
        private readonly CustomerContext _context;

        public CustomerController(ILogger<CustomerController> logger , CustomerContext context)
        {
            _context = context;
            _logger = logger;
        }


        
        [HttpPost]
        public IActionResult AddCustomer(Customer customer){

            if (!_context.isUserExist(customer))
            {
                _context.addCustomer(customer);
                _context.SaveChanges();
                return Ok(customer);
            }
            else {
                return NotFound("User already exists ");
            }
            
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Customer> users = _context.customers.ToList();
            return Ok(users);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(long id)
        {
            Customer temp = new Customer();
            temp.customerId = id;
            var customer = _context.find(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Remove(customer);
            await _context.SaveChangesAsync();

            return Ok("Customer Deleted");
        }
    }
}
