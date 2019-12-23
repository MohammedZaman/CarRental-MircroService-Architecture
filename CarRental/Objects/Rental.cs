using System;
namespace CarRental.Objects
{
    public class Rental
    {
        public long rentalId { get; set; }
        public DateTime rentalDate { get; set; }
        public long vehicleId { get; set; }
        public long customerId { get; set; }
        public string refNum { get; set; }
        public bool isReturned { get; set; }
    }
}
