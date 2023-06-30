using Newtonsoft.Json;
using SquareSix.Movies.Api.Responses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SquareSix.Movies.Api.Services
{
    public class MovieApiService : IMovieService
    {
        private async Task<T> GetAsync<T>(string url) where T : class
        {
            using (var httpClient = new HttpClient())
            {
                var httpResponse = await httpClient.GetAsync(url);
                httpResponse.EnsureSuccessStatusCode();
                var stringContent = await httpResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(stringContent);
            }
        }

        public async Task<GenresResponse> GetGenresAsync()
        {
            return await GetAsync<GenresResponse>($"{ApiConstants.ApiUrl}3/genre/movie/list?api_key={ApiConstants.ApiKey}");
        }

        public async Task<MovieDetailsResponse> GetMovieDetails(int id)
        {
            return await GetAsync<MovieDetailsResponse>($"{ApiConstants.ApiUrl}3/movie/{id}?api_key={ApiConstants.ApiKey}");
        }

        public async Task<MoviesResponse> GetMoviesAsync()
        {
            return await GetAsync<MoviesResponse>($"{ApiConstants.ApiUrl}3/discover/movie?api_key={ApiConstants.ApiKey}&sort_by=popularity.desc");
        }
    }
}
