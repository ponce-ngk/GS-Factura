using GS_Factura.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS_Factura
{
    public partial class GS_EliminaFactura : Form
    {
        AccesoDatos OAD = new AccesoDatos();
        List<SqlParameter> par = new List<SqlParameter>();
        int op;
        DataTable tb = new DataTable();
        string sql = "";
        public GS_EliminaFactura()
        {
            InitializeComponent();
        }

        private void txtBuscaFacturaCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!(char.IsLetter(e.KeyChar) || e.KeyChar == ' ' || char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
                {
                    if (txtBuscaFacturaCliente.Text != null)
                    {
                        if (op == 1)
                        {
                            if (txtBuscaFacturaCliente.TextLength != 0 || cmbitems.SelectedIndex == -1)
                            {
                                e.Handled = true;
                                tb.Clear();
                                par.Clear();
                                par.Add(new SqlParameter("@Campo", "CEDULA"));
                                par.Add(new SqlParameter("@Buscar", txtBuscaFacturaCliente.Text.Trim()));
                                tb = OAD.EscalarProcAlmTabla("BuscarFacturasClientes", par, true);
                                dtgFactura.DataSource = tb;
                                if (tb.Rows.Count == 0)
                                {
                                    //AlertlBoxArtan(Color.LightPink, Color.DarkRed, "Error", "Cliente no encontrado.", Properties.Resources.Error);
                                    MessageBox.Show("Producto no encontrado. \n\nSe sugiere al Usuario verificar el dato del Producto e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                tb = OAD.EscalarProcAlmTablaSinPar("BuscarFacturasVacio ", true);
                                dtgFactura.DataSource = tb;
                                //AlertlBoxArtan(Color.LightBlue, Color.DodgerBlue, "Información", "Por favor ingrese al menos un carácter.", Properties.Resources.Information);
                                MessageBox.Show("Por favor ingregse al menos un carácter");
                            }
                        }
                        else if (op == 2)
                        {
                            if (txtBuscaFacturaCliente.TextLength != 0 || cmbitems.SelectedIndex == -1)
                            {
                                e.Handled = true;
                                tb.Clear();
                                par.Clear();
                                par.Add(new SqlParameter("@Campo", "IDFACTURA"));
                                par.Add(new SqlParameter("@Buscar", txtBuscaFacturaCliente.Text.Trim()));
                                tb = OAD.EscalarProcAlmTabla("BuscarFacturasFac", par, true);
                                dtgFactura.DataSource = tb;
                                if (tb.Rows.Count == 0)
                                {
                                    //AlertlBoxArtan(Color.LightPink, Color.DarkRed, "Error", "Factura no encontrada.", Properties.Resources.Error);
                                    MessageBox.Show("Producto no encontrado. \n\nSe sugiere al Usuario verificar el dato del Producto e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                tb = OAD.EscalarProcAlmTablaSinPar("BuscarFacturasVacio ", true);
                                dtgFactura.DataSource = tb;
                                //AlertlBoxArtan(Color.LightBlue, Color.DodgerBlue, "Información", "Por favor ingregse al menos un carácter.", Properties.Resources.Information);
                                MessageBox.Show("Por favor ingregse al menos un carácter");
                            }
                        }
                        else
                        {
                            //AlertlBoxArtan(Color.LightBlue, Color.DodgerBlue, "Información", "Seleccione al menos un campo.", Properties.Resources.Information);
                            MessageBox.Show("Seleccione al menos un campo");
                        }
                    }
                    else if (op == null && txtBuscaFacturaCliente.Text == null)
                    {
                        //AlertlBoxArtan(Color.LightBlue, Color.DodgerBlue, "Información", "Por favor ingrese al menos un carácter.", Properties.Resources.Information);
                        MessageBox.Show("Por favor ingregse un carácter");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBuscaFacturaCliente.Text != null)
                {
                    if (op == 1)
                    {
                        if (txtBuscaFacturaCliente.TextLength != 0 || cmbitems.SelectedIndex == -1)
                        {

                            tb.Clear();
                            par.Clear();
                            par.Add(new SqlParameter("@Campo", "CEDULA"));
                            par.Add(new SqlParameter("@Buscar", txtBuscaFacturaCliente.Text.Trim()));
                            tb = OAD.EscalarProcAlmTabla("BuscarFacturasClientes", par, true);
                            dtgFactura.DataSource = tb;
                            if (tb.Rows.Count == 0)
                            {
                                MessageBox.Show("Producto no encontrado. \n\nSe sugiere al Usuario verificar el dato del Producto e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            tb = OAD.EscalarProcAlmTablaSinPar("BuscarFacturasVacio ", true);
                            dtgFactura.DataSource = tb;
                            MessageBox.Show("Por favor ingregse al menos un carácter");
                        }
                    }
                    else if (op == 2)
                    {
                        if (txtBuscaFacturaCliente.TextLength != 0 || cmbitems.SelectedIndex == -1)
                        {

                            tb.Clear();
                            par.Clear();
                            par.Add(new SqlParameter("@Campo", "IDFACTURA"));
                            par.Add(new SqlParameter("@Buscar", txtBuscaFacturaCliente.Text.Trim()));
                            tb = OAD.EscalarProcAlmTabla("BuscarFacturasFac", par, true);
                            dtgFactura.DataSource = tb;
                            if (tb.Rows.Count == 0)
                            {
                                MessageBox.Show("Producto no encontrado. \n\nSe sugiere al Usuario verificar el dato del Producto e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            tb = OAD.EscalarProcAlmTablaSinPar("BuscarFacturasVacio ", true);
                            dtgFactura.DataSource = tb;
                            MessageBox.Show("Por favor ingregse al menos un carácter");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Seleccione al menos un campo");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void LimpiaDatos()
        {
            txtBuscaFacturaCliente.Text = "";
        }

        private void dtgFactura_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && (e.ColumnIndex == dtgFactura.Columns["EliminarFila"].Index || e.ColumnIndex == dtgFactura.Columns["VerFactura"].Index || e.ColumnIndex == dtgFactura.Columns["editarFactura"].Index))
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    // Obtener el icono deseado según la columna
                    Icon icono = null;

                    if (e.ColumnIndex == dtgFactura.Columns["EliminarFila"].Index)
                    {
                        // Icono para la columna "EliminarFila"
                        icono = Properties.Resources.remove;
                    }
                    else if (e.ColumnIndex == dtgFactura.Columns["VerFactura"].Index)
                    {
                        // Icono para la columna "VerFactura"
                        icono = Properties.Resources.ver_nuevo;
                    }
                    else if (e.ColumnIndex == dtgFactura.Columns["editarFactura"].Index)
                    {
                        // Icono para la columna "VerFactura"
                        icono = Properties.Resources.edit;
                    }


                    // Calcular la posición para centrar el icono en la celda
                    int x = e.CellBounds.Left + (e.CellBounds.Width - icono.Width) / 2;
                    int y = e.CellBounds.Top + (e.CellBounds.Height - icono.Height) / 2;

                    // Dibujar el icono en la celda
                    e.Graphics.DrawIcon(icono, x, y);

                    // Indicar que no es necesario pintar la celda estándar
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción (puedes mostrar un mensaje, registrarla, etc.)
                MessageBox.Show($"Error en CellPainting: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtgFactura_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex >= 0 && e.ColumnIndex == dtgFactura.Columns["VerFactura"].Index)
            {
                try
                {
                    // Obtener el ID de la factura de la fila seleccionada
                    int idFactura = Convert.ToInt32(dtgFactura.Rows[e.RowIndex].Cells["IDFACTURA"].Value);

                    // Llamar al formulario de visualización de factura con el ID de la factura
                    VisualizaFacturaBorrar visualizaForm = new VisualizaFacturaBorrar(idFactura);

                    // Establecer el formulario como no independiente (TopLevel = false)
                    visualizaForm.TopLevel = false;

                    // Limpiar los controles existentes en el panelFactura
                    panelFactura.Controls.Clear();

                    // Establecer el tamaño del formulario al tamaño del panelFactura
                    visualizaForm.Size = panelFactura.Size;

                    // Agregar el formulario al panelFactura
                    panelFactura.Controls.Add(visualizaForm);

                    // Mostrar el formulario dentro del panelFactura
                    visualizaForm.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (e.RowIndex >= 0 && e.ColumnIndex == dtgFactura.Columns["Eliminarfila"].Index)
            {
                DialogResult resultado = MessageBox.Show("¿Estás seguro de que quieres eliminar la Factura", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    try
                    {

                        int idFactura = Convert.ToInt32(dtgFactura.Rows[e.RowIndex].Cells["IDFACTURA"].Value);

                        // Llamada al método para eliminar la factura
                        OAD.EliminarFactura(idFactura);
                        if (panelFactura.Controls.Count > 0 && panelFactura.Controls[0] is VisualizaFacturaBorrar)
                        {
                            MessageBox.Show("Los datos se han eliminado correctamente.", "Eliminación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ((VisualizaFacturaBorrar)panelFactura.Controls[0]).Close();
                        }
                        else
                        {
                            MessageBox.Show("Los datos se han eliminado correctamente.", "Eliminación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        // Recargar los datos en el DataGridView u otras acciones según sea necesario
                        dtgFactura.Rows.RemoveAt(index);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            if (e.RowIndex >= 0 && e.ColumnIndex == dtgFactura.Columns["EditarFactura"].Index)
            {
                try
                {
                    // Obtener el ID de la factura de la fila seleccionada
                    int idFactura = Convert.ToInt32(dtgFactura.Rows[e.RowIndex].Cells["IDFACTURA"].Value);

                    // Mostrar un mensaje de confirmación
                    DialogResult resultado = MessageBox.Show("¿Estás seguro de que quieres editar esta factura?", "Confirmar edición", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        DeshabilitarFormularios();
                        
                        GS_EditarFactura editarForm = new GS_EditarFactura(idFactura);
                        editarForm.FormClosed += (s, args) => HabilitarFormularios();
                        editarForm.Show();

                        // Recargar los datos en el DataGridView u otras acciones según sea necesario
                        dtgFactura.Rows.RemoveAt(index);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DeshabilitarFormularios()
        {
            foreach (Form form in Application.OpenForms)
            {
                form.Enabled = false;
                form.TopMost = false;
            }
        }
        private void HabilitarFormularios()
        {
            foreach (Form form in Application.OpenForms)
            {
                form.Enabled = true;
            }
        }

        private void cmbitems_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                op = cmbitems.SelectedIndex;
                switch (op)
                {
                    case 0:
                        txtBuscaFacturaCliente.Text = "";
                        txtBuscaFacturaCliente.Enabled = false;
                        tb.Clear();
                        tb = OAD.EscalarProcAlmTablaSinPar("BuscarFacturasFull", true);
                        dtgFactura.DataSource = tb;
                        if (txtBuscaFacturaCliente.TextLength > 0)
                        {
                            tb.Clear();
                            tb = OAD.EscalarProcAlmTablaSinPar("LeerProductoVacio", true);
                            MessageBox.Show("Debe tener el campo de busqueda vacio ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            cmbitems.SelectedIndex = -1;
                        }
                        break;
                    case 1:
                        txtBuscaFacturaCliente.Enabled = true;
                        op = 1;
                        tb.Clear();
                        break;
                    case 2:
                        txtBuscaFacturaCliente.Enabled = true;
                        op = 2;
                        tb.Clear();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }        
    }
}
