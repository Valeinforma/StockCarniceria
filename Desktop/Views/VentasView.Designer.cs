namespace Desktop.Views
{
    partial class VentasView
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            panel1 = new Panel();
            label2 = new Label();
            GridInscripciones = new DataGridView();
            BtnBuscarProducto = new FontAwesome.Sharp.IconButton();
            TxtBuscarProducto = new TextBox();
            ContextMenuInscripcion = new ContextMenuStrip(components);
            SubMenuEliminarInscripcion = new ToolStripMenuItem();
            BtnImprimirVenta = new FontAwesome.Sharp.IconButton();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GridInscripciones).BeginInit();
            ContextMenuInscripcion.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(17, 7);
            label1.Name = "label1";
            label1.Size = new Size(90, 31);
            label1.TabIndex = 1;
            label1.Text = "Venta";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 1);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1394, 47);
            panel1.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(323, 67);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(80, 21);
            label2.TabIndex = 10;
            label2.Text = "Productos";
            // 
            // GridInscripciones
            // 
            GridInscripciones.AllowUserToAddRows = false;
            GridInscripciones.AllowUserToDeleteRows = false;
            GridInscripciones.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            GridInscripciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GridInscripciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridInscripciones.Location = new Point(17, 107);
            GridInscripciones.Margin = new Padding(2);
            GridInscripciones.Name = "GridInscripciones";
            GridInscripciones.ReadOnly = true;
            GridInscripciones.RowHeadersVisible = false;
            GridInscripciones.RowHeadersWidth = 62;
            GridInscripciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridInscripciones.Size = new Size(1190, 315);
            GridInscripciones.TabIndex = 11;
            // 
            // BtnBuscarProducto
            // 
            BtnBuscarProducto.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnBuscarProducto.IconChar = FontAwesome.Sharp.IconChar.Search;
            BtnBuscarProducto.IconColor = Color.Black;
            BtnBuscarProducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnBuscarProducto.ImageAlign = ContentAlignment.MiddleLeft;
            BtnBuscarProducto.Location = new Point(714, 60);
            BtnBuscarProducto.Margin = new Padding(2);
            BtnBuscarProducto.Name = "BtnBuscarProducto";
            BtnBuscarProducto.Size = new Size(83, 32);
            BtnBuscarProducto.TabIndex = 16;
            BtnBuscarProducto.Text = "&Buscar";
            BtnBuscarProducto.TextAlign = ContentAlignment.MiddleRight;
            BtnBuscarProducto.UseVisualStyleBackColor = true;
            BtnBuscarProducto.Click += BtnBuscarProducto_Click_1;
            // 
            // TxtBuscarProducto
            // 
            TxtBuscarProducto.Font = new Font("Segoe UI", 12F);
            TxtBuscarProducto.Location = new Point(413, 63);
            TxtBuscarProducto.Margin = new Padding(2);
            TxtBuscarProducto.Name = "TxtBuscarProducto";
            TxtBuscarProducto.PlaceholderText = "Buscar Productos...";
            TxtBuscarProducto.Size = new Size(297, 29);
            TxtBuscarProducto.TabIndex = 15;
            TxtBuscarProducto.TextChanged += TxtBuscarProducto_TextChanged_1;
            // 
            // ContextMenuInscripcion
            // 
            ContextMenuInscripcion.Items.AddRange(new ToolStripItem[] { SubMenuEliminarInscripcion });
            ContextMenuInscripcion.Name = "ContextMenuInscripcion";
            ContextMenuInscripcion.Size = new Size(171, 26);
            ContextMenuInscripcion.Text = "&Eliminar";
            // 
            // SubMenuEliminarInscripcion
            // 
            SubMenuEliminarInscripcion.Name = "SubMenuEliminarInscripcion";
            SubMenuEliminarInscripcion.Size = new Size(170, 22);
            SubMenuEliminarInscripcion.Text = "&Anular inscripcion";
            // 
            // BtnImprimirVenta
            // 
            BtnImprimirVenta.Anchor = AnchorStyles.Bottom;
            BtnImprimirVenta.IconChar = FontAwesome.Sharp.IconChar.Print;
            BtnImprimirVenta.IconColor = Color.Black;
            BtnImprimirVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnImprimirVenta.IconSize = 30;
            BtnImprimirVenta.ImageAlign = ContentAlignment.MiddleLeft;
            BtnImprimirVenta.Location = new Point(562, 438);
            BtnImprimirVenta.Margin = new Padding(2);
            BtnImprimirVenta.Name = "BtnImprimirVenta";
            BtnImprimirVenta.Size = new Size(117, 32);
            BtnImprimirVenta.TabIndex = 18;
            BtnImprimirVenta.Text = "&Imprmir Venta";
            BtnImprimirVenta.TextAlign = ContentAlignment.MiddleRight;
            BtnImprimirVenta.UseCompatibleTextRendering = true;
            BtnImprimirVenta.UseVisualStyleBackColor = true;
            BtnImprimirVenta.Click += BtnImprimirVenta_Click;
            // 
            // VentasView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1218, 481);
            Controls.Add(BtnImprimirVenta);
            Controls.Add(BtnBuscarProducto);
            Controls.Add(TxtBuscarProducto);
            Controls.Add(GridInscripciones);
            Controls.Add(label2);
            Controls.Add(panel1);
            Margin = new Padding(2);
            Name = "VentasView";
            Text = "Ventas";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)GridInscripciones).EndInit();
            ContextMenuInscripcion.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Label label2;
        private DataGridView GridInscripciones;
        private TextBox TxtBuscarProducto;
        private FontAwesome.Sharp.IconButton BtnBuscarProducto;
        private ContextMenuStrip ContextMenuInscripcion;
        private ToolStripMenuItem SubMenuEliminarInscripcion;
        private FontAwesome.Sharp.IconButton BtnImprimirVenta;
    }
}