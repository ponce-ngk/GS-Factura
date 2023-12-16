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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dtgventaproducto = new System.Windows.Forms.DataGridView();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.iconButton15 = new FontAwesome.Sharp.IconButton();
            this.txtbuscarproducto = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btncloseProduct = new FontAwesome.Sharp.IconButton();
            this.panel10 = new System.Windows.Forms.Panel();
            this.lblidproducto = new System.Windows.Forms.Label();
            this.iconButton6 = new FontAwesome.Sharp.IconButton();
            this.label9 = new System.Windows.Forms.Label();
            this.txtnombreproducto = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.txtpreciounitario = new System.Windows.Forms.TextBox();
            this.panel17 = new System.Windows.Forms.Panel();
            this.lbltextocantidad = new System.Windows.Forms.Label();
            this.iconButton10 = new FontAwesome.Sharp.IconButton();
            this.txtcantidadproducto = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnGuardarPorducto = new FontAwesome.Sharp.IconButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblcantidadactualproducto = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgventaproducto)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel10.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.panel1.Controls.Add(this.tableLayoutPanel3);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1025, 559);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.dtgventaproducto, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.panel5, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(16, 284);
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
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
            this.dtgventaproducto.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dtgventaproducto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgventaproducto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgventaproducto.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgventaproducto.BackgroundColor = System.Drawing.Color.White;
            this.dtgventaproducto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgventaproducto.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dtgventaproducto.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(183)))), ((int)(((byte)(221)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgventaproducto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dtgventaproducto.ColumnHeadersHeight = 29;
            this.dtgventaproducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgventaproducto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.nombre,
            this.cantidad,
            this.precio});
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgventaproducto.DefaultCellStyle = dataGridViewCellStyle15;
            this.dtgventaproducto.EnableHeadersVisualStyles = false;
            this.dtgventaproducto.GridColor = System.Drawing.Color.Gainsboro;
            this.dtgventaproducto.Location = new System.Drawing.Point(0, 65);
            this.dtgventaproducto.Margin = new System.Windows.Forms.Padding(0);
            this.dtgventaproducto.MultiSelect = false;
            this.dtgventaproducto.Name = "dtgventaproducto";
            this.dtgventaproducto.ReadOnly = true;
            this.dtgventaproducto.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(183)))), ((int)(((byte)(221)))));
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgventaproducto.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dtgventaproducto.RowHeadersVisible = false;
            this.dtgventaproducto.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dtgventaproducto.Size = new System.Drawing.Size(989, 197);
            this.dtgventaproducto.TabIndex = 19;
            this.dtgventaproducto.DoubleClick += new System.EventHandler(this.dtgventaproducto_DoubleClick);
            // 
            // codigo
            // 
            this.codigo.FillWeight = 87.45342F;
            this.codigo.HeaderText = "Código";
            this.codigo.MinimumWidth = 6;
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            // 
            // nombre
            // 
            this.nombre.FillWeight = 104.6063F;
            this.nombre.HeaderText = "Nombre";
            this.nombre.MinimumWidth = 6;
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // cantidad
            // 
            this.cantidad.FillWeight = 131.1158F;
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.MinimumWidth = 6;
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            // 
            // precio
            // 
            this.precio.FillWeight = 116.7477F;
            this.precio.HeaderText = "Precio";
            this.precio.MinimumWidth = 6;
            this.precio.Name = "precio";
            this.precio.ReadOnly = true;
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
            this.panel6.Controls.Add(this.iconButton15);
            this.panel6.Controls.Add(this.txtbuscarproducto);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(989, 65);
            this.panel6.TabIndex = 4;
            // 
            // iconButton15
            // 
            this.iconButton15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(65)))));
            this.iconButton15.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.iconButton15.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iconButton15.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iconButton15.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.iconButton15.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.iconButton15.IconColor = System.Drawing.Color.White;
            this.iconButton15.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton15.IconSize = 27;
            this.iconButton15.Location = new System.Drawing.Point(11, 11);
            this.iconButton15.Margin = new System.Windows.Forms.Padding(0);
            this.iconButton15.Name = "iconButton15";
            this.iconButton15.Size = new System.Drawing.Size(44, 34);
            this.iconButton15.TabIndex = 26;
            this.iconButton15.UseVisualStyleBackColor = false;
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel10, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(16, 82);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(989, 202);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.btncloseProduct);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(494, 101);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(495, 101);
            this.panel4.TabIndex = 4;
            // 
            // btncloseProduct
            // 
            this.btncloseProduct.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btncloseProduct.BackColor = System.Drawing.Color.Red;
            this.btncloseProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btncloseProduct.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btncloseProduct.FlatAppearance.BorderSize = 0;
            this.btncloseProduct.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btncloseProduct.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(57)))), ((int)(((byte)(70)))));
            this.btncloseProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncloseProduct.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncloseProduct.ForeColor = System.Drawing.Color.White;
            this.btncloseProduct.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleLeft;
            this.btncloseProduct.IconColor = System.Drawing.Color.White;
            this.btncloseProduct.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btncloseProduct.IconSize = 27;
            this.btncloseProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncloseProduct.Location = new System.Drawing.Point(16, 22);
            this.btncloseProduct.Margin = new System.Windows.Forms.Padding(0);
            this.btncloseProduct.Name = "btncloseProduct";
            this.btncloseProduct.Size = new System.Drawing.Size(187, 62);
            this.btncloseProduct.TabIndex = 34;
            this.btncloseProduct.Text = "         Volver";
            this.btncloseProduct.UseVisualStyleBackColor = false;
            this.btncloseProduct.Click += new System.EventHandler(this.btncloseProduct_Click);
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.White;
            this.panel10.Controls.Add(this.lblidproducto);
            this.panel10.Controls.Add(this.iconButton6);
            this.panel10.Controls.Add(this.label9);
            this.panel10.Controls.Add(this.txtnombreproducto);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Margin = new System.Windows.Forms.Padding(0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(494, 101);
            this.panel10.TabIndex = 1;
            // 
            // lblidproducto
            // 
            this.lblidproducto.AutoSize = true;
            this.lblidproducto.Location = new System.Drawing.Point(425, 16);
            this.lblidproducto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblidproducto.Name = "lblidproducto";
            this.lblidproducto.Size = new System.Drawing.Size(51, 16);
            this.lblidproducto.TabIndex = 23;
            this.lblidproducto.Text = "label14";
            this.lblidproducto.Visible = false;
            // 
            // iconButton6
            // 
            this.iconButton6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.iconButton6.Enabled = false;
            this.iconButton6.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.iconButton6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iconButton6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iconButton6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.iconButton6.IconChar = FontAwesome.Sharp.IconChar.BasketShopping;
            this.iconButton6.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.iconButton6.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton6.IconSize = 27;
            this.iconButton6.Location = new System.Drawing.Point(21, 39);
            this.iconButton6.Margin = new System.Windows.Forms.Padding(0);
            this.iconButton6.Name = "iconButton6";
            this.iconButton6.Size = new System.Drawing.Size(44, 36);
            this.iconButton6.TabIndex = 19;
            this.iconButton6.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(21, 11);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(319, 22);
            this.label9.TabIndex = 4;
            this.label9.Text = "Nombre del Producto: (requerido)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtnombreproducto
            // 
            this.txtnombreproducto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtnombreproducto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtnombreproducto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtnombreproducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtnombreproducto.Enabled = false;
            this.txtnombreproducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnombreproducto.ForeColor = System.Drawing.Color.DimGray;
            this.txtnombreproducto.Location = new System.Drawing.Point(65, 39);
            this.txtnombreproducto.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.txtnombreproducto.Name = "txtnombreproducto";
            this.txtnombreproducto.Size = new System.Drawing.Size(409, 34);
            this.txtnombreproducto.TabIndex = 20;
            this.txtnombreproducto.Enter += new System.EventHandler(this.txtnombreproducto_Enter);
            this.txtnombreproducto.Leave += new System.EventHandler(this.txtnombreproducto_Leave);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.panel15, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel17, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(494, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(495, 101);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.White;
            this.panel15.Controls.Add(this.label10);
            this.panel15.Controls.Add(this.iconButton1);
            this.panel15.Controls.Add(this.txtpreciounitario);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel15.Location = new System.Drawing.Point(247, 0);
            this.panel15.Margin = new System.Windows.Forms.Padding(0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(248, 101);
            this.panel15.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Location = new System.Drawing.Point(15, 12);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(157, 22);
            this.label10.TabIndex = 4;
            this.label10.Text = "Precio Unitario: ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // iconButton1
            // 
            this.iconButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.iconButton1.Enabled = false;
            this.iconButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.iconButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iconButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Donate;
            this.iconButton1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 27;
            this.iconButton1.Location = new System.Drawing.Point(16, 39);
            this.iconButton1.Margin = new System.Windows.Forms.Padding(0);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(49, 36);
            this.iconButton1.TabIndex = 1;
            this.iconButton1.UseVisualStyleBackColor = false;
            // 
            // txtpreciounitario
            // 
            this.txtpreciounitario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtpreciounitario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtpreciounitario.Enabled = false;
            this.txtpreciounitario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpreciounitario.ForeColor = System.Drawing.Color.DimGray;
            this.txtpreciounitario.Location = new System.Drawing.Point(64, 39);
            this.txtpreciounitario.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.txtpreciounitario.Name = "txtpreciounitario";
            this.txtpreciounitario.Size = new System.Drawing.Size(170, 34);
            this.txtpreciounitario.TabIndex = 16;
            this.txtpreciounitario.Text = "1,2";
            this.txtpreciounitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel17
            // 
            this.panel17.BackColor = System.Drawing.Color.White;
            this.panel17.Controls.Add(this.lblcantidadactualproducto);
            this.panel17.Controls.Add(this.lbltextocantidad);
            this.panel17.Controls.Add(this.iconButton10);
            this.panel17.Controls.Add(this.txtcantidadproducto);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel17.Location = new System.Drawing.Point(0, 0);
            this.panel17.Margin = new System.Windows.Forms.Padding(0);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(247, 101);
            this.panel17.TabIndex = 6;
            // 
            // lbltextocantidad
            // 
            this.lbltextocantidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltextocantidad.AutoSize = true;
            this.lbltextocantidad.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltextocantidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbltextocantidad.Location = new System.Drawing.Point(12, 12);
            this.lbltextocantidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltextocantidad.Name = "lbltextocantidad";
            this.lbltextocantidad.Size = new System.Drawing.Size(104, 22);
            this.lbltextocantidad.TabIndex = 4;
            this.lbltextocantidad.Text = "Cantidad: ";
            this.lbltextocantidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // iconButton10
            // 
            this.iconButton10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.iconButton10.Enabled = false;
            this.iconButton10.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.iconButton10.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iconButton10.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iconButton10.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.iconButton10.IconChar = FontAwesome.Sharp.IconChar.CartPlus;
            this.iconButton10.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.iconButton10.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton10.IconSize = 27;
            this.iconButton10.Location = new System.Drawing.Point(15, 39);
            this.iconButton10.Margin = new System.Windows.Forms.Padding(0);
            this.iconButton10.Name = "iconButton10";
            this.iconButton10.Size = new System.Drawing.Size(44, 36);
            this.iconButton10.TabIndex = 1;
            this.iconButton10.UseVisualStyleBackColor = false;
            // 
            // txtcantidadproducto
            // 
            this.txtcantidadproducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtcantidadproducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcantidadproducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcantidadproducto.ForeColor = System.Drawing.Color.DimGray;
            this.txtcantidadproducto.Location = new System.Drawing.Point(57, 39);
            this.txtcantidadproducto.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.txtcantidadproducto.Name = "txtcantidadproducto";
            this.txtcantidadproducto.Size = new System.Drawing.Size(175, 34);
            this.txtcantidadproducto.TabIndex = 16;
            this.txtcantidadproducto.Text = "0";
            this.txtcantidadproducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtcantidadproducto.TextChanged += new System.EventHandler(this.txtcantidadproducto_TextChanged);
            this.txtcantidadproducto.Enter += new System.EventHandler(this.txtcantidadproducto_Enter);
            this.txtcantidadproducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcantidadproducto_KeyPress);
            this.txtcantidadproducto.Leave += new System.EventHandler(this.txtcantidadproducto_Leave);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.btnGuardarPorducto);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 101);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(494, 101);
            this.panel3.TabIndex = 3;
            // 
            // btnGuardarPorducto
            // 
            this.btnGuardarPorducto.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGuardarPorducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(65)))));
            this.btnGuardarPorducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarPorducto.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnGuardarPorducto.FlatAppearance.BorderSize = 0;
            this.btnGuardarPorducto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnGuardarPorducto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SpringGreen;
            this.btnGuardarPorducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarPorducto.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarPorducto.ForeColor = System.Drawing.Color.White;
            this.btnGuardarPorducto.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnGuardarPorducto.IconColor = System.Drawing.Color.White;
            this.btnGuardarPorducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardarPorducto.IconSize = 27;
            this.btnGuardarPorducto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarPorducto.Location = new System.Drawing.Point(293, 22);
            this.btnGuardarPorducto.Margin = new System.Windows.Forms.Padding(0);
            this.btnGuardarPorducto.Name = "btnGuardarPorducto";
            this.btnGuardarPorducto.Size = new System.Drawing.Size(187, 62);
            this.btnGuardarPorducto.TabIndex = 11;
            this.btnGuardarPorducto.Text = "         Guardar";
            this.btnGuardarPorducto.UseVisualStyleBackColor = false;
            this.btnGuardarPorducto.Click += new System.EventHandler(this.btnGuardarPorducto_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(16, 15);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
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
            // lblcantidadactualproducto
            // 
            this.lblcantidadactualproducto.AutoSize = true;
            this.lblcantidadactualproducto.Location = new System.Drawing.Point(183, 14);
            this.lblcantidadactualproducto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblcantidadactualproducto.Name = "lblcantidadactualproducto";
            this.lblcantidadactualproducto.Size = new System.Drawing.Size(14, 16);
            this.lblcantidadactualproducto.TabIndex = 24;
            this.lblcantidadactualproducto.Text = "1";
            this.lblcantidadactualproducto.Visible = false;
            // 
            // ProductoVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 559);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductoVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProductoVenta";
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgventaproducto)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel4;
        private FontAwesome.Sharp.IconButton btncloseProduct;
        private System.Windows.Forms.Panel panel10;
        public System.Windows.Forms.Label lblidproducto;
        private FontAwesome.Sharp.IconButton iconButton6;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox txtnombreproducto;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Label label10;
        private FontAwesome.Sharp.IconButton iconButton1;
        public System.Windows.Forms.TextBox txtpreciounitario;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Label lbltextocantidad;
        private FontAwesome.Sharp.IconButton iconButton10;
        public System.Windows.Forms.TextBox txtcantidadproducto;
        private System.Windows.Forms.Panel panel3;
        public FontAwesome.Sharp.IconButton btnGuardarPorducto;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel5;
        private FontAwesome.Sharp.IconButton iconButton15;
        private System.Windows.Forms.TextBox txtbuscarproducto;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView dtgventaproducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio;
        public System.Windows.Forms.Label lblcantidadactualproducto;
    }
}