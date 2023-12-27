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




        // Declaración del delegado
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

        // Este método se ejecuta cuando el campo de nombre de producto recibe el foco.

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

        // Este método se ejecuta cuando el campo de nombre de producto pierde el foco.
        private void txtnombreproducto_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtnombreproducto.Text == "")
                {
                    // Restaura el texto predeterminado y el color del texto.

                    txtnombreproducto.Text = "Nombre del Producto....";
                    txtnombreproducto.ForeColor = Color.DimGray;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }




        //recibe el foco
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
        //pierde el foco.
        private void txtcantidadproducto_Leave(object sender, EventArgs e)
        {
            try
            {
                // Si el texto está vacío, lo cambia a "0" y establece el color del texto a gris oscuro

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

        // Método asociado al evento Click del botón btnGuardarPorducto
        private void btnGuardarPorducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (EspacioEnblanco())
                {
                    return;
                }

                // Llama al método asociado al delegado pasarformFactura
                pasarproducto(lblidproducto.Text, txtnombreproducto.Text,
                   txtcantidadproducto.Text, txtpreciounitario.Text);
                // Oculta la ventana actual
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

        // Este método se ejecuta cuando el campo de búsqueda de productos recibe el foco.
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

        // Este método se ejecuta cuando el campo de búsqueda de productos pierde el foco.
        private void txtbuscarproducto_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtbuscarproducto.Text == "")
                {
                        // Restaura el texto predeterminado y el color del texto.
                    txtbuscarproducto.Text = "Busca Nombre del Producto...";
                    txtbuscarproducto.ForeColor = Color.DimGray;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        // Este método se ejecuta cuando cambia el texto en el campo de búsqueda de productos.

        private void txtbuscarproducto_TextChanged(object sender, EventArgs e)
        {
            if (txtbuscarproducto.Text != "" && txtbuscarproducto.Text != "Busca Nombre del Producto...")
            {

                try
                {
                    // Sentencia SQL para extraer información de productos que coincidan con el texto de búsqueda.

                    string sentenciaextraer = @"select IDPRODUCTO 
                    as IDPRODUCTO, PRODUCTO, PRECIO_UNITARIO AS PRECIO_UNITARIO,
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
                dtgventaproducto.DataSource = AccesoDatos.llenartablaparabuscar("exec sp_Mostrar_PRODUCTOS");
            }
        }

        public void extraerInfoData(string sentencia)
        {
            try
            {
                //limpia las columnas
                dtgventaproducto.Columns.Clear();
                // Abre una conexión a la base de datos utilizando el objeto AccesoDatos
                using (SqlConnection conexion = AccesoDatos.abrirConexion())
                {
                    using (SqlDataAdapter sentenciadata = new SqlDataAdapter(sentencia, conexion))
                    {
                        DataTable asiganardata = new DataTable();
                        sentenciadata.Fill(asiganardata);
                        // Asigna el DataTable como origen de datos para el DataGridView

                        dtgventaproducto.DataSource = asiganardata;
                    } // sentenciadata se libera automáticamente al salir del bloque using
                }
                // Ajusta el ancho de la columna con el nombre "Id"

                dtgventaproducto.Columns["IDPRODUCTO"].Width = 42;
         

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //todos los datos que se encuentra en la fila del data que dio clic pasa a  los campos como txt o label
        private void dtgventaproducto_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                lblidproducto.Text = dtgventaproducto.Rows[dtgventaproducto.CurrentRow.Index].Cells[0].Value.ToString();
                txtnombreproducto.Text = dtgventaproducto.Rows[dtgventaproducto.CurrentRow.Index].Cells[1].Value.ToString();
                txtpreciounitario.Text = dtgventaproducto.Rows[dtgventaproducto.CurrentRow.Index].Cells[2].Value.ToString();
                lblcantidadactualproducto.Text = dtgventaproducto.Rows[dtgventaproducto.CurrentRow.Index].Cells[3].Value.ToString();
                // Muestra el texto y el control que indica la cantidad actual

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
            // Verifica si el texto en txtcantidadproducto no está vacío y la cantidad ingresada es mayor que la cantidad actual
            if (txtcantidadproducto.Text != "" && decimal.Parse(txtcantidadproducto.Text) > decimal.Parse(lblcantidadactualproducto.Text))
            {
                MessageBox.Show("La cantidad colocada sobre pasa al stock del producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtcantidadproducto.Text = "0";
            }
        }

        private void ProductoVenta_Load(object sender, EventArgs e)
        {
            dtgventaproducto.DataSource = AccesoDatos.llenartablaparabuscar("exec sp_Mostrar_PRODUCTOS");
        }
    }
}
