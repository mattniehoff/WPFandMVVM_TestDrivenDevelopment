using FriendStorage.UI.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FriendStorage.UI.ViewModel
{
    public class NavigationItemViewModel
    {
        public NavigationItemViewModel(int id, string displayMember)
        {
            Id = id;
            DisplayMember = displayMember;
            OpenFriendEditViewCommand = new DelegateCommand(OnFriendEditViewExecute);
        }

        void OnFriendEditViewExecute(object obj)
        {
            throw new NotImplementedException();
        }

        public int Id { get; private set; }
        public string DisplayMember { get; private set; }
        public ICommand OpenFriendEditViewCommand { get; private set; }

    }
}
