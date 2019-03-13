using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.DataAccess
{
    public class MovieRepository : BaseRepository
    {
        public List<Movy> SearchReviews()
        {
            return dbContext.Movies.ToList();
        }
        public Movy GetReview(Guid movieId)
        {
            var movie = dbContext.Movies.FirstOrDefault(a => a.id == movieId);
            return movie;

        }

        public void AddMovie(Movy newMovie)
        {
            dbContext.Movies.Add(newMovie);
            dbContext.SaveChanges();
        }

        public void DeleteMovie(Guid movieId)
        {
            var movie = dbContext.Movies.FirstOrDefault(a => a.id == movieId);
            if (movie != null)
            {

                dbContext.Movies.Remove(movie);
                dbContext.SaveChanges();
            }
        }

        public void UpdateMovie(Movy updateMovie)
        {

            var existingMovie = dbContext.Movies.FirstOrDefault(a => a.id == updateMovie.id);
            if (existingMovie != null)
            {
                existingMovie.Title = updateMovie.Title;
                dbContext.SaveChanges();
            }

        }
    }
}
