using System;
using System.Linq;
using FriendStorage.UI.ViewModel;
using Xunit;

namespace FriendStorage.UITests.ViewModel
{
    public class NavigationViewModelTests
    {
        [Fact]
        public void ShouldLoadFriends()
        {
            var viewModel = new NavigationViewModel();

            viewModel.Load();

            // TODO: how do we figure out how to test this? example: get value to test without accessing file/web service.
            // Assert.Equal(2, viewModel.Friends.Count);
        }
    }
}
