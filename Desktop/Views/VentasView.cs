using Desktop.ExtensionMethod;
using Desktop.ViewReports;
using Service.Models;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Views
{
    public partial class VentasView : Form
    {
        GenericService<Producto> _productoService = new();
        List<Producto>? _productos = new();

        public VentasView()
        {
            InitializeComponent();
            _ = CargarProductos();
        }

        private async Task CargarProductos()
        {
            _productos = await _productoService.GetAllAsync();
            if (_productos != null)
            {
                GridInscripciones.DataSource = _productos
                    .OrderBy(p => p.Categoria.Nombre)
                    .ThenBy(p => p.Nombre)
                    .Select(p => new
                    {
                        p.Nombre,
                        Categoria = p.Categoria.Nombre,
                        EnStock = p.Stock > 0 ? "Sí" : "No",
                        p.Stock,
                        p.Id,

                    })
                    .ToList();

                GridInscripciones.HideColumns("Id", "DeleteDate", "IsDeleted");
            }
        }

        private async void TxtBuscarProducto_TextChanged_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtBuscarProducto.Text))
            {
                await CargarProductos();
            }
        }

        private void BtnBuscarProducto_Click_1(object sender, EventArgs e)
        {
            var filtro = TxtBuscarProducto.Text.Trim();
            if (!string.IsNullOrWhiteSpace(filtro))
            {
                GridInscripciones.DataSource = _productos?
                    .Where(p => p.Nombre.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                                p.Categoria.Nombre.Contains(filtro, StringComparison.OrdinalIgnoreCase))
                    .Select(p => new
                    {
                        p.Nombre,
                        CategoriaNombre = p.Categoria.Nombre,
                        EnStock = p.Stock > 0 ? "Sí" : "No",
                        p.Stock,
                        p.Id
                    })
                    .ToList();
            }
        }

        private void ComboProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var categoriaSeleccionada = TxtBuscarProducto.SelectedText as string;
            if (categoriaSeleccionada != null)
            {
                GridInscripciones.DataSource = _productos?
                    .Where(p => p.Categoria.Nombre.Equals(categoriaSeleccionada, StringComparison.OrdinalIgnoreCase))
                    .Select(p => new
                    {
                        p.Nombre,
                        CategoriaNombre = p.Categoria.Nombre,
                        EnStock = p.Stock > 0 ? "Sí" : "No",
                        p.Stock,
                        p.PrecioUnitario,
                        p.Id
                    })
                    .ToList();
            }
        }


        private async void  BtnImprimirVenta_Click(object sender, EventArgs e)
        {

            if (GridInscripciones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un producto", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Obtener el Id del objeto anónimo
            var selectedRow = GridInscripciones.SelectedRows[0];
            var selectedId = (int)selectedRow.Cells["Id"].Value;

            try
            {
                // Cargar el producto con sus relaciones (DetallesVenta)
                var selectedProducto = await _productoService.GetByIdAsync(selectedId);

                if (selectedProducto == null)
                {
                    MessageBox.Show("No se pudo encontrar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var ventasViewReport = new VentasViewReport(selectedProducto);
                ventasViewReport.MdiParent = this.MdiParent;
                ventasViewReport.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
