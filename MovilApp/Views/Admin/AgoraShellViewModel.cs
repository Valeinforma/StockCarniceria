using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MovilApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovilApp.ViewModels
{
    public partial class StockCarniceriaModel : ObservableObject
    {
        [ObservableProperty]
        private bool userIsLogged = false;

        public IRelayCommand LogoutCommand { get; }

        public StockCarniceriaModel()
        {
            LogoutCommand = new RelayCommand(OnLogout);
            SetLoginState(false); // Inicialmente no está logueado
        }

        public void SetLoginState(bool isLoggedIn)
        {
            if (Application.Current?.MainPage is AgoraShell shell)
            {
                if (isLoggedIn)
                    shell.FlyoutBehavior = FlyoutBehavior.Flyout;
                else
                    shell.FlyoutBehavior = FlyoutBehavior.Disabled;

                userIsLogged = isLoggedIn;
                if (isLoggedIn)
                    shell.GoToAsync("//MainPage");
                else
                    shell.GoToAsync("//Login");
            }

        }

        private void OnLogout()
        {
            SetLoginState(false);
        }
    }
}