using Microsoft.Reporting.WinForms;
using Service.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Desktop.ViewReports
{
    public partial class VentasViewReport : Form
    {
        private readonly ReportViewer _report;
        private readonly Producto _producto;

        public VentasViewReport(Producto producto)
        {
            _producto = producto ?? throw new ArgumentNullException(nameof(producto), "El producto no puede ser nulo.");

            InitializeComponent();
            _report = new ReportViewer();
            _report.Dock = DockStyle.Fill;
            this.Controls.Add(_report);

            this.Load += VentasViewReport_Load;
            this.FormClosing += VentasViewReport_FormClosing;
        }

        private void VentasViewReport_Load(object sender, EventArgs e)
        {
            // 1. Manejo de Datos Ausentes (Previene el error de ciclo de vida)
            if (_producto.DetallesVenta == null || !_producto.DetallesVenta.Any())
            {
                MessageBox.Show($"No hay datos de ventas para el producto: {_producto.Nombre ?? "seleccionado"}.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Solo retornamos; NO LLAMAMOS a this.Close().
                return;
            }

            try
            {
                // 2. Configuración del reporte
                _report.LocalReport.ReportEmbeddedResource = "Desktop.Reports.VentasReport.rdlc";
                _report.LocalReport.DataSources.Clear();

                // 3. Proyección de datos (Asegurando nombres de campo correctos)
                var ventasData = _producto.DetallesVenta
                    // Se usa 'Venta' (PascalCase) y se filtra por detalles válidos
                    .Where(detalle => detalle?.venta != null)
                    .Select(detalle => new
                    {
                        // Campos esperados por el RDLC:
                        Producto = _producto.Nombre ?? "N/A",
                        Vendedor = detalle.venta.Vendedor?.Nombre ?? "Sin vendedor",
                        Fecha = detalle.venta.Fecha.ToString("dd/MM/yyyy"),
                        TipoPago = detalle.venta.TipoPagoEnum.ToString(),

                        // Cálculo del subtotal, mapeado al campo RDLC 'PrecioTotal'
                        PrecioTotal = (detalle.CantidadProductoVendido * detalle.PrecioTotalProductoVendido).ToString("C2"),
                    })
                    .ToList();

                // 4. Añadir la fuente de datos
                // El nombre "DsStockCarniceria" debe coincidir con el DataSet en el RDLC.
                _report.LocalReport.DataSources.Add(new ReportDataSource("DsStockCarniceria", ventasData));

                // 5. Renderizar
                _report.SetDisplayMode(DisplayMode.PrintLayout);
                _report.ZoomMode = ZoomMode.Percent;
                _report.ZoomPercent = 100;

                _report.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el reporte: {ex.Message}\n\nDetalles internos: {ex.InnerException?.Message}", "Error de Reporte", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void VentasViewReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Liberación de recursos
            _report?.Dispose();
        }
    }
}