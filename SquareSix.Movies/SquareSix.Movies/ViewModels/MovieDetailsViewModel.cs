using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SquareSix.Movies.Api.Responses;
using SquareSix.Movies.Api.Services;
using SquareSix.Movies.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SquareSix.Movies.ViewModels
{
    public class MovieDetailsViewModel : ViewModelBase, INavigatedAware
    {
        private string _movieTitle;
        public string MovieTitle
        {
            get { return _movieTitle; }
            set { SetProperty(ref _movieTitle, value); }
        }

        private string _image;
        public string Image
        {
            get { return _image; }
            set { SetProperty(ref _image, value); }
        }

        private DateTime _releaseDate;
        public DateTime ReleaseDate
        {
            get { return _releaseDate; }
            set { SetProperty(ref _releaseDate, value); }
        }

        private int _voteCount;
        public int VoteCount
        {
            get { return _voteCount; }
            set { SetProperty(ref _voteCount, value); }
        }

        private string _overview;
        public string Overview
        {
            get { return  _overview; }
            set { SetProperty(ref  _overview, value); }
        }

        private int _rating;
        public int Rating
        {
            get { return _rating; }
            set { SetProperty(ref _rating, value); }
        }

        public DelegateCommand GoBackCommand { get; set; }
        public DelegateCommand OpenTrailerCommand { get; set; }

        private readonly IMovieService _movieService;
        private MovieDetailsResponse _movieDetail;
        public MovieDetailsViewModel(IMovieService movieService, INavigationService navigationService) : base (navigationService) 
        {
            _movieService = movieService;
            GoBackCommand = new DelegateCommand(async () => await GoBackAsync());
            OpenTrailerCommand = new DelegateCommand(async ()=> await OpenTrailer());
        }

        private async Task GetMovieDetails(int movieId)
        {
            try
            {
                var movieDetail = await _movieService.GetMovieDetails(movieId);
                if(movieDetail != null)
                {
                    FillMovieProperties(movieDetail);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void FillMovieProperties(MovieDetailsResponse movieDetail)
        {
            _movieDetail = movieDetail;
            MovieTitle = movieDetail.Title;
            Image = movieDetail.PosterImg;
            DateTime releasedDate = new DateTime();
            DateTime.TryParse(movieDetail.Release_date, System.Globalization.CultureInfo.GetCultureInfo("en-US"),
            System.Globalization.DateTimeStyles.None, out releasedDate);
            ReleaseDate = releasedDate;
            VoteCount = movieDetail.Vote_count;
            Overview = movieDetail.Overview;
            Rating = (int)Math.Abs(movieDetail.Vote_average / 2f);
        }

        private async Task GoBackAsync()
        {
            await NavigationService.GoBackAsync();
        }

        private async Task OpenTrailer()
        {
            await Launcher.OpenAsync(new Uri(_movieDetail.Homepage));
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("movieId"))
            {
                int movieId = parameters.GetValue<int>("movieId");
                GetMovieDetails(movieId);
            }
        }
    }
}
