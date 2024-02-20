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

        private void BtncloseProduct_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // Este método se ejecuta cuando el campo de búsqueda de productos recibe el foco.
        private void TxtbuscarProducto_Enter(object sender, EventArgs e)
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
        private void TxtbuscarProducto_Leave(object sender, EventArgs e)
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

        public void ExtraerInfoData(string sentencia)
        {
            try
            {
                //limpia las columnas
                dtgventaproducto.Columns.Clear();
                // Abre una conexión a la base de datos utilizando el objeto AccesoDatos
                using (SqlConnection conexion = AccesoDatos.AbrirConexion())
                {
                    using (SqlDataAdapter sentenciadata = new SqlDataAdapter(sentencia, conexion))
                    {
                        DataTable asiganardata = new DataTable();
                        sentenciadata.Fill(asiganardata);
                        // Asigna el DataTable como origen de datos para el DataGridView



                        if (asiganardata.Rows.Count > 0)
                        {
                            // Asigna el DataTable como origen de datos para el DataGridView
                            dtgventaproducto.DataSource = asiganardata;

                            // Ajusta el ancho de la columna con el nombre "Id"
                            dtgventaproducto.Columns["ID"].Width = 42;
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron productos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }


                    } // sentenciadata se libera automáticamente al salir del bloque using
                }
                // Ajusta el ancho de la columna con el nombre "Id"

         

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //todos los datos que se encuentra en la fila del data que dio clic pasa a  los campos como txt o label
        private void DtgventaProducto_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void ProductoVenta_Load(object sender, EventArgs e)
        {
            //dtgventaproducto.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_Mostrar_PRODUCTOS");
        }

        private void BtnsearchProdVenta_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtbuscarproducto.Text == "")
                {
                    MessageBox.Show("El campo de buscar producto se encuentra vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Sentencia SQL para extraer información de productos que coincidan con el texto de búsqueda.
                    string sentenciaextraer = @"select IDPRODUCTO 
                        as ID, PRODUCTO, PRECIO_UNITARIO AS PRECIO_UNITARIO,
                        STOCK from [dbo].[PRODUCTO]
                        where PRODUCTO LIKE '" + txtbuscarproducto.Text + "%' or IDPRODUCTO LIKE '" + txtbuscarproducto.Text + "%' AND Estado = 1";
                    this.ExtraerInfoData(sentenciaextraer);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void TxtbuscarProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validacion de que sea solo letras y espacio 
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == ' ') && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                //  dgvProductos.DataSource = AccesoDatos.LlenarTablaparaBuscar
                //("EXEC sp_Buscar_Producto2 '" + txtbuscarproducto.Texts + "'");
                dtgventaproducto.DataSource = AccesoDatos.LlenarTablaparaBuscar("SELECT  RTRIM(IDPRODUCTO) AS IDPRODUCTO,  RTRIM(PRODUCTO) AS PRODUCTO, REPLACE(CONVERT(VARCHAR, PRECIO_UNITARIO), '.', ',') AS PRECIO_UNITARIO,  REPLACE(CONVERT(VARCHAR, STOCK), '.', ',')  AS STOCK FROM PRODUCTO WHERE PRODUCTO LIKE '" + txtbuscarproducto.Text + "%' AND Estado = 1");
            }
            else if (e.KeyChar == (char)(Keys.Enter))
            {
                dtgventaproducto.DataSource = AccesoDatos.LlenarTablaparaBuscar("SELECT  RTRIM(IDPRODUCTO) AS IDPRODUCTO,  RTRIM(PRODUCTO) AS PRODUCTO, REPLACE(CONVERT(VARCHAR, PRECIO_UNITARIO), '.', ',') AS PRECIO_UNITARIO, RTRIM(STOCK) AS STOCK FROM PRODUCTO WHERE  Estado = 1;");
                e.Handled = true;
            }



        }

        private void DtgventaProducto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string cantidad = "0";
                // Llama al método asociado al delegado pasarformFactura
                pasarproducto(
                 dtgventaproducto.Rows[dtgventaproducto.CurrentRow.Index].Cells[0].Value.ToString(),
                 dtgventaproducto.Rows[dtgventaproducto.CurrentRow.Index].Cells[1].Value.ToString(),
                  cantidad, dtgventaproducto.Rows[dtgventaproducto.CurrentRow.Index].Cells[2].Value.ToString());
                // Oculta la ventana actual
                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
    }
}