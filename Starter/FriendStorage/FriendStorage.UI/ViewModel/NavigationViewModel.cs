﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using FriendStorage.Model;
using FriendStorage.UI.DataProvider;
using FriendStorage.UI.Events;
using Prism.Events;

namespace FriendStorage.UI.ViewModel
{
    public interface INavigationViewModel
    {
        void Load();
    }

    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        private INavigationDataProvider _dataProvider;
        private IEventAggregator _eventAggregator;

        public NavigationViewModel(
                   INavigationDataProvider dataProvider,
                   IEventAggregator eventAggregator)
        {
            Friends = new ObservableCollection<NavigationItemViewModel>();
            _dataProvider = dataProvider;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<FriendSavedEvent>().Subscribe(OnFriendSaved);
            _eventAggregator.GetEvent<FriendDeletedEvent>().Subscribe(OnFriendDeleted);
        }

        public ObservableCollection<NavigationItemViewModel> Friends { get; private set; }

        public void Load()
        {
            Friends.Clear();
            foreach (var friend in _dataProvider.GetAllFriends())
            {
                Friends.Add(new NavigationItemViewModel(friend.Id, friend.DisplayMember, _eventAggregator));
            }
        }

        private void OnFriendDeleted(int friendId)
        {
            var navigationItem = Friends.Single(f => f.Id == friendId);
            Friends.Remove(navigationItem);
        }

        private void OnFriendSaved(Friend friend)
        {
            var displayMember = $"{friend.FirstName} {friend.LastName}";
            var navigationItem = Friends.SingleOrDefault(n => n.Id == friend.Id);
            if (navigationItem != null)
            {
                navigationItem.DisplayMember = displayMember;
            }
            else
            {
                navigationItem = new NavigationItemViewModel(friend.Id, displayMember, _eventAggregator);
                Friends.Add(navigationItem);
            }
        }
    }
}
