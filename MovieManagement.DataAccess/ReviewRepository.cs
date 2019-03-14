using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.DataAccess
{
    public class ReviewRepository : BaseRepository
    {
        //adding access methods for application interaction with the DB - table Review.
        public List<Review> SearchReviews()
        {
            return dbContext.Reviews.ToList();
        }

        public Review GetReview(Guid reviewId)
        {
            var review = dbContext.Reviews.FirstOrDefault(a => a.id == reviewId);
            return review;

        }

        public void AddReview(Review newReview)
        {
            dbContext.Reviews.Add(newReview);
            dbContext.SaveChanges();
        }

        public void DeleteReview(Guid reviewId)
        {
            var review = dbContext.Reviews.FirstOrDefault(a => a.id == reviewId);
            if (review != null)
            {

                dbContext.Reviews.Remove(review);
                dbContext.SaveChanges();
            }
        }

        public void UpdateReview(Review updateReview)
        {

            var existingReview = dbContext.Reviews.FirstOrDefault(a => a.id == updateReview.id);
            if (existingReview != null)
            {
                existingReview.Score = updateReview.Score;
                dbContext.SaveChanges();
            }

        }
    }
}
