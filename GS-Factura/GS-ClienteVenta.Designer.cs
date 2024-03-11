namespace GS_Factura
{
    partial class ClienteVenta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClienteVenta));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtpFechaCliente = new System.Windows.Forms.DateTimePicker();
            this.iconButton4 = new FontAwesome.Sharp.IconButton();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtapellidoscliente = new System.Windows.Forms.TextBox();
            this.panel12 = new System.Windows.Forms.Panel();
            this.iconButton3 = new FontAwesome.Sharp.IconButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtnombrescliente = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.iconButton5 = new FontAwesome.Sharp.IconButton();
            this.label7 = new System.Windows.Forms.Label();
            this.txtcedulacliente = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BtnGuardar = new FontAwesome.Sharp.IconButton();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.DgvClientes = new System.Windows.Forms.DataGridView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cmbitems = new System.Windows.Forms.ComboBox();
            this.BtnSearchClienteVenta = new FontAwesome.Sharp.IconButton();
            this.txtbuscarCliente = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvClientes)).BeginInit();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel12, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(901, 97);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.dtpFechaCliente);
            this.panel2.Controls.Add(this.iconButton4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(675, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(226, 97);
            this.panel2.TabIndex = 9;
            // 
            // dtpFechaCliente
            // 
            this.dtpFechaCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFechaCliente.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtpFechaCliente.CalendarTitleForeColor = System.Drawing.SystemColors.ControlDark;
            this.dtpFechaCliente.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaCliente.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaCliente.Location = new System.Drawing.Point(39, 43);
            this.dtpFechaCliente.Name = "dtpFechaCliente";
            this.dtpFechaCliente.Size = new System.Drawing.Size(175, 29);
            this.dtpFechaCliente.TabIndex = 22;
            this.dtpFechaCliente.Value = new System.DateTime(2023, 12, 16, 20, 46, 10, 0);
            // 
            // iconButton4
            // 
            this.iconButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.iconButton4.Enabled = false;
            this.iconButton4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.iconButton4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iconButton4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iconButton4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.iconButton4.IconChar = FontAwesome.Sharp.IconChar.CalendarCheck;
            this.iconButton4.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.iconButton4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton4.IconSize = 27;
            this.iconButton4.Location = new System.Drawing.Point(11, 43);
            this.iconButton4.Margin = new System.Windows.Forms.Padding(0);
            this.iconButton4.Name = "iconButton4";
            this.iconButton4.Size = new System.Drawing.Size(29, 29);
            this.iconButton4.TabIndex = 21;
            this.iconButton4.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(4, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(221, 17);
            this.label3.TabIndex = 20;
            this.label3.Text = "F. de Nacimiento: (requerido)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel4.Controls.Add(this.iconButton2);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.txtapellidoscliente);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(450, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(225, 97);
            this.panel4.TabIndex = 8;
            // 
            // iconButton2
            // 
            this.iconButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.iconButton2.Enabled = false;
            this.iconButton2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.iconButton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iconButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.AddressCard;
            this.iconButton2.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.IconSize = 27;
            this.iconButton2.Location = new System.Drawing.Point(8, 43);
            this.iconButton2.Margin = new System.Windows.Forms.Padding(0);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Size = new System.Drawing.Size(29, 29);
            this.iconButton2.TabIndex = 22;
            this.iconButton2.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(5, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 17);
            this.label1.TabIndex = 21;
            this.label1.Text = "Apellidos: (requerido)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtapellidoscliente
            // 
            this.txtapellidoscliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtapellidoscliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtapellidoscliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtapellidoscliente.ForeColor = System.Drawing.Color.DimGray;
            this.txtapellidoscliente.Location = new System.Drawing.Point(36, 43);
            this.txtapellidoscliente.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtapellidoscliente.MaxLength = 25;
            this.txtapellidoscliente.Name = "txtapellidoscliente";
            this.txtapellidoscliente.Size = new System.Drawing.Size(179, 29);
            this.txtapellidoscliente.TabIndex = 23;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel12.Controls.Add(this.iconButton3);
            this.panel12.Controls.Add(this.label4);
            this.panel12.Controls.Add(this.txtnombrescliente);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(225, 0);
            this.panel12.Margin = new System.Windows.Forms.Padding(0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(225, 97);
            this.panel12.TabIndex = 5;
            // 
            // iconButton3
            // 
            this.iconButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.iconButton3.Enabled = false;
            this.iconButton3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.iconButton3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iconButton3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iconButton3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.iconButton3.IconChar = FontAwesome.Sharp.IconChar.AddressCard;
            this.iconButton3.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton3.IconSize = 27;
            this.iconButton3.Location = new System.Drawing.Point(7, 43);
            this.iconButton3.Margin = new System.Windows.Forms.Padding(0);
            this.iconButton3.Name = "iconButton3";
            this.iconButton3.Size = new System.Drawing.Size(29, 29);
            this.iconButton3.TabIndex = 17;
            this.iconButton3.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(4, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Nombres: (requerido)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtnombrescliente
            // 
            this.txtnombrescliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtnombrescliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtnombrescliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnombrescliente.ForeColor = System.Drawing.Color.DimGray;
            this.txtnombrescliente.Location = new System.Drawing.Point(36, 43);
            this.txtnombrescliente.Margin = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.txtnombrescliente.MaxLength = 25;
            this.txtnombrescliente.Name = "txtnombrescliente";
            this.txtnombrescliente.Size = new System.Drawing.Size(179, 29);
            this.txtnombrescliente.TabIndex = 18;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.iconButton5);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtcedulacliente);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 97);
            this.panel1.TabIndex = 0;
            // 
            // iconButton5
            // 
            this.iconButton5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.iconButton5.Enabled = false;
            this.iconButton5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.iconButton5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iconButton5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iconButton5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.iconButton5.IconChar = FontAwesome.Sharp.IconChar.Fingerprint;
            this.iconButton5.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.iconButton5.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton5.IconSize = 27;
            this.iconButton5.Location = new System.Drawing.Point(10, 43);
            this.iconButton5.Margin = new System.Windows.Forms.Padding(0);
            this.iconButton5.Name = "iconButton5";
            this.iconButton5.Size = new System.Drawing.Size(29, 29);
            this.iconButton5.TabIndex = 24;
            this.iconButton5.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(7, 15);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 17);
            this.label7.TabIndex = 23;
            this.label7.Text = "Cédula: (requerido)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtcedulacliente
            // 
            this.txtcedulacliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtcedulacliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtcedulacliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtcedulacliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcedulacliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcedulacliente.ForeColor = System.Drawing.Color.DimGray;
            this.txtcedulacliente.Location = new System.Drawing.Point(39, 43);
            this.txtcedulacliente.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtcedulacliente.MaxLength = 10;
            this.txtcedulacliente.Name = "txtcedulacliente";
            this.txtcedulacliente.Size = new System.Drawing.Size(174, 29);
            this.txtcedulacliente.TabIndex = 25;
            this.txtcedulacliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcedulacliente_KeyPress);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.92399F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.07601F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 262F));
            this.tableLayoutPanel2.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 97);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(901, 66);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.BtnGuardar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(267, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(371, 66);
            this.panel3.TabIndex = 0;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(167)))), ((int)(((byte)(171)))));
            this.BtnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnGuardar.FlatAppearance.BorderSize = 0;
            this.BtnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BtnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SpringGreen;
            this.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.ForeColor = System.Drawing.Color.White;
            this.BtnGuardar.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.BtnGuardar.IconColor = System.Drawing.Color.White;
            this.BtnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnGuardar.IconSize = 27;
            this.BtnGuardar.Location = new System.Drawing.Point(72, 4);
            this.BtnGuardar.Margin = new System.Windows.Forms.Padding(0);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(223, 58);
            this.BtnGuardar.TabIndex = 12;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.panel6, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.DgvClientes, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 163);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.57925F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.42075F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(901, 295);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // DgvClientes
            // 
            this.DgvClientes.AllowUserToAddRows = false;
            this.DgvClientes.AllowUserToResizeColumns = false;
            this.DgvClientes.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.DgvClientes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvClientes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvClientes.BackgroundColor = System.Drawing.Color.White;
            this.DgvClientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DgvClientes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.DgvClientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvClientes.ColumnHeadersHeight = 29;
            this.DgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvClientes.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvClientes.EnableHeadersVisualStyles = false;
            this.DgvClientes.GridColor = System.Drawing.Color.Gainsboro;
            this.DgvClientes.Location = new System.Drawing.Point(0, 51);
            this.DgvClientes.Margin = new System.Windows.Forms.Padding(0);
            this.DgvClientes.MultiSelect = false;
            this.DgvClientes.Name = "DgvClientes";
            this.DgvClientes.ReadOnly = true;
            this.DgvClientes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(183)))), ((int)(((byte)(221)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvClientes.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DgvClientes.RowHeadersVisible = false;
            this.DgvClientes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.DgvClientes.Size = new System.Drawing.Size(901, 244);
            this.DgvClientes.TabIndex = 20;
            this.DgvClientes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvClientes_CellDoubleClick);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Controls.Add(this.cmbitems);
            this.panel6.Controls.Add(this.BtnSearchClienteVenta);
            this.panel6.Controls.Add(this.txtbuscarCliente);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(901, 50);
            this.panel6.TabIndex = 5;
            // 
            // cmbitems
            // 
            this.cmbitems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbitems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbitems.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.cmbitems.FormattingEnabled = true;
            this.cmbitems.Items.AddRange(new object[] {
            "ID del Cliente",
            "Cédula",
            "Nombre",
            "Apellido"});
            this.cmbitems.Location = new System.Drawing.Point(750, 10);
            this.cmbitems.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbitems.MaxDropDownItems = 4;
            this.cmbitems.Name = "cmbitems";
            this.cmbitems.Size = new System.Drawing.Size(141, 29);
            this.cmbitems.TabIndex = 27;
            this.cmbitems.SelectedIndexChanged += new System.EventHandler(this.cmbitems_SelectedIndexChanged);
            // 
            // BtnSearchClienteVenta
            // 
            this.BtnSearchClienteVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.BtnSearchClienteVenta.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnSearchClienteVenta.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnSearchClienteVenta.FlatAppearance.BorderSize = 0;
            this.BtnSearchClienteVenta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BtnSearchClienteVenta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BtnSearchClienteVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSearchClienteVenta.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
            this.BtnSearchClienteVenta.ForeColor = System.Drawing.Color.White;
            this.BtnSearchClienteVenta.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.BtnSearchClienteVenta.IconColor = System.Drawing.Color.White;
            this.BtnSearchClienteVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnSearchClienteVenta.IconSize = 27;
            this.BtnSearchClienteVenta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSearchClienteVenta.Location = new System.Drawing.Point(5, 10);
            this.BtnSearchClienteVenta.Margin = new System.Windows.Forms.Padding(0);
            this.BtnSearchClienteVenta.Name = "BtnSearchClienteVenta";
            this.BtnSearchClienteVenta.Size = new System.Drawing.Size(80, 29);
            this.BtnSearchClienteVenta.TabIndex = 26;
            this.BtnSearchClienteVenta.Text = "Buscar";
            this.BtnSearchClienteVenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSearchClienteVenta.UseVisualStyleBackColor = false;
            this.BtnSearchClienteVenta.Click += new System.EventHandler(this.BtnSearchClienteVenta_Click);
            // 
            // txtbuscarCliente
            // 
            this.txtbuscarCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbuscarCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbuscarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbuscarCliente.ForeColor = System.Drawing.Color.DimGray;
            this.txtbuscarCliente.Location = new System.Drawing.Point(84, 10);
            this.txtbuscarCliente.Margin = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.txtbuscarCliente.Name = "txtbuscarCliente";
            this.txtbuscarCliente.Size = new System.Drawing.Size(646, 29);
            this.txtbuscarCliente.TabIndex = 25;
            this.txtbuscarCliente.Enter += new System.EventHandler(this.txtbuscarproducto_Enter);
            this.txtbuscarCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbuscarCliente_KeyDown);
            this.txtbuscarCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbuscarCliente_KeyPress);
            this.txtbuscarCliente.Leave += new System.EventHandler(this.txtbuscarproducto_Leave);
            // 
            // ClienteVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(901, 458);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ClienteVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvClientes)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton iconButton5;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtcedulacliente;
        private System.Windows.Forms.Panel panel12;
        private FontAwesome.Sharp.IconButton iconButton3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtnombrescliente;
        private System.Windows.Forms.Panel panel4;
        private FontAwesome.Sharp.IconButton iconButton2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtapellidoscliente;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dtpFechaCliente;
        private FontAwesome.Sharp.IconButton iconButton4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel3;
        private FontAwesome.Sharp.IconButton BtnGuardar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView DgvClientes;
        private FontAwesome.Sharp.IconButton BtnSearchClienteVenta;
        private System.Windows.Forms.TextBox txtbuscarCliente;
        private System.Windows.Forms.ComboBox cmbitems;
    }
}