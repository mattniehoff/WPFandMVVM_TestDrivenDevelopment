using FriendStorage.Model;
using FriendStorage.UI.DataProvider;
using System;

namespace FriendStorage.UI.ViewModel
{
    public interface IFriendEditViewModel
    {
        void Load(int friendId);
        Friend Friend { get; }

    }

    public class FriendEditViewModel : ViewModelBase, IFriendEditViewModel
    {
        private IFriendDataProvider @object;

        public FriendEditViewModel(IFriendDataProvider @object)
        {
            this.@object = @object;
        }

        public Friend Friend
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Load(int friendId)
        {
            throw new NotImplementedException();
        }

    }
}
