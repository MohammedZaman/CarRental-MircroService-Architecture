using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerManagement
{
    public class Customer
    {
        public long customerId { get; set; }

        [Required]
        public string userName { get; set; }

        [Required]
        public string password { get; set; }
      
    }
}
