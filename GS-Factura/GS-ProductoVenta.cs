using GS_Factura.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS_Factura
{
    public partial class ProductoVenta : Form
    {
        BD2 OAD = new BD2();
        List<SqlParameter> par = new List<SqlParameter>();
        int op;
        DataTable tb = new DataTable();
        string sql = "";
        // Declaración del delegado
        public delegate void pasarformFactura(string idproducto, string nameproduct,string cantidadproducto, string preciproducto);
        public event pasarformFactura pasarproducto;

        public ProductoVenta()
        {
            InitializeComponent();
            tb = OAD.EscalarProcAlmTablaSinPar("LeerProductoVacio ", true);
            dtgventaproducto.DataSource = tb;
        }

        
        private void TxtbuscarProducto_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtbuscarproducto.Text == "")
                {
                    txtbuscarproducto.ForeColor = Color.DimGray;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnsearchProdVenta_Click(object sender, EventArgs e)
        {
            if (txtbuscarproducto.Text != null)
            {
                if (op == 1)
                {
                    if (txtbuscarproducto.TextLength != 0 || cmbitems.SelectedIndex == -1)
                    {
                        tb.Clear();
                        par.Clear();
                        par.Add(new SqlParameter("@Campo", "PRODUCTO"));
                        par.Add(new SqlParameter("@Buscar", txtbuscarproducto.Text.Trim()));
                        tb = OAD.EscalarProcAlmTabla("BuscarProductos", par, true);
                        dtgventaproducto.DataSource = tb;
                        if (tb.Rows.Count == 0)
                        {
                            MessageBox.Show("Producto no encontrado. \n\nSe sugiere al Usuario verificar el dato del Producto e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        tb = OAD.EscalarProcAlmTablaSinPar("LeerProductoVacio ", true);
                        dtgventaproducto.DataSource = tb;
                        MessageBox.Show("Por favor ingregse al menos un carácter");
                    }
                }
                else if (op == 2)
                {
                    if (txtbuscarproducto.TextLength != 0 || cmbitems.SelectedIndex == -1)
                    {
                        tb.Clear();
                        par.Clear();
                        par.Add(new SqlParameter("@Campo", "IDPRODUCTO"));
                        par.Add(new SqlParameter("@Buscar", txtbuscarproducto.Text.Trim()));
                        tb = OAD.EscalarProcAlmTabla("BuscarProductos", par, true);
                        dtgventaproducto.DataSource = tb;
                        if (tb.Rows.Count == 0)
                        {
                            MessageBox.Show("Producto no encontrado. \n\nSe sugiere al Usuario verificar el dato del Producto e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        tb = OAD.EscalarProcAlmTablaSinPar("LeerProductoVacio ", true);
                        dtgventaproducto.DataSource = tb;
                        MessageBox.Show("Por favor ingregse al menos un carácter");
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione al menos un campo");
                }
            }
        }

        private void TxtbuscarProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == ' ' || char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                if (txtbuscarproducto.Text != null)
                {
                    if (op == 1)
                    {
                        if (txtbuscarproducto.TextLength != 0 || cmbitems.SelectedIndex == -1)
                        {
                            e.Handled = true;
                            tb.Clear();
                            par.Clear();
                            par.Add(new SqlParameter("@Campo", "PRODUCTO"));
                            par.Add(new SqlParameter("@Buscar", txtbuscarproducto.Text.Trim()));
                            tb = OAD.EscalarProcAlmTabla("BuscarProductos", par, true);
                            dtgventaproducto.DataSource = tb;
                            if (tb.Rows.Count == 0)
                            {
                                MessageBox.Show("Producto no encontrado. \n\nSe sugiere al Usuario verificar el dato del Producto e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            tb = OAD.EscalarProcAlmTablaSinPar("LeerProductoVacio ", true);
                            dtgventaproducto.DataSource = tb;
                            MessageBox.Show("Por favor ingregse al menos un carácter");
                        }
                    }
                    else if (op == 2)
                    {
                        if (txtbuscarproducto.TextLength != 0 || cmbitems.SelectedIndex == -1)
                        {
                            e.Handled = true;
                            tb.Clear();
                            par.Clear();
                            par.Add(new SqlParameter("@Campo", "IDPRODUCTO"));
                            par.Add(new SqlParameter("@Buscar", txtbuscarproducto.Text.Trim()));
                            tb = OAD.EscalarProcAlmTabla("BuscarProductos", par, true);
                            dtgventaproducto.DataSource = tb;
                            if (tb.Rows.Count == 0)
                            {
                                MessageBox.Show("Producto no encontrado. \n\nSe sugiere al Usuario verificar el dato del Producto e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            tb = OAD.EscalarProcAlmTablaSinPar("LeerProductoVacio ", true);
                            dtgventaproducto.DataSource = tb;
                            MessageBox.Show("Por favor ingregse al menos un carácter");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Seleccione al menos un campo");
                    }
                }
                else if (op == null && txtbuscarproducto.Text == null)
                {
                    MessageBox.Show("Por favor ingregse un carácter");
                }
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
                // Habilita todos los formularios
                HabilitarFormularios();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void HabilitarFormularios()
        {
            foreach (Form form in Application.OpenForms)
            {
                form.Enabled = true;
                form.TopMost = true;
            }
        }

        private void cmbitems_SelectedIndexChanged(object sender, EventArgs e)
        {
            op = cmbitems.SelectedIndex;
            switch (op)
            {
                case 0:
                    txtbuscarproducto.Enabled = false;
                    tb.Clear();
                    tb = OAD.EscalarProcAlmTablaSinPar("BuscarProductosFull", true);
                    dtgventaproducto.DataSource = tb;
                    if (txtbuscarproducto.TextLength > 0)
                    {
                        tb.Clear();
                        tb = OAD.EscalarProcAlmTablaSinPar("LeerProductoVacio", true);
                        MessageBox.Show("Debe tener el campo de busqueda vacio ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cmbitems.SelectedIndex = -1;
                    }
                    break;
                case 1:
                    txtbuscarproducto.Enabled = true;
                    op = 1;
                    tb.Clear();
                    break;
                case 2:
                    txtbuscarproducto.Enabled = true;
                    op = 2;
                    tb.Clear();
                    break;
            }
        }
    }
}
