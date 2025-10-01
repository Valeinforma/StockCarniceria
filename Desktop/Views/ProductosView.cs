using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service.Models;
using Service.Services;

namespace Desktop.Views
{
    public partial class ProductosView : Form
    {

        GenericService<Producto> _productoService = new GenericService<Producto>();
        Producto _currentProducto;
        List<Producto>? _productos;
        public ProductosView()
        {
            InitializeComponent();
            _ = GetAllData();
            checkBoxEliminados.CheckedChanged += DisplayHideControlsRestoreButton;

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
                _productos = await _productoService.GetAllAsync();
            GridData.DataSource = _productos;
            GridData.Columns["Id"].Visible = false;
            GridData.Columns["IsDeleted"].Visible = false;


        }
        private void GridPeliculas_SelectionChanged(object sender, EventArgs e)
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
        private void iconButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void iconButton2_Click(object sender, EventArgs e)
        {
            Producto ProductoAGuardar = new Producto
            {
                Id = _currentProducto?.Id ?? 0,
                Nombre = BtnNombre.Text,
                Precio = NumericPrecio.Value,
                Stock = (int)NumericStock.Value,
                Unidad = NumericUnidad.Text


            };
            bool response = false;
            if (_currentProducto != null)
            {
                response = await _productoService.UpdateAsync(ProductoAGuardar);
            }
            else
            {
                var nuevacapacitacion = await _productoService.AddAsync(
                   ProductoAGuardar);
                response = nuevacapacitacion != null;
            }
            if (response)
            {
                _currentProducto = null;
                MessageBox.Show($"Producto {ProductoAGuardar.Nombre} guardo correctamente");
                await GetAllData();
                TabControl.SelectedTab = tabPageLista;
            }
            else
            {
                MessageBox.Show("Error al modificar el Producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (GridData.RowCount > 0 && GridData.SelectedRows.Count > 0)
            {

                _currentProducto = (Producto)GridData.SelectedRows[0].DataBoundItem;
                BtnNombre.Text = _currentProducto.Nombre;
                NumericPrecio.Value = _currentProducto.Precio;
                NumericStock.Value = _currentProducto.Stock;
                NumericUnidad.Text = _currentProducto.Unidad;




                TabControl.SelectedTab = tabPageAgregar_Editar;

            }
        }

        private async void iconButton1_Click(object sender, EventArgs e)
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
           //generame para poder elegir categoria que quiero

        }
    }
}