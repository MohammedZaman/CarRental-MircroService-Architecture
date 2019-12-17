using System;
namespace CustomerManagement.Models
{
    public class Authorisation
    {
       public string userName { get; set; }
       public bool isAuthorized { get; set; }
       public long customerId { get; set; }
    }
}
