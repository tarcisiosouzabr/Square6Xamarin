using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SquareSix.Movies.Models
{
    public class MovieList
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public ObservableCollection<Api.Responses.Movies> Movies { get; set; }
        public MovieList()
        {
            Movies = new ObservableCollection<Api.Responses.Movies>();
        }
    }
}
