using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                if (string.IsNullOrEmpty(txtSearchCliente.Text))
                {
                    MessageBox.Show("El campo Cédula del Cliente está vacío. Por favor, ingrese un valor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (int.Parse(txtSearchCliente.Text) != 10)
                {
                    MessageBox.Show("El campo Cedula del Cliente no contiene 10 caracteres. Por favor, Ingrese todo los digitos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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
            //cmbTipoPago.SelectedIndex = 0;
            //this.GestionarFuncionalidadDtgVenta(decimal.Parse(txtdescuentoventa.Text), decimal.Parse(txtivaVenta.Text));
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


        public void ejecutaproductos(
            string nombreproducto, string cantidadproducto,
            string preciproducto)
        {

            int cantidad = int.Parse(cantidadproducto);
            decimal precio = decimal.Parse(preciproducto);
           
            // Calculamos el total
            decimal total = precio * cantidad;
;

            total = Math.Round(total, 2);

                 dtgVenta.Rows.Add(null, 1, nombreproducto,
                 cantidadproducto, preciproducto,  total.ToString("0.00"));

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
            //try
            //{
            //    if (e.ColumnIndex >= 0 && this.dtgVenta.Columns[e.ColumnIndex].Name == "Eliminarfila" && e.RowIndex >= 0)
            //    {
            //        e.Paint(e.CellBounds, DataGridViewPaintParts.All);
            //        Icon icoAtomico = new Icon(Environment.CurrentDirectory + @"\\e.ico", 30, 30);
            //        e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);
            //        this.dtgVenta.Rows[e.RowIndex].Height = icoAtomico.Height + 15;
            //        this.dtgVenta.Columns[e.ColumnIndex].Width = icoAtomico.Width + 15;
            //        e.Handled = true;
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
    }
}
