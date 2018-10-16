using System;
using System.Linq;
using Autofac;
using FriendStorage.DataAccess;
using FriendStorage.UI.DataProvider;
using FriendStorage.UI.View;
using FriendStorage.UI.ViewModel;

namespace FriendStorage.UI.Startup
{
    public class BootStrapper
    {
        public IContainer BootStrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();

            // Wherever INavigationViewModel is required, it'll use NavigationViewModel instance.
            builder.RegisterType<NavigationViewModel>()
                .As<INavigationViewModel>();

            builder.RegisterType<NavigationDataProvider>()
                .As<INavigationDataProvider>();

            builder.RegisterType<FileDataService>()
                .As<IDataService>();

            return builder.Build();
        }
    }
}
