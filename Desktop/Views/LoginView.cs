using Firebase.Auth;
using Firebase.Auth.Providers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Views
{
    public partial class LoginView : Form
    {
        FirebaseAuthClient _firebaseAuthClient;
        int loginFailsCount = 0;
        public LoginView()
        {
            InitializeComponent();
            SettingFirebase();
        }

        private void SettingFirebase()
        {
            var config = new FirebaseAuthConfig()
            {
                ApiKey = Service.Properties.Resources.ApiKeyFirebase,
                AuthDomain = Service.Properties.Resources.AuthDomainFirebase,
                Providers = new FirebaseAuthProvider[]
              {
                    new EmailProvider()
              }
            };
            _firebaseAuthClient = new FirebaseAuthClient(config);
        }

        private async void TxtInisioSesion_Click(object sender, EventArgs e)
        {
            try
            {
                UserCredential userCredential = await _firebaseAuthClient.SignInWithEmailAndPasswordAsync(TxtEmail.Text, TxtPassword.Text);
                if (userCredential != null && !string.IsNullOrEmpty(userCredential.User.Uid))
                {
                    this.Hide();
                    var menuPrincipalView = new MenuPrincipalView();
                    menuPrincipalView.ShowDialog();
                    this.Close();
                }
            }
            catch (FirebaseAuthException ex)
            {
                MessageBox.Show("Error al iniciar sesión. Verifique sus credenciales.");
                loginFailsCount++;
                if (loginFailsCount >= 3)
                {
                    MessageBox.Show("Ha excedido el número máximo de intentos fallidos. La aplicación se cerrará.");
                    this.Close();
                }
            }
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            TxtPassword.PasswordChar = checkBox.Checked ? '\0' : '*';
        }

        private void TxtCerrarSesion_Click(object sender, EventArgs e)
        {
           this.Close();
        }
    }
}
