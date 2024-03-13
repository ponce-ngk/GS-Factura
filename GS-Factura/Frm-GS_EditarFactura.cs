using GS_Factura.Clases;
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

namespace GS_Factura
{
    public partial class GS_EditarFactura : Form
    {
        private int idFactura;
        DataTable datosFactura;
        BD2 OAD = new BD2();

        public GS_EditarFactura(int idFactura)
        {
            InitializeComponent();
            this.idFactura = idFactura;
        }
        private void CargarDatosFactura(int idFactura)
        {
            try
            {
                datosFactura = new BD2().ObtenerDatosFactura(idFactura);
                if (datosFactura.Rows.Count > 0)
                {
                    lblcedulacliente.Text = datosFactura.Rows[0]["CEDULA"].ToString();
                    lblidcliente.Text = datosFactura.Rows[0]["IDCLIENTE"].ToString();
                    lblnombrecliente.Text = datosFactura.Rows[0]["ClienteNombre"].ToString();
                    txtSearchCliente.Text = datosFactura.Rows[0]["CEDULA"].ToString();
                    lblApellidocliente.Text = datosFactura.Rows[0]["ClienteApellidos"].ToString();
                    lblnumerofactura.Text = datosFactura.Rows[0]["IDFACTURA"].ToString();
                    lblFingresoVenta.Text = datosFactura.Rows[0]["FechaEmision"].ToString();
                    lblValorIva.Text = datosFactura.Rows[0]["IVA"].ToString().Replace(",", ".");
                    dtgVenta.DataSource = datosFactura;
                    dtgVenta.Columns["CANTIDAD"].DefaultCellStyle.Format = "N2";
                    this.ColumnViwers();
                    dtgVenta.Columns["IDPRODUCTO"].Width = 110;
                    // Obtener la fecha y hora actual
                    DateTime fechaHoraActual = DateTime.Now;
                    lblEdicion.Text = Convert.ToString(fechaHoraActual);
                    this.GestionarFuncionalidadDtgVenta();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ColumnViwers()
        {
            dtgVenta.Columns["ClienteNombre"].Visible = false;
            dtgVenta.Columns["ClienteApellidos"].Visible = false;
            dtgVenta.Columns["FechaEmision"].Visible = false;
            dtgVenta.Columns["CEDULA"].Visible = false;
            dtgVenta.Columns["IDFACTURA"].Visible = false;
            dtgVenta.Columns["IDDETALLEFACTURA"].Visible = false;
            dtgVenta.Columns["CANTIDADANTES"].Visible = false;
            dtgVenta.Columns["IVA"].Visible = false;
            dtgVenta.Columns["IDCLIENTE"].Visible = false;

            //ReadOnly
            dtgVenta.Columns["IDPRODUCTO"].ReadOnly = true;
            dtgVenta.Columns["NombreProducto"].ReadOnly = true;
            dtgVenta.Columns["PRECIO_UNITARIO"].ReadOnly = true;
            dtgVenta.Columns["TotalProducto"].ReadOnly = true;
            dtgVenta.Columns["CANTIDAD"].ReadOnly = false;
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

                    System.Drawing.Icon icoAtomico = new System.Drawing.Icon(Properties.Resources.remove, iconWidth, iconHeight);

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

        public void Ejecutaproductos(string idproduct, string nombreproducto, string cantidadproducto, string preciproducto)
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
                    DataRow newRow = datosFactura.NewRow();
                    newRow["IDPRODUCTO"] = idproduct;
                    newRow["NombreProducto"] = nombreproducto;
                    newRow["CANTIDAD"] = cantidadproducto;
                    newRow["CANTIDADANTES"] = cantidadproducto;
                    newRow["PRECIO_UNITARIO"] = preciproducto;
                    newRow["TotalProducto"] = total.ToString("0.00");
                    datosFactura.Rows.Add(newRow);
                    dtgVenta.DataSource = null;
                    dtgVenta.DataSource = datosFactura;

                    this.ColumnViwers();
                    this.GestionarFuncionalidadDtgVenta();
                    // Verifica las filas en el DataGridView (puede haber algún tipo de validación)
                    this.VerificarFilasEnDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
        private void Btncancelarventa_Click(object sender, EventArgs e)
        {
            this.Close();
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
        public void GestionarFuncionalidadDtgVenta()
        {
            try
            {
                decimal totalproductos = 0;
                decimal sumcantidadproductos = 0;
                decimal subtotalCompra = 0.0M;
                decimal descuentoCompra = 0.0M;
                decimal iva12 = decimal.Parse(lblValorIva.Text.Replace(".", ","));
                btnConfirmarVenta.Visible = true;
                btnConfirmarVenta.Enabled = true;
                foreach (DataGridViewRow recorrerdata in dtgVenta.Rows)
                {
                    // Suma los totales y cantidades de productos.
                    totalproductos += decimal.Parse(recorrerdata.Cells["TotalProducto"].Value.ToString().Replace(".", ","));
                    sumcantidadproductos += decimal.Parse(recorrerdata.Cells["CANTIDAD"].Value.ToString().Replace(".", ","));
                }
                // Calculamos el subtotal (sin descuento ni IVA)
                subtotalCompra = totalproductos;
                txtsubtotalventa.Text = subtotalCompra.ToString("0.00");

                // Agregamos el IVA
                decimal iva = subtotalCompra * (iva12 / 100.0M);
                //decimal iva = subtotalCompra * (int.Parse(12.00) / 100.0M);

                subtotalCompra += iva;

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
            }
        }
        private void GS_EditarFactura_Load(object sender, EventArgs e)
        {
            CargarDatosFactura(idFactura);
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
        private void Txtcancelado_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Verifica si el texto en txtcancelado no está en blanco o nulo
                if (!string.IsNullOrWhiteSpace(txtcancelado.Text))
                {
                    if (decimal.TryParse(txtcancelado.Text.Replace(".", ","), out decimal montoCancelado))
                    {
                        decimal totalVenta = decimal.Parse(txtTotalVenta.Text.Replace(".", ","));
                        // Calcula el cambio restando el monto cancelado al total de la venta
                        decimal cambio = montoCancelado - totalVenta;
                        // Si el cambio es positivo, muestra el cambio en txtcambioVenta en color verde
                        if (cambio >= 0)
                        {
                            txtcambioVenta.Text = cambio.ToString().Replace(",", ".");
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
        private void VerificarFilasEnDataGridView()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                if (dtgVenta.CurrentRow != null && dtgVenta.CurrentRow.Cells["CANTIDAD"] != null && dtgVenta.CurrentRow.Cells["CANTIDAD"].Value != null && !string.IsNullOrEmpty(dtgVenta.CurrentRow.Cells["CANTIDAD"].Value.ToString()) && dtgVenta.Rows.Count != 0)
                {
                    string cantidadStr = dtgVenta.CurrentRow.Cells["CANTIDAD"].Value.ToString();
                    string cantidadAnterior = dtgVenta.CurrentRow.Cells["CANTIDADANTES"].Value.ToString();
                    cantidadStr = cantidadStr.Replace(",", ".");
                    dtgVenta.CurrentRow.Cells["CANTIDAD"].Value = cantidadStr;


                    decimal stock;
                    int id_product = int.Parse(dtgVenta.CurrentRow.Cells["IDPRODUCTO"].Value.ToString());
                    stock = OAD.RetornarStock(id_product);
                    if (decimal.Parse(dtgVenta.CurrentRow.Cells["CANTIDAD"].Value.ToString().Replace(".", ",")) > stock)
                    {
                        dtgVenta.CurrentRow.Cells["CANTIDAD"].Value = cantidadAnterior;
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
                decimal cantidad = decimal.Parse(dtgVenta.CurrentRow.Cells["CANTIDAD"].Value.ToString().Replace(".", ","));
                decimal precio = decimal.Parse(dtgVenta.CurrentRow.Cells["PRECIO_UNITARIO"].Value.ToString().Replace(".", ","));
                // Calculamos el total del producto
                decimal total = precio * cantidad;
                // Redondea el total a dos decimales
                total = Math.Round(total, 2);
                dtgVenta.CurrentRow.Cells["TotalProducto"].Value = total.ToString("0.00").Replace(",", ".");
                this.GestionarFuncionalidadDtgVenta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
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
                    // Compara el ID y el nombre del producto con los valores en la fila actual.
                    if (decimal.Parse(recorrerdata.Cells["CANTIDAD"].Value.ToString()) <= 0)
                    {
                        MessageBox.Show("Falta agregar la cantidad al Producto de Id: " + recorrerdata.Cells["IdProducto"].Value.ToString() + "", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BtnAñadirCliente_Click(object sender, EventArgs e)
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
        public void EjecutaClientes(string idpcliente, string cedulacliente,string nombrecliente, string apellidocliente)
        {
            lblidcliente.Text = idpcliente;
            lblcedulacliente.Text = cedulacliente;
            txtSearchCliente.Text = cedulacliente;
            lblnombrecliente.Text = nombrecliente;
            lblApellidocliente.Text = apellidocliente;
        }
        private void BtnVender_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Deseas realizar esta venta? Por favor, confirma tu elección.", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    // Crea un elemento XML para representar la factura de la venta.
                    if (!string.IsNullOrEmpty(txtcancelado.Text) && decimal.Parse(txtcancelado.Text.Replace(".", ",")) >= decimal.Parse(txtTotalVenta.Text.Replace(".", ",")))
                    {
                        OAD.XmlEditarFactura(int.Parse(lblnumerofactura.Text), int.Parse(lblidcliente.Text), decimal.Parse(txtsubtotalventa.Text.Replace(".", ",")), decimal.Parse(lblValorIva.Text.Replace(".", ",")), decimal.Parse(txtivaVenta.Text.Replace(".", ",")), decimal.Parse(txtTotalVenta.Text.Replace(".", ",")), dtgVenta);
                        this.Close();
                    }
                    else MessageBox.Show("El usuario no ha cancelado. Por favor, ingrese un valor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
    }

}
