using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SquareSix.Movies.Api.Responses;
using SquareSix.Movies.Api.Services;
using SquareSix.Movies.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareSix.Movies.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public ObservableCollection<MovieList> GroupedMovies { get; set; }

        private List<Api.Responses.Movies> Movies { get; set; }
        private List<Api.Responses.Genre> Genres { get; set; }

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { SetProperty(ref _isRefreshing, value); }
        }

        public DelegateCommand RefreshCommand { get; private set; }
        public DelegateCommand<Api.Responses.Movies> MovieSelectedCommand { get; private set; }

        private readonly IMovieService _movieService;
        public MainPageViewModel(INavigationService navigationService, IMovieService movieService)
            : base(navigationService)
        {
            _movieService = movieService;
            Movies = new List<Api.Responses.Movies>();
            Genres = new List<Genre>();
            GroupedMovies = new ObservableCollection<MovieList>();
            RefreshCommand = new DelegateCommand(async () => await Refresh());
            MovieSelectedCommand = new DelegateCommand<Api.Responses.Movies>(async (movie) => await GetMovieDetails(movie));
        }

        private async Task GetMoviesAsync()
        {
            try
            {
                var movies = await _movieService.GetMoviesAsync();
                foreach (var item in movies.Results)
                {
                    Movies.Add(item);
                }
                await GetGenresAsync();
                var groupedList = GroupMoviesByGenre();
                foreach (var item in groupedList)
                {
                    GroupedMovies.Add(item);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private async Task GetGenresAsync()
        {
            try
            {
                var movies = await _movieService.GetGenresAsync();
                foreach (var item in movies.Genres)
                {
                    Genres.Add(item);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private List<MovieList> GroupMoviesByGenre()
        {
            List<MovieList> groupedList = new List<MovieList>();
            if (Movies.Count > 0)
            {
                var groupedMovies = Movies.GroupBy(x => x.Genre_ids.First())
                    .Select(y => new MovieList
                    {
                        GenreId = y.Key,
                        GenreName = Genres.Where(g => g.Id == y.Key).Select(z => z.Name).FirstOrDefault(),
                        Movies = new ObservableCollection<Api.Responses.Movies>(y.ToList())
                    }).ToList();
                groupedList = new List<MovieList>(groupedMovies);
            }
            return groupedList;
        }

        private async Task Refresh()
        {
            try
            {
                IsRefreshing = true;
                GroupedMovies.Clear();
                await GetMoviesAsync();
            }
            finally
            {
                IsRefreshing = false;
            }
        }

        private async Task GetMovieDetails(Api.Responses.Movies movie)
        {
            if(movie != null)
            {
                var navParams = new NavigationParameters
                {
                    { "movieId", JsonConvert.SerializeObject(movie.Id) }
                };
                await NavigationService.NavigateAsync("MovieDetails", navParams, true);
            }
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            GetMoviesAsync();
        }
    }
}
