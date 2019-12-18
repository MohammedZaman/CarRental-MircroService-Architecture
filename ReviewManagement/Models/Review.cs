using System;
namespace ReviewManagement.Models
{
    public class Review
    {
        public long reviewId {get; set;}
        public string reviewText { get; set; }
        public long rating { get; set; }
        public long customerId { get; set; }
    }
}
