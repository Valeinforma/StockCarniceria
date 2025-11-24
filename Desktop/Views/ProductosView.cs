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

        // Variables de Estado (usando Nullable Reference Types, si están habilitados)
        private Categoria? _currentCategoria;
        private Producto? _currentProducto;
        private List<Producto>? _productos;
        private List<Categoria>? _categorias;

        public ProductosView()
        {
            InitializeComponent();

            // Suscribir eventos una sola vez
            checkBoxEliminados.CheckedChanged += DisplayHideControlsRestoreButton;
            checkBoxEliminados.CheckedChanged += CheckBoxEliminados_CheckedChangedAsync;

            // Iniciar la carga de datos al abrir la vista
            _ = InitializeDataAsync();
        }

        // --- Inicialización y Carga de Datos ---

        private async Task InitializeDataAsync()
        {
            // 1. Cargar la lista de categorías (necesario para el ComboBox)
            await CargarCategoriasAsync();

            // 2. Cargar la lista inicial de productos (activos)
            await CargarProductosAsync();
        }

        private async Task CargarCategoriasAsync()
        {
            try
            {
                // El servicio obtiene todas las categorías activas
                _categorias = await _categoriaService.GetAllAsync();

                if (_categorias == null || !_categorias.Any())
                {
                    MessageBox.Show("No se pudieron cargar las categorías.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Configurar ComboBox
                ComboCategorias.DataSource = _categorias;
                ComboCategorias.DisplayMember = "Nombre";
                ComboCategorias.ValueMember = "Id";
                ComboCategorias.SelectedItem = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar categorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CargarProductosAsync(string? filter = null)
        {
            try
            {
                if (checkBoxEliminados.Checked)
                {
                    // Usa el nuevo endpoint: GET api/Productos/deleteds
                    _productos = await _productoService.GetAllDeletedAsync();
                }
                else
                {
                    // Usa el endpoint: GET api/Productos?filter={filter}
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

            // Ocultar propiedades internas y la propiedad de navegación que ahora debería ser un DTO o estar ignorada.
            // Si el backend retorna un DTO (objeto anónimo), "Categoria" será "CategoriaNombre".
            // Si retorna el modelo Producto, ocultamos "Categoria".
            GridData.HideColumns("Id", "DeleteDate", "IsDeleted", "CategoriaId", "Unidad", "Categoria");

            // Aplicar formato de moneda
            if (GridData.Columns.Contains("Precio"))
            {
                GridData.Columns["Precio"].DefaultCellStyle.Format = "C2";
                GridData.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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

        private async void CheckBoxEliminados_CheckedChangedAsync(object? sender, EventArgs e)
        {
            // Recarga el listado de productos usando el modo (Activo/Eliminado)
            await CargarProductosAsync();
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
            // Opcional: Mantener la referencia a la categoría seleccionada
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
            if (_currentProducto == null || ComboCategorias.SelectedItem == null)
            {
                MessageBox.Show("Debe completar todos los campos requeridos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Mapeo de datos
            _currentProducto.Nombre = TxtNombre.Text;
            _currentProducto.Precio = (int)NumericPrecio.Value;
            _currentProducto.Stock = (int)NumericStock.Value;

            // 2. Asignar solo el ID de la categoría (Lo que el backend espera)
            _currentProducto.CategoriaId = ((Categoria)ComboCategorias.SelectedItem).Id;
            // IMPORTANTE: NO ASIGNAR el objeto de navegación Categoria aquí, ya que causó el ciclo.
            _currentProducto.Categoria = null;

            bool success = false;
            string action = _currentProducto.Id == 0 ? "agregado" : "modificado";

            try
            {
                if (_currentProducto.Id == 0)
                {
                    var newProduct = await _productoService.AddAsync(_currentProducto);
                    success = newProduct != null;
                }
                else
                {
                    success = await _productoService.UpdateAsync(_currentProducto);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (success)
            {
                LabelStatusMessage.Text = $"Producto {_currentProducto.Nombre} {action} correctamente";
                TimerStatusBar.Start();

                await CargarProductosAsync();

                LimpiarControlAgregar();
                TabControl.SelectedTab = tabPageLista;
                _currentProducto = null;
            }
            else
            {
                MessageBox.Show("Error al guardar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (GridData.RowCount > 0 && GridData.SelectedRows.Count > 0)
            {
                // El producto es del DTO/Tipo Anónimo. Necesitas obtener el objeto completo si quieres la Categoría para el ComboBox
                // Sin embargo, si el DTO tiene CategoriaId, es suficiente.

                // Si el GridData.DataSource es List<Producto>:
                _currentProducto = (Producto)GridData.SelectedRows[0].DataBoundItem;

                // Mapear a los controles
                TxtNombre.Text = _currentProducto.Nombre;
                NumericPrecio.Value = _currentProducto.Precio;
                NumericStock.Value = _currentProducto.Stock;

                // Seleccionar la categoría
                if (_categorias != null && _currentProducto.CategoriaId != 0)
                {
                    ComboCategorias.SelectedItem = _categorias.FirstOrDefault(c => c.Id == _currentProducto.CategoriaId);
                }
                else
                {
                    ComboCategorias.SelectedItem = null;
                }

                TabControl.SelectedTab = tabPageAgregar_Editar;
            }
            else
            {
                MessageBox.Show("No hay Producto seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        await CargarProductosAsync();
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
                        await CargarProductosAsync();
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
                // No aplica buscar en eliminados, a menos que tu endpoint /deleteds también acepte filtro.
                // Por simplicidad, recargamos la lista completa de eliminados o no hacemos nada.
                MessageBox.Show("La búsqueda no está habilitada en la vista de productos eliminados.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Carga los productos activos filtrados
            await CargarProductosAsync(TxtBuscar.Text);
        }
    }
}