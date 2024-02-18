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
using System.Windows.Media;

namespace GS_Factura
{
    public partial class GS_RegistroCliente : Form
    {
        string date = DateTime.UtcNow.ToString("yyyy-MM-dd");

        public GS_RegistroCliente()
        {
            InitializeComponent();
            BloqueoControlesInicial();
            AccesoDatos fr = new AccesoDatos();
            // Se llena el DataGridView con los datos de los clientes al cargar el formulario
            dgvClientes.DataSource = AccesoDatos.LlenarTablaparaBuscar("sp_Listado_Clientes");
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
                    Cliente pClientes = new Cliente();

                    pClientes.Cedula = txtcedulacliente.Text;
                    pClientes.Nombre = txtnombrescliente.Text;
                    pClientes.Apellido = txtapellidoscliente.Text;
                    pClientes.FechaNA = dtpFechaCliente.Text;

                    // Se llama al metodo AgregarCliente de la clase CrudCliente y se envian los datos
                    int resultado2 = CrudCliente.AgregarCliente(pClientes);

                    if (resultado2 > 0)
                    {
                        MessageBox.Show("Los datos se han agregado correctamente.", "Adición exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudieron Guardar", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    
                    // Se actualiza el DataGridView y se limpian los campos
                    dgvClientes.DataSource = AccesoDatos.LlenarTablaparaBuscar("sp_Listado_Clientes");
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
                    Cliente pClientes = new Cliente();

                    pClientes.IdCliente = int.Parse(txtidcliente.Text);
                    pClientes.Cedula = txtcedulacliente.Text;
                    pClientes.Nombre = txtnombrescliente.Text;
                    pClientes.Apellido = txtapellidoscliente.Text;
                    pClientes.FechaNA = dtpFechaCliente.Text;

                    // Se llama al metodo ActualizarClient de la clase CrudCliente y se envian los datos
                    int resultado2 = CrudCliente.ActualizarClient(pClientes);

                    if (resultado2 > 0)
                    {
                        MessageBox.Show("Los datos de editaron correctamente", "Datos Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudieron Editar", "Error al editar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    // Actualizar el DataGridView y limpiar los campos
                    dgvClientes.DataSource = AccesoDatos.LlenarTablaparaBuscar("sp_Listado_Clientes");
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
                    Cliente pClientes = new Cliente();

                    pClientes.IdCliente = int.Parse(txtidcliente.Text);
                    pClientes.Estado = '0';

                    // Se llama al metodo EliminarClient de la clase CrudCliente y se envian los datos
                    int resultado2 = CrudCliente.EliminarClient(pClientes);

                    if (resultado2 > 0)
                    {
                        MessageBox.Show("Los datos se han eliminado correctamente.", "Eliminación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudieron Eliminar", "Error al Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    // Actualizar el DataGridView y limpiar los campos
                    dgvClientes.DataSource = AccesoDatos.LlenarTablaparaBuscar("sp_Listado_Clientes");
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
            dgvClientes.DataSource = AccesoDatos.LlenarTablaparaBuscar("sp_Listado_Clientes");
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

        private void txtcedulacliente_KeyUp(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    // Buscar clientes por cédula mientras se escribe en el campo de texto
            //    AccesoDatos.abrirConexion();
            //    AccesoDatos rt = new AccesoDatos();
            //    // se llena la tabla con el resultando que traiga el metodo retornaClientebuscar
            //    dgvClientes.DataSource = rt.retornaClientebuscar(txtcedulacliente.Text);
            //    AccesoDatos.CerrarConexion(AccesoDatos.abrirConexion());
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void txtnombrescliente_KeyUp(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    // Buscar clientes por nombre mientras se escribe en el campo de texto
            //    AccesoDatos.abrirConexion();
            //    AccesoDatos rt = new AccesoDatos();
            //    dgvClientes.DataSource = rt.retornaClientebuscar(txtnombrescliente.Text);
            //    AccesoDatos.CerrarConexion(AccesoDatos.abrirConexion());
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void txtapellidoscliente_KeyUp(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    // Buscar clientes por apellido mientras se escribe en el campo de texto
            //    AccesoDatos.abrirConexion();
            //    AccesoDatos rt = new AccesoDatos();
            //    dgvClientes.DataSource = rt.retornaClientebuscar(txtapellidoscliente.Text);
            //    AccesoDatos.CerrarConexion(AccesoDatos.abrirConexion());
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
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
            dgvClientes.DataSource = AccesoDatos.LlenarTablaparaBuscar("EXEC sp_Buscar_Clientes '" + txt_Buscar.Text + "'");
         
        }

        private void txt_Buscar_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                dgvClientes.DataSource = AccesoDatos.LlenarTablaparaBuscar("EXEC sp_Buscar_Clientes '" + txt_Buscar.Text + "'");
            }
        }

        private void dgvClientes_DoubleClick(object sender, EventArgs e)
        {

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

        private void txt_Buscar_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
