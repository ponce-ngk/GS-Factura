using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using GS_Factura.Clases;
using System.Xml.Linq;
using FontAwesome.Sharp;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;


namespace GS_Factura
{
    public partial class GS_GeneraFactura : Form
    {
        AccesoDatos bD2 = new AccesoDatos();
        List<SqlParameter> par = new List<SqlParameter>();
        int op;
        string date = DateTime.UtcNow.ToString("yyyy-MM-dd");
        string sql = "";
        DataTable tb = new DataTable();
        public GS_GeneraFactura()
        {
            InitializeComponent();
            this.Cargarnumerofactura();
        }
        public void Cargarnumerofactura()
        {
            try
            {
                string result = bD2.ObetnerDatosFactura("SELECT ISNULL(MAX(IDFACTURA), 0) FROM FACTURA").PadLeft(6, '0');
                lblnumerofactura.Text = "001-" + result;
            }
            catch (Exception ex)
            {
                throw;
            }          
        }
        public void EjecutaClientes(string idpcliente, string cedulacliente,string nombrecliente, string apellidocliente)
        {
            lblidcliente.Text = idpcliente;
            lblcedulacliente.Text = cedulacliente;
            txtSearchCliente.Text = cedulacliente;
            lblnombrecliente.Text = nombrecliente;
            lblApellidocliente.Text = apellidocliente;
        }       
        private void TmtDate_Tick(object sender, EventArgs e)
        {
            lblFingresoVenta.Text = DateTime.Now.ToShortDateString();
        }
        private void BtnañadirVenta_Click(object sender, EventArgs e)
        {
            try
            {
                DeshabilitarFormularios();
                ProductoVenta formPRODUCT = new ProductoVenta();
                formPRODUCT.FormClosed += (s, args) => HabilitarFormularios();
                formPRODUCT.pasarproducto += new ProductoVenta.pasarformFactura(Ejecutaproductos);
                formPRODUCT.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        private void DeshabilitarFormularios()
        {
            foreach (Form form in Application.OpenForms)
            {
                form.Enabled = false;
                form.TopMost = false;
            }
        }
        private void HabilitarFormularios()
        {
            foreach (Form form in Application.OpenForms)
            {
                form.Enabled = true;
            }
        }
        public void Ejecutaproductos(string idproduct,string nombreproducto, string cantidadproducto,string preciproducto)
        {
            try
            {
                // Convierte las cantidades y precios a los tipos de datos apropiados
                int cantidad = int.Parse(cantidadproducto);
                decimal precio = decimal.Parse(preciproducto);

                // Calculamos el total del producto
                decimal total = precio * cantidad;

                // Redondea el total a dos decimales
                total = Math.Round(total, 2);

                // Verifica si el producto ya está en la venta (evita duplicados)
                if (VerificarRestaPDataLotes(idproduct, nombreproducto))
                {
                    //añade
                    dtgVenta.Rows.Add(null, idproduct, nombreproducto,
                    cantidadproducto, preciproducto, total.ToString("0.00"));
                    this.GestionarFuncionalidadDtgVenta();
                    // Verifica las filas en el DataGridView (puede haber algún tipo de validación)
                    this.VerificarFilasEnDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        public bool VerificarRestaPDataLotes(string idproducto, string nomproducto)
        {
            try
            {
                foreach (DataGridViewRow recorrerdata in dtgVenta.Rows)
                {
                    // Compara el ID y el nombre del producto con los valores en la fila actual.
                    if (idproducto.ToString() == recorrerdata.Cells["IdProducto"].Value.ToString() && nomproducto == recorrerdata.Cells["NombreProducto"].Value.ToString())
                    {
                        MessageBox.Show("Producto ya se encuentra agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        private void DtgVenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dtgVenta.Columns[e.ColumnIndex].Name == "Eliminarfila")
                {
                    DialogResult resultado = MessageBox.Show("¿Estás seguro de que quieres eliminar los datos de los campos de texto?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        int index = e.RowIndex;
                        if (index >= 0)
                        {
                            // Remueve la fila seleccionada de la DataGridView.
                            dtgVenta.Rows.RemoveAt(index);
                            this.GestionarFuncionalidadDtgVenta();
                            this.VerificarFilasEnDataGridView();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        private void DtgVenta_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex >= 0 && this.dtgVenta.Columns[e.ColumnIndex].Name == "Eliminarfila" && e.RowIndex >= 0)
                {
                    e.CellStyle.BackColor = Color.Red;

                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    // Ajusta las dimensiones del icono para hacer el botón más pequeño
                    int iconWidth = 30;
                    int iconHeight = 30;
                    //extrae la imagen remove.ico  imagen ico
                    //Icon icoAtomico = new Icon(Environment.CurrentDirectory + @"\\remove.ico", iconWidth, iconHeight);

                    System.Drawing.Icon  icoAtomico = new System.Drawing.Icon(Properties.Resources.remove, iconWidth, iconHeight);

                    e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + (e.CellBounds.Width - iconWidth) / 2, e.CellBounds.Top + (e.CellBounds.Height - iconHeight) / 2);

                    // Ajusta las dimensiones de la celda para que coincidan con el tamaño del botón
                    this.dtgVenta.Rows[e.RowIndex].Height = iconHeight + 4;
                    this.dtgVenta.Columns[e.ColumnIndex].Width = iconWidth + 9;

                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void GestionarFuncionalidadDtgVenta()
        {
            try
            {
                decimal totalproductos = 0;
                decimal sumcantidadproductos = 0;
                decimal subtotalCompra = 0.0M;
                decimal descuentoCompra = 0.0M;
                decimal iva12 = ObtenerValorIVAActual();
                btnConfirmarVenta.Visible = true;
                btnConfirmarVenta.Enabled = true;

                foreach (DataGridViewRow recorrerdata in dtgVenta.Rows)
                {
                    // Suma los totales y cantidades de productos.
                    totalproductos += decimal.Parse(recorrerdata.Cells["TotalProducto"].Value.ToString().Replace(".", ","));
                    sumcantidadproductos += decimal.Parse(recorrerdata.Cells["StockProducto"].Value.ToString().Replace(".", ","));
                }
                // Calculamos el subtotal (sin descuento ni IVA)
                subtotalCompra = totalproductos;
                txtsubtotalventa.Text = subtotalCompra.ToString("0.00");

                // Agregamos el IVA
                decimal iva = subtotalCompra * (iva12 / 100.0M);
                //decimal iva = subtotalCompra * (int.Parse(12.00) / 100.0M);

                subtotalCompra += iva;
                //txtivaVenta.Text = iva.ToString("0.00");

                // Calculamos el total de la compra
                decimal total = subtotalCompra;
                txtTotalVenta.Text = total.ToString("0.00").Replace(",", ".");
                txtivaVenta.Text = iva.ToString("0.00");
                txtTotalVenta.ForeColor = Color.Red;

                // Actualiza etiquetas con información relevante.
                lbl_V_cantidad.Text = sumcantidadproductos.ToString().Replace(",", ".");
                lbl_TotalItems.Text = dtgVenta.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        private void BtnVender_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Deseas realizar esta venta? Por favor, confirma tu elección.", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    // Crea un elemento XML para representar la factura de la venta.
                    if (!string.IsNullOrEmpty(txtcancelado.Text) && decimal.Parse(txtcancelado.Text.Replace(".", ",")) >= decimal.Parse(txtTotalVenta.Text.Replace(".",",")))
                    {
                        DateTime fechaIngreso = DateTime.ParseExact(lblFingresoVenta.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        bD2.XmlVenta(int.Parse(lblidcliente.Text), decimal.Parse(txtsubtotalventa.Text.Replace(".", ",")), decimal.Parse(lblValorIva.Text.Replace(".", ",")), decimal.Parse(txtivaVenta.Text.Replace(".", ",")), decimal.Parse(txtTotalVenta.Text.Replace(".", ",")), dtgVenta);
                        this.LimpiarDatosVenta();
                        this.Cargarnumerofactura();
                        // Guardar los tamaños actuales de las columnas
                        float tamañoColumna1 = tblVentayFactura.ColumnStyles[0].Width;
                        float tamañoColumna2 = tblVentayFactura.ColumnStyles[1].Width;

                        //Intercambiar los tamaños de las columnas
                        tblVentayFactura.ColumnStyles[0].Width = tamañoColumna2;
                        tblVentayFactura.ColumnStyles[1].Width = tamañoColumna1;
                        GS_Factura frmFactura = new GS_Factura();
                        //Añade GS_Factura como un control en el Panel
                        frmFactura.TopLevel = false;
                        frmFactura.Dock = DockStyle.Fill;
                        panelFactura.Controls.Add(frmFactura);
                        frmFactura.Show();
                        this.Cargarnumerofactura();
                    }
                    else MessageBox.Show("El usuario no ha cancelado. Por favor, ingrese un valor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void LimpiarDatosVenta()
        {
            lblcedulacliente.Text = "Numero de Cedula";
            lblnombrecliente.Text = "Nombre del Cliente";
            lblApellidocliente.Text = "Apellido del Cliente";
            dtgVenta.Rows.Clear();
            txtivaVenta.Text = "0";
            txtcancelado.Text = "0";

            txtcancelado.Enabled = false;
            dtgVenta.Enabled = true;
            btnañadirVenta.Enabled = true;
            btnVender.Enabled = false;
            txtSearchCliente.Text = "";
            this.GestionarFuncionalidadDtgVenta();
            this.VerificarFilasEnDataGridView();
        }
        private void VerificarFilasEnDataGridView()
        {
            if (dtgVenta.Rows.Count > 0)
            {
                btnConfirmarVenta.Visible = true;
                btnConfirmarVenta.Enabled = true;
            }
            else
            {
                btnConfirmarVenta.Visible = false;
                btnConfirmarVenta.Enabled = false;
            }
        }
        private void BtncancelarVenta_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Deseas cancelar la compra? Por favor, confirma tu elección.", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                this.LimpiarDatosVenta();
            }
        }
        private void BtnConfirmarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblcedulacliente.Text == "Numero Cedula")
                {
                    MessageBox.Show("El campo Cédula del Cliente está vacío. Por favor, ingrese un valor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                foreach (DataGridViewRow recorrerdata in dtgVenta.Rows)
                {
                    if (decimal.Parse(recorrerdata.Cells["StockProducto"].Value.ToString()) <= 0)
                    {
                        MessageBox.Show("Falta agregar la cantidad al Producto de Id: " + recorrerdata.Cells["IdProducto"].Value.ToString() + "", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                if (btnConfirmarVenta.Text == "  Cancelar Proceso de Pago")
                {
                    DialogResult respuestaCancelacion = MessageBox.Show("Deseas Cancelar al Proceso de Pago? Por favor, confirma tu elección.", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    
                    if (respuestaCancelacion == DialogResult.Yes)
                    {
                        txtcancelado.Enabled = false;
                        txtcancelado.Text = "0";
                        dtgVenta.Enabled = true;
                        btnañadirVenta.Enabled = true;
                        btnVender.Enabled = false;
                        btnvalidarCliente.Enabled = true;

                        btnConfirmarVenta.Text = "      Cerrar Venta";
                        btnConfirmarVenta.BackColor = Color.ForestGreen;
                    }
                }
                else
                {
                    DialogResult respuesta = MessageBox.Show("Deseas Pasar al Proceso de Pago? Por favor, confirma tu elección.", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (respuesta == DialogResult.Yes)
                    {
                        txtcancelado.Enabled = true;
                        dtgVenta.Enabled = false;
                        btnañadirVenta.Enabled = false;
                        btnConfirmarVenta.Text = "    Cancelar Proceso de Pago";
                        btnConfirmarVenta.Font = new Font(btnConfirmarVenta.Font.FontFamily, 20f);
                        btnVender.Enabled = true;
                        btnvalidarCliente.Enabled = false;
                        btnConfirmarVenta.BackColor = Color.Red;
                        txtcancelado.Focus();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void CklistConsumidorFinal_CheckedChanged(object sender, EventArgs e)
        {
            if (cklistConsumidorFinal.Checked)
            {
                lblcedulacliente.Text = "9999999999";
                lblnombrecliente.Text = "Consumidor";
                lblApellidocliente.Text = "Final";
                lblidcliente.Text = "1";
                txtSearchCliente.Clear();
                txtSearchCliente.Enabled = false;
            }
            else
            {
                txtSearchCliente.Enabled = true;
                lblcedulacliente.Text = "Numero Cedula";
                lblnombrecliente.Text = "Nombre del Cliente";
                lblnombrecliente.Text = "Apellido del Cliente";
             
            }
        }
        private void DtgVenta_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            this.CantidadDataGriedview();
        }        
        public void CantidadDataGriedview()
        {
            try
            {
                if (dtgVenta.CurrentRow != null && dtgVenta.CurrentRow.Cells[3] != null && dtgVenta.CurrentRow.Cells[3].Value != null && !string.IsNullOrEmpty(dtgVenta.CurrentRow.Cells[3].Value.ToString()) && dtgVenta.Rows.Count != 0)
                {
                    string cantidadStr = dtgVenta.CurrentRow.Cells[3].Value.ToString();
                    cantidadStr = cantidadStr.Replace(",", ".");
                    dtgVenta.CurrentRow.Cells[3].Value = cantidadStr;

                    decimal stock;
                    int id_product = int.Parse(dtgVenta.CurrentRow.Cells[1].Value.ToString());
                    stock = bD2.RetornarStock(id_product);
                    if (decimal.Parse(dtgVenta.CurrentRow.Cells[3].Value.ToString().Replace(".", ",")) > stock)
                    {
                        dtgVenta.CurrentRow.Cells[3].Value = 0;
                        MessageBox.Show("Producto no dispone de ese stock", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        this.CalcularCantidadData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        public void CalcularCantidadData()
        {
            try
            {
                decimal cantidad = decimal.Parse(dtgVenta.CurrentRow.Cells[3].Value.ToString().Replace(".", ","));
                decimal precio = decimal.Parse(dtgVenta.CurrentRow.Cells[4].Value.ToString().Replace(".", ","));

                decimal total = precio * cantidad;

                total = Math.Round(total, 2);


                dtgVenta.CurrentRow.Cells[5].Value = total.ToString("0.00").Replace(",", ".");
                this.GestionarFuncionalidadDtgVenta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        private void LblcontadorCedulaCliente_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(lblcontadorcedulaCliente.Text) > 10)
            {
                MessageBox.Show("El campo Cedula del Cliente no contiene 10 caracteres. Por favor, Ingrese todo los digitos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSearchCliente.MaxLength = 10;
                return;
            }           
        }
        private void btnAñadirCliente_Click(object sender, EventArgs e)
        {            
            try
            {
                DeshabilitarFormularios();
                ClienteVenta clienteVenta = new ClienteVenta();
                clienteVenta.FormClosed += (s, args) => HabilitarFormularios();
                clienteVenta.pasarCliente += new ClienteVenta.pasarformFactura(EjecutaClientes);
                clienteVenta.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        private void GS_GeneraFactura_Load(object sender, EventArgs e)
        {
            lblValorIva.Text = ObtenerValorIVAActual().ToString().Replace(",",".");
        }
        public decimal ObtenerValorIVAActual()
        {
            decimal valorIVA = 12.0m;
            try
            {
                tb = bD2.EscalarProcAlmTablaSinPar("SeleccionarIVAActual ", true);
                DataRow row = tb.Rows[0];
                valorIVA = Convert.ToDecimal(row["ValorIVA"].ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el ValorIVA: " + ex.Message);
            }
            return valorIVA;
        }
        private void txt_Buscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                {
                    if (txtSearchCliente.Text != null)
                    {
                        e.Handled = true;
                        tb.Clear();
                        par.Clear();
                        par.Add(new SqlParameter("@Cedula", txtSearchCliente.Text.Trim()));
                        tb = bD2.EscalarProcAlmTabla("BuscarClientePorCedula ", par, true);
                        if (tb.Rows.Count == 0)
                        {
                            MessageBox.Show("Cliente no encontrado. \n\nSe sugiere el registro del Cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            DataRow row = tb.Rows[0];
                            lblcedulacliente.Text = row["CEDULA"].ToString();
                            lblnombrecliente.Text = row["NOMBRE"].ToString();
                            lblApellidocliente.Text = row["APELLIDOS"].ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor ingrese un carácter");
                    }
                }
                else if (txtSearchCliente.Text == null)
                {
                    MessageBox.Show("Por favor ingrese un carácter");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        private void txtSearchCliente2_TextChanged(object sender, EventArgs e)
        {
            this.lblcontadorcedulaCliente.Text = txtSearchCliente.Text.Length.ToString();
        }
        private void txtcancelado2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtcancelado.Text))
                {
                    if (decimal.TryParse(txtcancelado.Text.Replace(".", ","), out decimal montoCancelado))
                    {
                        decimal totalVenta = decimal.Parse(txtTotalVenta.Text.Replace(".", ","));
                        decimal cambio = montoCancelado - totalVenta;
                        
                        if (cambio >= 0)
                        {
                            txtcambioVenta.Text = cambio.ToString().Replace(",", ".");
                            txtcambioVenta.ForeColor = Color.Green;
                        }
                        else
                        {
                            txtcambioVenta.Text = "0.00";
                            txtcambioVenta.ForeColor = Color.Black;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese un número válido en el campo de cancelación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtcambioVenta.Text = "0.00";
                        txtcambioVenta.ForeColor = Color.Black;
                    }
                }
                else
                {
                    txtcambioVenta.Text = "0,00";
                    txtcambioVenta.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        private void txtcancelado2_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtcancelado.Text == "")
                {
                    txtcancelado.Text = "0";
                    txtcancelado.ForeColor = Color.DimGray;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void txtcancelado2_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!(char.IsDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == (char)Keys.Back))
                {
                    e.Handled = true;
                    if (txtcancelado.Text != null)
                    {
                        DialogResult respuesta = MessageBox.Show("Deseas realizar esta venta? Por favor, confirma tu elección.", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (respuesta == DialogResult.Yes)
                        {
                            try
                            {
                                if (!string.IsNullOrEmpty(txtcancelado.Text) && decimal.Parse(txtcancelado.Text.Replace(".", ",")) >= decimal.Parse(txtTotalVenta.Text.Replace(".", ",")))
                                {
                                    DateTime fechaIngreso = DateTime.ParseExact(lblFingresoVenta.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                                    bD2.XmlVenta(int.Parse(lblidcliente.Text), decimal.Parse(txtsubtotalventa.Text.Replace(".", ",")), decimal.Parse(lblValorIva.Text.Replace(".", ",")), decimal.Parse(txtivaVenta.Text.Replace(".", ",")), decimal.Parse(txtTotalVenta.Text.Replace(".", ",")), dtgVenta);
                                    this.LimpiarDatosVenta();
                                    this.Cargarnumerofactura();
                                    float tamañoColumna1 = tblVentayFactura.ColumnStyles[0].Width;
                                    float tamañoColumna2 = tblVentayFactura.ColumnStyles[1].Width;

                                    tblVentayFactura.ColumnStyles[0].Width = tamañoColumna2;
                                    tblVentayFactura.ColumnStyles[1].Width = tamañoColumna1;
                                    GS_Factura frmFactura = new GS_Factura();
                                    frmFactura.TopLevel = false;
                                    frmFactura.Dock = DockStyle.Fill;
                                    panelFactura.Controls.Add(frmFactura);
                                    frmFactura.Show();
                                    this.Cargarnumerofactura();
                                }
                                else MessageBox.Show("El usuario no ha cancelado. Por favor, ingrese un valor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor ingrese un carácter");
                    }
                }
                else if (txtSearchCliente.Text == null)
                {
                    MessageBox.Show("Por favor ingregse un carácter");
                }

                if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
    }
}
