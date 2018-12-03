using System;
using System.Windows.Input;
using FriendStorage.Model;
using FriendStorage.UI.Command;
using FriendStorage.UI.DataProvider;
using FriendStorage.UI.Wrapper;

namespace FriendStorage.UI.ViewModel
{
    public interface IFriendEditViewModel
    {
        FriendWrapper Friend { get; }

        void Load(int friendId);
    }

    public class FriendEditViewModel : ViewModelBase, IFriendEditViewModel
    {
        private IFriendDataProvider _dataProvider;
        private FriendWrapper _friend;

        public ICommand SaveCommand { get; private set; }

        public FriendEditViewModel(IFriendDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExectute);
        }

        public FriendWrapper Friend
        {
            get
            {
                return _friend;
            }
            private set
            {
                _friend = value;
                OnPropertyChanged();
            }
        }

        public void Load(int friendId)
        {
            var friend = _dataProvider.GetFriendById(friendId);
            Friend = new FriendWrapper(friend);
        }

        private void OnSaveExecute(object obj)
        {
            throw new NotImplementedException();
        }

        private bool OnSaveCanExectute(object arg)
        {
            return Friend != null && Friend.IsChanged;
        }
    }
}
