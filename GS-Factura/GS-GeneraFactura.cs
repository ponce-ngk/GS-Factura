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
        BD2 bD2 = new BD2();

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

        private void TxtSearchCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Si la tecla presionada no es un número y no es una tecla de control como Backspace o Delete
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Cancela el evento de tecla presionada
                e.Handled = true;

                // Muestra un mensaje de error
                MessageBox.Show("Solo se permiten números", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                return;
            }
        }

        private void TmtDate_Tick(object sender, EventArgs e)
        {
            lblFingresoVenta.Text = DateTime.Now.ToShortDateString();
        }

        private void BtnañadirVenta_Click(object sender, EventArgs e)
        {
            try            
            {
                ProductoVenta formPRODUCT = new ProductoVenta();
                // Asigna un evento delegado para pasar información entre formularios
                formPRODUCT.pasarproducto += new ProductoVenta.pasarformFactura(Ejecutaproductos);
                formPRODUCT.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        public void Ejecutaproductos(string idproduct,string nombreproducto, string cantidadproducto,string preciproducto)
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
                 cantidadproducto, preciproducto,  total.ToString("0.00"));
                this.GestionarFuncionalidadDtgVenta();
                // Verifica las filas en el DataGridView (puede haber algún tipo de validación)
                this.VerificarFilasEnDataGridView();
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

        // Este método se ejecuta al hacer clic en el botón de vender.
        private void BtnVender_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Deseas realizar esta venta? Por favor, confirma tu elección.", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    // Crea un elemento XML para representar la factura de la venta.
                    if (!string.IsNullOrEmpty(txtcancelado.Text) && decimal.Parse(txtcancelado.Text) >= decimal.Parse(txtTotalVenta.Text))
                    {
                        DateTime fechaIngreso = DateTime.ParseExact(lblFingresoVenta.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        bD2.XmlVenta(int.Parse(lblidcliente.Text), decimal.Parse(txtsubtotalventa.Text.Replace(".", ",")), decimal.Parse(lblValorIva.Text.Replace(".", ",")), decimal.Parse(txtTotalVenta.Text.Replace(".", ",")), dtgVenta);
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
            //txtdescuentoventa.Text = "0";
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
                // Hay al menos una fila, mostrar y habilitar el botón
                btnConfirmarVenta.Visible = true;
                btnConfirmarVenta.Enabled = true;
            }
            else
            {
                // No hay filas, ocultar y deshabilitar el botón
                btnConfirmarVenta.Visible = false;
                btnConfirmarVenta.Enabled = false;
            }
        }

        private void BtncancelarVenta_Click(object sender, EventArgs e)
        {
            //limpia los datos
            DialogResult respuesta = MessageBox.Show("Deseas cancelar la compra? Por favor, confirma tu elección.", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                this.LimpiarDatosVenta();
            }
        }



        // Este método se ejecuta al hacer clic en el botón de confirmar venta.
        private void BtnConfirmarVenta_Click(object sender, EventArgs e)
        {

            if (lblcedulacliente.Text == "Numero Cedula")
            {
                MessageBox.Show("El campo Cédula del Cliente está vacío. Por favor, ingrese un valor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            foreach (DataGridViewRow recorrerdata in dtgVenta.Rows)
            {
                // Compara el ID y el nombre del producto con los valores en la fila actual.

                if (decimal.Parse(recorrerdata.Cells["StockProducto"].Value.ToString()) <= 0 )
                {
                    MessageBox.Show("Falta agregar la cantidad al Producto de Id: "+ recorrerdata.Cells["IdProducto"].Value.ToString() + "", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            if (btnConfirmarVenta.Text == "  Cancelar Proceso de Pago")
            {
                DialogResult respuestaCancelacion = MessageBox.Show("Deseas Cancelar al Proceso de Pago? Por favor, confirma tu elección.", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Si la respuesta es afirmativa (Yes), realiza acciones de cancelación.

                if (respuestaCancelacion == DialogResult.Yes)
                {
                    txtcancelado.Enabled = false;
                    txtcancelado.Text = "0";
                    dtgVenta.Enabled = true;
                    btnañadirVenta.Enabled = true;
                    btnVender.Enabled = false;
                    btnvalidarCliente.Enabled = true;

                    btnConfirmarVenta.Text = "     Cerrar Venta";
                    btnConfirmarVenta.BackColor = Color.ForestGreen;
                }
            }
            else
            {
                // Si no está en modo de cancelación, pregunta si se desea pasar al proceso de pago.
                DialogResult respuesta = MessageBox.Show("Deseas Pasar al Proceso de Pago? Por favor, confirma tu elección.", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    txtcancelado.Enabled = true;
                    dtgVenta.Enabled = false;
                    btnañadirVenta.Enabled = false;
                    btnConfirmarVenta.Text = "  Cancelar Proceso de Pago";
                    btnVender.Enabled = true;
                    btnvalidarCliente.Enabled = false;
                    btnConfirmarVenta.BackColor = Color.Red;
                    txtcancelado.Focus();
                    return;
                }
            }
        }

        private void TxtSearchCliente_TextChanged(object sender, EventArgs e)
        {
            // Actualiza el valor del contador de caracteres con la longitud del texto en txtSearchCliente
            this.lblcontadorcedulaCliente.Text = txtSearchCliente.Text.Length.ToString();
            
        }

        private void Txtcancelado_TextChanged(object sender, EventArgs e)
        {
         

            try
            {
                // Verifica si el texto en txtcancelado no está en blanco o nulo
                if (!string.IsNullOrWhiteSpace(txtcancelado.Text))
                {
                    if (decimal.TryParse(txtcancelado.Text.Replace(".", ","), out decimal montoCancelado))
                    {
                        decimal totalVenta = decimal.Parse(txtTotalVenta.Text.Replace(".",","));
                        // Calcula el cambio restando el monto cancelado al total de la venta

                        decimal cambio = montoCancelado - totalVenta;

                        // Si el cambio es positivo, muestra el cambio en txtcambioVenta en color verde

                        if (cambio >= 0)
                        {
                            txtcambioVenta.Text = cambio.ToString().Replace(",",".");
                            txtcambioVenta.ForeColor = Color.Green;
                        }
                        else
                        {
                            // Si el cambio es negativo, muestra "0,00" en txtcambioVenta en color negro

                            txtcambioVenta.Text = "0.00"; //  valor que desees si el cambio es negativo
                            txtcambioVenta.ForeColor = Color.Black; 
                        }
                    }
                    else
                    {
                        // Muestra un mensaje de error si no se puede convertir el texto a decimal
                        MessageBox.Show("Ingrese un número válido en el campo de cancelación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtcambioVenta.Text = "0.00";
                        txtcambioVenta.ForeColor = Color.Black;
                    }
                }
                else
                {
                    // Si el texto en txtcancelado está en blanco o nulo, muestra "0,00" en txtcambioVenta en color negro

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


        private void Txtcancelado_Enter(object sender, EventArgs e)
        {
            try
            {
                // Si el texto en txtcancelado es "0", lo cambia a vacío y establece el color del texto a negro
                if (txtcancelado.Text == "0")
                {
                    txtcancelado.Text = "";
                    txtcancelado.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Txtcancelado_Leave(object sender, EventArgs e)
        {
            try
            {
                // Si el texto en txtcancelado está vacío, establece el texto a "0" y el color del texto a gris oscuro
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

        private void Txtcancelado_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',' && e.KeyChar != ' ' && !char.IsWhiteSpace(e.KeyChar))
            //{
            //    e.Handled = true;
            //    MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else if (e.KeyChar == ',')
            //{
            //    e.KeyChar = '.'; // Reemplazar la coma por un punto
            //}
            //else if (char.IsWhiteSpace(e.KeyChar))
            //{
            //    e.Handled = true;
            //    MessageBox.Show("No se permiten espacios en blanco", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //// Verificar si el usuario ha ingresado un punto decimal
            //if (e.KeyChar == ',' && txtcancelado.Text.IndexOf('.') > -1)
            //{
            //    // Si ya hay un punto decimal en el cuadro de texto, ignorar el evento
            //    e.Handled = true;
            //}
            //Permitir solo números, el caracter de control(para borrar) y el punto decimal
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                DialogResult respuesta = MessageBox.Show("Deseas realizar esta venta? Por favor, confirma tu elección.", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    try
                    {
                        // Crea un elemento XML para representar la factura de la venta.
                        if (!string.IsNullOrEmpty(txtcancelado.Text) && decimal.Parse(txtcancelado.Text) >= decimal.Parse(txtTotalVenta.Text))
                        {
                            DateTime fechaIngreso = DateTime.ParseExact(lblFingresoVenta.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                            bD2.XmlVenta(int.Parse(lblidcliente.Text), decimal.Parse(txtsubtotalventa.Text.Replace(".", ",")), decimal.Parse(lblValorIva.Text.Replace(".", ",")), decimal.Parse(txtTotalVenta.Text.Replace(".", ",")), dtgVenta);
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
            //Permitir solo una coma como punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }


        // Este método se ejecuta cuando cambia el estado del CheckBox de Consumidor Final.

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

                // Calculamos el total del producto
                decimal total = precio * cantidad;

                // Redondea el total a dos decimales
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
                // Cancela el evento de tecla presionada
                MessageBox.Show("El campo Cedula del Cliente no contiene 10 caracteres. Por favor, Ingrese todo los digitos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSearchCliente.MaxLength = 10;
                return;
            }
           
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            GS_Factura frmFactura = new GS_Factura();

            // Limpia el Panel antes de agregar el formulario
            panelFondo.Controls.Clear();

            // Añade GS_Factura como un control en el Panel
            frmFactura.TopLevel = false;
            frmFactura.Dock = DockStyle.Fill;
            panelFondo.Controls.Add(frmFactura);

            frmFactura.Show();

            this.Cargarnumerofactura();
        }

        public void iconButton1_Click_1(object sender, EventArgs e)
        {
            // Guardar los tamaños actuales de las columnas
            float tamañoColumna1 = tblVentayFactura.ColumnStyles[0].Width;
            float tamañoColumna2 = tblVentayFactura.ColumnStyles[1].Width;

            // Intercambiar los tamaños de las columnas
            tblVentayFactura.ColumnStyles[0].Width = tamañoColumna2;
            tblVentayFactura.ColumnStyles[1].Width = tamañoColumna1;

            GS_Factura frmFactura = new GS_Factura();


            // Añade GS_Factura como un control en el Panel
            frmFactura.TopLevel = false;
            frmFactura.Dock = DockStyle.Fill;
            panelFactura.Controls.Add(frmFactura);

            frmFactura.Show();

            this.Cargarnumerofactura();
        }

        private void btnAñadirCliente_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    ClienteVenta clienteVenta = new ClienteVenta();
                    clienteVenta.pasarCliente += new ClienteVenta.pasarformFactura(EjecutaClientes);
                    clienteVenta.ShowDialog();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GS_GeneraFactura_Load(object sender, EventArgs e)
        {
            lblValorIva.Text = ObtenerValorIVAActual().ToString().Replace(",",".");
        }
        public decimal ObtenerValorIVAActual()
        {
            decimal valorIVA = 12.0m; // Valor predeterminado

            try
            {
                    using (SqlCommand comando = new SqlCommand("SeleccionarIVAActual", AccesoDatos.AbrirConexion()))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Si hay resultados, obtener el valor del campo ValorIVA
                                valorIVA = Convert.ToDecimal(reader["ValorIVA"]);
                            }
                        }
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el ValorIVA: " + ex.Message);
            }

            return valorIVA;
        }
    }

}
