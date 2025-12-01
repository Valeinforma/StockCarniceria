using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using Microsoft.Maui.Storage;
using MovilApp.Views;

namespace MovilApp.ViewModels.Login
{
    // Requerido para usar los métodos como comandos automáticos
    public partial class LoginViewModel : ObservableObject
    {
        public readonly FirebaseAuthClient _clientAuth;
        private FileUserRepository _userRepository;
        private UserInfo _userInfo;
        private FirebaseCredential _firebaseCredential;

        [ObservableProperty]
        // Se mantiene NotifyCanExecuteChangedFor, ahora apuntando al nombre generado automáticamente
        [NotifyCanExecuteChangedFor(nameof(IniciarSesionCommand))]
        private string email;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(IniciarSesionCommand))]
        private string password;

        [ObservableProperty]
        private bool recordarContraseña;

        [ObservableProperty]
        private bool estaDescargando;


        public LoginViewModel()
        {
            _clientAuth = new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                // Asegúrate de que las propiedades de recursos son correctas.
                ApiKey = Service.Properties.Resources.ApiKeyFirebase,
                AuthDomain = Service.Properties.Resources.AuthDomainFirebase,
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            });

            _userRepository = new FileUserRepository("StockCarniceriaMovilApp");
            ChequearSiHayUsuarioAlmacenado();
            // 🛑 SE ELIMINÓ LA INICIALIZACIÓN MANUAL DE COMANDOS 🛑
        }

        // 1. COMANDO DE REGISTRO
        [RelayCommand] // El Source Generator crea public IRelayCommand RegistrarseCommand { get; }
        private async Task Registrarse()
        {
            if (Application.Current?.MainPage is StockCarniceriaShell shell)
            {
                await shell.GoToAsync("//Registrarse");
            }
        }

        private async void ChequearSiHayUsuarioAlmacenado()
        {
            // Solo se chequea en plataformas móviles
            if (DeviceInfo.Platform == DevicePlatform.Android || DeviceInfo.Platform == DevicePlatform.iOS)
            {
                try
                {
                    if (_userRepository.UserExists())
                    {
                        (_userInfo, _firebaseCredential) = _userRepository.ReadUser();

                        if (Application.Current?.MainPage is StockCarniceriaShell shell)
                        {
                            shell.SetLoginState(true);
                            await shell.GoToAsync("//MainPage");
                        }
                    }
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Ocurrió un problema al leer el usuario almacenado: " + ex.Message, "Ok");
                }
            }
        }

        // 2. CONDICIÓN DE COMANDO
        private bool CanIniciarSesion()
        {
            return !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password) && !EstaDescargando;
        }

        // 3. COMANDO DE INICIO DE SESIÓN
        [RelayCommand(CanExecute = nameof(CanIniciarSesion))] // El Source Generator crea public IRelayCommand IniciarSesionCommand { get; }
        private async Task IniciarSesion()
        {
            try
            {
                EstaDescargando = true;

                var userCredential = await _clientAuth.SignInWithEmailAndPasswordAsync(email, password);

                if (userCredential.User.Info.IsEmailVerified == false)
                {
                    await Application.Current.MainPage.DisplayAlert("Inicio de sesión", "Debe verificar su correo electrónico", "Ok");
                    return;
                }

                if (recordarContraseña)
                {
                    _userRepository.SaveUser(userCredential.User);
                }
                else
                {
                    _userRepository.DeleteUser();
                }

                if (Application.Current?.MainPage is StockCarniceriaShell shell)
                {
                    shell.SetLoginState(true);
                }
            }
            catch (FirebaseAuthException error)
            {
                await Application.Current.MainPage.DisplayAlert("Inicio de sesión", "Ocurrió un problema: " + error.Reason, "Ok");
            }
            finally
            {
                EstaDescargando = false;
            }
        }
    }
}