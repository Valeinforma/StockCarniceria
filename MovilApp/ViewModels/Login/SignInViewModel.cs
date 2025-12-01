using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Requests;
using MovilApp.Views;
using Service.Enum;
using Service.Models; // Asegúrate de que apunta a tu clase Usuarios
using Service.Services;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace MovilApp.ViewModels.Login
{
    public partial class SignInViewModel : ObservableObject
    {
        // 1. SERVICIOS Y DEPENDENCIAS 🛠️
        private readonly FirebaseAuthClient _clientAuth;
        // Se usa GenericService<Usuarios> para coincidir con tu modelo
        GenericService<Usuario> _usuarioService = new();
        private readonly string FirebaseApiKey;
        private readonly string RequestUri;

        // 2. COMANDOS ⚡
        public IRelayCommand RegistrarseCommand { get; }
        public IRelayCommand VolverCommand { get; }

        // 3. PROPIEDADES OBSERVABLES ✨

        // **Modificación:** Eliminadas Lastname y Dni del modelo

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(RegistrarseCommand))]
        private string name;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(RegistrarseCommand))]
        private string email;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(RegistrarseCommand))]
        private string password;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(RegistrarseCommand))]
        private string verifyPassword;

        // 4. CONSTRUCTOR 🏗️
        public SignInViewModel()
        {
            FirebaseApiKey = Service.Properties.Resources.ApiKeyFirebase;
            RequestUri = "https://identitytoolkit.googleapis.com/v1/accounts:sendOobCode?key=" + FirebaseApiKey;

            RegistrarseCommand = new AsyncRelayCommand(Registrarse, PermitirRegistrarse);
            VolverCommand = new AsyncRelayCommand(Volver);

            _clientAuth = new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey = FirebaseApiKey,
                AuthDomain = Service.Properties.Resources.AuthDomainFirebase,
                Providers = new Firebase.Auth.Providers.FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            });
        }

        // 5. MÉTODOS DE LÓGICA 🧠

        private bool PermitirRegistrarse()
        {
            // **Modificación:** Solo se validan campos existentes
            return !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(Email)
                && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(VerifyPassword);
        }

        private async Task Volver()
        {
            // Asumo que tu Shell se llama StockCarniceriaShell
            if (Application.Current?.MainPage is StockCarniceriaShell shell)
            {
                await shell.GoToAsync("//Login");
            }
        }

        private async Task Registrarse()
        {
            if (password != verifyPassword)
            {
                await Application.Current.MainPage.DisplayAlert("Registrarse", "Las contraseñas ingresadas no coinciden", "Ok");
                return;
            }

            try
            {
                // 1. Crear usuario en Firebase
                // Se usa el nombre del usuario como DisplayName
                var user = await _clientAuth.CreateUserWithEmailAndPasswordAsync(email, password, name);

                // 2. Guardar el usuario en la base de datos/servicio local
                var nuevoUsuario = new Usuario // Usando tu clase 'Usuarios'
                {
                    Nombre = name,
                    // Se usa la propiedad de tu modelo: 'tipoUsuarioEnum'
                    tipoUsuarioEnum = TipoUsuarioEnum.Cliente,
                    IsDeleted = false
                    // Los campos Id y Email se manejarán en la capa de servicio/base de datos
                };

                // Usando GenericService<Usuarios>
                var usuarioCreado = await _usuarioService.AddAsync(nuevoUsuario);

                // 3. Enviar correo de verificación de Firebase
                await SendVerificationEmailAsync(user.User.GetIdTokenAsync().Result);

                await Application.Current.MainPage.DisplayAlert("Registrarse", "Cuenta creada! Se ha enviado un correo de verificación.", "Ok");

                // 4. Navegar de vuelta al Login
                if (Application.Current?.MainPage is StockCarniceriaShell shell)
                {
                    await shell.GoToAsync("//Login");
                }
            }
            catch (FirebaseAuthException error)
            {
                await Application.Current.MainPage.DisplayAlert("Registrarse", "Ocurrió un problema: " + error.Reason, "Ok");
            }
        }

        public async Task SendVerificationEmailAsync(string idToken)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var content = new StringContent("{\"requestType\":\"VERIFY_EMAIL\",\"idToken\":\"" + idToken + "\"}");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await client.PostAsync(RequestUri, content);
                response.EnsureSuccessStatusCode();
            }
        }
    }
}