using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SquareSix.Movies.Api.Responses
{
    public class MoviesResponse
    {
        public int Page { get; set; }
        public Movies[] Results { get; set; }
        public int Total_pages { get; set; }
        public int Total_results { get; set; }
    }

    public class Movies
    {
        public bool Adult { get; set; }
        public string Backdrop_path { get; set; }
        public List<int> Genre_ids { get; set; }
        public int Id { get; set; }
        public string Original_language { get; set; }
        public string Original_title { get; set; }
        public string Overview { get; set; }
        public float Popularity { get; set; }
        public string Poster_path { get; set; }
        public string Release_date { get; set; }
        public string Title { get; set; }
        public bool Video { get; set; }
        public float Vote_average { get; set; }
        public int Vote_count { get; set; }

        [JsonIgnore]
        public string PosterImg
        {
            get
            {
                return $"{ApiConstants.ImageUrl}{Poster_path}";
            }
        }
    }

}
