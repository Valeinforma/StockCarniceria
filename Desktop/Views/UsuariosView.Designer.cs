namespace Desktop.Views
{
    partial class UsuariosView
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
            TabControl = new TabControl();
            TabPageLista = new TabPage();
            BtnRestaurar = new FontAwesome.Sharp.IconButton();
            checkVerEliminados = new CheckBox();
            BtnBuscar = new FontAwesome.Sharp.IconButton();
            TxtBuscar = new TextBox();
            label2 = new Label();
            BtnSalir = new FontAwesome.Sharp.IconButton();
            DataGrid = new DataGridView();
            BtnEliminar = new FontAwesome.Sharp.IconButton();
            BtnAgregar = new FontAwesome.Sharp.IconButton();
            BtnModificar = new FontAwesome.Sharp.IconButton();
            TabPageAgregarEditar = new TabPage();
            TxtPassword2 = new TextBox();
            LabelPassword2 = new Label();
            TextPassword = new TextBox();
            LabelPassword = new Label();
            TxtEmail = new TextBox();
            label5 = new Label();
            TxtNombre = new TextBox();
            label3 = new Label();
            BtnCancelar = new FontAwesome.Sharp.IconButton();
            BtnGuardar = new FontAwesome.Sharp.IconButton();
            panel1 = new Panel();
            label1 = new Label();
            statusStrip1 = new StatusStrip();
            LabelStatusMessage = new ToolStripStatusLabel();
            TimerStatusBar = new System.Windows.Forms.Timer(components);
            ComboTiposDeUsuarios = new ComboBox();
            label8 = new Label();
            TabControl.SuspendLayout();
            TabPageLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGrid).BeginInit();
            TabPageAgregarEditar.SuspendLayout();
            panel1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // TabControl
            // 
            TabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TabControl.Controls.Add(TabPageLista);
            TabControl.Controls.Add(TabPageAgregarEditar);
            TabControl.Location = new Point(15, 50);
            TabControl.Margin = new Padding(2);
            TabControl.Name = "TabControl";
            TabControl.SelectedIndex = 0;
            TabControl.Size = new Size(1207, 363);
            TabControl.TabIndex = 0;
            // 
            // TabPageLista
            // 
            TabPageLista.Controls.Add(BtnRestaurar);
            TabPageLista.Controls.Add(checkVerEliminados);
            TabPageLista.Controls.Add(BtnBuscar);
            TabPageLista.Controls.Add(TxtBuscar);
            TabPageLista.Controls.Add(label2);
            TabPageLista.Controls.Add(BtnSalir);
            TabPageLista.Controls.Add(DataGrid);
            TabPageLista.Controls.Add(BtnEliminar);
            TabPageLista.Controls.Add(BtnAgregar);
            TabPageLista.Controls.Add(BtnModificar);
            TabPageLista.Location = new Point(4, 24);
            TabPageLista.Margin = new Padding(2);
            TabPageLista.Name = "TabPageLista";
            TabPageLista.Padding = new Padding(2);
            TabPageLista.Size = new Size(1199, 335);
            TabPageLista.TabIndex = 1;
            TabPageLista.Text = "Lista";
            TabPageLista.UseVisualStyleBackColor = true;
            // 
            // BtnRestaurar
            // 
            BtnRestaurar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnRestaurar.IconChar = FontAwesome.Sharp.IconChar.Reply;
            BtnRestaurar.IconColor = Color.Black;
            BtnRestaurar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnRestaurar.ImageAlign = ContentAlignment.MiddleLeft;
            BtnRestaurar.Location = new Point(867, 155);
            BtnRestaurar.Margin = new Padding(2);
            BtnRestaurar.Name = "BtnRestaurar";
            BtnRestaurar.Size = new Size(95, 32);
            BtnRestaurar.TabIndex = 6;
            BtnRestaurar.Text = "&Restaurar";
            BtnRestaurar.TextAlign = ContentAlignment.MiddleRight;
            BtnRestaurar.UseVisualStyleBackColor = true;
            BtnRestaurar.Visible = false;
            BtnRestaurar.Click += BtnRestaurar_Click;
            // 
            // checkVerEliminados
            // 
            checkVerEliminados.AutoSize = true;
            checkVerEliminados.Location = new Point(618, 16);
            checkVerEliminados.Margin = new Padding(2);
            checkVerEliminados.Name = "checkVerEliminados";
            checkVerEliminados.Size = new Size(103, 19);
            checkVerEliminados.TabIndex = 1;
            checkVerEliminados.Text = "Ver eliminados";
            checkVerEliminados.UseVisualStyleBackColor = true;
            checkVerEliminados.CheckedChanged += checkVerEliminados_CheckedChanged;
            // 
            // BtnBuscar
            // 
            BtnBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            BtnBuscar.IconColor = Color.Black;
            BtnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnBuscar.ImageAlign = ContentAlignment.MiddleLeft;
            BtnBuscar.Location = new Point(867, 5);
            BtnBuscar.Margin = new Padding(2);
            BtnBuscar.Name = "BtnBuscar";
            BtnBuscar.Size = new Size(95, 32);
            BtnBuscar.TabIndex = 2;
            BtnBuscar.Text = "&Buscar";
            BtnBuscar.TextAlign = ContentAlignment.MiddleRight;
            BtnBuscar.UseVisualStyleBackColor = true;
            BtnBuscar.Click += BtnBuscar_Click;
            // 
            // TxtBuscar
            // 
            TxtBuscar.Location = new Point(60, 13);
            TxtBuscar.Margin = new Padding(2);
            TxtBuscar.Name = "TxtBuscar";
            TxtBuscar.Size = new Size(546, 23);
            TxtBuscar.TabIndex = 0;
            TxtBuscar.TextChanged += TxtBuscar_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(4, 14);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(45, 15);
            label2.TabIndex = 13;
            label2.Text = "Buscar:";
            // 
            // BtnSalir
            // 
            BtnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnSalir.IconChar = FontAwesome.Sharp.IconChar.DoorOpen;
            BtnSalir.IconColor = Color.Black;
            BtnSalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnSalir.ImageAlign = ContentAlignment.MiddleLeft;
            BtnSalir.Location = new Point(867, 229);
            BtnSalir.Margin = new Padding(2);
            BtnSalir.Name = "BtnSalir";
            BtnSalir.Size = new Size(95, 31);
            BtnSalir.TabIndex = 7;
            BtnSalir.Text = "Salir";
            BtnSalir.TextAlign = ContentAlignment.MiddleRight;
            BtnSalir.UseVisualStyleBackColor = true;
            BtnSalir.Click += BtnSalir_Click;
            // 
            // DataGrid
            // 
            DataGrid.AllowUserToAddRows = false;
            DataGrid.AllowUserToDeleteRows = false;
            DataGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGrid.Location = new Point(4, 37);
            DataGrid.Margin = new Padding(2);
            DataGrid.MultiSelect = false;
            DataGrid.Name = "DataGrid";
            DataGrid.ReadOnly = true;
            DataGrid.RowHeadersWidth = 62;
            DataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGrid.Size = new Size(853, 230);
            DataGrid.TabIndex = 7;
            DataGrid.SelectionChanged += GridPeliculas_SelectionChanged_1;
            // 
            // BtnEliminar
            // 
            BtnEliminar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnEliminar.IconChar = FontAwesome.Sharp.IconChar.Trash;
            BtnEliminar.IconColor = Color.Black;
            BtnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnEliminar.ImageAlign = ContentAlignment.MiddleLeft;
            BtnEliminar.Location = new Point(867, 120);
            BtnEliminar.Margin = new Padding(2);
            BtnEliminar.Name = "BtnEliminar";
            BtnEliminar.Size = new Size(95, 32);
            BtnEliminar.TabIndex = 5;
            BtnEliminar.Text = "&Eliminar";
            BtnEliminar.TextAlign = ContentAlignment.MiddleRight;
            BtnEliminar.UseVisualStyleBackColor = true;
            BtnEliminar.Click += BtnEliminar_Click_1;
            // 
            // BtnAgregar
            // 
            BtnAgregar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnAgregar.IconChar = FontAwesome.Sharp.IconChar.FileCirclePlus;
            BtnAgregar.IconColor = Color.Black;
            BtnAgregar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnAgregar.ImageAlign = ContentAlignment.MiddleLeft;
            BtnAgregar.Location = new Point(867, 50);
            BtnAgregar.Margin = new Padding(2);
            BtnAgregar.Name = "BtnAgregar";
            BtnAgregar.Size = new Size(95, 32);
            BtnAgregar.TabIndex = 3;
            BtnAgregar.Text = "&Agregar";
            BtnAgregar.TextAlign = ContentAlignment.MiddleRight;
            BtnAgregar.UseVisualStyleBackColor = true;
            BtnAgregar.Click += BtnAgregar_Click;
            // 
            // BtnModificar
            // 
            BtnModificar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnModificar.IconChar = FontAwesome.Sharp.IconChar.Pencil;
            BtnModificar.IconColor = Color.Black;
            BtnModificar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnModificar.ImageAlign = ContentAlignment.MiddleLeft;
            BtnModificar.Location = new Point(867, 86);
            BtnModificar.Margin = new Padding(2);
            BtnModificar.Name = "BtnModificar";
            BtnModificar.Size = new Size(95, 30);
            BtnModificar.TabIndex = 4;
            BtnModificar.Text = "&Modificar";
            BtnModificar.TextAlign = ContentAlignment.MiddleRight;
            BtnModificar.UseVisualStyleBackColor = true;
            BtnModificar.Click += BtnModificar_Click;
            // 
            // TabPageAgregarEditar
            // 
            TabPageAgregarEditar.Controls.Add(ComboTiposDeUsuarios);
            TabPageAgregarEditar.Controls.Add(label8);
            TabPageAgregarEditar.Controls.Add(TxtPassword2);
            TabPageAgregarEditar.Controls.Add(LabelPassword2);
            TabPageAgregarEditar.Controls.Add(TextPassword);
            TabPageAgregarEditar.Controls.Add(LabelPassword);
            TabPageAgregarEditar.Controls.Add(TxtEmail);
            TabPageAgregarEditar.Controls.Add(label5);
            TabPageAgregarEditar.Controls.Add(TxtNombre);
            TabPageAgregarEditar.Controls.Add(label3);
            TabPageAgregarEditar.Controls.Add(BtnCancelar);
            TabPageAgregarEditar.Controls.Add(BtnGuardar);
            TabPageAgregarEditar.Location = new Point(4, 24);
            TabPageAgregarEditar.Margin = new Padding(2);
            TabPageAgregarEditar.Name = "TabPageAgregarEditar";
            TabPageAgregarEditar.Padding = new Padding(2);
            TabPageAgregarEditar.Size = new Size(1199, 335);
            TabPageAgregarEditar.TabIndex = 0;
            TabPageAgregarEditar.Text = "Agregar/Editar";
            TabPageAgregarEditar.UseVisualStyleBackColor = true;
            // 
            // TxtPassword2
            // 
            TxtPassword2.Location = new Point(241, 124);
            TxtPassword2.Margin = new Padding(2);
            TxtPassword2.Name = "TxtPassword2";
            TxtPassword2.PasswordChar = '*';
            TxtPassword2.PlaceholderText = "Minimo 6 Caracteres";
            TxtPassword2.Size = new Size(792, 23);
            TxtPassword2.TabIndex = 35;
            // 
            // LabelPassword2
            // 
            LabelPassword2.Location = new Point(52, 124);
            LabelPassword2.Margin = new Padding(2, 0, 2, 0);
            LabelPassword2.Name = "LabelPassword2";
            LabelPassword2.Size = new Size(190, 23);
            LabelPassword2.TabIndex = 36;
            LabelPassword2.Text = "Repetir Contraseña:";
            LabelPassword2.TextAlign = ContentAlignment.TopRight;
            // 
            // TextPassword
            // 
            TextPassword.Location = new Point(241, 87);
            TextPassword.Margin = new Padding(2);
            TextPassword.Name = "TextPassword";
            TextPassword.PasswordChar = '*';
            TextPassword.PlaceholderText = "Minimo 6 Caracteres";
            TextPassword.Size = new Size(792, 23);
            TextPassword.TabIndex = 33;
            // 
            // LabelPassword
            // 
            LabelPassword.Location = new Point(74, 90);
            LabelPassword.Margin = new Padding(2, 0, 2, 0);
            LabelPassword.Name = "LabelPassword";
            LabelPassword.Size = new Size(163, 23);
            LabelPassword.TabIndex = 34;
            LabelPassword.Text = "Contraseña Anterior:";
            LabelPassword.TextAlign = ContentAlignment.TopRight;
            // 
            // TxtEmail
            // 
            TxtEmail.Location = new Point(241, 44);
            TxtEmail.Margin = new Padding(2);
            TxtEmail.Name = "TxtEmail";
            TxtEmail.Size = new Size(792, 23);
            TxtEmail.TabIndex = 31;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(195, 52);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(39, 15);
            label5.TabIndex = 32;
            label5.Text = "Email:";
            // 
            // TxtNombre
            // 
            TxtNombre.Location = new Point(241, 6);
            TxtNombre.Margin = new Padding(2);
            TxtNombre.Name = "TxtNombre";
            TxtNombre.Size = new Size(792, 23);
            TxtNombre.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(180, 9);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 0;
            label3.Text = "Nombre:";
            // 
            // BtnCancelar
            // 
            BtnCancelar.Anchor = AnchorStyles.Bottom;
            BtnCancelar.IconChar = FontAwesome.Sharp.IconChar.Cancel;
            BtnCancelar.IconColor = Color.Black;
            BtnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
            BtnCancelar.Location = new Point(562, 237);
            BtnCancelar.Margin = new Padding(2);
            BtnCancelar.Name = "BtnCancelar";
            BtnCancelar.Size = new Size(95, 32);
            BtnCancelar.TabIndex = 8;
            BtnCancelar.Text = "&Cancelar";
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
            BtnGuardar.ImageAlign = ContentAlignment.MiddleLeft;
            BtnGuardar.Location = new Point(422, 237);
            BtnGuardar.Margin = new Padding(2);
            BtnGuardar.Name = "BtnGuardar";
            BtnGuardar.Size = new Size(95, 32);
            BtnGuardar.TabIndex = 7;
            BtnGuardar.Text = "&Guardar";
            BtnGuardar.TextAlign = ContentAlignment.MiddleRight;
            BtnGuardar.UseVisualStyleBackColor = true;
            BtnGuardar.Click += BtnGuardar_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-2, -1);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1234, 47);
            panel1.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(17, 7);
            label1.Name = "label1";
            label1.Size = new Size(130, 31);
            label1.TabIndex = 1;
            label1.Text = "Usuarios";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { LabelStatusMessage });
            statusStrip1.Location = new Point(0, 423);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 10, 0);
            statusStrip1.Size = new Size(1190, 22);
            statusStrip1.TabIndex = 8;
            statusStrip1.Text = "statusStrip1";
            // 
            // LabelStatusMessage
            // 
            LabelStatusMessage.Name = "LabelStatusMessage";
            LabelStatusMessage.Size = new Size(0, 17);
            // 
            // TimerStatusBar
            // 
            TimerStatusBar.Interval = 5000;
            TimerStatusBar.Tick += TimerStatusBar_Tick;
            // 
            // ComboTiposDeUsuarios
            // 
            ComboTiposDeUsuarios.FormattingEnabled = true;
            ComboTiposDeUsuarios.Location = new Point(241, 168);
            ComboTiposDeUsuarios.Margin = new Padding(2);
            ComboTiposDeUsuarios.Name = "ComboTiposDeUsuarios";
            ComboTiposDeUsuarios.Size = new Size(215, 23);
            ComboTiposDeUsuarios.TabIndex = 38;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(127, 168);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(91, 15);
            label8.TabIndex = 37;
            label8.Text = "Tipo de usuario:";
            // 
            // UsuariosView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1190, 445);
            Controls.Add(statusStrip1);
            Controls.Add(panel1);
            Controls.Add(TabControl);
            Margin = new Padding(2);
            Name = "UsuariosView";
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;
            TabControl.ResumeLayout(false);
            TabPageLista.ResumeLayout(false);
            TabPageLista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DataGrid).EndInit();
            TabPageAgregarEditar.ResumeLayout(false);
            TabPageAgregarEditar.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TabControl TabControl;
        private TabPage TabPageLista;
        private TabPage TabPageAgregarEditar;
        private Panel panel1;
        private Label label1;
        private FontAwesome.Sharp.IconButton BtnSalir;
        private DataGridView DataGrid;
        private FontAwesome.Sharp.IconButton BtnEliminar;
        private FontAwesome.Sharp.IconButton BtnAgregar;
        private FontAwesome.Sharp.IconButton BtnModificar;
        private Label label2;
        private FontAwesome.Sharp.IconButton BtnBuscar;
        private TextBox TxtBuscar;
        private FontAwesome.Sharp.IconButton BtnCancelar;
        private FontAwesome.Sharp.IconButton BtnGuardar;
        private TextBox TxtNombre;
        private Label label3;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel LabelStatusMessage;
        private System.Windows.Forms.Timer TimerStatusBar;
        private FontAwesome.Sharp.IconButton BtnRestaurar;
        private CheckBox checkVerEliminados;
        private TextBox TxtEmail;
        private Label label5;
        private TextBox TextPassword;
        private Label LabelPassword;
        private TextBox TxtPassword2;
        private Label LabelPassword2;
        private ComboBox ComboTiposDeUsuarios;
        private Label label8;
    }
}