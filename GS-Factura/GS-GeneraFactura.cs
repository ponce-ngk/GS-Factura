﻿using System;
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


namespace GS_Factura
{
    public partial class GS_GeneraFactura : Form
    {
        public GS_GeneraFactura()
        {
            InitializeComponent();
            this.cargarnumerofactura();
        }

        public void cargarnumerofactura()
        {
            SqlCommand command = new SqlCommand("select top 1 IDFACTURA from FACTURA order by IDFACTURA desc", AccesoDatos.abrirConexion());
            string result = command.ExecuteScalar().ToString().PadLeft(6, '0');
            if (result== "")
            {
                result = "0";
            }
            lblnumerofactura.Text = "001-" + result;
        }

        // Este método se ejecuta al hacer clic en el botón de validar cliente.
        private void btnvalidarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                string consultaSQL = "select CEDULA,NOMBRE,APELLIDOS from [dbo].[CLIENTE] WHERE CEDULA  = @CedulaPerson";

                if (string.IsNullOrEmpty(txtSearchCliente.Text))
                {
                    MessageBox.Show("El campo Cédula del Cliente está vacío. Por favor, ingrese un valor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (int.Parse(lblcontadorcedulaCliente.Text) != 10)
                {
                    MessageBox.Show("El campo Cedula del Cliente no contiene 10 caracteres. Por favor, Ingrese todo los digitos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Verifica si la cédula del cliente existe en la base de datos.
                else if (CrudCliente.VerificarExistenciaRegistros(consultaSQL, txtSearchCliente.Text))
                {

                    MessageBox.Show("El Cliente ha sido encontrado en la base de datos. Puede proceder a guardar la información.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    Cliente cliente = CrudCliente.MostrarDatosCliente(@"select IDCLIENTE, CEDULA, NOMBRE, APELLIDOS from [dbo].[CLIENTE] WHERE CEDULA =  '" + txtSearchCliente.Text + "'");

                    if (cliente != null)
                    {
                        // Asignación de valores a las etiquetas
                        lblidcliente.Text = cliente.IdCliente.ToString();
                        lblcedulacliente.Text = cliente.Cedula;
                        lblnombrecliente.Text = cliente.Nombre;
                        lblApellidocliente.Text = cliente.Apellido;
                    }

                    return;
                }
                else
                {
                    MessageBox.Show("La cédula del Cliente no se encuentra en la base de datos. Por favor, ingrese una cédula válida", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void txtSearchCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Si la tecla presionada no es un número y no es una tecla de control como Backspace o Delete
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Cancela el evento de tecla presionada
                e.Handled = true;

                // Muestra un mensaje de error
                MessageBox.Show("Solo se permiten números", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void tmtDate_Tick(object sender, EventArgs e)
        {
            lblFingresoVenta.Text = DateTime.Now.ToShortDateString();

        }

        private void btnañadirVenta_Click(object sender, EventArgs e)
        {
            try
            {

                ProductoVenta formPRODUCT = new ProductoVenta();
                // Asigna un evento delegado para pasar información entre formularios
                formPRODUCT.pasarproducto += new ProductoVenta.pasarformFactura(ejecutaproductos);
                formPRODUCT.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        public void ejecutaproductos(string idproduct,
            string nombreproducto, string cantidadproducto,
            string preciproducto)
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

        // Este método verifica si un producto ya ha sido agregado a la DataGridView en la aplicación.
        // Recibe dos parámetros: el ID del producto y el nombre del producto.
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

        // Este evento se desencadena cuando se hace clic en el contenido de una celda en la DataGridView.

        private void dtgVenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void dtgVenta_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

                    Icon icoAtomico = new Icon(Properties.Resources.remove, iconWidth, iconHeight);

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

        // Este método gestiona la funcionalidad de la DataGridView de ventas.

        public void GestionarFuncionalidadDtgVenta()
        {
            decimal totalproductos = 0;
            int sumcantidadproductos = 0;
            decimal subtotalCompra = 0.0M;
            decimal descuentoCompra = 0.0M;

            btnConfirmarVenta.Visible = true;
            btnConfirmarVenta.Enabled = true;

            foreach (DataGridViewRow recorrerdata in dtgVenta.Rows)
            {
                // Suma los totales y cantidades de productos.
                totalproductos += decimal.Parse(recorrerdata.Cells["TotalProducto"].Value.ToString());
                sumcantidadproductos += int.Parse(recorrerdata.Cells["StockProducto"].Value.ToString());
            }

            // Calculamos el subtotal (sin descuento ni IVA)
            subtotalCompra = totalproductos;

            txtsubtotalventa.Text = subtotalCompra.ToString("0.00");

            // Aplicamos el descuento  que es 0
            txtsubtotalDescuentoVenta.Text = descuentoCompra.ToString("0.00");


            // Agregamos el IVA
            decimal iva = subtotalCompra * (int.Parse(txtivaVenta.Text) / 100.0M);

            subtotalCompra += iva;

            // Calculamos el total de la compra
            decimal total = subtotalCompra;
            txtTotalVenta.Text = total.ToString("0.00");

            txtTotalVenta.ForeColor = Color.Red;


            // Actualiza etiquetas con información relevante.

            lbl_V_cantidad.Text = sumcantidadproductos.ToString();
            lbl_TotalItems.Text = dtgVenta.Rows.Count.ToString();
        }

        // Este método se ejecuta al hacer clic en el botón de vender.
        private void btnVender_Click(object sender, EventArgs e)
        {
            
            DialogResult respuesta = MessageBox.Show("Deseas realizar esta venta? Por favor, confirma tu elección.", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    // Crea un elemento XML para representar la factura de la venta.

                    DateTime fechaIngreso = DateTime.ParseExact(lblFingresoVenta.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                    XElement Venta = new XElement("FACTURA");
                    Venta.Add(new XElement("item",
                        new XElement("IDCLIENTE", int.Parse(lblidcliente.Text)),
                        new XElement("FECHA", fechaIngreso),
                        new XElement("SUBTOTAL", decimal.Parse(txtsubtotalventa.Text.Replace(".", ","))),
                        new XElement("TOTAL", decimal.Parse(txtTotalVenta.Text.Replace(".", ",")))
                        ));
                
                    XElement detalle_venta = new XElement("DETALLE_FACTURA");
                    foreach (DataGridViewRow row in dtgVenta.Rows)
                    {

                        detalle_venta.Add(new XElement("item",
                                new XElement("IDPRODUCTO", row.Cells["IdProducto"].Value),
                                new XElement("CANTIDAD", row.Cells["StockProducto"].Value),
                                new XElement("PRECIO_UNITARIO", Convert.ToDecimal(row.Cells["PrecioVenta"].Value)),
                                new XElement("SUBTOTAL", Convert.ToDecimal(row.Cells["TotalProducto"].Value))
                                ));

                    }

                    // Combina los elementos XML de venta y detalle de venta en una consulta.
                    string consulta = Venta.ToString() + detalle_venta.ToString();
                    xmlVenta(consulta);
                    this.cargarnumerofactura();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            GS_Factura frm = new GS_Factura();
            frm.Show();

        }

        // Este método procesa la venta almacenando la información en la base de datos.
        public void xmlVenta(string Detalle)
        {
            try
            {
                using (SqlConnection conexion = AccesoDatos.abrirConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_VentaProducto", conexion))
                    {
                        cmd.Parameters.Add("@StringXML", SqlDbType.VarChar).Value = Detalle;
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.ExecuteNonQuery();
                    } // El bloque using cerrará automáticamente el comando.

                    MessageBox.Show("La venta ha sido exitosa.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LimpiarDatosVenta();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        //limpia todos los datos
        public void LimpiarDatosVenta()
        {
            lblcedulacliente.Text = "Numero de Cedula";
            lblnombrecliente.Text = "Nombre del Cliente";
            lblApellidocliente.Text = "Apellido del Cliente";
            dtgVenta.Rows.Clear();
            txtdescuentoventa.Text = "0";
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

        private void btncancelarventa_Click(object sender, EventArgs e)
        {
            //limpia los datos
            DialogResult respuesta = MessageBox.Show("Deseas cancelar la compra? Por favor, confirma tu elección.", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                this.LimpiarDatosVenta();
            }
        }



        // Este método se ejecuta al hacer clic en el botón de confirmar venta.
        private void btnConfirmarVenta_Click(object sender, EventArgs e)
        {

            if (lblcedulacliente.Text == "Numero Cedula")
            {
                MessageBox.Show("El campo Cédula del Cliente está vacío. Por favor, ingrese un valor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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
                    return;
                }
            }
        }

        private void txtSearchCliente_TextChanged(object sender, EventArgs e)
        {
            // Actualiza el valor del contador de caracteres con la longitud del texto en txtSearchCliente
            this.lblcontadorcedulaCliente.Text = txtSearchCliente.Text.Length.ToString();
        }

        private void txtcancelado_TextChanged(object sender, EventArgs e)
        {
         

            try
            {
                // Verifica si el texto en txtcancelado no está en blanco o nulo
                if (!string.IsNullOrWhiteSpace(txtcancelado.Text))
                {
                    if (decimal.TryParse(txtcancelado.Text, out decimal montoCancelado))
                    {
                        decimal totalVenta = decimal.Parse(txtTotalVenta.Text);
                        // Calcula el cambio restando el monto cancelado al total de la venta

                        decimal cambio = montoCancelado - totalVenta;

                        // Si el cambio es positivo, muestra el cambio en txtcambioVenta en color verde

                        if (cambio >= 0)
                        {
                            txtcambioVenta.Text = cambio.ToString();
                            txtcambioVenta.ForeColor = Color.Green;
                        }
                        else
                        {
                            // Si el cambio es negativo, muestra "0,00" en txtcambioVenta en color negro

                            txtcambioVenta.Text = "0,00"; //  valor que desees si el cambio es negativo
                            txtcambioVenta.ForeColor = Color.Black; 
                        }
                    }
                    else
                    {
                        // Muestra un mensaje de error si no se puede convertir el texto a decimal
                        MessageBox.Show("Ingrese un número válido en el campo de cancelación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtcambioVenta.Text = "0,00";
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


        private void txtcancelado_Enter(object sender, EventArgs e)
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

        private void txtcancelado_Leave(object sender, EventArgs e)
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

        private void txtcancelado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',' && e.KeyChar != ' ')
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (e.KeyChar == '.')
            {
                e.KeyChar = ','; // Reemplazar la coma por un punto
            }
            else if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("No se permiten espacios en blanco", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // Verificar si el usuario ha ingresado un punto decimal
            if (e.KeyChar == ',' && txtcancelado.Text.IndexOf(',') > -1)
            {
                // Si ya hay un punto decimal en el cuadro de texto, ignorar el evento
                e.Handled = true;
            }
        }


        // Este método se ejecuta cuando cambia el estado del CheckBox de Consumidor Final.

        private void cklistConsumidorFinal_CheckedChanged(object sender, EventArgs e)
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
    }
}
