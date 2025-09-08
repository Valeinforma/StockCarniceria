using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using Firebase.Auth.Providers;
using System.Net.Http.Headers;

namespace MovilApp.ViewModels.Login
{
    public partial class SigInViewModel : ObservableObject
    {
        private readonly FirebaseAuthClient _clientAuth;
        private readonly string FirebaseApiKey;
        private readonly string RequestUri;

        public IRelayCommand RegistrarseCommand { get; }

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string verifyPassword;

        public SigInViewModel()
        {
            FirebaseApiKey = Service.Properties.Resources.ApiKeyFirebase;
            RequestUri = "https://identitytoolkit.googleapis.com/v1/accounts:sendOobCode?key=" + FirebaseApiKey;
            RegistrarseCommand = new RelayCommand(Registrarse);
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

        private async void Registrarse()
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(verifyPassword))
            {
                await Application.Current.MainPage.DisplayAlert("Registrarse", "Por favor, complete todos los campos.", "Ok");
                return;
            }

            if (password == verifyPassword)
            {
                try
                {
                    var user = await _clientAuth.CreateUserWithEmailAndPasswordAsync(email, password, name);
                    await SendVerificationEmailAsync(user.User.GetIdTokenAsync().Result);
                    await Application.Current.MainPage.DisplayAlert("Registrarse", "Cuenta creada!", "Ok");
                }
                catch (FirebaseAuthException error) // Use alias here 
                {
                    await Application.Current.MainPage.DisplayAlert("Registrarse", "Ocurrió un problema:" + error.Reason, "Ok");

                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Registrarse", "Las contraseñas ingresadas no coinciden", "Ok");
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
