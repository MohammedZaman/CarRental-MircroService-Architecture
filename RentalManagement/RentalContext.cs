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
            List<Rental> rentalsList = rentals.ToList();

            for(int i = 0; i < rentalsList.Count; i++) {
                if (rentalsList[i].refNum == refNum)
                {
                    return rentalsList[i];
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
