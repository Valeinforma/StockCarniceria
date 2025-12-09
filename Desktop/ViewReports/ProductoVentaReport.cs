using Microsoft.Reporting.WinForms;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Desktop.ViewReports
{
    public partial class ProductoVentaReport : Form
    {
        private readonly ReportViewer _report;
        private readonly List<Producto> _productosVenta;

        public ProductoVentaReport(List<Producto> productosVenta)
        {
            InitializeComponent();
            _productosVenta = productosVenta;

            _report = new ReportViewer();
            _report.Dock = DockStyle.Fill;
            this.Controls.Add(_report);

            this.Load += ProductoVentaReport_Load;
        }

        private void ProductoVentaReport_Load(object sender, EventArgs e)
        {
            try
            {
                _report.LocalReport.ReportEmbeddedResource = "Desktop.Reports.ProductosVenta.rdlc";

                var dataset = _productosVenta.Select(cs => new
                {
                    Nombre = cs.Nombre ?? "Sin Nombre",
                    PrecioUnitario = cs.PrecioUnitario,
                    DetalleVenta = cs.DetallesVenta,
                    Stock = cs.Stock
                }).ToList();

                _report.LocalReport.DataSources.Clear();
                _report.LocalReport.DataSources.Add(new ReportDataSource("StockDs", dataset));

                _report.SetDisplayMode(DisplayMode.PrintLayout);
                _report.ZoomMode = ZoomMode.PageWidth;

                _report.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}