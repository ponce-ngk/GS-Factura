namespace GS_Factura
{
    partial class ProductoVenta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dtgventaproducto = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnsearchProdVenta = new FontAwesome.Sharp.IconButton();
            this.txtbuscarproducto = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgventaproducto)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.panel1.Controls.Add(this.tableLayoutPanel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1025, 364);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.dtgventaproducto, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.panel5, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(16, 81);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.80916F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.19084F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(989, 262);
            this.tableLayoutPanel3.TabIndex = 9;
            // 
            // dtgventaproducto
            // 
            this.dtgventaproducto.AllowUserToAddRows = false;
            this.dtgventaproducto.AllowUserToResizeColumns = false;
            this.dtgventaproducto.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.dtgventaproducto.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dtgventaproducto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgventaproducto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgventaproducto.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgventaproducto.BackgroundColor = System.Drawing.Color.White;
            this.dtgventaproducto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgventaproducto.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dtgventaproducto.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(183)))), ((int)(((byte)(221)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgventaproducto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dtgventaproducto.ColumnHeadersHeight = 29;
            this.dtgventaproducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgventaproducto.DefaultCellStyle = dataGridViewCellStyle7;
            this.dtgventaproducto.EnableHeadersVisualStyles = false;
            this.dtgventaproducto.GridColor = System.Drawing.Color.Gainsboro;
            this.dtgventaproducto.Location = new System.Drawing.Point(0, 65);
            this.dtgventaproducto.Margin = new System.Windows.Forms.Padding(0);
            this.dtgventaproducto.MultiSelect = false;
            this.dtgventaproducto.Name = "dtgventaproducto";
            this.dtgventaproducto.ReadOnly = true;
            this.dtgventaproducto.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(183)))), ((int)(((byte)(221)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgventaproducto.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dtgventaproducto.RowHeadersVisible = false;
            this.dtgventaproducto.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dtgventaproducto.Size = new System.Drawing.Size(989, 197);
            this.dtgventaproducto.TabIndex = 19;
            this.dtgventaproducto.DoubleClick += new System.EventHandler(this.dtgventaproducto_DoubleClick);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(989, 65);
            this.panel5.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Controls.Add(this.btnsearchProdVenta);
            this.panel6.Controls.Add(this.txtbuscarproducto);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(989, 65);
            this.panel6.TabIndex = 4;
            // 
            // btnsearchProdVenta
            // 
            this.btnsearchProdVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(65)))));
            this.btnsearchProdVenta.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnsearchProdVenta.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnsearchProdVenta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnsearchProdVenta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnsearchProdVenta.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnsearchProdVenta.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnsearchProdVenta.IconColor = System.Drawing.Color.White;
            this.btnsearchProdVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnsearchProdVenta.IconSize = 27;
            this.btnsearchProdVenta.Location = new System.Drawing.Point(11, 11);
            this.btnsearchProdVenta.Margin = new System.Windows.Forms.Padding(0);
            this.btnsearchProdVenta.Name = "btnsearchProdVenta";
            this.btnsearchProdVenta.Size = new System.Drawing.Size(44, 34);
            this.btnsearchProdVenta.TabIndex = 26;
            this.btnsearchProdVenta.UseVisualStyleBackColor = false;
            this.btnsearchProdVenta.Click += new System.EventHandler(this.btnsearchProdVenta_Click);
            // 
            // txtbuscarproducto
            // 
            this.txtbuscarproducto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbuscarproducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbuscarproducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbuscarproducto.ForeColor = System.Drawing.Color.Gray;
            this.txtbuscarproducto.Location = new System.Drawing.Point(55, 11);
            this.txtbuscarproducto.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.txtbuscarproducto.Name = "txtbuscarproducto";
            this.txtbuscarproducto.Size = new System.Drawing.Size(917, 34);
            this.txtbuscarproducto.TabIndex = 25;
            this.txtbuscarproducto.Text = "Busca Nombre del Producto...";
            this.txtbuscarproducto.TextChanged += new System.EventHandler(this.txtbuscarproducto_TextChanged);
            this.txtbuscarproducto.Enter += new System.EventHandler(this.txtbuscarproducto_Enter);
            this.txtbuscarproducto.Leave += new System.EventHandler(this.txtbuscarproducto_Leave);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(16, 15);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(989, 60);
            this.panel2.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(13, 0, 13, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(13, 0, 13, 0);
            this.label1.Size = new System.Drawing.Size(980, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "FORMULARIO DE REGISTRO DEL PRODUCTO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProductoVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 364);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductoVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProductoVenta";
            this.Load += new System.EventHandler(this.ProductoVenta_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgventaproducto)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel5;
        private FontAwesome.Sharp.IconButton btnsearchProdVenta;
        private System.Windows.Forms.TextBox txtbuscarproducto;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView dtgventaproducto;
    }
}