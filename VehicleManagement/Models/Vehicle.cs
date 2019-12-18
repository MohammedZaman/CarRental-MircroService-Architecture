using System;
namespace VehicleManagement.Models
{
    public class Vehicle
    {
        public long vehicleId{get; set;}
        public string make { get; set; }
        public string model { get; set; }
        public bool isAvailable { get; set; }

    }
}
