using Newtonsoft.Json;
using SquareSix.Movies.Api.Responses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SquareSix.Movies.Api.Services
{
    public interface IMovieService
    {
        Task<MoviesResponse> GetMoviesAsync();
        Task<GenresResponse> GetGenresAsync();
        Task<MovieDetailsResponse> GetMovieDetails(int id);
    }
    public class MovieApiService : IMovieService
    {


        public async Task<GenresResponse> GetGenresAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var httpResponse = await httpClient.GetAsync($"{ApiConstants.ApiUrl}3/genre/movie/list?api_key={ApiConstants.ApiKey}");
                httpResponse.EnsureSuccessStatusCode();
                var stringContent = await httpResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<GenresResponse>(stringContent);
            }
        }

        public async Task<MovieDetailsResponse> GetMovieDetails(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var httpResponse = await httpClient.GetAsync($"{ApiConstants.ApiUrl}3/movie/{id}?api_key={ApiConstants.ApiKey}");
                httpResponse.EnsureSuccessStatusCode();
                var stringContent = await httpResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<MovieDetailsResponse>(stringContent);
            }
        }

        public async Task<MoviesResponse> GetMoviesAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var httpResponse = await httpClient.GetAsync($"{ApiConstants.ApiUrl}3/discover/movie?api_key={ApiConstants.ApiKey}&sort_by=popularity.desc");
                httpResponse.EnsureSuccessStatusCode();
                var stringContent = await httpResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<MoviesResponse>(stringContent);
            }
        }
    }
}
