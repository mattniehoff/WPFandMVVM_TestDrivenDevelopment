using FriendStorage.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FriendStorage.UITests.ViewModel
{ 
    public class MainViewModelTests
    {
        [Fact]
        public void ShouldCallTheLoadMethodOfTheNavigationViewModel()
        {
            var navigationViewModel = new NavigationViewModelMock();
            var viewModel = new MainViewModel(navigationViewModel);

            viewModel.Load();

            // How to assert load of navigation viewmodel has been called?
            Assert.True(navigationViewModel.LoadHasBeenCalled);
        }
    }

    public class NavigationViewModelMock : INavigationViewModel
    {
        public bool LoadHasBeenCalled { get; set; }
        public void Load()
        {
            LoadHasBeenCalled = true;
        }
    }
}
