using MovieManagement.DataAccess;
using MovieManagement.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Management
{
    public class MovieManagement
    {
        private MovieRepository _repo = new MovieRepository();
        public List<MovieDTO> Search()
        {
            var result = _repo.SearchMovies();
            var toReturn = result.Select(a => new MovieDTO
            {
                Id = a.id,
                AverageScore = (float)a.AverageScore,
                CategoryName = a.Category.name,
                Length = a.Length,
                Rating = a.Rating,
                ReleaseDate = a.ReleaseDate,
                Title = a.Title
            }).ToList();

            return toReturn;
        }

        public MovieDTO GetMovie(Guid id)
        {
            var repoResult = _repo.GetMovies(id);
            return new MovieDTO
            {
                Id = repoResult.id,
                AverageScore = (float)repoResult.AverageScore,
                CategoryName = repoResult.Category.name,
                Length = repoResult.Length,
                Rating = repoResult.Rating,
                ReleaseDate = repoResult.ReleaseDate,
                Title = repoResult.Title
            };

        }

        public void DeleteMovie(Guid id)
        {
            _repo.DeleteMovie(id);
        }

        public void AddOrUpdate (MovieDTO movie)
        {

            var movy = new Movy
            {
                id = movie.Id!=Guid.Empty ? movie.Id : Guid.NewGuid(), //checking if passed movie object ID already exists, if not then we create a new ID.
                Title = movie.Title,
                ReleaseDate = movie.ReleaseDate,
                AverageScore = movie.AverageScore,
                Length = movie.Length,
                Rating = movie.Rating,
            };

            //category needs to be set differently. If we have something in our MovieDTO model (movie), we need to search category table for the name and get the ID of the category in order to assign it to the object.

            if (!string.IsNullOrEmpty(movie.CategoryName))
            {
                var categoryRepo = new CategoryRepository();
                var existingCategory = categoryRepo.GetCategoryByName(movie.CategoryName);
                if (existingCategory != null)
                {
                    movy.CategoryID = existingCategory.id;
                }
            }


            if (movie.Id != Guid.Empty)
            {
                //movie exists => update
                _repo.UpdateMovie(movy);
            }
            else
            {
                //movie doesn't exist => add
                _repo.AddMovie(movy);
            }

        }

    }
}
