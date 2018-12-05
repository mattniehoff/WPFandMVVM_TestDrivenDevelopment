using System;
using System.Collections.Generic;
using System.Linq;
using FriendStorage.Model;

namespace FriendStorage.UI.DataProvider
{
    public interface INavigationDataProvider
    {
        IEnumerable<LookupItem> GetAllFriends();
    }
}
