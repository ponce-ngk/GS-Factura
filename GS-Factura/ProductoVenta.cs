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
    public partial class ProductoVenta : Form
    {


        //public delegate void pasarformFactura(string nameproduct,
        //string cantidadproducto, string preciproducto);


        public delegate void pasarformFactura(string idproducto, string nameproduct,
                string cantidadproducto, string preciproducto);




        public event pasarformFactura pasarproducto;


        public ProductoVenta()
        {
            InitializeComponent();
        }

        private void btncloseProduct_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtnombreproducto_Enter(object sender, EventArgs e)
        {
            try
            {
                if (txtnombreproducto.Text == "Nombre del Producto....")
                {
                    txtnombreproducto.Text = "";
                    txtnombreproducto.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void txtnombreproducto_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtnombreproducto.Text == "")
                {
                    txtnombreproducto.Text = "Nombre del Producto....";
                    txtnombreproducto.ForeColor = Color.DimGray;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }





        private void txtcantidadproducto_Enter(object sender, EventArgs e)
        {
            try
            {
                if (txtcantidadproducto.Text == "0")
                {
                    txtcantidadproducto.Text = "";
                    txtcantidadproducto.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void txtcantidadproducto_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtcantidadproducto.Text == "")
                {
                    txtcantidadproducto.Text = "0";
                    txtcantidadproducto.ForeColor = Color.DimGray;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnGuardarPorducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (EspacioEnblanco())
                {
                    return;
                }
             

                pasarproducto(lblidproducto.Text, txtnombreproducto.Text,
                   txtcantidadproducto.Text, txtpreciounitario.Text);

          
                this.Hide();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool EspacioEnblanco()
        {
            if (txtnombreproducto.Text == "")
            {
                MessageBox.Show("El campo nombre del Producto está vacío. Por favor, ingrese un nombre válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            if (txtcantidadproducto.Text == "0")
            {
                MessageBox.Show("El campo cantidad del producto se encuentra en 0. Por favor, ingrese una cantidad valida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            return false;


        }

        private void txtcantidadproducto_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtbuscarproducto_Enter(object sender, EventArgs e)
        {
            try
            {
                if (txtbuscarproducto.Text == "Busca Nombre del Producto...")
                {
                    txtbuscarproducto.Text = "";
                    txtbuscarproducto.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void txtbuscarproducto_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtbuscarproducto.Text == "")
                {
                    txtbuscarproducto.Text = "Busca Nombre del Producto...";
                    txtbuscarproducto.ForeColor = Color.DimGray;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void txtbuscarproducto_TextChanged(object sender, EventArgs e)
        {
            if (txtbuscarproducto.Text != "" && txtbuscarproducto.Text != "Busca Nombre del Producto...")
            {

                try
                {
                    string sentenciaextraer = @"select IDPRODUCTO 
                    as ID, PRODUCTO, PRECIO_UNITARIO AS PRECIO_UNITARIO,
                    STOCK from [dbo].[PRODUCTO]
                    where PRODUCTO LIKE '" + txtbuscarproducto.Text + "%'";


                    this.extraerInfoData(sentenciaextraer);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (txtbuscarproducto.Text == "")
            {
                dtgventaproducto.Columns.Clear();
            }
        }

        public void extraerInfoData(string sentencia)
        {
            try
            {

                dtgventaproducto.Columns.Clear();
                using (SqlConnection conexion = AccesoDatos.abrirConexion())
                {
                    using (SqlDataAdapter sentenciadata = new SqlDataAdapter(sentencia, conexion))
                    {
                        DataTable asiganardata = new DataTable();
                        sentenciadata.Fill(asiganardata);

                        dtgventaproducto.DataSource = asiganardata;
                    } // sentenciadata se libera automáticamente al salir del bloque using
                }

                dtgventaproducto.Columns["Id"].Width = 42;
                //dtgventaproducto.Columns["Stock"].Width = 52;
                //dtgventaproducto.Columns["IdLote"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtgventaproducto_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                lblidproducto.Text = dtgventaproducto.Rows[dtgventaproducto.CurrentRow.Index].Cells[0].Value.ToString();
                txtnombreproducto.Text = dtgventaproducto.Rows[dtgventaproducto.CurrentRow.Index].Cells[1].Value.ToString();
                txtpreciounitario.Text = dtgventaproducto.Rows[dtgventaproducto.CurrentRow.Index].Cells[2].Value.ToString();
                lblcantidadactualproducto.Text = dtgventaproducto.Rows[dtgventaproducto.CurrentRow.Index].Cells[3].Value.ToString();
                lbltextocantidad.Text = "Cantidad Actual:";
                lblcantidadactualproducto.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void txtcantidadproducto_TextChanged(object sender, EventArgs e)
        {
            if (txtcantidadproducto.Text != "" && decimal.Parse(txtcantidadproducto.Text) > decimal.Parse(lblcantidadactualproducto.Text))
            {
                MessageBox.Show("La cantidad colocada sobre pasa al stock del producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtcantidadproducto.Text = "0";
            }
        }
    }
}
