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
        }

        private async Task GetAllData()
        {
            _productos = await _productoService.GetAllAsync();
            GridPeliculas.DataSource = _productos;
            GridPeliculas.Columns["Id"].Visible = false;
            GridPeliculas.Columns["IsDeleted"].Visible = false; // Ocultamos la columna eliminar // Ocultamos la columna eliminar


        }
        private void GridPeliculas_SelectionChanged(object sender, EventArgs e)
        {
            if (GridPeliculas.RowCount > 0 && GridPeliculas.SelectedRows.Count > 0)
            {
                //    Capacitacion _curr = (Pelicula)GridPeliculas.SelectedRows[0].DataBoundItem;
                //    FilmPicture.ImageLocation = peliculaSeleccionada.portada;
            }
        }

        private async void BtnEliminar_Click(object sender, EventArgs e)
        {
            //checkeamos que haya peliculas seleccionadas
            if (GridPeliculas.RowCount > 0 && GridPeliculas.SelectedRows.Count > 0)
            {
                Producto entitySelected = (Producto)GridPeliculas.SelectedRows[0].DataBoundItem;
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
            //    LimpiarControlAgregar();
            //    tabAgregarEliminar.SelectTab("tabPageAgregar");
        }
        private void LimpiarControlAgregar()
        {
            titulo2.Text = string.Empty;
            NumericDuracion.Value = 0;
            txtPortada2.Text = string.Empty;
            FilmPicture.ImageLocation = null;
        }
        private void iconButton3_Click(object sender, EventArgs e)
        {
            tabAgregarEliminar.SelectTab("tabPageLista");
        }

        private async void iconButton2_Click(object sender, EventArgs e)
        {
            //    Pelicula PeliculaAGuardar = new Pelicula
            //    {
            //        id = peliculaModificada?.id ?? null,
            //        titulo = titulo2.Text,
            //        duracion = (int)NumericDuracion.Value,
            //        portada = txtPortada2.Text,
            //        calificacion = (double)NumericCalificacion.Value,
            //        // Asignamos el PaisId del combo seleccionado

            //        PaisId = (int?)comboPaises.SelectedValue
            //    };
            //    bool response;
            //    if (peliculaModificada != null)
            //    {
            //        response = await peliculaService.UpdateAsync(PeliculaAGuardar);
            //    }
            //    else
            //    {
            //        response = await peliculaService.AddAsync(
            //           PeliculaAGuardar);
            //    }
            //    if (response)
            //    {
            //        peliculaModificada = null;
            //        MessageBox.Show("Pelicula se guardo correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        obtenemosPeliculas();
            //        tabAgregarEliminar.SelectTab("TabPageLista");
            //    }
            //    else
            //    {
            //        MessageBox.Show("Error al modificar la pelicula", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            //    if (GridPeliculas.RowCount > 0 && GridPeliculas.SelectedRows.Count > 0)
            //    {
            //        peliculaModificada = (Pelicula)GridPeliculas.SelectedRows[0].DataBoundItem;
            //        titulo2.Text = peliculaModificada.titulo;
            //        NumericDuracion.Value = peliculaModificada.duracion;
            //        txtPortada2.Text = peliculaModificada.portada;
            //        NumericCalificacion.Value = (decimal)peliculaModificada.calificacion;
            //        tabAgregarEliminar.SelectTab("tabPageAgregar");
            //        //asigna el pais seleccionado al combo
            //        if (peliculaModificada.PaisId != null)
            //        {
            //            comboPaises.SelectedValue = peliculaModificada.PaisId;
            //        }
            //        else
            //        {
            //            comboPaises.SelectedIndex = -1; // Si no hay PaisId, deselecciona el combo
            //        }
            //    }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            //    GridPeliculas.DataSource = peliculas.Where(p => p.titulo.ToUpper().Contains(TxtBuscar.Text.ToUpper())).ToList();

        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            //    if (String.IsNullOrWhiteSpace(TxtBuscar.Text))
            //    {
            //        BtnBuscar.PerformClick();
        }

        //}

       private void TimerStatusBar_Tick(object sender, EventArgs e)
        {
            //    LabelStatusMessage.Text = string.Empty;
            //    TimerStatusBar.Stop();
            //}
        }
    }
}