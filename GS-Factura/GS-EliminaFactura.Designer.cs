namespace GS_Factura
{
    partial class GS_EliminaFactura
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tblFormulario = new System.Windows.Forms.TableLayoutPanel();
            this.tblFacturaMuestra = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelFactura = new System.Windows.Forms.Panel();
            this.tblBuscaFactura = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtgFactura = new System.Windows.Forms.DataGridView();
            this.Eliminarfila = new System.Windows.Forms.DataGridViewButtonColumn();
            this.verFactura = new System.Windows.Forms.DataGridViewButtonColumn();
            this.editarFactura = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.btnBuscar = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbitems = new System.Windows.Forms.ComboBox();
            this.txtBuscaFacturaCliente = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tblFormulario.SuspendLayout();
            this.tblFacturaMuestra.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tblBuscaFactura.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFactura)).BeginInit();
            this.panel5.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tblFormulario);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1033, 599);
            this.panel1.TabIndex = 0;
            // 
            // tblFormulario
            // 
            this.tblFormulario.ColumnCount = 2;
            this.tblFormulario.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblFormulario.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblFormulario.Controls.Add(this.tblFacturaMuestra, 1, 0);
            this.tblFormulario.Controls.Add(this.tblBuscaFactura, 0, 0);
            this.tblFormulario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblFormulario.Location = new System.Drawing.Point(0, 0);
            this.tblFormulario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tblFormulario.Name = "tblFormulario";
            this.tblFormulario.RowCount = 1;
            this.tblFormulario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblFormulario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tblFormulario.Size = new System.Drawing.Size(1033, 599);
            this.tblFormulario.TabIndex = 0;
            // 
            // tblFacturaMuestra
            // 
            this.tblFacturaMuestra.ColumnCount = 1;
            this.tblFacturaMuestra.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblFacturaMuestra.Controls.Add(this.panel2, 0, 0);
            this.tblFacturaMuestra.Controls.Add(this.panelFactura, 0, 1);
            this.tblFacturaMuestra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblFacturaMuestra.Location = new System.Drawing.Point(516, 0);
            this.tblFacturaMuestra.Margin = new System.Windows.Forms.Padding(0);
            this.tblFacturaMuestra.Name = "tblFacturaMuestra";
            this.tblFacturaMuestra.RowCount = 2;
            this.tblFacturaMuestra.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.624944F));
            this.tblFacturaMuestra.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.37505F));
            this.tblFacturaMuestra.Size = new System.Drawing.Size(517, 599);
            this.tblFacturaMuestra.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(517, 57);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(36, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(465, 44);
            this.label1.TabIndex = 35;
            this.label1.Text = "PREVISUALIZACIÓN DE LA FACTURA";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelFactura
            // 
            this.panelFactura.BackColor = System.Drawing.Color.Silver;
            this.panelFactura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFactura.Location = new System.Drawing.Point(0, 57);
            this.panelFactura.Margin = new System.Windows.Forms.Padding(0);
            this.panelFactura.Name = "panelFactura";
            this.panelFactura.Size = new System.Drawing.Size(517, 542);
            this.panelFactura.TabIndex = 1;
            // 
            // tblBuscaFactura
            // 
            this.tblBuscaFactura.ColumnCount = 1;
            this.tblBuscaFactura.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblBuscaFactura.Controls.Add(this.panel4, 0, 1);
            this.tblBuscaFactura.Controls.Add(this.panel5, 0, 0);
            this.tblBuscaFactura.Controls.Add(this.panel6, 0, 2);
            this.tblBuscaFactura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblBuscaFactura.Location = new System.Drawing.Point(0, 0);
            this.tblBuscaFactura.Margin = new System.Windows.Forms.Padding(0);
            this.tblBuscaFactura.Name = "tblBuscaFactura";
            this.tblBuscaFactura.RowCount = 3;
            this.tblBuscaFactura.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblBuscaFactura.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tblBuscaFactura.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblBuscaFactura.Size = new System.Drawing.Size(516, 599);
            this.tblBuscaFactura.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dtgFactura);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 59);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(516, 479);
            this.panel4.TabIndex = 0;
            // 
            // dtgFactura
            // 
            this.dtgFactura.AllowUserToAddRows = false;
            this.dtgFactura.AllowUserToResizeColumns = false;
            this.dtgFactura.AllowUserToResizeRows = false;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            this.dtgFactura.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dtgFactura.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgFactura.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgFactura.BackgroundColor = System.Drawing.Color.White;
            this.dtgFactura.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgFactura.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dtgFactura.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgFactura.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dtgFactura.ColumnHeadersHeight = 29;
            this.dtgFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgFactura.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Eliminarfila,
            this.verFactura,
            this.editarFactura});
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgFactura.DefaultCellStyle = dataGridViewCellStyle13;
            this.dtgFactura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgFactura.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgFactura.EnableHeadersVisualStyles = false;
            this.dtgFactura.GridColor = System.Drawing.Color.Gainsboro;
            this.dtgFactura.Location = new System.Drawing.Point(0, 0);
            this.dtgFactura.Margin = new System.Windows.Forms.Padding(0);
            this.dtgFactura.MultiSelect = false;
            this.dtgFactura.Name = "dtgFactura";
            this.dtgFactura.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(183)))), ((int)(((byte)(221)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgFactura.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dtgFactura.RowHeadersVisible = false;
            this.dtgFactura.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgFactura.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.dtgFactura.Size = new System.Drawing.Size(516, 479);
            this.dtgFactura.TabIndex = 3;
            this.dtgFactura.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgFactura_CellClick);
            this.dtgFactura.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dtgFactura_CellPainting);
            // 
            // Eliminarfila
            // 
            this.Eliminarfila.FillWeight = 43.91354F;
            this.Eliminarfila.HeaderText = "Eliminar";
            this.Eliminarfila.MinimumWidth = 6;
            this.Eliminarfila.Name = "Eliminarfila";
            this.Eliminarfila.Text = "";
            // 
            // verFactura
            // 
            this.verFactura.FillWeight = 45.27168F;
            this.verFactura.HeaderText = "Ver";
            this.verFactura.MinimumWidth = 6;
            this.verFactura.Name = "verFactura";
            // 
            // editarFactura
            // 
            this.editarFactura.FillWeight = 45.27168F;
            this.editarFactura.HeaderText = "Editar";
            this.editarFactura.MinimumWidth = 6;
            this.editarFactura.Name = "editarFactura";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel5.Controls.Add(this.tableLayoutPanel1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(516, 59);
            this.panel5.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Controls.Add(this.panel11, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(516, 59);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.btnBuscar);
            this.panel11.Controls.Add(this.label2);
            this.panel11.Controls.Add(this.cmbitems);
            this.panel11.Controls.Add(this.txtBuscaFacturaCliente);
            this.panel11.Controls.Add(this.label9);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Margin = new System.Windows.Forms.Padding(0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(516, 59);
            this.panel11.TabIndex = 4;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnBuscar.IconColor = System.Drawing.Color.White;
            this.btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscar.IconSize = 20;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(387, 36);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(0);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(129, 33);
            this.btnBuscar.TabIndex = 40;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(299, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 22);
            this.label2.TabIndex = 42;
            this.label2.Text = "*";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbitems
            // 
            this.cmbitems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbitems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbitems.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.cmbitems.FormattingEnabled = true;
            this.cmbitems.Items.AddRange(new object[] {
            "Mostrar Todas",
            "Cedula del Cliente",
            "Numero de Factura"});
            this.cmbitems.Location = new System.Drawing.Point(221, 34);
            this.cmbitems.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbitems.MaxDropDownItems = 4;
            this.cmbitems.Name = "cmbitems";
            this.cmbitems.Size = new System.Drawing.Size(163, 35);
            this.cmbitems.TabIndex = 41;
            this.cmbitems.SelectedIndexChanged += new System.EventHandler(this.cmbitems_SelectedIndexChanged);
            // 
            // txtBuscaFacturaCliente
            // 
            this.txtBuscaFacturaCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscaFacturaCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscaFacturaCliente.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
            this.txtBuscaFacturaCliente.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtBuscaFacturaCliente.Location = new System.Drawing.Point(16, 34);
            this.txtBuscaFacturaCliente.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtBuscaFacturaCliente.Name = "txtBuscaFacturaCliente";
            this.txtBuscaFacturaCliente.Size = new System.Drawing.Size(200, 34);
            this.txtBuscaFacturaCliente.TabIndex = 4;
            this.txtBuscaFacturaCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscaFacturaCliente_KeyPress);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(13, -1);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(479, 33);
            this.label9.TabIndex = 36;
            this.label9.Text = "Selecciona el tipo de factura a buscar";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.IndianRed;
            this.panel6.Controls.Add(this.label3);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 538);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(516, 61);
            this.panel6.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(9, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(496, 36);
            this.label3.TabIndex = 37;
            this.label3.Text = "Nota: Una vez eliminada la factura no se podrá recuperarla";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GS_EliminaFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1033, 599);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "GS_EliminaFactura";
            this.Text = "GS_EliminaFactura";
            this.Load += new System.EventHandler(this.GS_EliminaFactura_Load);
            this.panel1.ResumeLayout(false);
            this.tblFormulario.ResumeLayout(false);
            this.tblFacturaMuestra.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tblBuscaFactura.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgFactura)).EndInit();
            this.panel5.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tblFormulario;
        private System.Windows.Forms.TableLayoutPanel tblFacturaMuestra;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelFactura;
        private System.Windows.Forms.TableLayoutPanel tblBuscaFactura;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dtgFactura;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewButtonColumn Eliminarfila;
        private System.Windows.Forms.DataGridViewButtonColumn verFactura;
        private System.Windows.Forms.DataGridViewButtonColumn editarFactura;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.TextBox txtBuscaFacturaCliente;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbitems;
        private System.Windows.Forms.Label label2;
    }
}