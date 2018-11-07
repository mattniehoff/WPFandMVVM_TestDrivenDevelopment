using FriendStorage.DataAccess;
using FriendStorage.Model;
using FriendStorage.UI.DataProvider;
using System;
using System.Collections.ObjectModel;

namespace FriendStorage.UI.ViewModel
{
    public interface INavigationViewModel
    {
        void Load();
    }

    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {

        private INavigationDataProvider _dataProvider;

        public NavigationViewModel(INavigationDataProvider dataProvider)
        {
            Friends = new ObservableCollection<NavigationItemViewModel>();
            _dataProvider = dataProvider;
        }

        public ObservableCollection<NavigationItemViewModel> Friends { get; private set; }

        public void Load()
        {
            Friends.Clear();
            foreach (var friend in _dataProvider.GetAllFriends())
            {
                Friends.Add(new NavigationItemViewModel(friend.Id, friend.DisplayMember));
            }
        }
    }
}
