namespace GS_Factura
{
    partial class GS_BuscaFactura
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtcedulaCliente = new System.Windows.Forms.TextBox();
            this.btn_busca_factura = new FontAwesome.Sharp.IconButton();
            this.rptFacturaBuscar = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rptFacturaBuscar, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(782, 541);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtcedulaCliente);
            this.panel1.Controls.Add(this.btn_busca_factura);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(782, 40);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(203, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Ingrese el numero de factura";
            // 
            // txtcedulaCliente
            // 
            this.txtcedulaCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtcedulaCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtcedulaCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtcedulaCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcedulaCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcedulaCliente.ForeColor = System.Drawing.Color.DimGray;
            this.txtcedulaCliente.Location = new System.Drawing.Point(31, 10);
            this.txtcedulaCliente.Margin = new System.Windows.Forms.Padding(10);
            this.txtcedulaCliente.Name = "txtcedulaCliente";
            this.txtcedulaCliente.Size = new System.Drawing.Size(159, 23);
            this.txtcedulaCliente.TabIndex = 27;
            // 
            // btn_busca_factura
            // 
            this.btn_busca_factura.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.btn_busca_factura.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_busca_factura.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_busca_factura.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_busca_factura.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_busca_factura.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btn_busca_factura.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.btn_busca_factura.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_busca_factura.IconSize = 20;
            this.btn_busca_factura.Location = new System.Drawing.Point(9, 10);
            this.btn_busca_factura.Margin = new System.Windows.Forms.Padding(0);
            this.btn_busca_factura.Name = "btn_busca_factura";
            this.btn_busca_factura.Size = new System.Drawing.Size(23, 23);
            this.btn_busca_factura.TabIndex = 26;
            this.btn_busca_factura.UseVisualStyleBackColor = false;
            this.btn_busca_factura.Click += new System.EventHandler(this.Btn_busca_factura_Click);
            // 
            // rptFacturaBuscar
            // 
            this.rptFacturaBuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptFacturaBuscar.Location = new System.Drawing.Point(3, 43);
            this.rptFacturaBuscar.Name = "rptFacturaBuscar";
            this.rptFacturaBuscar.ServerReport.BearerToken = null;
            this.rptFacturaBuscar.Size = new System.Drawing.Size(776, 495);
            this.rptFacturaBuscar.TabIndex = 1;
            // 
            // GS_BuscaFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(782, 541);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GS_BuscaFactura";
            this.Text = "GS_BuscaFactura";
            this.Load += new System.EventHandler(this.GS_BuscaFactura_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private Microsoft.Reporting.WinForms.ReportViewer rptFacturaBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtcedulaCliente;
        private FontAwesome.Sharp.IconButton btn_busca_factura;
    }
}