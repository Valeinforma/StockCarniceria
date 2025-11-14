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
            panel2 = new Panel();
            label4 = new Label();
            ComboTipoPago = new ComboBox();
            BtnTipoPago = new FontAwesome.Sharp.IconButton();
            BtnBuscarProducto = new FontAwesome.Sharp.IconButton();
            TxtBuscarProducto = new TextBox();
            GridUsuarios = new DataGridView();
            ContextMenuInscripcion = new ContextMenuStrip(components);
            SubMenuEliminarInscripcion = new ToolStripMenuItem();
            BtnImprimirInscripciones = new FontAwesome.Sharp.IconButton();
            ComboProductos = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GridInscripciones).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GridUsuarios).BeginInit();
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
            label2.Location = new Point(18, 75);
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
            GridInscripciones.Size = new Size(524, 315);
            GridInscripciones.TabIndex = 11;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(label4);
            panel2.Controls.Add(ComboTipoPago);
            panel2.Controls.Add(BtnTipoPago);
            panel2.Controls.Add(BtnBuscarProducto);
            panel2.Controls.Add(TxtBuscarProducto);
            panel2.Controls.Add(GridUsuarios);
            panel2.Location = new Point(545, 68);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(532, 390);
            panel2.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(15, 194);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(99, 21);
            label4.TabIndex = 19;
            label4.Text = "Tipo de Pago";
            // 
            // ComboTipoPago
            // 
            ComboTipoPago.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboTipoPago.Font = new Font("Segoe UI", 12F);
            ComboTipoPago.FormattingEnabled = true;
            ComboTipoPago.Location = new Point(15, 215);
            ComboTipoPago.Margin = new Padding(2);
            ComboTipoPago.Name = "ComboTipoPago";
            ComboTipoPago.Size = new Size(297, 29);
            ComboTipoPago.TabIndex = 18;
            ComboTipoPago.SelectedIndexChanged += ComboTipoPago_SelectedIndexChanged;
            // 
            // BtnTipoPago
            // 
            BtnTipoPago.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnTipoPago.IconChar = FontAwesome.Sharp.IconChar.FileCirclePlus;
            BtnTipoPago.IconColor = Color.Black;
            BtnTipoPago.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnTipoPago.ImageAlign = ContentAlignment.MiddleLeft;
            BtnTipoPago.Location = new Point(316, 214);
            BtnTipoPago.Margin = new Padding(2);
            BtnTipoPago.Name = "BtnTipoPago";
            BtnTipoPago.Size = new Size(105, 32);
            BtnTipoPago.TabIndex = 17;
            BtnTipoPago.Text = "&Agregar inscripto...";
            BtnTipoPago.TextAlign = ContentAlignment.MiddleRight;
            BtnTipoPago.UseCompatibleTextRendering = true;
            BtnTipoPago.UseVisualStyleBackColor = true;
            BtnTipoPago.Click += BtnTipoPago_Click;
            // 
            // BtnBuscarProducto
            // 
            BtnBuscarProducto.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnBuscarProducto.IconChar = FontAwesome.Sharp.IconChar.Search;
            BtnBuscarProducto.IconColor = Color.Black;
            BtnBuscarProducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnBuscarProducto.ImageAlign = ContentAlignment.MiddleLeft;
            BtnBuscarProducto.Location = new Point(316, 42);
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
            TxtBuscarProducto.Location = new Point(15, 45);
            TxtBuscarProducto.Margin = new Padding(2);
            TxtBuscarProducto.Name = "TxtBuscarProducto";
            TxtBuscarProducto.PlaceholderText = "Buscar Productos...";
            TxtBuscarProducto.Size = new Size(297, 29);
            TxtBuscarProducto.TabIndex = 15;
            TxtBuscarProducto.TextChanged += TxtBuscarProducto_TextChanged_1;
            // 
            // GridUsuarios
            // 
            GridUsuarios.AllowUserToAddRows = false;
            GridUsuarios.AllowUserToDeleteRows = false;
            GridUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridUsuarios.Location = new Point(15, 88);
            GridUsuarios.Margin = new Padding(2);
            GridUsuarios.Name = "GridUsuarios";
            GridUsuarios.ReadOnly = true;
            GridUsuarios.RowHeadersVisible = false;
            GridUsuarios.RowHeadersWidth = 62;
            GridUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridUsuarios.Size = new Size(476, 96);
            GridUsuarios.TabIndex = 14;
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
            // BtnImprimirInscripciones
            // 
            BtnImprimirInscripciones.Anchor = AnchorStyles.Bottom;
            BtnImprimirInscripciones.IconChar = FontAwesome.Sharp.IconChar.Print;
            BtnImprimirInscripciones.IconColor = Color.Black;
            BtnImprimirInscripciones.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnImprimirInscripciones.IconSize = 30;
            BtnImprimirInscripciones.ImageAlign = ContentAlignment.MiddleLeft;
            BtnImprimirInscripciones.Location = new Point(154, 426);
            BtnImprimirInscripciones.Margin = new Padding(2);
            BtnImprimirInscripciones.Name = "BtnImprimirInscripciones";
            BtnImprimirInscripciones.Size = new Size(155, 32);
            BtnImprimirInscripciones.TabIndex = 18;
            BtnImprimirInscripciones.Text = "&Imprmir Inscripciones";
            BtnImprimirInscripciones.TextAlign = ContentAlignment.MiddleRight;
            BtnImprimirInscripciones.UseCompatibleTextRendering = true;
            BtnImprimirInscripciones.UseVisualStyleBackColor = true;
            // 
            // ComboProductos
            // 
            ComboProductos.Font = new Font("Segoe UI", 12F);
            ComboProductos.Location = new Point(113, 72);
            ComboProductos.Margin = new Padding(2);
            ComboProductos.Name = "ComboProductos";
            ComboProductos.PlaceholderText = "Buscar Productos...";
            ComboProductos.Size = new Size(297, 29);
            ComboProductos.TabIndex = 19;
            // 
            // VentasView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1218, 481);
            Controls.Add(ComboProductos);
            Controls.Add(BtnImprimirInscripciones);
            Controls.Add(panel2);
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
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)GridUsuarios).EndInit();
            ContextMenuInscripcion.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Label label2;
        private DataGridView GridInscripciones;
        private Panel panel2;
        private DataGridView GridUsuarios;
        private TextBox TxtBuscarProducto;
        private FontAwesome.Sharp.IconButton BtnBuscarProducto;
        private ContextMenuStrip ContextMenuInscripcion;
        private ToolStripMenuItem SubMenuEliminarInscripcion;
        private FontAwesome.Sharp.IconButton BtnImprimirInscripciones;
        private Label label4;
        private ComboBox ComboTipoPago;
        private FontAwesome.Sharp.IconButton BtnTipoPago;
        private TextBox ComboProductos;
    }
}