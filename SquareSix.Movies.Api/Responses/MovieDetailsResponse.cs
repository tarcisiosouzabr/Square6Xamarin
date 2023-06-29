using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SquareSix.Movies.Api.Responses
{
    public class MovieDetailsResponse
    {
        public bool Adult { get; set; }
        public string Backdrop_path { get; set; }
        public BelongsToCollection Belongs_to_collection { get; set; }
        public int Budget { get; set; }
        public Genre[] Genres { get; set; }
        public string Homepage { get; set; }
        public int Id { get; set; }
        public string Imdb_id { get; set; }
        public string Original_language { get; set; }
        public string Original_title { get; set; }
        public string Overview { get; set; }
        public float Popularity { get; set; }
        public string Poster_path { get; set; }
        public ProductionCompanies[] Production_companies { get; set; }
        public ProductionCountries[] Production_countries { get; set; }
        public string Release_date { get; set; }
        public int Revenue { get; set; }
        public int Runtime { get; set; }
        public SpokenLanguages[] Spoken_languages { get; set; }
        public string Status { get; set; }
        public string Tagline { get; set; }
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

    public class BelongsToCollection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Poster_path { get; set; }
        public string Backdrop_path { get; set; }
    }

    public class ProductionCompanies
    {
        public int Id { get; set; }
        public string Logo_path { get; set; }
        public string Name { get; set; }
        public string Origin_country { get; set; }
    }

    public class ProductionCountries
    {
        public string Iso_3166_1 { get; set; }
        public string Name { get; set; }
    }

    public class SpokenLanguages
    {
        public string English_name { get; set; }
        public string Iso_639_1 { get; set; }
        public string Name { get; set; }
    }

}
