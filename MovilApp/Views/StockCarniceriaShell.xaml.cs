using MovilApp.ViewModels;
using MovilApp.Views.Login; 

namespace MovilApp.Views;

public partial class StockCarniceriaShell : Shell
{
    // 1. Propiedad ViewModel (Descomentada y Corregida)
    public StockCarniceriaShellViewModel ViewModel => (StockCarniceriaShellViewModel)BindingContext;

    // 2. Constructor (Descomentado y Obligatorio)
    public StockCarniceriaShell()
    {
        InitializeComponent();
    }

    // 3. Método de Estado de Sesión (Descomentado y Esencial)
    public void SetLoginState(bool isLoggedIn)
    {
        // Esto asume que tienes un método SetLoginState en StockCarniceriaShellViewModel
        ViewModel.SetLoginState(isLoggedIn);
    }
}