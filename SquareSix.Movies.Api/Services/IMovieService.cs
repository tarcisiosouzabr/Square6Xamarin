using SquareSix.Movies.Api.Responses;
using System.Threading.Tasks;

namespace SquareSix.Movies.Api.Services
{
    public interface IMovieService
    {
        Task<MoviesResponse> GetMoviesAsync();
        Task<GenresResponse> GetGenresAsync();
        Task<MovieDetailsResponse> GetMovieDetails(int id);
    }
}
