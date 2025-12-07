using Desktop.ExtensionMethod;
using Service.Models;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Views
{
    public partial class ProductosView : Form
    {
        // Servicios
        private readonly GenericService<Producto> _productoService = new GenericService<Producto>();
        private readonly GenericService<Categoria> _categoriaService = new GenericService<Categoria>();

        // Variables de Estado
        private Categoria? _currentCategoria;
        private Producto? _currentProducto;
        private List<Producto>? _productos;
        private List<Categoria>? _categorias;

        public ProductosView()
        {
            InitializeComponent();

            // Suscribir eventos
            checkBoxEliminados.CheckedChanged += DisplayHideControlsRestoreButton;
            checkBoxEliminados.CheckedChanged += CheckBoxEliminados_CheckedChanged;

            // Iniciar la carga de datos
            _ = InitializeDataAsync();
        }

        // --- Inicialización y Carga de Datos ---

        private async Task InitializeDataAsync()
        {
            // 1. Cargar la lista de categorías (para el ComboBox)
            await CargarCategoriasAsync();

            // 2. Cargar la lista inicial de productos (activos)
            await GetAllData();
        }

        private async Task CargarCategoriasAsync()
        {
            try
            {
                _categorias = await _categoriaService.GetAllAsync();

                if (_categorias == null)
                {
                    _categorias = new List<Categoria>();
                }

                ComboCategorias.DataSource = _categorias;
                ComboCategorias.DisplayMember = "Nombre";
                ComboCategorias.ValueMember = "Id";

                if (ComboCategorias.Items.Count > 0)
                {
                    ComboCategorias.SelectedIndex = -1;
                }
            }
            catch (Exception ex) // <-- ¡Asegúrate de tener este bloque!
            {
                // Muestra el mensaje de la excepción para ver el detalle de la API.
                MessageBox.Show($"Error al cargar categorías: {ex.Message}", "Error de Conexión/API", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task GetAllData(string? filter = null)
        {
            try
            {
                if (checkBoxEliminados.Checked)
                {
                    _productos = await _productoService.GetAllDeletedAsync();
                }
                else
                {
                    _productos = await _productoService.GetAllAsync(filter);
                }

                ActualizarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarGrid()
        {
            GridData.DataSource = _productos;

            // Ocultar propiedades internas y las propiedades de navegación innecesarias para la edición
            // NOTA: Se deja 'Categoria' visible para mostrar el nombre.
            GridData.HideColumns("Id", "DeleteDate", "IsDeleted", "CategoriaId", "Unidad", "DetallesVenta", "ProveedorId", "Proveedor");

            // Aplicar formato de moneda
            if (GridData.Columns.Contains("PrecioUnitario"))
            {
                GridData.Columns["PrecioUnitario"].HeaderText = "Precio";
                GridData.Columns["PrecioUnitario"].DefaultCellStyle.Format = "C2";
                GridData.Columns["PrecioUnitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // Si el grid contiene la columna Categoria (como objeto de navegación)
            if (GridData.Columns.Contains("Categoria"))
            {
                GridData.Columns["Categoria"].HeaderText = "Categoría";
            }
        }

        // --- Eventos de UI ---

        private void DisplayHideControlsRestoreButton(object? sender, EventArgs e)
        {
            bool isDeletedMode = checkBoxEliminados.Checked;

            BtnRestaurar.Visible = isDeletedMode;
            TxtBuscar.Enabled = !isDeletedMode;
            BtnModificar.Enabled = !isDeletedMode;
            BtnEliminar.Enabled = !isDeletedMode;
            BtnAgregar.Enabled = !isDeletedMode;
            BtnBuscar.Enabled = !isDeletedMode;
        }

        private async void CheckBoxEliminados_CheckedChanged(object sender, EventArgs e)
        {
            await GetAllData();
        }

        private void GridData_SelectionChanged(object sender, EventArgs e)
        {
            // Lógica para mostrar detalles del producto seleccionado, si es necesario
        }

        private void TimerStatusBar_Tick(object sender, EventArgs e)
        {
            LabelStatusMessage.Text = string.Empty;
            TimerStatusBar.Stop();
        }

        private void ComboCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentCategoria = ComboCategorias.SelectedItem as Categoria;
        }

        // --- CRUD y Operaciones ---

        private void LimpiarControlAgregar()
        {
            TxtNombre.Text = string.Empty;
            NumericPrecio.Value = 0;
            NumericStock.Value = 0;
            ComboCategorias.SelectedItem = null;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            LimpiarControlAgregar();
            _currentProducto = new Producto();
            TabControl.SelectedTab = tabPageAgregar_Editar;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            TabControl.SelectedTab = tabPageLista;
            LimpiarControlAgregar();
            _currentProducto = null;
        }

        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            // --- Validaciones ---
            if (_currentProducto == null)
            {
                MessageBox.Show("No se pudo inicializar el objeto Producto para guardar.", "Error interno", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(TxtNombre.Text))
            {
                MessageBox.Show("El nombre del producto es requerido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ComboCategorias.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una categoría.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Mapeo de datos (Transferir valores de los controles al objeto _currentProducto)
            _currentProducto.Nombre = TxtNombre.Text.Trim();
            _currentProducto.PrecioUnitario = NumericPrecio.Value;
            _currentProducto.Stock = (int)NumericStock.Value;
            _currentProducto.Unidad = "kg";

            // 2. Asignar la clave foránea (Foreign Key)
            _currentProducto.CategoriaId = ((Categoria)ComboCategorias.SelectedItem).Id;

            // ** CORRECCIÓN: ANULAR TODAS las propiedades de navegación antes de enviar **
            // Esto es crucial porque el objeto podría contener datos de Proveedor y Categoria 
            // cargados durante la operación de Modificar (por el GridData), y el servidor
            // rechaza esos objetos anidados en el POST/PUT.
            _currentProducto.Categoria = null;
            _currentProducto.Proveedor = null;
            _currentProducto.DetallesVenta = null;

            // 3. Lógica de Guardado (Add o Update)
            bool success = false;
            string action = _currentProducto.Id == 0 ? "agregado" : "modificado";

            try
            {
                if (_currentProducto.Id == 0) // Producto nuevo (ADD)
                {
                    var newProduct = await _productoService.AddAsync(_currentProducto);
                    success = newProduct != null;
                }
                else // Producto existente (UPDATE)
                {
                    success = await _productoService.UpdateAsync(_currentProducto);
                }
            }
            catch (Exception ex)
            {
                // El error de BadRequest se captura aquí
                MessageBox.Show($"Error al guardar el producto: {ex.Message}\n\nDetalles internos: {ex.InnerException?.Message}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4. Post-Proceso 
            if (success)
            {
                LabelStatusMessage.Text = $"Producto {_currentProducto.Nombre} {action} correctamente";
                TimerStatusBar.Start();

                await GetAllData(); // Recargar la lista de productos

                LimpiarControlAgregar();
                TabControl.SelectedTab = tabPageLista;
                _currentProducto = null;
            }
            else
            {
                MessageBox.Show($"Error al guardar el producto. El servicio de datos no indicó éxito.", "Error de Guardado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (GridData.RowCount > 0 && GridData.SelectedRows.Count > 0)
            {
                _currentProducto = (Producto)GridData.SelectedRows[0].DataBoundItem;

                // Mapear a los controles
                TxtNombre.Text = _currentProducto.Nombre;
                NumericPrecio.Value = _currentProducto.PrecioUnitario;
                NumericStock.Value = _currentProducto.Stock;

                // Seleccionar la categoría
                if (_categorias != null && _currentProducto.CategoriaId != 0)
                {
                    var categoriaSeleccionada = _categorias.FirstOrDefault(c => c.Id == _currentProducto.CategoriaId);
                    ComboCategorias.SelectedItem = categoriaSeleccionada;
                }
                else
                {
                    ComboCategorias.SelectedItem = null;
                }

                TabControl.SelectedTab = tabPageAgregar_Editar;
            }
            else
            {
                MessageBox.Show("Debe seleccionar un producto para modificarlo.", "Error de Selección",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (GridData.RowCount > 0 && GridData.SelectedRows.Count > 0)
            {
                Producto entitySelected = (Producto)GridData.SelectedRows[0].DataBoundItem;

                var respuesta = MessageBox.Show($"¿Seguro que quieres eliminar (lógicamente) el Producto: {entitySelected.Nombre}?", "Borrar Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    if (await _productoService.DeleteAsync(entitySelected.Id))
                    {
                        LabelStatusMessage.Text = $"Producto {entitySelected.Nombre} eliminado correctamente";
                        TimerStatusBar.Start();
                        await GetAllData();
                    }
                    else
                    {
                        MessageBox.Show("Error al borrar Producto. Puede que ya esté eliminado.", "Borrar Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay Producto seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnRestaurar_Click(object sender, EventArgs e)
        {
            if (!checkBoxEliminados.Checked) return;

            if (GridData.RowCount > 0 && GridData.SelectedRows.Count > 0)
            {
                Producto entitySelected = (Producto)GridData.SelectedRows[0].DataBoundItem;

                var respuesta = MessageBox.Show($"¿Seguro que quieres recuperar el Producto: {entitySelected.Nombre}?", "Confirmar Restauración", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    if (await _productoService.RestoreAsync(entitySelected.Id))
                    {
                        LabelStatusMessage.Text = $"Producto {entitySelected.Nombre} restaurado correctamente";
                        TimerStatusBar.Start();
                        await GetAllData();
                    }
                    else
                    {
                        MessageBox.Show("Error al restaurar Producto. Puede que ya esté activo.", "Restaurar Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (checkBoxEliminados.Checked)
            {
                MessageBox.Show("La búsqueda no está habilitada en la vista de productos eliminados.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            await GetAllData(TxtBuscar.Text);
        }
    }
}