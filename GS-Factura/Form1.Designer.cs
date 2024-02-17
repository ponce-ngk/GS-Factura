namespace GS_Factura
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelLayoutMenu = new System.Windows.Forms.TableLayoutPanel();
            this.panelDashCenter = new System.Windows.Forms.Panel();
            this.btnBuscaFactura = new FontAwesome.Sharp.IconButton();
            this.btnVenta = new FontAwesome.Sharp.IconButton();
            this.btnProductos = new FontAwesome.Sharp.IconButton();
            this.btnRegistro = new FontAwesome.Sharp.IconButton();
            this.panelDashHead = new System.Windows.Forms.Panel();
            this.lblNombre = new System.Windows.Forms.Label();
            this.ptmfotouser = new RJCodeAdvance.RJControls.RJCircularPictureBox();
            this.panelDashOut = new System.Windows.Forms.Panel();
            this.btnCerrarsesion = new FontAwesome.Sharp.IconButton();
            this.panelLayoutForms = new System.Windows.Forms.TableLayoutPanel();
            this.panelForms = new System.Windows.Forms.Panel();
            this.panelLayoutFormsHead = new System.Windows.Forms.TableLayoutPanel();
            this.panelDashHeadCenter = new System.Windows.Forms.Panel();
            this.lblEncabezadoGS = new System.Windows.Forms.Label();
            this.panelButtomDash = new System.Windows.Forms.Panel();
            this.btnMenu = new FontAwesome.Sharp.IconButton();
            this.panelLayourMaximizar = new System.Windows.Forms.TableLayoutPanel();
            this.btn_minimizar = new FontAwesome.Sharp.IconButton();
            this.btn_cerrar = new FontAwesome.Sharp.IconButton();
            this.btn_maximizar = new FontAwesome.Sharp.IconButton();
            this.panelLayoutMenu.SuspendLayout();
            this.panelDashCenter.SuspendLayout();
            this.panelDashHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptmfotouser)).BeginInit();
            this.panelDashOut.SuspendLayout();
            this.panelLayoutForms.SuspendLayout();
            this.panelLayoutFormsHead.SuspendLayout();
            this.panelDashHeadCenter.SuspendLayout();
            this.panelButtomDash.SuspendLayout();
            this.panelLayourMaximizar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLayoutMenu
            // 
            this.panelLayoutMenu.ColumnCount = 1;
            this.panelLayoutMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 224F));
            this.panelLayoutMenu.Controls.Add(this.panelDashCenter, 0, 1);
            this.panelLayoutMenu.Controls.Add(this.panelDashHead, 0, 0);
            this.panelLayoutMenu.Controls.Add(this.panelDashOut, 0, 2);
            this.panelLayoutMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLayoutMenu.Location = new System.Drawing.Point(0, 0);
            this.panelLayoutMenu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelLayoutMenu.Name = "panelLayoutMenu";
            this.panelLayoutMenu.RowCount = 3;
            this.panelLayoutMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.panelLayoutMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.panelLayoutMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.panelLayoutMenu.Size = new System.Drawing.Size(224, 1035);
            this.panelLayoutMenu.TabIndex = 0;
            // 
            // panelDashCenter
            // 
            this.panelDashCenter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelDashCenter.Controls.Add(this.btnBuscaFactura);
            this.panelDashCenter.Controls.Add(this.btnVenta);
            this.panelDashCenter.Controls.Add(this.btnProductos);
            this.panelDashCenter.Controls.Add(this.btnRegistro);
            this.panelDashCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDashCenter.Location = new System.Drawing.Point(0, 155);
            this.panelDashCenter.Margin = new System.Windows.Forms.Padding(0);
            this.panelDashCenter.Name = "panelDashCenter";
            this.panelDashCenter.Size = new System.Drawing.Size(224, 828);
            this.panelDashCenter.TabIndex = 0;
            // 
            // btnBuscaFactura
            // 
            this.btnBuscaFactura.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnBuscaFactura.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscaFactura.FlatAppearance.BorderSize = 0;
            this.btnBuscaFactura.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnBuscaFactura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscaFactura.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscaFactura.ForeColor = System.Drawing.Color.White;
            this.btnBuscaFactura.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlassChart;
            this.btnBuscaFactura.IconColor = System.Drawing.Color.White;
            this.btnBuscaFactura.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscaFactura.IconSize = 30;
            this.btnBuscaFactura.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscaFactura.Location = new System.Drawing.Point(0, 291);
            this.btnBuscaFactura.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBuscaFactura.Name = "btnBuscaFactura";
            this.btnBuscaFactura.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnBuscaFactura.Size = new System.Drawing.Size(224, 86);
            this.btnBuscaFactura.TabIndex = 22;
            this.btnBuscaFactura.Tag = "registro";
            this.btnBuscaFactura.Text = "  Facturas";
            this.btnBuscaFactura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscaFactura.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscaFactura.UseVisualStyleBackColor = false;
            this.btnBuscaFactura.Click += new System.EventHandler(this.BtnBuscaFactura_Click);
            // 
            // btnVenta
            // 
            this.btnVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnVenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVenta.FlatAppearance.BorderSize = 0;
            this.btnVenta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVenta.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVenta.ForeColor = System.Drawing.Color.White;
            this.btnVenta.IconChar = FontAwesome.Sharp.IconChar.MoneyBillTransfer;
            this.btnVenta.IconColor = System.Drawing.Color.White;
            this.btnVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnVenta.IconSize = 30;
            this.btnVenta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVenta.Location = new System.Drawing.Point(0, 5);
            this.btnVenta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnVenta.Name = "btnVenta";
            this.btnVenta.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.btnVenta.Size = new System.Drawing.Size(224, 86);
            this.btnVenta.TabIndex = 20;
            this.btnVenta.Tag = "venta";
            this.btnVenta.Text = "   Facturar";
            this.btnVenta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVenta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVenta.UseVisualStyleBackColor = false;
            this.btnVenta.Click += new System.EventHandler(this.BtnVenta_Click);
            // 
            // btnProductos
            // 
            this.btnProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnProductos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProductos.FlatAppearance.BorderSize = 0;
            this.btnProductos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductos.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductos.ForeColor = System.Drawing.Color.White;
            this.btnProductos.IconChar = FontAwesome.Sharp.IconChar.LayerGroup;
            this.btnProductos.IconColor = System.Drawing.Color.White;
            this.btnProductos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnProductos.IconSize = 30;
            this.btnProductos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductos.Location = new System.Drawing.Point(0, 100);
            this.btnProductos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnProductos.Size = new System.Drawing.Size(224, 86);
            this.btnProductos.TabIndex = 21;
            this.btnProductos.Tag = "productos";
            this.btnProductos.Text = "   Productos";
            this.btnProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProductos.UseVisualStyleBackColor = false;
            this.btnProductos.Click += new System.EventHandler(this.BtnProductos_Click);
            // 
            // btnRegistro
            // 
            this.btnRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnRegistro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistro.FlatAppearance.BorderSize = 0;
            this.btnRegistro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnRegistro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistro.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistro.ForeColor = System.Drawing.Color.White;
            this.btnRegistro.IconChar = FontAwesome.Sharp.IconChar.UserEdit;
            this.btnRegistro.IconColor = System.Drawing.Color.White;
            this.btnRegistro.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRegistro.IconSize = 30;
            this.btnRegistro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegistro.Location = new System.Drawing.Point(0, 195);
            this.btnRegistro.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRegistro.Name = "btnRegistro";
            this.btnRegistro.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnRegistro.Size = new System.Drawing.Size(224, 86);
            this.btnRegistro.TabIndex = 19;
            this.btnRegistro.Tag = "registro";
            this.btnRegistro.Text = " Clientes";
            this.btnRegistro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegistro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRegistro.UseVisualStyleBackColor = false;
            this.btnRegistro.Click += new System.EventHandler(this.BtnRegistro_Click);
            // 
            // panelDashHead
            // 
            this.panelDashHead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(17)))), ((int)(((byte)(91)))));
            this.panelDashHead.Controls.Add(this.lblNombre);
            this.panelDashHead.Controls.Add(this.ptmfotouser);
            this.panelDashHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDashHead.Location = new System.Drawing.Point(0, 0);
            this.panelDashHead.Margin = new System.Windows.Forms.Padding(0);
            this.panelDashHead.Name = "panelDashHead";
            this.panelDashHead.Size = new System.Drawing.Size(224, 155);
            this.panelDashHead.TabIndex = 1;
            // 
            // lblNombre
            // 
            this.lblNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNombre.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(3, 122);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(15, 15, 15, 15);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(225, 23);
            this.lblNombre.TabIndex = 7;
            this.lblNombre.Text = "Admin";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ptmfotouser
            // 
            this.ptmfotouser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ptmfotouser.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ptmfotouser.BackgroundImage")));
            this.ptmfotouser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ptmfotouser.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.ptmfotouser.BorderColor = System.Drawing.Color.RoyalBlue;
            this.ptmfotouser.BorderColor2 = System.Drawing.Color.HotPink;
            this.ptmfotouser.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.ptmfotouser.BorderSize = 2;
            this.ptmfotouser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptmfotouser.GradientAngle = 50F;
            this.ptmfotouser.Location = new System.Drawing.Point(63, 15);
            this.ptmfotouser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ptmfotouser.Name = "ptmfotouser";
            this.ptmfotouser.Size = new System.Drawing.Size(102, 102);
            this.ptmfotouser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptmfotouser.TabIndex = 6;
            this.ptmfotouser.TabStop = false;
            this.ptmfotouser.Click += new System.EventHandler(this.Ptmfotouser_Click);
            // 
            // panelDashOut
            // 
            this.panelDashOut.BackColor = System.Drawing.Color.RosyBrown;
            this.panelDashOut.Controls.Add(this.btnCerrarsesion);
            this.panelDashOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDashOut.Location = new System.Drawing.Point(0, 983);
            this.panelDashOut.Margin = new System.Windows.Forms.Padding(0);
            this.panelDashOut.Name = "panelDashOut";
            this.panelDashOut.Size = new System.Drawing.Size(224, 52);
            this.panelDashOut.TabIndex = 2;
            // 
            // btnCerrarsesion
            // 
            this.btnCerrarsesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCerrarsesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarsesion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCerrarsesion.FlatAppearance.BorderSize = 0;
            this.btnCerrarsesion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnCerrarsesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarsesion.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarsesion.ForeColor = System.Drawing.Color.White;
            this.btnCerrarsesion.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            this.btnCerrarsesion.IconColor = System.Drawing.Color.White;
            this.btnCerrarsesion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCerrarsesion.IconSize = 30;
            this.btnCerrarsesion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarsesion.Location = new System.Drawing.Point(0, 0);
            this.btnCerrarsesion.Margin = new System.Windows.Forms.Padding(0);
            this.btnCerrarsesion.Name = "btnCerrarsesion";
            this.btnCerrarsesion.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnCerrarsesion.Size = new System.Drawing.Size(224, 52);
            this.btnCerrarsesion.TabIndex = 24;
            this.btnCerrarsesion.Tag = "perfiles";
            this.btnCerrarsesion.Text = " Cerrar Sesión";
            this.btnCerrarsesion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarsesion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCerrarsesion.UseVisualStyleBackColor = false;
            this.btnCerrarsesion.Click += new System.EventHandler(this.BtnCerrarsesion_Click);
            // 
            // panelLayoutForms
            // 
            this.panelLayoutForms.ColumnCount = 1;
            this.panelLayoutForms.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelLayoutForms.Controls.Add(this.panelForms, 0, 1);
            this.panelLayoutForms.Controls.Add(this.panelLayoutFormsHead, 0, 0);
            this.panelLayoutForms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLayoutForms.Location = new System.Drawing.Point(224, 0);
            this.panelLayoutForms.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelLayoutForms.Name = "panelLayoutForms";
            this.panelLayoutForms.RowCount = 2;
            this.panelLayoutForms.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.panelLayoutForms.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95F));
            this.panelLayoutForms.Size = new System.Drawing.Size(1240, 1035);
            this.panelLayoutForms.TabIndex = 1;
            // 
            // panelForms
            // 
            this.panelForms.BackColor = System.Drawing.Color.LavenderBlush;
            this.panelForms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForms.Location = new System.Drawing.Point(0, 51);
            this.panelForms.Margin = new System.Windows.Forms.Padding(0);
            this.panelForms.Name = "panelForms";
            this.panelForms.Size = new System.Drawing.Size(1240, 984);
            this.panelForms.TabIndex = 1;
            // 
            // panelLayoutFormsHead
            // 
            this.panelLayoutFormsHead.ColumnCount = 3;
            this.panelLayoutFormsHead.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.panelLayoutFormsHead.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83F));
            this.panelLayoutFormsHead.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.panelLayoutFormsHead.Controls.Add(this.panelDashHeadCenter, 1, 0);
            this.panelLayoutFormsHead.Controls.Add(this.panelButtomDash, 0, 0);
            this.panelLayoutFormsHead.Controls.Add(this.panelLayourMaximizar, 2, 0);
            this.panelLayoutFormsHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLayoutFormsHead.Location = new System.Drawing.Point(0, 0);
            this.panelLayoutFormsHead.Margin = new System.Windows.Forms.Padding(0);
            this.panelLayoutFormsHead.Name = "panelLayoutFormsHead";
            this.panelLayoutFormsHead.RowCount = 1;
            this.panelLayoutFormsHead.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelLayoutFormsHead.Size = new System.Drawing.Size(1240, 51);
            this.panelLayoutFormsHead.TabIndex = 2;
            // 
            // panelDashHeadCenter
            // 
            this.panelDashHeadCenter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.panelDashHeadCenter.Controls.Add(this.lblEncabezadoGS);
            this.panelDashHeadCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDashHeadCenter.Location = new System.Drawing.Point(62, 0);
            this.panelDashHeadCenter.Margin = new System.Windows.Forms.Padding(0);
            this.panelDashHeadCenter.Name = "panelDashHeadCenter";
            this.panelDashHeadCenter.Size = new System.Drawing.Size(1029, 51);
            this.panelDashHeadCenter.TabIndex = 1;
            // 
            // lblEncabezadoGS
            // 
            this.lblEncabezadoGS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEncabezadoGS.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncabezadoGS.ForeColor = System.Drawing.Color.White;
            this.lblEncabezadoGS.Location = new System.Drawing.Point(48, 8);
            this.lblEncabezadoGS.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEncabezadoGS.Name = "lblEncabezadoGS";
            this.lblEncabezadoGS.Size = new System.Drawing.Size(938, 35);
            this.lblEncabezadoGS.TabIndex = 0;
            this.lblEncabezadoGS.Text = "Gestión del Software - Sistema de Facturación - v1.0";
            this.lblEncabezadoGS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelButtomDash
            // 
            this.panelButtomDash.BackColor = System.Drawing.Color.White;
            this.panelButtomDash.Controls.Add(this.btnMenu);
            this.panelButtomDash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtomDash.Location = new System.Drawing.Point(0, 0);
            this.panelButtomDash.Margin = new System.Windows.Forms.Padding(0);
            this.panelButtomDash.Name = "panelButtomDash";
            this.panelButtomDash.Size = new System.Drawing.Size(62, 51);
            this.panelButtomDash.TabIndex = 0;
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMenu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(125)))));
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.IconChar = FontAwesome.Sharp.IconChar.Navicon;
            this.btnMenu.IconColor = System.Drawing.Color.White;
            this.btnMenu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMenu.IconSize = 27;
            this.btnMenu.Location = new System.Drawing.Point(0, 0);
            this.btnMenu.Margin = new System.Windows.Forms.Padding(0);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(62, 51);
            this.btnMenu.TabIndex = 23;
            this.btnMenu.UseVisualStyleBackColor = false;
            this.btnMenu.Click += new System.EventHandler(this.BtnMenu_Click);
            // 
            // panelLayourMaximizar
            // 
            this.panelLayourMaximizar.ColumnCount = 3;
            this.panelLayourMaximizar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.panelLayourMaximizar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.panelLayourMaximizar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.panelLayourMaximizar.Controls.Add(this.btn_minimizar, 0, 0);
            this.panelLayourMaximizar.Controls.Add(this.btn_cerrar, 2, 0);
            this.panelLayourMaximizar.Controls.Add(this.btn_maximizar, 1, 0);
            this.panelLayourMaximizar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLayourMaximizar.Location = new System.Drawing.Point(1091, 0);
            this.panelLayourMaximizar.Margin = new System.Windows.Forms.Padding(0);
            this.panelLayourMaximizar.Name = "panelLayourMaximizar";
            this.panelLayourMaximizar.RowCount = 1;
            this.panelLayourMaximizar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.panelLayourMaximizar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.panelLayourMaximizar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.panelLayourMaximizar.Size = new System.Drawing.Size(149, 51);
            this.panelLayourMaximizar.TabIndex = 2;
            // 
            // btn_minimizar
            // 
            this.btn_minimizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btn_minimizar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_minimizar.FlatAppearance.BorderSize = 0;
            this.btn_minimizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_minimizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(125)))));
            this.btn_minimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_minimizar.ForeColor = System.Drawing.Color.White;
            this.btn_minimizar.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.btn_minimizar.IconColor = System.Drawing.Color.White;
            this.btn_minimizar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_minimizar.IconSize = 20;
            this.btn_minimizar.Location = new System.Drawing.Point(0, 0);
            this.btn_minimizar.Margin = new System.Windows.Forms.Padding(0);
            this.btn_minimizar.Name = "btn_minimizar";
            this.btn_minimizar.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btn_minimizar.Size = new System.Drawing.Size(49, 51);
            this.btn_minimizar.TabIndex = 7;
            this.btn_minimizar.UseVisualStyleBackColor = false;
            this.btn_minimizar.Click += new System.EventHandler(this.Btn_Minimizar_Click);
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btn_cerrar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_cerrar.FlatAppearance.BorderSize = 0;
            this.btn_cerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_cerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkRed;
            this.btn_cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cerrar.ForeColor = System.Drawing.Color.White;
            this.btn_cerrar.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.btn_cerrar.IconColor = System.Drawing.Color.White;
            this.btn_cerrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_cerrar.IconSize = 20;
            this.btn_cerrar.Location = new System.Drawing.Point(98, 0);
            this.btn_cerrar.Margin = new System.Windows.Forms.Padding(0);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btn_cerrar.Size = new System.Drawing.Size(51, 51);
            this.btn_cerrar.TabIndex = 5;
            this.btn_cerrar.UseVisualStyleBackColor = false;
            this.btn_cerrar.Click += new System.EventHandler(this.Btn_cerrar_Click);
            // 
            // btn_maximizar
            // 
            this.btn_maximizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btn_maximizar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_maximizar.FlatAppearance.BorderSize = 0;
            this.btn_maximizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_maximizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(125)))));
            this.btn_maximizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_maximizar.ForeColor = System.Drawing.Color.White;
            this.btn_maximizar.IconChar = FontAwesome.Sharp.IconChar.ObjectUngroup;
            this.btn_maximizar.IconColor = System.Drawing.Color.White;
            this.btn_maximizar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_maximizar.IconSize = 20;
            this.btn_maximizar.Location = new System.Drawing.Point(49, 0);
            this.btn_maximizar.Margin = new System.Windows.Forms.Padding(0);
            this.btn_maximizar.Name = "btn_maximizar";
            this.btn_maximizar.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btn_maximizar.Size = new System.Drawing.Size(49, 51);
            this.btn_maximizar.TabIndex = 6;
            this.btn_maximizar.UseVisualStyleBackColor = false;
            this.btn_maximizar.Click += new System.EventHandler(this.Btn_Maximizar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1464, 1035);
            this.Controls.Add(this.panelLayoutForms);
            this.Controls.Add(this.panelLayoutMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SISTEMA DE FACTURACIÓN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelLayoutMenu.ResumeLayout(false);
            this.panelDashCenter.ResumeLayout(false);
            this.panelDashHead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptmfotouser)).EndInit();
            this.panelDashOut.ResumeLayout(false);
            this.panelLayoutForms.ResumeLayout(false);
            this.panelLayoutFormsHead.ResumeLayout(false);
            this.panelDashHeadCenter.ResumeLayout(false);
            this.panelButtomDash.ResumeLayout(false);
            this.panelLayourMaximizar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelDashHead;
        private System.Windows.Forms.Panel panelDashOut;
        private System.Windows.Forms.TableLayoutPanel panelLayoutForms;
        private System.Windows.Forms.TableLayoutPanel panelLayoutFormsHead;
        private System.Windows.Forms.Panel panelDashHeadCenter;
        private System.Windows.Forms.Panel panelButtomDash;
        private System.Windows.Forms.Label lblEncabezadoGS;
        private FontAwesome.Sharp.IconButton btnMenu;
        private System.Windows.Forms.TableLayoutPanel panelLayourMaximizar;
        private FontAwesome.Sharp.IconButton btn_minimizar;
        private FontAwesome.Sharp.IconButton btn_cerrar;
        private FontAwesome.Sharp.IconButton btn_maximizar;
        private FontAwesome.Sharp.IconButton btnCerrarsesion;
        private System.Windows.Forms.Label lblNombre;
        private RJCodeAdvance.RJControls.RJCircularPictureBox ptmfotouser;
        public FontAwesome.Sharp.IconButton btnVenta;
        private FontAwesome.Sharp.IconButton btnProductos;
        private FontAwesome.Sharp.IconButton btnRegistro;
        public System.Windows.Forms.Panel panelForms;
        public System.Windows.Forms.TableLayoutPanel panelLayoutMenu;
        public System.Windows.Forms.Panel panelDashCenter;
        private FontAwesome.Sharp.IconButton btnBuscaFactura;
    }
}

