using Service.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Views
{
    public partial class MenuPrincipalView : Form
    {
        public MenuPrincipalView()
        {
            InitializeComponent();
        }

        private void BtnSalirDelSistema_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var UsuariosView = new UsuariosView();
            UsuariosView.MdiParent = this;
            UsuariosView.Show();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ProductosView = new ProductosView();
            ProductosView.MdiParent = this;
            ProductosView.Show();
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var VentasView = new VentasView();
            VentasView.MdiParent = this;
            VentasView.Show();
        }
    }
}
