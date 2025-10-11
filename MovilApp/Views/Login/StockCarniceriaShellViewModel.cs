
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
    public partial class StockCarniceriaShellViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool userIsLogout = true;

        public IRelayCommand LogoutCommand { get; }

        public StockCarniceriaShellViewModel()
        {
            LogoutCommand = new RelayCommand(OnLogout);
        }

        private void OnLogout()
        {
            userIsLogout = true;
            var StockCarniceriaShell = (StockCarniceriaShell)App.Current.MainPage;
            StockCarniceriaShell.DisableAppAfterLogin();
        }
    }
}
