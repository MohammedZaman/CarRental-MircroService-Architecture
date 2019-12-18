using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RentalManagement.Models;

namespace RentalManagement
{
    public class RentalContext : DbContext
    {


       
     
       public RentalContext(DbContextOptions<RentalContext> options)
           : base(options)
        {
        }

        public DbSet<Rental> rentals{ get; set; }

      
        public void addRentals(Rental rental)
        {
            rentals.Add(rental);
        }



        public Rental find(long id)
        {
            return (Rental)rentals.Find(id);
        }



        public Rental findWithReference(String refNum)
        {
            foreach (var dbItem in rentals)
            {
                if (refNum  == dbItem.refNum) {
                    return (Rental)dbItem;
                }
            }
            return null;
        }

        public void updateRental(Rental rental)
        {
            rentals.Update(rental);
        }

    }
}
