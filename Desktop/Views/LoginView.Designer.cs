namespace Desktop.Views
{
    partial class LoginView
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
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            checkBox = new CheckBox();
            TxtInisioSesion = new FontAwesome.Sharp.IconButton();
            TxtCerrarSesion = new FontAwesome.Sharp.IconButton();
            TxtEmail = new TextBox();
            TxtPassword = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.freepik_br_14b71b36_615e_464a_9730_ca9158fb72c0;
            pictureBox1.Location = new Point(-2, -2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(371, 294);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(470, 67);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 1;
            label1.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(449, 120);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 2;
            label2.Text = "Password";
            // 
            // checkBox
            // 
            checkBox.AutoSize = true;
            checkBox.Location = new Point(545, 158);
            checkBox.Name = "checkBox";
            checkBox.Size = new Size(105, 19);
            checkBox.TabIndex = 3;
            checkBox.Text = "Ver Contraseña";
            checkBox.UseVisualStyleBackColor = true;
            checkBox.CheckedChanged += checkBox_CheckedChanged;
            // 
            // TxtInisioSesion
            // 
            TxtInisioSesion.IconChar = FontAwesome.Sharp.IconChar.User;
            TxtInisioSesion.IconColor = Color.Black;
            TxtInisioSesion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            TxtInisioSesion.IconSize = 20;
            TxtInisioSesion.ImageAlign = ContentAlignment.MiddleLeft;
            TxtInisioSesion.Location = new Point(470, 218);
            TxtInisioSesion.Name = "TxtInisioSesion";
            TxtInisioSesion.Size = new Size(112, 28);
            TxtInisioSesion.TabIndex = 4;
            TxtInisioSesion.Text = "Iniciar Sesion";
            TxtInisioSesion.TextAlign = ContentAlignment.MiddleRight;
            TxtInisioSesion.UseVisualStyleBackColor = true;
            TxtInisioSesion.Click += TxtInisioSesion_Click;
            // 
            // TxtCerrarSesion
            // 
            TxtCerrarSesion.IconChar = FontAwesome.Sharp.IconChar.Close;
            TxtCerrarSesion.IconColor = Color.Black;
            TxtCerrarSesion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            TxtCerrarSesion.IconSize = 20;
            TxtCerrarSesion.ImageAlign = ContentAlignment.MiddleLeft;
            TxtCerrarSesion.Location = new Point(590, 218);
            TxtCerrarSesion.Name = "TxtCerrarSesion";
            TxtCerrarSesion.Size = new Size(112, 28);
            TxtCerrarSesion.TabIndex = 5;
            TxtCerrarSesion.Text = "Cerrar Sesion";
            TxtCerrarSesion.TextAlign = ContentAlignment.MiddleRight;
            TxtCerrarSesion.UseVisualStyleBackColor = true;
            TxtCerrarSesion.Click += TxtCerrarSesion_Click;
            // 
            // TxtEmail
            // 
            TxtEmail.Location = new Point(512, 64);
            TxtEmail.Name = "TxtEmail";
            TxtEmail.Size = new Size(180, 23);
            TxtEmail.TabIndex = 6;
            // 
            // TxtPassword
            // 
            TxtPassword.Location = new Point(512, 117);
            TxtPassword.Name = "TxtPassword";
            TxtPassword.PasswordChar = '*';
            TxtPassword.Size = new Size(180, 23);
            TxtPassword.TabIndex = 7;
            // 
            // LoginView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(750, 292);
            Controls.Add(TxtPassword);
            Controls.Add(TxtEmail);
            Controls.Add(TxtCerrarSesion);
            Controls.Add(TxtInisioSesion);
            Controls.Add(checkBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginView";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private CheckBox checkBox;
        private FontAwesome.Sharp.IconButton TxtInisioSesion;
        private FontAwesome.Sharp.IconButton TxtCerrarSesion;
        private TextBox TxtEmail;
        private TextBox TxtPassword;
    }
}