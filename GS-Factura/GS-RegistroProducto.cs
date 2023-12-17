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
            txtcantidadproducto.Text = "";
            txtnombreproducto.Text = "";
            txtpreciounitario.Text = "";
            txtIdProducto.Text = "";
            dgvProductos.DataSource = AccesoDatos.llenartablaparabuscar("exec sp_Mostrar_PRODUCTOS");
        }
        private void btnAñadirProducto_Click(object sender, EventArgs e)
        {
            if (txtcantidadproducto.Text != "" && txtnombreproducto.Text != "" && txtpreciounitario.Text != "")
            {
                DialogResult confirmacion = MessageBox.Show("¿Estás seguro de que quieres agregar estos datos?", "Confirmar adición", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmacion == DialogResult.Yes)
                {
                    Producto pProducto = new Producto();
                    pProducto.PRODUCTO1 = txtnombreproducto.Text;
                    pProducto.STOTCK1 = txtcantidadproducto.Text;
                    pProducto.PRECIO_UNITARIO1 = txtpreciounitario.Text;
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
            }
            else
            {
                MessageBox.Show("campos vacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtnombreproducto.Text != "" && txtpreciounitario.Text != "" && txtcantidadproducto.Text != "")
            {
                DialogResult confirmacion = MessageBox.Show("¿Estás seguro de que quieres actualizar estos datos?", "Confirmar modificacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmacion == DialogResult.Yes)
                {
                    Producto pProducto = new Producto();
                    pProducto.IDPRODUCTO1 = int.Parse(txtIdProducto.Text);
                    pProducto.PRODUCTO1 = txtnombreproducto.Text;
                    pProducto.STOTCK1 = txtcantidadproducto.Text;
                    pProducto.PRECIO_UNITARIO1 = txtpreciounitario.Text;
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
                txtIdProducto.Text = dgvProductos.CurrentRow.Cells[0].Value.ToString();
                txtnombreproducto.Text = dgvProductos.CurrentRow.Cells[1].Value.ToString();
                txtpreciounitario.Text = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                txtcantidadproducto.Text = dgvProductos.CurrentRow.Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (txtIdProducto.Text != "" )
            {
                DialogResult confirmacion = MessageBox.Show("¿Estás seguro de que quieres eliminar estos datos?", "Confirmar eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmacion == DialogResult.Yes)
                {
                    Producto pProducto = new Producto();
                    pProducto.IDPRODUCTO1 = int.Parse(txtIdProducto.Text);
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
        private void txtbuscarproducto__TextChanged(object sender, EventArgs e)
        {
            dgvProductos.DataSource = AccesoDatos.llenartablaparabuscar
                ("select RTRIM(IDPRODUCTO) AS IDPRODUCTO, RTRIM(PRODUCTO) AS PRODUCTO, RTRIM(PRECIO_UNITARIO) AS PRECIO_UNITARIO," +
                "RTRIM(STOCK) AS STOCK from PRODUCTO WHERE ESTADO = 1 and PRODUCTO like '" + txtbuscarproducto.Texts+"%'");
        }
    }
}
