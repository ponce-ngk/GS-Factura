using GS_Factura.Clases;
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
using static GS_Factura.ProductoVenta;

namespace GS_Factura
{
    public partial class ClienteVenta : Form
    {
        BD2 OAD = new BD2();
        List<SqlParameter> par = new List<SqlParameter>();
        int op;
        string date = DateTime.UtcNow.ToString("yyyy-MM-dd");
        string sql = "";
        DataTable tb = new DataTable();

        public delegate void pasarformFactura(string idproducto, string cedulacliente,
               string namecliente, string apellidocliente);

        public event pasarformFactura pasarCliente;


        public ClienteVenta()
        {
            InitializeComponent();
            DgvClientes.DataSource = AccesoDatos.LlenarTablaparaBuscar("sp_Listado_Clientes");
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtbuscarproducto_Enter(object sender, EventArgs e)
        {
            try
            {
                if (txtbuscarCliente.Text == "Busca Por ID,Nombre,Apellido,Cedula del Usuario...")
                {
                    txtbuscarCliente.Text = "";
                    txtbuscarCliente.ForeColor = Color.Black;
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
                if (txtbuscarCliente.Text == "")
                {
                    // Restaura el texto predeterminado y el color del texto.
                    //txtbuscarCliente.Text = "Busca Por ID,Nombre,Apellido,Cedula del Usuario...";
                    txtbuscarCliente.ForeColor = Color.DimGray;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void txtbuscarCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DgvClientes.DataSource = AccesoDatos.LlenarTablaparaBuscar("EXEC sp_Buscar_Clientes '" + txtbuscarCliente.Text + "'");
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtcedulacliente.Text) ||
                string.IsNullOrWhiteSpace(txtnombrescliente.Text) ||
                string.IsNullOrWhiteSpace(txtapellidoscliente.Text) ||
                string.IsNullOrWhiteSpace(dtpFechaCliente.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos antes de continuar.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Se confirmar antes de agregar al cliente
                DialogResult resultado = MessageBox.Show("¿Estás seguro de que quieres agregar estos datos?", "Confirmar adición", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    sql = "";
                    par.Clear();
                    par.Add(new SqlParameter("@Cedula", txtcedulacliente.Text.Trim()));
                    par.Add(new SqlParameter("@Nombre_Cliente", txtnombrescliente.Text.Trim()));
                    par.Add(new SqlParameter("@Apellido", txtapellidoscliente.Text.Trim()));
                    par.Add(new SqlParameter("@Fecha_Nac", dtpFechaCliente.Text.Trim()));
                    sql = OAD.EscalarProcAlmString("sp_Insertar_CLIENTE", par, true);
                    if (sql != null)
                    {
                        MessageBox.Show("Los datos se han agregado correctamente.", "Adición exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudieron Guardar", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    DgvClientes.DataSource = AccesoDatos.LlenarTablaparaBuscar("sp_Listado_Clientes");
                    // Se actualiza el DataGridView y se limpian los campos
                    //DgvClientes.DataSource = AccesoDatos.LlenarTablaparaBuscar("EXEC sp_Buscar_Clientes '" + txtcedulacliente.Text + "'");

                    LimpiarCampos();
                }
            }
        }
        private void LimpiarCampos()
        {
            // Se limpian todos los campos para volverlo ingresar
            txtcedulacliente.Text = "";
            txtnombrescliente.Text = "";
            txtapellidoscliente.Text = "";
            dtpFechaCliente.Text = date.ToString();
        }

        private void DgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Llama al método asociado al delegado pasarformFactura
                pasarCliente(
                 DgvClientes.Rows[DgvClientes.CurrentRow.Index].Cells[0].Value.ToString(),
                 DgvClientes.Rows[DgvClientes.CurrentRow.Index].Cells[1].Value.ToString(),
                 DgvClientes.Rows[DgvClientes.CurrentRow.Index].Cells[2].Value.ToString(),
                 DgvClientes.Rows[DgvClientes.CurrentRow.Index].Cells[3].Value.ToString()
                 );
                // Oculta la ventana actual
                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void txtcedulacliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cmbitems_SelectedIndexChanged(object sender, EventArgs e)
        {
            op = cmbitems.SelectedIndex;
            switch (op)
            {
                case 0:
                    op = 0;
                    break;
                case 1:
                    op = 1;
                    break;
                case 2:
                    op = 2;
                    break;
                case 3:
                    op = 3;
                    break;
            }
        }

        private void txtbuscarCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validacion de que sea solo letras y espacio 
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == ' ' || char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                if (txtbuscarCliente.Text != null)
                {
                    if (op == 0)
                    {
                        if (txtbuscarCliente.TextLength != 0 || cmbitems.SelectedIndex == -1)
                        {
                            e.Handled = true;
                            tb.Clear();
                            par.Clear();
                            par.Add(new SqlParameter("@Campo", "IDCLIENTE"));
                            par.Add(new SqlParameter("@Buscar", txtbuscarCliente.Text.Trim()));
                            tb = OAD.EscalarProcAlmTabla("BuscarClientes ", par, true);
                            DgvClientes.DataSource = tb;
                        }
                        else
                        {
                            DgvClientes.DataSource = AccesoDatos.LlenarTablaparaBuscar("sp_Listado_Clientes");
                            MessageBox.Show("Por favor ingregse al menos un carácter");
                        }
                    }
                    else if (op == 1)
                    {
                        if (txtbuscarCliente.TextLength != 0 || cmbitems.SelectedIndex == -1)
                        {
                            e.Handled = true;
                            tb.Clear();
                            par.Clear();
                            par.Add(new SqlParameter("@Campo", "CEDULA"));
                            par.Add(new SqlParameter("@Buscar", txtbuscarCliente.Text.Trim()));
                            tb = OAD.EscalarProcAlmTabla("BuscarClientes ", par, true);
                            DgvClientes.DataSource = tb;
                        }
                        else
                        {
                            DgvClientes.DataSource = AccesoDatos.LlenarTablaparaBuscar("sp_Listado_Clientes");
                            MessageBox.Show("Por favor ingregse al menos un carácter");
                        }
                    }
                    else if (op == 2)
                    {
                        if (txtbuscarCliente.TextLength != 0 || cmbitems.SelectedIndex == -1)
                        {
                            e.Handled = true;
                            tb.Clear();
                            par.Clear();
                            par.Add(new SqlParameter("@Campo", "NOMBRE"));
                            par.Add(new SqlParameter("@Buscar", txtbuscarCliente.Text.Trim()));
                            tb = OAD.EscalarProcAlmTabla("BuscarClientes ", par, true);
                            DgvClientes.DataSource = tb;
                        }
                        else
                        {
                            DgvClientes.DataSource = AccesoDatos.LlenarTablaparaBuscar("sp_Listado_Clientes");
                            MessageBox.Show("Por favor ingregse al menos un carácter");
                        }
                    }
                    else if (op == 3)
                    {
                        if (txtbuscarCliente.TextLength != 0 || cmbitems.SelectedIndex == -1)
                        {
                            e.Handled = true;
                            tb.Clear();
                            par.Clear();
                            par.Add(new SqlParameter("@Campo", "APELLIDOS"));
                            par.Add(new SqlParameter("@Buscar", txtbuscarCliente.Text.Trim()));
                            tb = OAD.EscalarProcAlmTabla("BuscarClientes ", par, true);
                            DgvClientes.DataSource = tb;
                        }
                        else
                        {
                            DgvClientes.DataSource = AccesoDatos.LlenarTablaparaBuscar("sp_Listado_Clientes");
                            MessageBox.Show("Por favor ingregse al menos un carácter");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione al menos un campo");
                }
            }
            else if (op == null && txtbuscarCliente.Text == null)
            {
                MessageBox.Show("Por favor ingregse un carácter");
            }
        }

        private void BtnSearchClienteVenta_Click(object sender, EventArgs e)
        {
            if (txtbuscarCliente.Text != null)
            {
                if (op == 0)
                {
                    if (txtbuscarCliente.TextLength != 0 || cmbitems.SelectedIndex == -1)
                    {

                        tb.Clear();
                        par.Clear();
                        par.Add(new SqlParameter("@Campo", "IDCLIENTE"));
                        par.Add(new SqlParameter("@Buscar", txtbuscarCliente.Text.Trim()));
                        tb = OAD.EscalarProcAlmTabla("BuscarClientes ", par, true);
                        DgvClientes.DataSource = tb;
                    }
                    else
                    {
                        DgvClientes.DataSource = AccesoDatos.LlenarTablaparaBuscar("sp_Listado_Clientes");
                        MessageBox.Show("Por favor ingregse al menos un carácter");
                    }
                }
                else if (op == 1)
                {
                    if (txtbuscarCliente.TextLength != 0 || cmbitems.SelectedIndex == -1)
                    {
                        tb.Clear();
                        par.Clear();
                        par.Add(new SqlParameter("@Campo", "CEDULA"));
                        par.Add(new SqlParameter("@Buscar", txtbuscarCliente.Text.Trim()));
                        tb = OAD.EscalarProcAlmTabla("BuscarClientes ", par, true);
                        DgvClientes.DataSource = tb;
                    }
                    else
                    {
                        DgvClientes.DataSource = AccesoDatos.LlenarTablaparaBuscar("sp_Listado_Clientes");
                        MessageBox.Show("Por favor ingregse al menos un carácter");
                    }
                }
                else if (op == 2)
                {
                    if (txtbuscarCliente.TextLength != 0 || cmbitems.SelectedIndex == -1)
                    {
                        tb.Clear();
                        par.Clear();
                        par.Add(new SqlParameter("@Campo", "NOMBRE"));
                        par.Add(new SqlParameter("@Buscar", txtbuscarCliente.Text.Trim()));
                        tb = OAD.EscalarProcAlmTabla("BuscarClientes ", par, true);
                        DgvClientes.DataSource = tb;
                    }
                    else
                    {
                        DgvClientes.DataSource = AccesoDatos.LlenarTablaparaBuscar("sp_Listado_Clientes");
                        MessageBox.Show("Por favor ingregse al menos un carácter");
                    }
                }
                else if (op == 3)
                {
                    if (txtbuscarCliente.TextLength != 0 || cmbitems.SelectedIndex == -1)
                    {
                        tb.Clear();
                        par.Clear();
                        par.Add(new SqlParameter("@Campo", "APELLIDOS"));
                        par.Add(new SqlParameter("@Buscar", txtbuscarCliente.Text.Trim()));
                        tb = OAD.EscalarProcAlmTabla("BuscarClientes ", par, true);
                        DgvClientes.DataSource = tb;
                    }
                    else
                    {
                        DgvClientes.DataSource = AccesoDatos.LlenarTablaparaBuscar("sp_Listado_Clientes");
                        MessageBox.Show("Por favor ingregse al menos un carácter");
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione al menos un campo");
            }
        }
    }

}
