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
    public partial class ProductoVenta : Form
    {


        public delegate void pasarformFactura(string nameproduct,
        string cantidadproducto, string preciproducto);
//public delegate void pasarformFactura(string idproducto, string nameproduct,
//        string cantidadproducto, string preciproducto);




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

                //pasarproducto(lblidproducto.Text, txtnombreproducto.Text,
                //   txtcantidadproducto.Text, txtpreciounitario.Text);
                
                pasarproducto(txtnombreproducto.Text,
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
    }
}
