using Desktop.ExtensionMethod;
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
                        CategoriaNombre = p.Categoria.Nombre, // Renombrar la propiedad para evitar duplicados
                        EnStock = p.Stock > 0 ? "Sí" : "No",
                        p.Stock
                    })
                    .ToList();

                // Ocultar columnas innecesarias
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
                        CategoriaNombre = p.Categoria.Nombre, // Renombrar la propiedad para evitar duplicados
                        EnStock = p.Stock > 0 ? "Sí" : "No",
                        p.Stock
                    })
                    .ToList();
            }
        }

        private void ComboProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //que aparezcan los productos de la categoria seleccionada
            var categoriaSeleccionada = ComboProductos.SelectedText as string;
            if (categoriaSeleccionada != null)
            {
                GridInscripciones.DataSource = _productos?
                    .Where(p => p.Categoria.Nombre.Equals(categoriaSeleccionada, StringComparison.OrdinalIgnoreCase))
                    .Select(p => new
                    {
                        p.Nombre,
                        CategoriaNombre = p.Categoria.Nombre, // Renombrar la propiedad para evitar duplicados
                        EnStock = p.Stock > 0 ? "Sí" : "No",
                        p.Stock
                    })
                    .ToList();

            }
        }

        private void ComboTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            //que apaparezca la forma de pago seleccionada
            var tipoPagoSeleccionado = ComboTipoPago.SelectedItem as string;
            if (tipoPagoSeleccionado != null)
            {
                // Lógica para manejar el cambio en la selección del tipo de pago
                // Por ejemplo, podrías mostrar un mensaje o actualizar otra parte de la interfaz
                MessageBox.Show($"Tipo de pago seleccionado: {tipoPagoSeleccionado}", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void BtnTipoPago_Click(object sender, EventArgs e)
        {
            //que guarde el metodo de pago seleccionado y el producto seleccionado
            var productoSeleccionado = GridInscripciones.CurrentRow?.Cells["Nombre"].Value.ToString();
            var tipoPagoSeleccionado = ComboTipoPago.SelectedItem as string;
            if (productoSeleccionado != null && tipoPagoSeleccionado != null)
            {
                MessageBox.Show($"Producto: {productoSeleccionado}\nTipo de pago: {tipoPagoSeleccionado}", "Venta Registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un producto y un tipo de pago.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
