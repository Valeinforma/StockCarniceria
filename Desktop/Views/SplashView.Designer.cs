namespace Desktop.Views
{
    partial class SplashView
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
            pictureBox1 = new PictureBox();
            progressBar = new ProgressBar();
            TimerSplash = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.CR_259Z;
            pictureBox1.Location = new Point(235, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(274, 271);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // progressBar
            // 
            progressBar.ForeColor = Color.Firebrick;
            progressBar.Location = new Point(12, 250);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(701, 23);
            progressBar.TabIndex = 1;
            // 
            // TimerSplash
            // 
            TimerSplash.Enabled = true;
            TimerSplash.Interval = 300;
            TimerSplash.Tick += timer1_Tick;
            // 
            // SplashView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(725, 285);
            Controls.Add(progressBar);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SplashView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SplashView";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private ProgressBar progressBar;
        private System.Windows.Forms.Timer TimerSplash;
    }
}