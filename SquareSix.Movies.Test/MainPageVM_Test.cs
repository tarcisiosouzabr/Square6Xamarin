using Moq;
using Prism.Navigation;
using Prism.Services;
using SquareSix.Movies.Test.MockService;
using SquareSix.Movies.ViewModels;

namespace SquareSix.Movies.Test
{
    public class MainPageVM_Test
    {
        [Fact]
        public void RefreshCommandIsNotNullTest()
        {
            Mock<INavigationService> mockNavigationService = new Mock<INavigationService>();
            Mock<IPageDialogService> mockDialogService = new Mock<IPageDialogService>();
            var mainViewModel = new MainPageViewModel(mockNavigationService.Object, new MoviesMockService(), mockDialogService.Object);

            Assert.NotNull(mainViewModel.RefreshCommand);
        }

        [Fact]
        public void MovieSelectedCommandIsNotNullTest()
        {
            Mock<INavigationService> mockNavigationService = new Mock<INavigationService>();
            Mock<IPageDialogService> mockDialogService = new Mock<IPageDialogService>();
            var mainViewModel = new MainPageViewModel(mockNavigationService.Object, new MoviesMockService(), mockDialogService.Object);

            Assert.NotNull(mainViewModel.MovieSelectedCommand);
        }


        [Fact]
        public void GroupedMoviesIsNotNullTest()
        {
            Mock<INavigationService> mockNavigationService = new Mock<INavigationService>();
            Mock<IPageDialogService> mockDialogService = new Mock<IPageDialogService>();

            var mainViewModel = new MainPageViewModel(mockNavigationService.Object, new MoviesMockService(), mockDialogService.Object);

            Assert.NotNull(mainViewModel.GroupedMovies);
        }

        [Fact]
        public void IsRefreshingPropertyIsFalseWhenViewModelInstantiatedTest()
        {
            Mock<INavigationService> mockNavigationService = new Mock<INavigationService>();
            Mock<IPageDialogService> mockDialogService = new Mock<IPageDialogService>();

            var mainViewModel = new MainPageViewModel(mockNavigationService.Object, new MoviesMockService(), mockDialogService.Object);

            Assert.False(mainViewModel.IsRefreshing);
        }

        [Fact]
        public void GroupedMoviesIsGreaterThanOneAfterNavigationTest()
        {
            Mock<INavigationService> mockNavigationService = new Mock<INavigationService>();
            Mock<INavigationParameters> mockNavParams = new Mock<INavigationParameters>();
            Mock<IPageDialogService> mockDialogService = new Mock<IPageDialogService>();

            var mainViewModel = new MainPageViewModel(mockNavigationService.Object, new MoviesMockService(), mockDialogService.Object);

            mainViewModel.OnNavigatedTo(mockNavParams.Object);

            Assert.True(mainViewModel.GroupedMovies.Count > 1);
        }

        [Fact]
        public void NavigateAfterExecuteMovieSelectedCommandTest()
        {
            Mock<INavigationService> mockNavigationService = new Mock<INavigationService>();
            Mock<INavigationParameters> mockNavParams = new Mock<INavigationParameters>();
            mockNavigationService.Setup(a => a.NavigateAsync(It.IsAny<string>(), It.IsAny<INavigationParameters>(), It.IsAny<bool>(), It.IsAny<bool>()));
            Mock<IPageDialogService> mockDialogService = new Mock<IPageDialogService>();

            var mainViewModel = new MainPageViewModel(mockNavigationService.Object, new MoviesMockService(), mockDialogService.Object);
            mainViewModel.MovieSelectedCommand.Execute(new Api.Responses.Movies { Id = 1 });

            mockNavigationService.Verify(x => x.NavigateAsync(It.IsAny<string>(), It.IsAny<INavigationParameters>(), It.IsAny<bool>(), It.IsAny<bool>()), Times.Once());
        }

    }
}
