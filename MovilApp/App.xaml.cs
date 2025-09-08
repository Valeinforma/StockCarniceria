using MovilApp.Views;

namespace MovilApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new StockCarniceriaShell();
        }
    }
}
