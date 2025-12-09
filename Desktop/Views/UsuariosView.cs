using Desktop.ExtensionMethod;
using Service.Enum;
using Service.Models;
using Service.Services;
using System.Data;
using System.Linq.Expressions;
using System.Net.Http.Headers;
// Se eliminan los using de Firebase.Auth, Firebase.Auth.Providers

namespace Desktop.Views
{
    public partial class UsuariosView : Form
    {
        GenericService<Usuario> _usuarioService = new();
        Usuario _currentUsuario;
        List<Usuario>? _usuarios; // Usamos _usuarios para consistencia
        // Se elimina FirebaseAuthClient _firebaseAuthClient;

        public UsuariosView()
        {
            InitializeComponent();
            _ = GetAllData();
            // Se elimina SettingFirebase();
            checkVerEliminados.CheckedChanged += DisplayHideControlsRestoreButton;
        }

        // Se elimina SettingFirebase()

        private void DisplayHideControlsRestoreButton(object? sender, EventArgs e)
        {
            BtnRestaurar.Visible = checkVerEliminados.Checked;
            TxtBuscar.Enabled = !checkVerEliminados.Checked;
            BtnModificar.Enabled = !checkVerEliminados.Checked;
            BtnEliminar.Enabled = !checkVerEliminados.Checked;
            BtnAgregar.Enabled = !checkVerEliminados.Checked;
            BtnBuscar.Enabled = !checkVerEliminados.Checked;
        }

        private async Task GetAllData()
        {
            try
            {
                if (checkVerEliminados.Checked)
                    _usuarios = await _usuarioService.GetAllDeletedAsync();
                else
                    _usuarios = await _usuarioService.GetAllAsync();

                DataGrid.DataSource = _usuarios;

                // Cambiar nombres de columnas
                if (DataGrid.Columns.Contains("Id")) 
                {
                    DataGrid.Columns["Id"].Visible = false;
                }
                if (DataGrid.Columns.Contains("IsDeleted")) 
                {
                    DataGrid.Columns["IsDeleted"].Visible = false;
                }
                
                // ✅ CAMBIAR NOMBRES DE COLUMNAS
                if (DataGrid.Columns.Contains("Nombre"))
                {
                    DataGrid.Columns["Nombre"].HeaderText = "Nombre del Usuario";
                }
                
                if (DataGrid.Columns.Contains("tipoUsuarioEnum"))
                {
                    DataGrid.Columns["tipoUsuarioEnum"].HeaderText = "Tipo de Usuario";
                }

                GetComboTiposDeUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetComboTiposDeUsuarios()
        {
            // Cargo el combo de tipos con el enum TipoUsuarioEnum
            ComboTiposDeUsuarios.DataSource = Enum.GetValues(typeof(TipoUsuarioEnum));
        }

        private void GridPeliculas_SelectionChanged_1(object sender, EventArgs e)
        {
            if (DataGrid.RowCount > 0 && DataGrid.SelectedRows.Count > 0)
            {
                // Lógica de selección, si aplica
            }
        }

        private async void BtnEliminar_Click_1(object sender, EventArgs e)
        {
            if (DataGrid.RowCount > 0 && DataGrid.SelectedRows.Count > 0)
            {
                Usuario entitySelected = (Usuario)DataGrid.SelectedRows[0].DataBoundItem;
                var respuesta = MessageBox.Show($"¿Seguro que desea eliminar el usuario {entitySelected.Nombre}?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    if (await _usuarioService.DeleteAsync(entitySelected.Id))
                    {
                        LabelStatusMessage.Text = $"Usuario {entitySelected.Nombre} eliminado correctamente";
                        TimerStatusBar.Start();
                        await GetAllData();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuario a eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            LimpiarControlesAgregarEditar();
            _currentUsuario = null; // Modo Agregar
            TabControl.SelectedTab = TabPageAgregarEditar;
        }

        private void LimpiarControlesAgregarEditar()
        {
            TxtNombre.Clear();
            // Se eliminan TxtDni.Clear(); TxtApellido.Clear(); TxtEmail.Clear();
            // Se eliminan TxtPassword.Clear(); TxtPassword2.Clear();
            GetComboTiposDeUsuarios();
            // Se eliminan LabelPassword.Text, TxtPassword.PlaceholderText, etc. (Si no tienes estos Labels/Textboxes, este código debe borrarse)
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            TabControl.SelectedTab = TabPageLista;
        }

        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!DataControl())
                return;

            Usuario usuarioAGuardar = GetUserDataFromScreen();
            bool responseSuccessfull = false;

            if (_currentUsuario != null)// Modificando un usuario existente
            {
                responseSuccessfull = await _usuarioService.UpdateAsync(usuarioAGuardar);
                // Se elimina lógica de UpdatePasswordInFirebase
            }
            else // Agregando un nuevo usuario
            {
                try
                {
                    var nuevoUsuario = await _usuarioService.AddAsync(usuarioAGuardar);
                    responseSuccessfull = nuevoUsuario != null;
                    // Se elimina lógica de CreateUserInFirebase
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (!responseSuccessfull)
            {
                MessageBox.Show("Error al guardar el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _currentUsuario = null;
            LabelStatusMessage.Text = $"Usuario {usuarioAGuardar.Nombre} guardado correctamente";
            TimerStatusBar.Start();
            await GetAllData();
            LimpiarControlesAgregarEditar();
            TabControl.SelectedTab = TabPageLista;
        }

        // Se elimina CreateUserInFirebase()
        // Se elimina UpdatePasswordInFirebase()

        private Usuario GetUserDataFromScreen()
        {
            return new Usuario
            {
                Id = _currentUsuario?.Id ?? 0,
                Nombre = TxtNombre.Text,
                // Se eliminan Apellido, Dni, Email
                tipoUsuarioEnum = (TipoUsuarioEnum)(ComboTiposDeUsuarios.SelectedItem ?? TipoUsuarioEnum.Cliente)
            };
        }

        private bool DataControl()
        {
            // Solo validación de nombre
            if (string.IsNullOrWhiteSpace(TxtNombre.Text))
            {
                MessageBox.Show("El nombre no puede estar vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Se eliminan todas las validaciones de Apellido, Dni, Email y Contraseñas

            return true;
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (DataGrid.RowCount > 0 && DataGrid.SelectedRows.Count > 0)
            {
                _currentUsuario = (Usuario)DataGrid.SelectedRows[0].DataBoundItem;

                // Carga de datos
                TxtNombre.Text = _currentUsuario.Nombre;
                // Se eliminan Apellido, Dni, Email
                ComboTiposDeUsuarios.SelectedItem = _currentUsuario.tipoUsuarioEnum;

                // Se eliminan configuraciones de Contraseña para Modificar

                TabControl.SelectedTab = TabPageAgregarEditar;
            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuario a modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnBuscar_Click(object sender, EventArgs e)
        {
            DataGrid.DataSource = await _usuarioService.GetAllAsync(TxtBuscar.Text);
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            // Lógica de búsqueda
        }

        private void TimerStatusBar_Tick(object sender, EventArgs e)
        {
            LabelStatusMessage.Text = string.Empty;
            TimerStatusBar.Stop();
        }

        private async void checkVerEliminados_CheckedChanged(object sender, EventArgs e)
        {
            await GetAllData();
        }

        private async void BtnRestaurar_Click(object sender, EventArgs e)
        {
            if (!checkVerEliminados.Checked) return;

            if (DataGrid.RowCount > 0 && DataGrid.SelectedRows.Count > 0)
            {
                Usuario entitySelected = (Usuario)DataGrid.SelectedRows[0].DataBoundItem;
                var respuesta = MessageBox.Show($"¿Seguro que desea restaurar al usuario {entitySelected.Nombre}?", "Confirmar Restauración", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    if (await _usuarioService.RestoreAsync(entitySelected.Id))
                    {
                        LabelStatusMessage.Text = $"Usuario {entitySelected.Nombre} restaurado correctamente";
                        TimerStatusBar.Start();
                        await GetAllData();
                    }
                    else
                    {
                        MessageBox.Show("Error al restaurar el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuario a restaurar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Se elimina SendVerificationEmailAsync()
    }
}