using System;
using Microsoft.EntityFrameworkCore;
using VehicleManagement.Models;



namespace VehicleManagement
{
    public class VehicleContext : DbContext
    {
        public VehicleContext(DbContextOptions<VehicleContext> options)
       : base(options)
        {
        }


        public DbSet<Vehicle> vehicles { get; set; }

        public void addVehicle(Vehicle vehicle) {
            vehicles.Add(vehicle);

        }

        public Vehicle find(long id)
        {
            return (Vehicle)vehicles.Find(id);
        }

        public void updateVehicle(Vehicle vehicle) {
            vehicles.Update(vehicle);
        }

        public Vehicle findWithId(long id)
        {
           return vehicles.Find(id);
        }



    }
}





   