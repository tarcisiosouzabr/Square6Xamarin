using SquareSix.Movies.Api.Responses;
using SquareSix.Movies.Api.Services;

namespace SquareSix.Movies.Test.MockService
{
    public class MoviesMockService : IMovieService
    {
        public Task<GenresResponse> GetGenresAsync()
        {
            var genreResponse = new GenresResponse() { 
                Genres = new Genre[] 
                { 
                    new Genre { Id = 1, Name = "Action" },
                    new Genre { Id = 2, Name = "Horror" },
                } 
            };
            return Task.FromResult(genreResponse);
        }

        public Task<MovieDetailsResponse> GetMovieDetails(int id)
        {
            var movieDetailsResponse = new MovieDetailsResponse() { Id = id, Title = "Factor X", Release_date = "01-05-2023", Overview = "Great Movie" };
            return Task.FromResult(movieDetailsResponse);
        }

        public Task<MoviesResponse> GetMoviesAsync()
        {
            var moviesResponse = new MoviesResponse() 
            { 
                Results = new Api.Responses.Movies[] 
                {
                    new Api.Responses.Movies { Id = 1, Title = "Factor X", Poster_path = "fiVW06jE7z9YnO4trhaMEdclSiC.jpg", Genre_ids = new List<int>() { 1 } },
                    new Api.Responses.Movies { Id = 2, Title = "Uma Noite no Cinema", Poster_path = "fiVW06jE7z9YnO4trhaMEdclSiC.jpg", Genre_ids = new List<int>() { 2 } }
                } 
            };
            return Task.FromResult(moviesResponse);
        }
    }
}
