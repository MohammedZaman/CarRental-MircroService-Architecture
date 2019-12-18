using System;
using System.Collections.Generic;
using System.Linq;
using CustomerManagement.Models;
using Microsoft.EntityFrameworkCore;
namespace CustomerManagement
{
    public class CustomerContext : DbContext
    {


       
     
       public CustomerContext(DbContextOptions<CustomerContext> options)
           : base(options)
        {
        }

        public DbSet<Customer> customers{ get; set; }

        public void addCustomer(string userName,string password) {
            customers.Add(new Customer { userName = userName , password = password});
        }

        public void addCustomer(Customer customer)
        {
            customers.Add(customer);
        }


        public bool isUserExist(Customer customer)
        {

            if (customers.Any(o => o.userName == customer.userName))
            {
                return true;

            }
            return false;
        }

        public Customer find(long id)
        {
            return (Customer)customers.Find(id);
        }

        public Authorisation Authenticate (string userName,string password)
        {
            var myUser = this.customers
                 .FirstOrDefault(u => u.userName == userName
                              && u.password == password);

            if (myUser != null)    
            {
                Authorisation validAuth = new Authorisation();
                validAuth.userName = userName;
                validAuth.isAuthorized = true;
                validAuth.customerId = myUser.customerId;
                return validAuth;
            }
            else    
            {
                Authorisation notValid = new Authorisation();
                notValid.customerId = -1;
                notValid.userName = userName;
                notValid.isAuthorized = false;
                return notValid;


            }
        }
    }
}
