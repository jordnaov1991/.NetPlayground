using MovieManagement.DataAccess;
using MovieManagement.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Management
{
    public class ReviewManagement
    {
        private ReviewRepository _repo = new ReviewRepository();


        public List<ReviewDTO> Search()
        {
            var result = _repo.SearchReviews();
            var toReturn = result.Select(a => new ReviewDTO
            {
                Id = a.id,
                Score = a.Score,

            }).ToList();

            return toReturn;
        }


    public ReviewDTO GetReview(Guid id)
    {
        var repoResult = _repo.GetReview(id);
        return new ReviewDTO
        {
            Id = repoResult.id,
            Score = repoResult.Score,
        };

    }

    public void DeleteReview(Guid id)
    {
        _repo.DeleteReview(id);
    }

    public void AddOrUpdate(ReviewDTO review)
    {

        var rev = new Review
        {
            id = review.Id != Guid.Empty ? review.Id : Guid.NewGuid(), //checking if passed movie object ID already exists, if not then we create a new ID.
            Score = review.Score,
        };
        
        if (review.Id != Guid.Empty)
        {
            //movie exists => update
            _repo.UpdateReview(rev);
        }
        else
        {
            //movie doesn't exist => add
            _repo.AddReview(rev);
        }

    }

    }
}
