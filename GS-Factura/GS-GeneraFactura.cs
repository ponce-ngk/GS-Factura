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


namespace GS_Factura
{
    public partial class GS_GeneraFactura : Form
    {

        public GS_GeneraFactura()
        {
            InitializeComponent();
        }

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
                else if (CrudCliente.VerificarExistenciaRegistros(consultaSQL, txtSearchCliente.Text))
                {
                    //representante1validado = true;

                    MessageBox.Show("El Cliente ha sido encontrado en la base de datos. Puede proceder a guardar la información.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    Cliente cliente = CrudCliente.MostrarDatosCliente(@"select CEDULA, NOMBRE, APELLIDOS from [dbo].[CLIENTE] WHERE CEDULA =  '" + txtSearchCliente.Text + "'");

                    if (cliente != null)
                    {
                        // Asignación de valores a las etiquetas
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

            int cantidad = int.Parse(cantidadproducto);
            decimal precio = decimal.Parse(preciproducto);
           
            // Calculamos el total
            decimal total = precio * cantidad;
;

            total = Math.Round(total, 2);

                 dtgVenta.Rows.Add(null, idproduct, nombreproducto,
                 cantidadproducto, preciproducto,  total.ToString("0.00"));

            this.GestionarFuncionalidadDtgVenta();
            this.VerificarFilasEnDataGridView();


        }

        private void dtgVenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dtgVenta.Columns[e.ColumnIndex].Name == "Eliminarfila")
                {
                    int index = e.RowIndex;
                    if (index >= 0)
                    {
                        dtgVenta.Rows.RemoveAt(index);
                        //this.GestionarFuncionalidadDtgCompra(decimal.Parse(txtdescuentoCompra.Text), decimal.Parse(txtcompraiva.Text));
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
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    // Ajusta las dimensiones del icono para hacer el botón más pequeño
                    int iconWidth = 30;
                    int iconHeight = 30;

                    Icon icoAtomico = new Icon(Environment.CurrentDirectory + @"\\remove.ico", iconWidth, iconHeight);
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


        //public void GestionarFuncionalidadDtgCompra(decimal descuentoCompra, decimal ivaproducto)
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
                totalproductos += decimal.Parse(recorrerdata.Cells["TotalProducto"].Value.ToString());
                sumcantidadproductos += int.Parse(recorrerdata.Cells["StockProducto"].Value.ToString());
            }





            // Calculamos el subtotal (sin descuento ni IVA)
            subtotalCompra = totalproductos;

            txtsubtotalventa.Text = subtotalCompra.ToString("0.00");



            // Aplicamos el descuento (si es que el usuario lo ingresó)
            // supongamos que esta variable indica si el usuario ingresó un descuento

            descuentoCompra = subtotalCompra * (descuentoCompra / 100.0M);
            subtotalCompra -= descuentoCompra;
            txtsubtotalDescuentoVenta.Text = descuentoCompra.ToString("0.00");


            // Agregamos el IVA
            decimal iva = subtotalCompra * (int.Parse(txtivaVenta.Text) / 100.0M);

            subtotalCompra += iva;

            // Calculamos el total de la compra
            decimal total = subtotalCompra;
            txtTotalVenta.Text = total.ToString("0.00");

            txtTotalVenta.ForeColor = Color.Red;


            lbl_V_cantidad.Text = sumcantidadproductos.ToString();
            lbl_TotalItems.Text = dtgVenta.Rows.Count.ToString();
        }

        private void btnVender_Click(object sender, EventArgs e)
        {

        }

        public void LimpiarDatosVenta()
        {
            lblcedulacliente.Text = "Numero de Cedula";
            lblnombrecliente.Text = "Nombre del Cliente";
            lblApellidocliente.Text = "Apellido del Cliente";
            dtgVenta.Rows.Clear();
            txtdescuentoventa.Text = "0";
            txtivaVenta.Text = "0";
            txtcancelado.Text = "0,00";

            txtcancelado.Enabled = false;
            dtgVenta.Enabled = true;
            btnañadirVenta.Enabled = true;
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
            DialogResult respuesta = MessageBox.Show("Deseas cancelar la compra? Por favor, confirma tu elección.", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                this.LimpiarDatosVenta();
            }
        }

        private void btnConfirmarVenta_Click(object sender, EventArgs e)
        {
           
            if(btnConfirmarVenta.Text == "  Cancelar Proceso de Pago")
            {
                DialogResult respuestaCancelacion = MessageBox.Show("Deseas Cancelar al Proceso de Pago? Por favor, confirma tu elección.", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuestaCancelacion == DialogResult.Yes)
                {
                    txtcancelado.Enabled = false;
                    txtcancelado.Text = "0.00";
                    dtgVenta.Enabled = true;
                    btnañadirVenta.Enabled = true;
                    btnConfirmarVenta.Text = "     Cerrar Venta";
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
                    btnConfirmarVenta.Text = "  Cancelar Proceso de Pago";
                    btnConfirmarVenta.BackColor = Color.Red;
                    return;
                }
            }
        }

        private void txtSearchCliente_TextChanged(object sender, EventArgs e)
        {
            this.lblcontadorcedulaCliente.Text = txtSearchCliente.Text.Length.ToString();
        }
    }
}
