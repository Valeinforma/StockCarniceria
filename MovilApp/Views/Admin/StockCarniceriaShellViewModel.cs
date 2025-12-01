using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MovilApp.Views; // Contiene StockCarniceriaShell

namespace MovilApp.ViewModels
{
    // El 'partial' es necesario para la generación automática de comandos y propiedades.
    public partial class StockCarniceriaShellViewModel : ObservableObject
    {
        // 1. PROPIEDAD DE ESTADO (CRÍTICA)
        // [ObservableProperty] genera automáticamente la propiedad pública 'UserIsLogged'.
        // Esto es lo que usa tu XAML (IsEnabled="{Binding UserIsLogged}") para activar/desactivar el menú.
        [ObservableProperty]
        private bool userIsLogged = false;

        // 2. Declaración del Comando: ¡Se elimina la declaración manual IRelayCommand!
        // El atributo [RelayCommand] lo genera automáticamente.
        // public IRelayCommand LogoutCommand { get; }

        public StockCarniceriaShellViewModel()
        {
            // 3. Inicialización: ¡Se elimina la inicialización manual del comando!
            // LogoutCommand = new RelayCommand(OnLogout);

            // La inicialización del estado debe manejarse al cargar el usuario, 
            // no directamente aquí, o se sobrescribirá.
            // SetLoginState(false); // Eliminado, ya está en la declaración de la propiedad
        }

        // 4. MÉTODO DE CONTROL DE ESTADO (Llamado desde LoginViewModel.cs)
        public async void SetLoginState(bool isLoggedIn)
        {
            // Actualiza la propiedad Observable: esto notifica al XAML para habilitar/deshabilitar el menú.
            UserIsLogged = isLoggedIn;

            // 5. NAVEGACIÓN (Movida aquí para asegurar que el estado se refleje)
            // Usamos Shell.Current porque es accesible globalmente después de la inicialización.
            if (isLoggedIn)
            {
                // Navega a la página principal (Home)
                await Shell.Current.GoToAsync("//BuscarProductos");
            }
            else
            {
                // Navega a la página de Login y limpia la pila de navegación
                await Shell.Current.GoToAsync("//Login");
            }
        }

        // 6. COMANDO CERRAR SESIÓN
        [RelayCommand]
        private void OnLogout()
        {
            // Lógica adicional de limpieza de sesión (ej: borrar token/datos de usuario) iría aquí.

            // Llama a SetLoginState para actualizar el estado visual (UserIsLogged = False) y navegar al Login.
            SetLoginState(false);
        }
    }
}