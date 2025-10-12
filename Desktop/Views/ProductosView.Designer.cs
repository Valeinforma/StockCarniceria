namespace Desktop.Views
{
    partial class ProductosView
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
            GridData = new DataGridView();
            BtnAgregar = new FontAwesome.Sharp.IconButton();
            BtnEliminar = new FontAwesome.Sharp.IconButton();
            BtnModificar = new FontAwesome.Sharp.IconButton();
            BtnSalir = new FontAwesome.Sharp.IconButton();
            TabControl = new TabControl();
            tabPageLista = new TabPage();
            BtnRestaurar = new FontAwesome.Sharp.IconButton();
            checkBoxEliminados = new CheckBox();
            BtnBuscar = new FontAwesome.Sharp.IconButton();
            TxtBuscar = new TextBox();
            LbBuscar = new Label();
            tabPageAgregar_Editar = new TabPage();
            ComboCategorias = new ComboBox();
            label = new Label();
            label4 = new Label();
            NumericStock = new NumericUpDown();
            DuracionMinutos = new Label();
            NumericPrecio = new NumericUpDown();
            BtnNombre = new TextBox();
            nombre = new Label();
            BtnCancelar = new FontAwesome.Sharp.IconButton();
            BtnGuardar = new FontAwesome.Sharp.IconButton();
            panel1 = new Panel();
            label1 = new Label();
            LabelStatusMessage = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            TimerStatusBar = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)GridData).BeginInit();
            TabControl.SuspendLayout();
            tabPageLista.SuspendLayout();
            tabPageAgregar_Editar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumericStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumericPrecio).BeginInit();
            panel1.SuspendLayout();
            LabelStatusMessage.SuspendLayout();
            SuspendLayout();
            // 
            // GridData
            // 
            GridData.AllowUserToAddRows = false;
            GridData.AllowUserToDeleteRows = false;
            GridData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            GridData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GridData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridData.Location = new Point(6, 66);
            GridData.MultiSelect = false;
            GridData.Name = "GridData";
            GridData.ReadOnly = true;
            GridData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridData.Size = new Size(710, 251);
            GridData.TabIndex = 0;
            GridData.SelectionChanged += GridData_SelectionChanged_1;
            // 
            // BtnAgregar
            // 
            BtnAgregar.Anchor = AnchorStyles.Bottom;
            BtnAgregar.IconChar = FontAwesome.Sharp.IconChar.FileCirclePlus;
            BtnAgregar.IconColor = Color.Black;
            BtnAgregar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnAgregar.IconSize = 40;
            BtnAgregar.ImageAlign = ContentAlignment.MiddleLeft;
            BtnAgregar.Location = new Point(1128, 71);
            BtnAgregar.Name = "BtnAgregar";
            BtnAgregar.Size = new Size(101, 43);
            BtnAgregar.TabIndex = 1;
            BtnAgregar.Text = "Agregar";
            BtnAgregar.TextAlign = ContentAlignment.MiddleRight;
            BtnAgregar.UseVisualStyleBackColor = true;
            BtnAgregar.Click += BtnAgregar_Click;
            // 
            // BtnEliminar
            // 
            BtnEliminar.Anchor = AnchorStyles.Bottom;
            BtnEliminar.IconChar = FontAwesome.Sharp.IconChar.Trash;
            BtnEliminar.IconColor = Color.Black;
            BtnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnEliminar.IconSize = 40;
            BtnEliminar.ImageAlign = ContentAlignment.MiddleLeft;
            BtnEliminar.Location = new Point(1128, 174);
            BtnEliminar.Name = "BtnEliminar";
            BtnEliminar.Size = new Size(101, 54);
            BtnEliminar.TabIndex = 2;
            BtnEliminar.Text = "Eliminar";
            BtnEliminar.TextAlign = ContentAlignment.MiddleRight;
            BtnEliminar.UseVisualStyleBackColor = true;
            BtnEliminar.Click += BtnEliminar_Click;
            // 
            // BtnModificar
            // 
            BtnModificar.Anchor = AnchorStyles.Bottom;
            BtnModificar.IconChar = FontAwesome.Sharp.IconChar.Pencil;
            BtnModificar.IconColor = Color.Black;
            BtnModificar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnModificar.IconSize = 40;
            BtnModificar.ImageAlign = ContentAlignment.MiddleLeft;
            BtnModificar.Location = new Point(1128, 120);
            BtnModificar.Name = "BtnModificar";
            BtnModificar.Size = new Size(101, 48);
            BtnModificar.TabIndex = 3;
            BtnModificar.Text = "Modificar";
            BtnModificar.TextAlign = ContentAlignment.MiddleRight;
            BtnModificar.UseVisualStyleBackColor = true;
            BtnModificar.Click += BtnModificar_Click;
            // 
            // BtnSalir
            // 
            BtnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnSalir.IconChar = FontAwesome.Sharp.IconChar.DoorOpen;
            BtnSalir.IconColor = Color.Black;
            BtnSalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnSalir.IconSize = 40;
            BtnSalir.ImageAlign = ContentAlignment.MiddleLeft;
            BtnSalir.Location = new Point(1154, 323);
            BtnSalir.Name = "BtnSalir";
            BtnSalir.Size = new Size(81, 43);
            BtnSalir.TabIndex = 4;
            BtnSalir.Text = "Salir";
            BtnSalir.TextAlign = ContentAlignment.MiddleRight;
            BtnSalir.UseVisualStyleBackColor = true;
            BtnSalir.Click += BtnSalir_Click;
            // 
            // TabControl
            // 
            TabControl.Controls.Add(tabPageLista);
            TabControl.Controls.Add(tabPageAgregar_Editar);
            TabControl.Location = new Point(3, 62);
            TabControl.Name = "TabControl";
            TabControl.SelectedIndex = 0;
            TabControl.Size = new Size(1249, 400);
            TabControl.TabIndex = 6;
            // 
            // tabPageLista
            // 
            tabPageLista.Controls.Add(BtnRestaurar);
            tabPageLista.Controls.Add(checkBoxEliminados);
            tabPageLista.Controls.Add(BtnBuscar);
            tabPageLista.Controls.Add(TxtBuscar);
            tabPageLista.Controls.Add(LbBuscar);
            tabPageLista.Controls.Add(BtnEliminar);
            tabPageLista.Controls.Add(BtnModificar);
            tabPageLista.Controls.Add(BtnSalir);
            tabPageLista.Controls.Add(GridData);
            tabPageLista.Controls.Add(BtnAgregar);
            tabPageLista.Location = new Point(4, 24);
            tabPageLista.Name = "tabPageLista";
            tabPageLista.Padding = new Padding(3);
            tabPageLista.Size = new Size(1241, 372);
            tabPageLista.TabIndex = 0;
            tabPageLista.Text = "Lista";
            tabPageLista.UseVisualStyleBackColor = true;
            // 
            // BtnRestaurar
            // 
            BtnRestaurar.Anchor = AnchorStyles.Bottom;
            BtnRestaurar.IconChar = FontAwesome.Sharp.IconChar.Trash;
            BtnRestaurar.IconColor = Color.Black;
            BtnRestaurar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnRestaurar.IconSize = 40;
            BtnRestaurar.ImageAlign = ContentAlignment.MiddleLeft;
            BtnRestaurar.Location = new Point(1128, 234);
            BtnRestaurar.Name = "BtnRestaurar";
            BtnRestaurar.Size = new Size(101, 54);
            BtnRestaurar.TabIndex = 13;
            BtnRestaurar.Text = "Restaurar";
            BtnRestaurar.TextAlign = ContentAlignment.MiddleRight;
            BtnRestaurar.UseVisualStyleBackColor = true;
            BtnRestaurar.Click += BtnRestaurar_Click;
            // 
            // checkBoxEliminados
            // 
            checkBoxEliminados.AutoSize = true;
            checkBoxEliminados.Location = new Point(768, 32);
            checkBoxEliminados.Name = "checkBoxEliminados";
            checkBoxEliminados.Size = new Size(103, 19);
            checkBoxEliminados.TabIndex = 12;
            checkBoxEliminados.Text = "Ver Eliminados";
            checkBoxEliminados.UseVisualStyleBackColor = true;
            checkBoxEliminados.CheckedChanged += checkBoxEliminados_CheckedChanged;
            // 
            // BtnBuscar
            // 
            BtnBuscar.Anchor = AnchorStyles.Bottom;
            BtnBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            BtnBuscar.IconColor = Color.Black;
            BtnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnBuscar.IconSize = 40;
            BtnBuscar.ImageAlign = ContentAlignment.MiddleLeft;
            BtnBuscar.Location = new Point(1128, 15);
            BtnBuscar.Name = "BtnBuscar";
            BtnBuscar.Size = new Size(101, 50);
            BtnBuscar.TabIndex = 10;
            BtnBuscar.Text = "Buscar";
            BtnBuscar.TextAlign = ContentAlignment.MiddleRight;
            BtnBuscar.UseVisualStyleBackColor = true;
            BtnBuscar.Click += BtnBuscar_Click;
            // 
            // TxtBuscar
            // 
            TxtBuscar.Location = new Point(57, 30);
            TxtBuscar.Name = "TxtBuscar";
            TxtBuscar.Size = new Size(659, 23);
            TxtBuscar.TabIndex = 9;
            TxtBuscar.TextChanged += TxtBuscar_TextChanged;
            // 
            // LbBuscar
            // 
            LbBuscar.Location = new Point(6, 33);
            LbBuscar.Name = "LbBuscar";
            LbBuscar.Size = new Size(45, 23);
            LbBuscar.TabIndex = 8;
            LbBuscar.Text = "Buscar:";
            // 
            // tabPageAgregar_Editar
            // 
            tabPageAgregar_Editar.Controls.Add(ComboCategorias);
            tabPageAgregar_Editar.Controls.Add(label);
            tabPageAgregar_Editar.Controls.Add(label4);
            tabPageAgregar_Editar.Controls.Add(NumericStock);
            tabPageAgregar_Editar.Controls.Add(DuracionMinutos);
            tabPageAgregar_Editar.Controls.Add(NumericPrecio);
            tabPageAgregar_Editar.Controls.Add(BtnNombre);
            tabPageAgregar_Editar.Controls.Add(nombre);
            tabPageAgregar_Editar.Controls.Add(BtnCancelar);
            tabPageAgregar_Editar.Controls.Add(BtnGuardar);
            tabPageAgregar_Editar.Location = new Point(4, 24);
            tabPageAgregar_Editar.Name = "tabPageAgregar_Editar";
            tabPageAgregar_Editar.Padding = new Padding(3);
            tabPageAgregar_Editar.Size = new Size(1241, 372);
            tabPageAgregar_Editar.TabIndex = 1;
            tabPageAgregar_Editar.Text = "Agregar/Editar";
            tabPageAgregar_Editar.UseVisualStyleBackColor = true;
            // 
            // ComboCategorias
            // 
            ComboCategorias.FormattingEnabled = true;
            ComboCategorias.Location = new Point(460, 81);
            ComboCategorias.Name = "ComboCategorias";
            ComboCategorias.Size = new Size(121, 23);
            ComboCategorias.TabIndex = 25;
            ComboCategorias.SelectedIndexChanged += ComboCategorias_SelectedIndexChanged;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(391, 84);
            label.Name = "label";
            label.Size = new Size(63, 15);
            label.TabIndex = 24;
            label.Text = "Categorias";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(601, 83);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 20;
            label4.Text = "Stock";
            // 
            // NumericStock
            // 
            NumericStock.Location = new Point(643, 81);
            NumericStock.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            NumericStock.Name = "NumericStock";
            NumericStock.Size = new Size(77, 23);
            NumericStock.TabIndex = 19;
            NumericStock.TextAlign = HorizontalAlignment.Right;
            // 
            // DuracionMinutos
            // 
            DuracionMinutos.AutoSize = true;
            DuracionMinutos.Location = new Point(249, 86);
            DuracionMinutos.Name = "DuracionMinutos";
            DuracionMinutos.Size = new Size(40, 15);
            DuracionMinutos.TabIndex = 14;
            DuracionMinutos.Text = "Precio";
            // 
            // NumericPrecio
            // 
            NumericPrecio.DecimalPlaces = 2;
            NumericPrecio.Location = new Point(295, 84);
            NumericPrecio.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            NumericPrecio.Name = "NumericPrecio";
            NumericPrecio.Size = new Size(77, 23);
            NumericPrecio.TabIndex = 13;
            // 
            // BtnNombre
            // 
            BtnNombre.Location = new Point(295, 26);
            BtnNombre.Name = "BtnNombre";
            BtnNombre.Size = new Size(397, 23);
            BtnNombre.TabIndex = 10;
            // 
            // nombre
            // 
            nombre.AutoSize = true;
            nombre.Location = new Point(235, 29);
            nombre.Name = "nombre";
            nombre.Size = new Size(51, 15);
            nombre.TabIndex = 4;
            nombre.Text = "Nombre";
            // 
            // BtnCancelar
            // 
            BtnCancelar.Anchor = AnchorStyles.Bottom;
            BtnCancelar.IconChar = FontAwesome.Sharp.IconChar.Cancel;
            BtnCancelar.IconColor = Color.Black;
            BtnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnCancelar.IconSize = 40;
            BtnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
            BtnCancelar.Location = new Point(591, 303);
            BtnCancelar.Name = "BtnCancelar";
            BtnCancelar.Size = new Size(101, 43);
            BtnCancelar.TabIndex = 3;
            BtnCancelar.Text = "cancelar";
            BtnCancelar.TextAlign = ContentAlignment.MiddleRight;
            BtnCancelar.UseVisualStyleBackColor = true;
            BtnCancelar.Click += BtnCancelar_Click;
            // 
            // BtnGuardar
            // 
            BtnGuardar.Anchor = AnchorStyles.Bottom;
            BtnGuardar.IconChar = FontAwesome.Sharp.IconChar.Save;
            BtnGuardar.IconColor = Color.Black;
            BtnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnGuardar.IconSize = 38;
            BtnGuardar.ImageAlign = ContentAlignment.MiddleLeft;
            BtnGuardar.Location = new Point(465, 303);
            BtnGuardar.Name = "BtnGuardar";
            BtnGuardar.Size = new Size(104, 43);
            BtnGuardar.TabIndex = 2;
            BtnGuardar.Text = "Guardar ";
            BtnGuardar.TextAlign = ContentAlignment.MiddleRight;
            BtnGuardar.UseVisualStyleBackColor = true;
            BtnGuardar.Click += BtnGuardar_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-2, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1254, 58);
            panel1.TabIndex = 7;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(5, 0);
            label1.Name = "label1";
            label1.Size = new Size(204, 51);
            label1.TabIndex = 0;
            label1.Text = "Productos";
            // 
            // LabelStatusMessage
            // 
            LabelStatusMessage.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            LabelStatusMessage.Location = new Point(0, 467);
            LabelStatusMessage.Name = "LabelStatusMessage";
            LabelStatusMessage.Size = new Size(1252, 22);
            LabelStatusMessage.TabIndex = 8;
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(0, 17);
            // 
            // TimerStatusBar
            // 
            TimerStatusBar.Interval = 3000;
            TimerStatusBar.Tick += TimerStatusBar_Tick;
            // 
            // ProductosView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1252, 489);
            Controls.Add(LabelStatusMessage);
            Controls.Add(panel1);
            Controls.Add(TabControl);
            Name = "ProductosView";
            Text = "ProductosView";
            ((System.ComponentModel.ISupportInitialize)GridData).EndInit();
            TabControl.ResumeLayout(false);
            tabPageLista.ResumeLayout(false);
            tabPageLista.PerformLayout();
            tabPageAgregar_Editar.ResumeLayout(false);
            tabPageAgregar_Editar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NumericStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumericPrecio).EndInit();
            panel1.ResumeLayout(false);
            LabelStatusMessage.ResumeLayout(false);
            LabelStatusMessage.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView GridData;
        private FontAwesome.Sharp.IconButton BtnAgregar;
        private FontAwesome.Sharp.IconButton BtnEliminar;
        private FontAwesome.Sharp.IconButton BtnModificar;
        private FontAwesome.Sharp.IconButton BtnSalir;
        private TabControl TabControl;
        private TabPage tabPageLista;
        private TabPage tabPageAgregar_Editar;
        private Panel panel1;
        private Label label1;
        private Label LbBuscar;
        private TextBox TxtBuscar;
        private FontAwesome.Sharp.IconButton BtnCancelar;
        private FontAwesome.Sharp.IconButton BtnGuardar;
        private TextBox BtnNombre;
        private Label nombre;
        private FontAwesome.Sharp.IconButton BtnBuscar;
        private StatusStrip LabelStatusMessage;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Timer TimerStatusBar;
        private CheckBox checkBoxEliminados;
        private FontAwesome.Sharp.IconButton BtnRestaurar;
        private Label DuracionMinutos;
        private NumericUpDown NumericPrecio;
        private Label label4;
        private NumericUpDown NumericStock;
        private Label label;
        private ComboBox ComboCategorias;
    }
}