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
    public partial class GS_RP_ADD : Form
    {
        GS_RegistroProducto rp = new GS_RegistroProducto();
        public GS_RP_ADD()
        {
            InitializeComponent();
        }
        public void Limpiar()
        {
            txtcantidadproducto.Text = "";
            txtnombreproducto.Text = "";
            txtpreciounitario.Text = "";
        }
        private void btncloseLote_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardarPorducto_Click(object sender, EventArgs e)
        {
            //if(txtcantidadproducto.Texts != "" && txtnombreproducto.Texts != "" && txtpreciounitario.Texts != "")
            //{
                
            //    Producto pProducto = new Producto();
            //    pProducto.PRODUCTO1 = txtnombreproducto.Texts;
            //    pProducto.STOTCK1 = txtcantidadproducto.Texts;
            //    pProducto.PRECIO_UNITARIO1 = txtpreciounitario.Texts;
                
            //    int resultado = CrudProducto.AgregarProducto(pProducto);

            //    if (resultado > 0)
            //    {
            //        MessageBox.Show("Los datos de Guardaron correctamente", "Datos Guardados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else
            //    {
            //        MessageBox.Show("No se pudieron Guardar", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    }
            //    rp.dgvProductos.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_Mostrar_PRODUCTOS");
            //    Limpiar();
            //}
            //else
            //{
            //    MessageBox.Show("campos vacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            
        }
    }
}
