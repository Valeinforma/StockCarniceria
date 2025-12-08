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

            // Ocultar propiedades internas
            GridData.HideColumns("Id", "DeleteDate", "IsDeleted", "CategoriaId", "Unidad", "DetallesVenta", "ProveedorId", "Proveedor", "Categoria");

            // Aplicar formato de moneda
            if (GridData.Columns.Contains("PrecioUnitario"))
            {
                GridData.Columns["PrecioUnitario"].HeaderText = "Precio";
                GridData.Columns["PrecioUnitario"].DefaultCellStyle.Format = "C2";
                GridData.Columns["PrecioUnitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // NUEVA COLUMNA: Mostrar el nombre de la categoría
            if (!GridData.Columns.Contains("NombreCategoria"))
            {
                DataGridViewTextBoxColumn colCategoria = new DataGridViewTextBoxColumn();
                colCategoria.Name = "NombreCategoria";
                colCategoria.HeaderText = "Categoría";
                GridData.Columns.Add(colCategoria);
            }

            // Llenar la columna manualmente con nombres de categorías
            if (_categorias != null && _productos != null)
            {
                for (int i = 0; i < GridData.Rows.Count; i++)
                {
                    var producto = _productos[i];
                    var categoria = _categorias.FirstOrDefault(c => c.Id == producto.CategoriaId);
                    GridData.Rows[i].Cells["NombreCategoria"].Value = categoria?.Nombre ?? "Sin categoría";
                }
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
            _currentProducto = null;  // ← Inicializar como null para indicar que es NUEVO
            TabControl.SelectedTab = tabPageAgregar_Editar;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            _currentProducto = null;  // ← Limpiar estado
            LimpiarControlAgregar();  // ← Agregar esta línea
            TabControl.SelectedTab = tabPageLista;
        }

        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            // --- Validaciones ---
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

            try
            {
                // 1. Crear objeto a guardar
                Producto productoAGuardar = new Producto
                {
                    Id = _currentProducto?.Id ?? 0,
                    Nombre = TxtNombre.Text.Trim(),
                    PrecioUnitario = NumericPrecio.Value,
                    Stock = (int)NumericStock.Value,
                    Unidad = "kg",
                    Categoria = (Categoria)ComboCategorias.SelectedItem,
                    CategoriaId = ((Categoria)ComboCategorias.SelectedItem).Id,
                    ProveedorId = 1,
                    Proveedor = new Proveedor { Id = 1 },
                    DetallesVenta = null
                };

                bool success = false;
                string action = _currentProducto?.Id > 0 ? "modificado" : "agregado";

                // 2. Guardar según sea crear o actualizar
                if (_currentProducto?.Id > 0)
                {
                    // ✅ ACTUALIZAR producto existente
                    success = await _productoService.UpdateAsync(productoAGuardar);
                }
                else
                {
                    // ✅ CREAR nuevo producto
                    var newProduct = await _productoService.AddAsync(productoAGuardar);
                    success = newProduct != null;
                }

                // 3. Resultado
                if (success)
                {
                    _currentProducto = null;
                    LabelStatusMessage.Text = $"Producto '{productoAGuardar.Nombre}' {action} correctamente";
                    TimerStatusBar.Start();
                    await GetAllData();
                    LimpiarControlAgregar();
                    TabControl.SelectedTab = tabPageLista;
                }
                else
                {
                    MessageBox.Show("Error al guardar el producto. El servicio de datos no indicó éxito.", "Error de Guardado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el producto: {ex.Message}\n\nDetalles internos: {ex.InnerException?.Message}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
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