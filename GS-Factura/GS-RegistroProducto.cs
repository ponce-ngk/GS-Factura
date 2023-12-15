using GS_Factura.Clases;
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
    public partial class GS_RegistroProducto : Form
    {
        public GS_RegistroProducto()
        {
            InitializeComponent();
            LlenarLimpiar();
        }
        public void LlenarLimpiar() {
                txtcantidadproducto.Texts = "";
                txtnombreproducto.Texts = "";
                txtpreciounitario.Texts = "";
            txtIdProducto.Texts = "";
            dgvProductos.DataSource = AccesoDatos.llenartablaparabuscar("exec sp_Mostrar_PRODUCTOS");
        }
        private void btnAñadirProducto_Click(object sender, EventArgs e)
        {
            //GS_RP_ADD gS_RP_ADD = new GS_RP_ADD();
            //gS_RP_ADD.ShowDialog();
            if (txtcantidadproducto.Texts != "" && txtnombreproducto.Texts != "" && txtpreciounitario.Texts != "")
            {
                Producto pProducto = new Producto();
                pProducto.PRODUCTO1 = txtnombreproducto.Texts;
                pProducto.STOTCK1 = txtcantidadproducto.Texts;
                pProducto.PRECIO_UNITARIO1 = txtpreciounitario.Texts;

                int resultado = CrudProducto.AgregarProducto(pProducto);

                if (resultado > 0)
                {
                    MessageBox.Show("Los datos de Guardaron correctamente", "Datos Guardados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudieron Guardar", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                LlenarLimpiar();
            }
            else
            {
                MessageBox.Show("campos vacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtnombreproducto.Texts != "" && txtpreciounitario.Texts != "" && txtpreciounitario.Texts != "")
            {
                Producto pProducto = new Producto();
                pProducto.IDPRODUCTO1 = int.Parse(txtIdProducto.Texts);
                pProducto.PRODUCTO1 = txtnombreproducto.Texts;
                pProducto.STOTCK1 = txtcantidadproducto.Texts;
                pProducto.PRECIO_UNITARIO1 = txtpreciounitario.Texts;
                int resultado = CrudProducto.ActualizarProducto(pProducto);

                if (resultado > 0)
                {
                    MessageBox.Show("Los datos de editaron correctamente", "Datos Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudieron Editar", "Error al editar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                LlenarLimpiar();
            }
            else
            {
                MessageBox.Show("campos vacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvProductos_Click(object sender, EventArgs e)
        {
            try
            {
                
                txtIdProducto.Texts = dgvProductos.CurrentRow.Cells[0].Value.ToString();
                //txtIdProducto.PlaceholderText = dgvProductos.CurrentRow.Cells[0].Value.ToString();
                
                txtnombreproducto.Texts = dgvProductos.CurrentRow.Cells[1].Value.ToString();
                //txtnombreproducto.PlaceholderText = dgvProductos.CurrentRow.Cells[1].Value.ToString();
                
                txtpreciounitario.Texts = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                //txtpreciounitario.PlaceholderText = dgvProductos.CurrentRow.Cells[2].Value.ToString();
               
                txtcantidadproducto.Texts = dgvProductos.CurrentRow.Cells[3].Value.ToString();
                //txtcantidadproducto.PlaceholderText = dgvProductos.CurrentRow.Cells[3].Value.ToString();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (txtIdProducto.Texts != "" )
            {
                Producto pProducto = new Producto();
                pProducto.IDPRODUCTO1 = int.Parse(txtIdProducto.Texts);
                pProducto.ESTADO1 = '0';
                int resultado = CrudProducto.EliminarProducto(pProducto);

                if (resultado > 0)
                {
                    MessageBox.Show("Los datos de Eliminaron correctamente", "Datos Eliminados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudieron Eliminar", "Error al Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                LlenarLimpiar();
            }
            else
            {
                MessageBox.Show("campos vacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            LlenarLimpiar();
        }
    }
}
