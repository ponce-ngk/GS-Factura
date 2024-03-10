
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
using System.Windows.Media;

namespace GS_Factura
{
    public partial class GS_RegistroCliente : Form
    {
        BD2 OAD = new BD2();
        List<SqlParameter> par = new List<SqlParameter>();
        int op;
        string date = DateTime.UtcNow.ToString("yyyy-MM-dd");
        string sql = "";
        DataTable tb = new DataTable();

        public GS_RegistroCliente()
        {
            InitializeComponent();
            BloqueoControlesInicial();
            AccesoDatos fr = new AccesoDatos();
            // Se llena el DataGridView con los datos de los clientes al cargar el formulario
            tb = OAD.EscalarProcAlmTablaSinPar("sp_Listado_Clientes ", true);
            dgvClientes.DataSource = tb;
            //dgvClientes.DataSource = AccesoDatos.LlenarTablaparaBuscar("sp_Listado_Clientes");
            // Se establece el formato personalizado de la fecha en el control DateTimePicker para poderlo guardar
            dtpFechaCliente.CustomFormat = "yyyy-MM-dd";
        }
        public void BloqueoControlesInicial()
        {
            dgvClientes.CurrentCell = null;
            btnEditarCliente.Visible = false;
            btnEliminarCliente.Visible = false;
        }
        public void BloqueoControles()
        {
            btnEditarCliente.Visible = false;
            btnEliminarCliente.Visible = false;
            btnGuardar.Visible = true;
        }
        public void BloqueoClickDgv()
        {
            btnGuardar.Visible = false;
            btnEditarCliente.Visible = true;
            btnEliminarCliente.Visible = true;
        }
        private void btnGuardarDueño_Click(object sender, EventArgs e)
        {
            // Se valida si hay campos vacíos antes de continuar
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
                    // Se actualiza el DataGridView y se limpian los campos
                    //dgvClientes.DataSource = AccesoDatos.LlenarTablaparaBuscar("sp_Listado_Clientes");
                    BloqueoControles();
                    LimpiarCampos();
                }
            }
        }
        private void btnEditarCliente_Click(object sender, EventArgs e)
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
                DialogResult resultado = MessageBox.Show("¿Estás seguro de que quieres actualizar estos datos?", "Confirmar actualización", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Se confirmar antes de editar al cliente
                if (resultado == DialogResult.Yes)
                {
                    sql = "";
                    par.Clear();
                    par.Add(new SqlParameter("@IDCLIENTE", int.Parse(txtidcliente.Text.Trim())));
                    par.Add(new SqlParameter("@Cedula", txtcedulacliente.Text.Trim()));
                    par.Add(new SqlParameter("@Nombre", txtnombrescliente.Text.Trim()));
                    par.Add(new SqlParameter("@Apellido", txtapellidoscliente.Text.Trim()));
                    par.Add(new SqlParameter("@Fecha_Nac", dtpFechaCliente.Text.Trim()));
                    sql = OAD.EscalarProcAlmString("sp_actualizar_CLIENTE", par, true);
                    if (sql != null)
                    {
                        MessageBox.Show("Los datos de editaron correctamente", "Datos Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudieron Editar", "Error al editar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    // Actualizar el DataGridView y limpiar los campos
                    //dgvClientes.DataSource = AccesoDatos.LlenarTablaparaBuscar("sp_Listado_Clientes");
                    BloqueoControles();
                    LimpiarCampos();
                }
            }
        }
        private void btnEliminarCliente_Click(object sender, EventArgs e)
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
                // Se confirmar antes de eliminar al cliente
                DialogResult resultado = MessageBox.Show("¿Estás seguro de que quieres eliminar los datos de los campos de texto?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    sql = "";
                    par.Clear();
                    par.Add(new SqlParameter("@idcliente", txtidcliente.Text.Trim()));
                    sql = OAD.EscalarProcAlmString("sp_Delete_Client", par, true);
                    if (sql != null)
                    {
                        MessageBox.Show("Los datos se han eliminado correctamente.", "Eliminación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudieron Eliminar", "Error al Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    // Actualizar el DataGridView y limpiar los campos
                    //dgvClientes.DataSource = AccesoDatos.LlenarTablaparaBuscar("sp_Listado_Clientes");
                    BloqueoControles();
                    LimpiarCampos();
                }
                // Si el usuario elige 'No', no se hace nada
            }
        }
        private void LimpiarCampos()
        {
            // Se limpian todos los campos para volverlo ingresar
            txtidcliente.Text = "";
            txtcedulacliente.Text = "";
            txtnombrescliente.Text = "";
            txtapellidoscliente.Text = "";
            dtpFechaCliente.Text = date.ToString();
            txt_Buscar.Text = "";
            cmbitems.SelectedIndex = -1;
            tb = OAD.EscalarProcAlmTablaSinPar("sp_Listado_Clientes ", true);
            dgvClientes.DataSource = tb;
            //dgvClientes.DataSource = AccesoDatos.LlenarTablaparaBuscar("sp_Listado_Clientes");
        }
        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(dgvClientes.CurrentCell == null)
                {
                    BloqueoControles();
                }
                else
                {
                    BloqueoClickDgv();
                    // Mostrar los datos de la fila seleccionada en los campos correspondientes
                    txtidcliente.Text = dgvClientes.CurrentRow.Cells[0].Value.ToString();
                    txtcedulacliente.Text = dgvClientes.CurrentRow.Cells[1].Value.ToString();
                    txtnombrescliente.Text = dgvClientes.CurrentRow.Cells[2].Value.ToString();
                    txtapellidoscliente.Text = dgvClientes.CurrentRow.Cells[3].Value.ToString();
                    dtpFechaCliente.Text = dgvClientes.CurrentRow.Cells[4].Value.ToString();
                }
            }
            catch (Exception ex)
            {   
                MessageBox.Show(ex.Message);
            }
        }
        private void btnlimpiardatos_Click(object sender, EventArgs e)
        {            
            LimpiarCampos();
            BloqueoControles();
        }
        private void txtcedulacliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo dígitos en el campo de cédula
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtnombrescliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras, espacios y retroceso en el campo de nombres
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == ' ' || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }
        private void txtapellidoscliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras, espacios y retroceso en el campo de apellidos
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == ' ' || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }
        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            if (txt_Buscar.Text != null)
            {
                if (op == 0)
                {
                    if (txt_Buscar.TextLength != 0 || cmbitems.SelectedIndex == -1)
                    {
                        
                        tb.Clear();
                        par.Clear();
                        par.Add(new SqlParameter("@Campo", "IDCLIENTE"));
                        par.Add(new SqlParameter("@Buscar", txt_Buscar.Text.Trim()));
                        tb = OAD.EscalarProcAlmTabla("BuscarClientes ", par, true);
                        dgvClientes.DataSource = tb;
                    }
                    else
                    {
                        tb = OAD.EscalarProcAlmTablaSinPar("sp_Listado_Clientes ", true);
                        dgvClientes.DataSource = tb;
                        //dgvClientes.DataSource = AccesoDatos.LlenarTablaparaBuscar("sp_Listado_Clientes");
                        MessageBox.Show("Por favor ingregse al menos un carácter");
                    }
                }
                else if (op == 1)
                {
                    if (txt_Buscar.TextLength != 0 || cmbitems.SelectedIndex == -1)
                    {
                        tb.Clear();
                        par.Clear();
                        par.Add(new SqlParameter("@Campo", "CEDULA"));
                        par.Add(new SqlParameter("@Buscar", txt_Buscar.Text.Trim()));
                        tb = OAD.EscalarProcAlmTabla("BuscarClientes ", par, true);
                        dgvClientes.DataSource = tb;
                    }
                    else
                    {
                        tb = OAD.EscalarProcAlmTablaSinPar("sp_Listado_Clientes ", true);
                        dgvClientes.DataSource = tb;
                        //dgvClientes.DataSource = AccesoDatos.LlenarTablaparaBuscar("sp_Listado_Clientes");
                        MessageBox.Show("Por favor ingregse al menos un carácter");
                    }
                }
                else if (op == 2)
                {
                    if (txt_Buscar.TextLength != 0 || cmbitems.SelectedIndex == -1)
                    {
                        tb.Clear();
                        par.Clear();
                        par.Add(new SqlParameter("@Campo", "NOMBRE"));
                        par.Add(new SqlParameter("@Buscar", txt_Buscar.Text.Trim()));
                        tb = OAD.EscalarProcAlmTabla("BuscarClientes ", par, true);
                        dgvClientes.DataSource = tb;
                    }
                    else
                    {
                        tb = OAD.EscalarProcAlmTablaSinPar("sp_Listado_Clientes ", true);
                        dgvClientes.DataSource = tb;
                        //dgvClientes.DataSource = AccesoDatos.LlenarTablaparaBuscar("sp_Listado_Clientes");
                        MessageBox.Show("Por favor ingregse al menos un carácter");
                    }
                }
                else if (op == 3)
                {
                    if (txt_Buscar.TextLength != 0 || cmbitems.SelectedIndex == -1)
                    {
                        tb.Clear();
                        par.Clear();
                        par.Add(new SqlParameter("@Campo", "APELLIDOS"));
                        par.Add(new SqlParameter("@Buscar", txt_Buscar.Text.Trim()));
                        tb = OAD.EscalarProcAlmTabla("BuscarClientes ", par, true);
                        dgvClientes.DataSource = tb;
                    }
                    else
                    {
                        tb = OAD.EscalarProcAlmTablaSinPar("sp_Listado_Clientes ", true);
                        dgvClientes.DataSource = tb;
                        //dgvClientes.DataSource = AccesoDatos.LlenarTablaparaBuscar("sp_Listado_Clientes");
                        MessageBox.Show("Por favor ingregse al menos un carácter");
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione al menos un campo");
            }
        }
        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvClientes.CurrentCell == null)
                {
                    BloqueoControles();
                }
                else
                {
                    BloqueoClickDgv();
                    // Mostrar los datos de la fila seleccionada en los campos correspondientes
                    txtidcliente.Text = dgvClientes.CurrentRow.Cells[0].Value.ToString();
                    txtcedulacliente.Text = dgvClientes.CurrentRow.Cells[1].Value.ToString();
                    txtnombrescliente.Text = dgvClientes.CurrentRow.Cells[2].Value.ToString();
                    txtapellidoscliente.Text = dgvClientes.CurrentRow.Cells[3].Value.ToString();
                    dtpFechaCliente.Text = dgvClientes.CurrentRow.Cells[4].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
        private void txt_Buscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validacion de que sea solo letras y espacio 
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == ' ' || char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                if (txt_Buscar.Text != null)
                {
                    if (op == 0)
                    {
                        if(txt_Buscar.TextLength != 0 || cmbitems.SelectedIndex == -1)
                        {
                            e.Handled = true;
                            tb.Clear();
                            par.Clear();
                            par.Add(new SqlParameter("@Campo", "IDCLIENTE"));
                            par.Add(new SqlParameter("@Buscar", txt_Buscar.Text.Trim()));
                            tb = OAD.EscalarProcAlmTabla("BuscarClientes ", par, true);
                            dgvClientes.DataSource = tb;
                        }
                        else
                        {
                            tb = OAD.EscalarProcAlmTablaSinPar("sp_Listado_Clientes ", true);
                            dgvClientes.DataSource = tb;
                            //dgvClientes.DataSource = AccesoDatos.LlenarTablaparaBuscar("sp_Listado_Clientes");
                            MessageBox.Show("Por favor ingregse al menos un carácter");
                        }
                    }
                    else if (op == 1)
                    {
                        if (txt_Buscar.TextLength != 0 || cmbitems.SelectedIndex == -1)
                        {
                            e.Handled = true;
                            tb.Clear();
                            par.Clear();
                            par.Add(new SqlParameter("@Campo", "CEDULA"));
                            par.Add(new SqlParameter("@Buscar", txt_Buscar.Text.Trim()));
                            tb = OAD.EscalarProcAlmTabla("BuscarClientes ", par, true);
                            dgvClientes.DataSource = tb;
                        }
                        else
                        {
                            tb = OAD.EscalarProcAlmTablaSinPar("sp_Listado_Clientes ", true);
                            dgvClientes.DataSource = tb;
                            //dgvClientes.DataSource = AccesoDatos.LlenarTablaparaBuscar("sp_Listado_Clientes");
                            MessageBox.Show("Por favor ingregse al menos un carácter");
                        }                        
                    }
                    else if (op == 2)
                    {
                        if (txt_Buscar.TextLength != 0 || cmbitems.SelectedIndex == -1)
                        {
                            e.Handled = true;
                            tb.Clear();
                            par.Clear();
                            par.Add(new SqlParameter("@Campo", "NOMBRE"));
                            par.Add(new SqlParameter("@Buscar", txt_Buscar.Text.Trim()));
                            tb = OAD.EscalarProcAlmTabla("BuscarClientes ", par, true);
                            dgvClientes.DataSource = tb;
                        }
                        else
                        {
                            tb = OAD.EscalarProcAlmTablaSinPar("sp_Listado_Clientes ", true);
                            dgvClientes.DataSource = tb;
                            //dgvClientes.DataSource = AccesoDatos.LlenarTablaparaBuscar("sp_Listado_Clientes");
                            MessageBox.Show("Por favor ingregse al menos un carácter");
                        }
                    }
                    else if (op == 3)
                    {
                        if (txt_Buscar.TextLength != 0 || cmbitems.SelectedIndex == -1)
                        {
                            e.Handled = true;
                            tb.Clear();
                            par.Clear();
                            par.Add(new SqlParameter("@Campo", "APELLIDOS"));
                            par.Add(new SqlParameter("@Buscar", txt_Buscar.Text.Trim()));
                            tb = OAD.EscalarProcAlmTabla("BuscarClientes ", par, true);
                            dgvClientes.DataSource = tb;
                        }
                        else
                        {
                            tb = OAD.EscalarProcAlmTablaSinPar("sp_Listado_Clientes ", true);
                            dgvClientes.DataSource = tb;
                            //dgvClientes.DataSource = AccesoDatos.LlenarTablaparaBuscar("sp_Listado_Clientes");
                            MessageBox.Show("Por favor ingregse al menos un carácter");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione al menos un campo");
                }
            }
            else if (op == null && txt_Buscar.Text == null)
            {
                MessageBox.Show("Por favor ingregse un carácter");
            }
        }
    }
}
