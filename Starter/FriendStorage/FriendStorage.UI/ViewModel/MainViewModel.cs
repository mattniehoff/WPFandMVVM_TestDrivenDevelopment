using System;
using System.Collections.ObjectModel;
using FriendStorage.DataAccess;
using FriendStorage.UI.DataProvider;
using FriendStorage.UI.Events;
using Prism.Events;

namespace FriendStorage.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private Func<IFriendEditViewModel> _friendEditVmCreator;

        private IFriendEditViewModel _selectedFriendEditViewModel;

        public MainViewModel(
            INavigationViewModel navigationViewModel,
            Func<IFriendEditViewModel> friendEditVmCreator,
            IEventAggregator eventAggregator)
        {
            NavigationViewModel = navigationViewModel;
            FriendEditViewModels = new ObservableCollection<IFriendEditViewModel>();
            _friendEditVmCreator = friendEditVmCreator;
            eventAggregator.GetEvent<OpenFriendEditViewEvent>().Subscribe(OnOpenFriendEditView);
        }

        public ObservableCollection<IFriendEditViewModel> FriendEditViewModels { get; private set; }

        public INavigationViewModel NavigationViewModel { get; private set; }
        public IFriendEditViewModel SelectedFriendEditViewModel
        {
            get
            {
                return _selectedFriendEditViewModel;
            }

            set
            {
                _selectedFriendEditViewModel = value;
            }
        }

        public void Load()
        {
            NavigationViewModel.Load();
        }

        public void OnOpenFriendEditView(int friendId)
        {
            var friendEditVm = _friendEditVmCreator();
            FriendEditViewModels.Add(friendEditVm);
            friendEditVm.Load(friendId);
            SelectedFriendEditViewModel = friendEditVm;
        }
    }
}
