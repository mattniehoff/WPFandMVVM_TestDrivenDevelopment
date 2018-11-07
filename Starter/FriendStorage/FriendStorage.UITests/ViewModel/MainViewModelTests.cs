using System;
using System.Collections.Generic;
using System.Linq;
using FriendStorage.UI.Events;
using FriendStorage.UI.ViewModel;
using Moq;
using Prism.Events;
using Xunit;

namespace FriendStorage.UITests.ViewModel
{
    public class MainViewModelTests
    {
        private Mock<IEventAggregator> _eventAggregatorMock;
        private List<Mock<IFriendEditViewModel>> _friendEditViewModelMocks;
        private Mock<INavigationViewModel> _navigationViewModelMock;
        private OpenFriendEditViewEvent _openFriendEditViewEvent;
        private MainViewModel _viewModel;

        public MainViewModelTests()
        {
            _friendEditViewModelMocks = new List<Mock<IFriendEditViewModel>>();
            _navigationViewModelMock = new Mock<INavigationViewModel>();

            _openFriendEditViewEvent = new OpenFriendEditViewEvent();
            _eventAggregatorMock = new Mock<IEventAggregator>();
            _eventAggregatorMock.Setup(ea => ea.GetEvent<OpenFriendEditViewEvent>())
            .Returns(_openFriendEditViewEvent);


            _viewModel = new MainViewModel(
                             _navigationViewModelMock.Object,
                             CreateFriendEditViewModel,
                             _eventAggregatorMock.Object);
        }

        [Fact]
        public void ShouldAddFriendEditViewModelAndLoadAndSelectIt()
        {
            const int friendId = 7;
            _openFriendEditViewEvent.Publish(friendId);

            Assert.Equal(1, _viewModel.FriendEditViewModels.Count);
            var friendEditVm = _viewModel.FriendEditViewModels.First();
            Assert.Equal(friendEditVm, _viewModel.SelectedFriendEditViewModel);

            _friendEditViewModelMocks.First().Verify(vm => vm.Load(friendId), Times.Once);
        }

        [Fact]
        public void ShouldCallTheLoadMethodOfTheNavigationViewModel()
        {
            _viewModel.Load();

            // Mock that verifies a method is called once.
            _navigationViewModelMock.Verify(vm => vm.Load(), Times.Once);
        }

        IFriendEditViewModel CreateFriendEditViewModel()
        {
            var friendEditViewModelMock = new Mock<IFriendEditViewModel>();
            _friendEditViewModelMocks.Add(friendEditViewModelMock);
            return friendEditViewModelMock.Object;
        }
    }
}
