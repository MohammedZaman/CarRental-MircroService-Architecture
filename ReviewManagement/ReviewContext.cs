using System;
using Microsoft.EntityFrameworkCore;
using ReviewManagement.Models;

namespace ReviewManagement
{
    public class ReviewContext : DbContext
    {
        public ReviewContext(DbContextOptions<ReviewContext> options)
       : base(options)
        {
        }


        public DbSet<Review> reviews { get; set; }

        public void addReview(Review review) {
            reviews.Add(review);

        }

        public Review find(long id)
        {
            return (Review)reviews.Find(id);
        }

    }
}





   