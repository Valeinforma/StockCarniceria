using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using MovilApp.Views;

namespace MovilApp.ViewModels.Login
{
    public partial class LoginViewModel : ObservableObject
    {
        public readonly FirebaseAuthClient _clientAuth;
        private FileUserRepository _userRepository;
        private UserInfo _userInfo;
        private FirebaseCredential _firebaseCredential;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(IniciarSesionCommand))]
        private string email;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(IniciarSesionCommand))]
        private string password;

        [ObservableProperty]
        private bool recordarContraseña;


        public IRelayCommand IniciarSesionCommand { get; }
        public IRelayCommand RegistrarseCommand { get; }

        public LoginViewModel()
        {

            _clientAuth = new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey = Service.Properties.Resources.ApiKeyFirebase,
                AuthDomain = Service.Properties.Resources.AuthDomainFirebase,
                Providers = new Firebase.Auth.Providers.FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            });
            _userRepository = new FileUserRepository("StockCarneMovilApp");
            ChequearSiHayUsuarioAlmacenado();
            IniciarSesionCommand = new RelayCommand(IniciarSesion, PermitirIniciarSesion);
            RegistrarseCommand = new RelayCommand(Registrarse);
        }

        private async void Registrarse()
        {
            await Shell.Current.GoToAsync("Registrarse");
        }

        private async void ChequearSiHayUsuarioAlmacenado()
        {
            if (_userRepository.UserExists())
            {
                (_userInfo, _firebaseCredential) = _userRepository.ReadUser();

                var StockCarniceriaShell = (StockCarniceriaShell)App.Current.MainPage;
                StockCarniceriaShell.EnableAppAfterLogin();
            }
        }

        private bool PermitirIniciarSesion()
        {
            return !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password);
        }

        private async void IniciarSesion()
        {
            try
            {

                var userCredential = await _clientAuth.SignInWithEmailAndPasswordAsync(email, password);
                //if (userCredential.User.Info.IsEmailVerified == false)
                //{
                //    await Application.Current.MainPage.DisplayAlert("Inicios de sesión", "Debe verificar su correo electrónico", "Ok");
                //    return;
                //}

                if (recordarContraseña)
                {
                    _userRepository.SaveUser(userCredential.User);
                }
                else
                {
                    _userRepository.DeleteUser();
                }

                var StockCarniceriaShell = (StockCarniceriaShell)App.Current.MainPage;
                StockCarniceriaShell.EnableAppAfterLogin();

            }
            catch (FirebaseAuthException error)
            {
                await Application.Current.MainPage.DisplayAlert("Inicio de sesión", "Ocurrió un problema:" + error.Reason, "Ok");

            }

        }
    }
}
