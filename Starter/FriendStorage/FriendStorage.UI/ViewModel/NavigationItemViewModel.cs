using System;
using System.Linq;
using System.Windows.Input;
using FriendStorage.UI.Command;
using Prism.Events;

namespace FriendStorage.UI.ViewModel
{
    public class NavigationItemViewModel
    {
        public NavigationItemViewModel(int id, string displayMember, IEventAggregator eventAggregator)
        {
            Id = id;
            DisplayMember = displayMember;
            OpenFriendEditViewCommand = new DelegateCommand(OnFriendEditViewExecute);
        }

        public string DisplayMember { get; private set; }

        public int Id { get; private set; }

        public ICommand OpenFriendEditViewCommand { get; private set; }

        void OnFriendEditViewExecute(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
