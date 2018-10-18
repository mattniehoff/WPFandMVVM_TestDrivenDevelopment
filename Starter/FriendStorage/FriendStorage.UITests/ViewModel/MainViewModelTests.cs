using System;
using System.Linq;
using FriendStorage.UI.ViewModel;
using Moq;
using Xunit;

namespace FriendStorage.UITests.ViewModel
{
    public class MainViewModelTests
    {
        Mock<INavigationViewModel> navigationViewModelMock;
        private MainViewModel viewModel;

        public MainViewModelTests()
        {
            navigationViewModelMock = new Mock<INavigationViewModel>();
            viewModel = new MainViewModel(navigationViewModelMock.Object);
        }

        [Fact]
        public void ShouldCallTheLoadMethodOfTheNavigationViewModel()
        {
            viewModel.Load();

            // Mock that verifies a method is called once.
            navigationViewModelMock.Verify(vm => vm.Load(), Times.Once);
        }
    }
}
