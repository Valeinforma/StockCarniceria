namespace Desktop.Views
{
    partial class MenuPrincipalView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            BtnPrincipal = new FontAwesome.Sharp.IconMenuItem();
            usuariosToolStripMenuItem = new ToolStripMenuItem();
            productosToolStripMenuItem = new ToolStripMenuItem();
            BtnSalir = new ToolStripMenuItem();
            BtnSalirDelSistema = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            ventasToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { BtnPrincipal, BtnSalir });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // BtnPrincipal
            // 
            BtnPrincipal.DropDownItems.AddRange(new ToolStripItem[] { usuariosToolStripMenuItem, productosToolStripMenuItem, ventasToolStripMenuItem });
            BtnPrincipal.IconChar = FontAwesome.Sharp.IconChar.None;
            BtnPrincipal.IconColor = Color.Black;
            BtnPrincipal.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnPrincipal.Name = "BtnPrincipal";
            BtnPrincipal.Size = new Size(81, 20);
            BtnPrincipal.Text = "Principal";
            // 
            // usuariosToolStripMenuItem
            // 
            usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            usuariosToolStripMenuItem.Size = new Size(180, 22);
            usuariosToolStripMenuItem.Text = "Usuarios";
            usuariosToolStripMenuItem.Click += usuariosToolStripMenuItem_Click;
            // 
            // productosToolStripMenuItem
            // 
            productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            productosToolStripMenuItem.Size = new Size(180, 22);
            productosToolStripMenuItem.Text = "Productos";
            productosToolStripMenuItem.Click += productosToolStripMenuItem_Click;
            // 
            // BtnSalir
            // 
            BtnSalir.DropDownItems.AddRange(new ToolStripItem[] { BtnSalirDelSistema });
            BtnSalir.Name = "BtnSalir";
            BtnSalir.Size = new Size(41, 20);
            BtnSalir.Text = "Salir";
            // 
            // BtnSalirDelSistema
            // 
            BtnSalirDelSistema.Name = "BtnSalirDelSistema";
            BtnSalirDelSistema.Size = new Size(159, 22);
            BtnSalirDelSistema.Text = "Salir del Sistema";
            BtnSalirDelSistema.Click += BtnSalirDelSistema_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.Location = new Point(0, 24);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
            toolStrip1.TabIndex = 5;
            toolStrip1.Text = "toolStrip1";
            // 
            // ventasToolStripMenuItem
            // 
            ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            ventasToolStripMenuItem.Size = new Size(180, 22);
            ventasToolStripMenuItem.Text = "Ventas";
            ventasToolStripMenuItem.Click += ventasToolStripMenuItem_Click;
            // 
            // MenuPrincipalView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "MenuPrincipalView";
            Text = "MenuPrincipalView";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private FontAwesome.Sharp.IconMenuItem BtnPrincipal;
        private ToolStripMenuItem BtnSalir;
        private ToolStripMenuItem BtnSalirDelSistema;
        private ToolStrip toolStrip1;
        private ToolStripMenuItem usuariosToolStripMenuItem;
        private ToolStripMenuItem productosToolStripMenuItem;
        private ToolStripMenuItem ventasToolStripMenuItem;
    }
}