namespace GS_Factura
{
    partial class Notificaciones
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
            this.components = new System.ComponentModel.Container();
            this.LinAlertBox = new System.Windows.Forms.Panel();
            this.LblTextAlertBox = new System.Windows.Forms.Label();
            this.LblTitleAlertBox = new System.Windows.Forms.Label();
            this.PicAlertBox = new System.Windows.Forms.PictureBox();
            this.timerAnimation = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.PicCerrar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PicAlertBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicCerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // LinAlertBox
            // 
            this.LinAlertBox.BackColor = System.Drawing.Color.Black;
            this.LinAlertBox.Location = new System.Drawing.Point(0, 73);
            this.LinAlertBox.Name = "LinAlertBox";
            this.LinAlertBox.Size = new System.Drawing.Size(5, 6);
            this.LinAlertBox.TabIndex = 8;
            // 
            // LblTextAlertBox
            // 
            this.LblTextAlertBox.AutoSize = true;
            this.LblTextAlertBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTextAlertBox.Location = new System.Drawing.Point(69, 44);
            this.LblTextAlertBox.Name = "LblTextAlertBox";
            this.LblTextAlertBox.Size = new System.Drawing.Size(128, 23);
            this.LblTextAlertBox.TabIndex = 7;
            this.LblTextAlertBox.Text = "TextAlertBox";
            // 
            // LblTitleAlertBox
            // 
            this.LblTitleAlertBox.AutoSize = true;
            this.LblTitleAlertBox.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitleAlertBox.Location = new System.Drawing.Point(69, 10);
            this.LblTitleAlertBox.Name = "LblTitleAlertBox";
            this.LblTitleAlertBox.Size = new System.Drawing.Size(180, 34);
            this.LblTitleAlertBox.TabIndex = 6;
            this.LblTitleAlertBox.Text = "TitleAlertBox";
            // 
            // PicAlertBox
            // 
            this.PicAlertBox.Location = new System.Drawing.Point(13, 13);
            this.PicAlertBox.Name = "PicAlertBox";
            this.PicAlertBox.Size = new System.Drawing.Size(50, 50);
            this.PicAlertBox.TabIndex = 5;
            this.PicAlertBox.TabStop = false;
            // 
            // timerAnimation
            // 
            this.timerAnimation.Interval = 10;
            this.timerAnimation.Tick += new System.EventHandler(this.timerAnimation_Tick);
            // 
            // timer1
            // 
            this.timer1.Interval = 5;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // PicCerrar
            // 
            this.PicCerrar.Image = global::GS_Factura.Properties.Resources.Cerrar;
            this.PicCerrar.Location = new System.Drawing.Point(467, 1);
            this.PicCerrar.Name = "PicCerrar";
            this.PicCerrar.Size = new System.Drawing.Size(32, 30);
            this.PicCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicCerrar.TabIndex = 14;
            this.PicCerrar.TabStop = false;
            this.PicCerrar.Click += new System.EventHandler(this.PicCerrar_Click);
            // 
            // Notificaciones
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 80);
            this.Controls.Add(this.PicCerrar);
            this.Controls.Add(this.LinAlertBox);
            this.Controls.Add(this.LblTextAlertBox);
            this.Controls.Add(this.LblTitleAlertBox);
            this.Controls.Add(this.PicAlertBox);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Notificaciones";
            this.Text = "Notificaciones";
            this.Load += new System.EventHandler(this.Notificaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicAlertBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicCerrar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LblTextAlertBox;
        private System.Windows.Forms.Label LblTitleAlertBox;
        private System.Windows.Forms.PictureBox PicAlertBox;
        private System.Windows.Forms.Timer timerAnimation;
        public System.Windows.Forms.Panel LinAlertBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox PicCerrar;
        
        //public Notificaciones.ellipse ellipse;
    }
}