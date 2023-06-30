using Moq;
using Prism.Navigation;
using Prism.Services;
using SquareSix.Movies.Test.MockService;
using SquareSix.Movies.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareSix.Movies.Test
{
    public class MovieDetailsVM_Test
    {
        [Fact]
        public void GoBackCommandIsNotNullTest()
        {
            Mock<INavigationService> mockNavigationService = new Mock<INavigationService>();
            Mock<IPageDialogService> mockDialogService = new Mock<IPageDialogService>();

            var mainViewModel = new MovieDetailsViewModel(new MoviesMockService(), mockNavigationService.Object, mockDialogService.Object);

            Assert.NotNull(mainViewModel.GoBackCommand);
        }

        [Fact]
        public void OpenTrailerCommandIsNotNullTest()
        {
            Mock<INavigationService> mockNavigationService = new Mock<INavigationService>();
            Mock<IPageDialogService> mockDialogService = new Mock<IPageDialogService>();

            var mainViewModel = new MovieDetailsViewModel(new MoviesMockService(), mockNavigationService.Object, mockDialogService.Object);

            Assert.NotNull(mainViewModel.OpenTrailerCommand);
        }

        [Fact]
        public void ShoudlFillTitleAfterNavigateTest()
        {
            Mock<IPageDialogService> mockDialogService = new Mock<IPageDialogService>();
            Mock<INavigationService> mockNavigationService = new Mock<INavigationService>();
            var mainViewModel = new MovieDetailsViewModel(new MoviesMockService(), mockNavigationService.Object, mockDialogService.Object);

            mainViewModel.OnNavigatedTo(new NavigationParameters() { { "movieId", 1 } });

            Assert.Equal("Factor X", mainViewModel.MovieTitle);
        }
    }
}
