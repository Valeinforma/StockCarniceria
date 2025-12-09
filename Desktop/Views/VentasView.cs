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
            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            await CargarProductos();
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

        

        private void BtnImprimirVenta_Click(object sender, EventArgs e)
        {
            if (_productos == null || !_productos.Any())
            {
                MessageBox.Show(
                    "Por favor, espera a que los productos se carguen.",
                    "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            var productosConStock = _productos
                .Where(p => p.Stock > 0)
                .OrderByDescending(p => p.Stock)
                .ToList();

            if (!productosConStock.Any())
            {
                MessageBox.Show(
                    "No hay productos con stock para generar el reporte.",
                    "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            var productoVentaReporte = new ProductoVentaReport(productosConStock);
            productoVentaReporte.MdiParent = this.MdiParent;
            productoVentaReporte.Show();
        }
    }
}
