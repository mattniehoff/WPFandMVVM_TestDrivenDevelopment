using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using FriendStorage.Model;
using FriendStorage.UI.Command;
using FriendStorage.UI.DataProvider;
using FriendStorage.UI.Dialogs;
using FriendStorage.UI.Events;
using FriendStorage.UI.Wrapper;
using Prism.Events;

namespace FriendStorage.UI.ViewModel
{
    public interface IFriendEditViewModel
    {
        FriendWrapper Friend { get; }

        void Load(int? friendId);
    }

    public class FriendEditViewModel : ViewModelBase, IFriendEditViewModel
    {
        private IFriendDataProvider _dataProvider;
        IEventAggregator _eventAggregator;
        private FriendWrapper _friend;
        IMessageDialogService _messageDialogService;

        public FriendEditViewModel(IFriendDataProvider dataProvider, IEventAggregator eventAggregator,
            IMessageDialogService messageDialogService)
        {
            _dataProvider = dataProvider;
            _eventAggregator = eventAggregator;
            _messageDialogService = messageDialogService;
            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExectute);
            DeleteCommand = new DelegateCommand(OnDeleteExecute, OnDeleteCanExecute);
        }

        public ICommand DeleteCommand { get; private set; }

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

        public ICommand SaveCommand { get; private set; }

        public void Load(int? friendId)
        {
            var friend = friendId.HasValue
                ? _dataProvider.GetFriendById(friendId.Value)
                : new Friend();
            Friend = new FriendWrapper(friend);

            Friend.PropertyChanged += Friend_PropertyChanged;

            InvalidateCommands();
        }

        private void Friend_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            InvalidateCommands();
        }

        private void InvalidateCommands()
        {
            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
            ((DelegateCommand)DeleteCommand).RaiseCanExecuteChanged();
        }

        private bool OnDeleteCanExecute(object arg)
        {
            return Friend != null && Friend.Id > 0;
        }

        private void OnDeleteExecute(object obj)
        {
            var result = _messageDialogService.ShowYesNoDialog(
                "Delete Friend",
                $"Do you really want to delete the friend '{Friend.FirstName} {Friend.LastName}'?");

            if (result == MessageDialogResult.Yes)
            {
                _dataProvider.DeleteFriend(Friend.Id);
                _eventAggregator.GetEvent<FriendDeletedEvent>().Publish(Friend.Id);
            }
        }

        private bool OnSaveCanExectute(object arg)
        {
            return Friend != null && Friend.IsChanged;
        }

        private void OnSaveExecute(object obj)
        {
            _dataProvider.SaveFriend(Friend.Model);
            Friend.AcceptChanges();
            _eventAggregator.GetEvent<FriendSavedEvent>().Publish(Friend.Model);
        }
    }
}
