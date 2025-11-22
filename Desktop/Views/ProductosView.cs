using Service.Models;
using Service.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace Desktop.Views
{
    public partial class ProductosView : Form
    {

        GenericService<Producto> _productoService = new GenericService<Producto>();
        GenericService<Categoria> _categoriaService = new GenericService<Categoria>();
        Categoria _currentCategoria;
        Producto _currentProducto;
        List<Producto>? _productos;
        List<Categoria>? _categorias;
        public ProductosView()
        {
            InitializeComponent();
            _ = GetAllData();
            checkBoxEliminados.CheckedChanged += DisplayHideControlsRestoreButton;
            CargarCategorias();

        }

        private void DisplayHideControlsRestoreButton(object? sender, EventArgs e)
        {
            BtnRestaurar.Visible = checkBoxEliminados.Checked;
            TxtBuscar.Enabled = !checkBoxEliminados.Checked;
            BtnModificar.Enabled = !checkBoxEliminados.Checked;
            BtnEliminar.Enabled = !checkBoxEliminados.Checked;
            BtnAgregar.Enabled = !checkBoxEliminados.Checked;
            BtnBuscar.Enabled = !checkBoxEliminados.Checked;
        }

        private async Task GetAllData()
        {
            if (checkBoxEliminados.Checked)
                _productos = await _productoService.GetAllDeletedAsync();

            else
            {
                _categorias = await _categoriaService.GetAllAsync();
                _productos = await _productoService.GetAllAsync();
            }

            GridData.DataSource = _productos;
            GridData.Columns["Id"].Visible = false;
            GridData.Columns["IsDeleted"].Visible = false;
            ActualizarGridView();

        }
        private void ActualizarGridView()
        {
            GridData.DataSource = null;
            GridData.DataSource = _productos;

            GridData.Columns["Id"].Visible = false;
            GridData.Columns["IsDeleted"].Visible = false;
            // Oculta o formatea otras columnas según necesidad
        }
        private void GridData_SelectionChanged_1(object sender, EventArgs e)
        {
            if (GridData.RowCount > 0 && GridData.SelectedRows.Count > 0)
            {
                //    Capacitacion _curr = (Pelicula)GridPeliculas.SelectedRows[0].DataBoundItem;
                //    FilmPicture.ImageLocation = peliculaSeleccionada.portada;
            }
        }
      
        private async void BtnEliminar_Click(object sender, EventArgs e)
        {
            //checkeamos que haya peliculas seleccionadas
            if (GridData.RowCount > 0 && GridData.SelectedRows.Count > 0)
            {
                Producto entitySelected = (Producto)GridData.SelectedRows[0].DataBoundItem;
                var respuesta = MessageBox.Show($"¿Seguro que quieres borrar el Producto ?{entitySelected.Nombre}", "Borrar Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {

                    if (await _productoService.DeleteAsync(entitySelected.Id))
                    {
                        LabelStatusMessage.Text = $"Producto {entitySelected.Nombre} eliminada correctamente";
                        TimerStatusBar.Start();
                        await GetAllData();
                    }
                    else
                    {
                        MessageBox.Show("Error al borrar Producto", "Borrar Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No hay Producto seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            LimpiarControlAgregar();
            TabControl.SelectedTab = tabPageAgregar_Editar;
        }
        private void LimpiarControlAgregar()
        {
            //limpiar todo
            BtnNombre.Text = string.Empty;
            NumericPrecio.Value = 0;
            NumericStock.Value = 0;


        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validación de campos obligatorios
                if (string.IsNullOrWhiteSpace(ComboCategorias.Text) ||
                    string.IsNullOrWhiteSpace(NumericPrecio.Text) ||
                    string.IsNullOrWhiteSpace(NumericStock.Text) ||
                    ComboCategorias.SelectedItem == null)
                {
                    MessageBox.Show("Todos los campos marcados son obligatorios.",
                                    "Validación",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                // Asignar la categoría seleccionada
                var categoriaSeleccionada = ComboCategorias.SelectedItem as Categoria;
                if (categoriaSeleccionada == null)
                {
                    MessageBox.Show("Debes seleccionar una categoría válida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Producto productoAguardar = new Producto
                {
                    Nombre = BtnNombre.Text,
                    Precio = NumericPrecio.Value,
                    Stock = (int)NumericStock.Value,
                    CategoriaId = categoriaSeleccionada.Id,
                    Categoria = categoriaSeleccionada // <--- Esto es lo que falta
                };

                bool success = false;

                if (_currentCategoria != null)
                {
                    // Actualización
                    if (!await _categoriaService.UpdateAsync(categoriaSeleccionada))
                        throw new Exception("Error al actualizar la categoria");

                    if (!await _productoService.UpdateAsync(productoAguardar))
                        throw new Exception("Error al actualizar el producto");

                    success = true;
                }
                else
                {
                    // Creación
                    var nuevoProducto = await _productoService.AddAsync(productoAguardar);
                    if (nuevoProducto == null)
                        throw new Exception("Error al crear el usuario");

                    var nuevaCategoria = await _categoriaService.AddAsync(categoriaSeleccionada);
                    if (nuevaCategoria == null)
                        throw new Exception("Error al crear el cliente");

                    success = true;
                }

                if (success)
                {
                    MessageBox.Show($"Cliente {productoAguardar.Nombre} guardado correctamente",
                                  "Éxito",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                    await GetAllData();
                    LimpiarControlAgregar();
                    TabControl.SelectedTab = tabPageLista;
                    _currentProducto = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en la operación: {ex.Message}",
                               "Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (GridData.RowCount > 0 && GridData.SelectedRows.Count > 0)
            {
                var id = (int)GridData.SelectedRows[0].Cells["Id"].Value;
                _currentProducto = _productos.FirstOrDefault(p => p.Id == id);
                if (_currentProducto != null)
                {
                    BtnNombre.Text = _currentProducto.Nombre;
                    NumericPrecio.Value = _currentProducto.Precio;
                    NumericStock.Value = _currentProducto.Stock;
                    TabControl.SelectedTab = tabPageAgregar_Editar;
                }
            }
        }

        private async void BtnBuscar_Click(object sender, EventArgs e)
        {
            GridData.DataSource = await _productoService.GetAllAsync(TxtBuscar.Text);

        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {

            //BtnBuscar.PerformClick();

        }

        //}

        private void TimerStatusBar_Tick(object sender, EventArgs e)
        {
            //    LabelStatusMessage.Text = string.Empty;
            //    TimerStatusBar.Stop();
            //}
        }


        private async void checkBoxEliminados_CheckedChanged(object sender, EventArgs e)
        {
            await GetAllData();
        }

        private async void BtnRestaurar_Click(object sender, EventArgs e)
        {
            if (!checkBoxEliminados.Checked) return;

            //checkeamos que haya peliculas seleccionadas
            if (GridData.RowCount > 0 && GridData.SelectedRows.Count > 0)
            {
                Producto entitySelected = (Producto)GridData.SelectedRows[0].DataBoundItem;
                var respuesta = MessageBox.Show($"¿Seguro que quieres recuperar el Producto ?{entitySelected.Nombre}", "Confirmar Restauracion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {


                    if (await _productoService.RestoreAsync(entitySelected.Id))
                    {
                        LabelStatusMessage.Text = $"Producto {entitySelected.Nombre} eliminada correctamente";
                        TimerStatusBar.Start();
                        await GetAllData();
                    }


                    else
                    {
                        MessageBox.Show("No hay Producto seleccionadas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void ComboCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
          //seleccionar la categoria y guardarla en la variable _currentCategoria
            if (ComboCategorias.SelectedItem != null)
            {
                _currentCategoria = (Categoria)ComboCategorias.SelectedItem;
            }
            else
            {
                _currentCategoria = null;
            }
        }
        private async void CargarCategorias()
        {
            _categorias = await _categoriaService.GetAllAsync(null);
            if (_categorias == null || !_categorias.Any())
            {
                MessageBox.Show("No se pudieron cargar las categorías.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ComboCategorias.DataSource = _categorias;
            ComboCategorias.DisplayMember = "Nombre";
            ComboCategorias.ValueMember = "Id";
            ComboCategorias.SelectedItem = null;
        }

        
    }

}