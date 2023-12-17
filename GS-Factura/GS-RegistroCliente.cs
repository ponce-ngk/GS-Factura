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
            AccesoDatos fr = new AccesoDatos();
            dgvClientes.DataSource = AccesoDatos.llenartablaparabuscar("sp_Listado_Clientes");
            dtpFechaCliente.CustomFormat = "yyyy-MM-dd";
        }

        private void btnGuardarDueño_Click(object sender, EventArgs e)
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
                DialogResult resultado = MessageBox.Show("¿Estás seguro de que quieres agregar estos datos?", "Confirmar adición", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    Cliente pClientes = new Cliente();

                    pClientes.Cedula = txtcedulacliente.Text;
                    pClientes.Nombre = txtnombrescliente.Text;
                    pClientes.Apellido = txtapellidoscliente.Text;
                    pClientes.FechaNA = dtpFechaCliente.Text;


                    int resultado2 = CrudCliente.AgregarCliente(pClientes);

                    if (resultado2 > 0)
                    {
                        MessageBox.Show("Los datos se han agregado correctamente.", "Adición exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudieron Guardar", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    dgvClientes.DataSource = AccesoDatos.llenartablaparabuscar("sp_Listado_Clientes");
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

                // Verificar la respuesta del usuario
                if (resultado == DialogResult.Yes)
                {
                    Cliente pClientes = new Cliente();

                    pClientes.IdCliente = int.Parse(txtidcliente.Text);
                    pClientes.Cedula = txtcedulacliente.Text;
                    pClientes.Nombre = txtnombrescliente.Text;
                    pClientes.Apellido = txtapellidoscliente.Text;
                    pClientes.FechaNA = dtpFechaCliente.Text;

                    int resultado2 = CrudCliente.ActualizarClient(pClientes);

                    if (resultado2 > 0)
                    {
                        MessageBox.Show("Los datos de editaron correctamente", "Datos Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudieron Editar", "Error al editar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    dgvClientes.DataSource = AccesoDatos.llenartablaparabuscar("sp_Listado_Clientes");
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
                DialogResult resultado = MessageBox.Show("¿Estás seguro de que quieres eliminar los datos de los campos de texto?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    Cliente pClientes = new Cliente();

                    pClientes.IdCliente = int.Parse(txtidcliente.Text);
                    pClientes.Estado = '0';

                    int resultado2 = CrudCliente.EliminarClient(pClientes);

                    if (resultado2 > 0)
                    {
                        MessageBox.Show("Los datos se han eliminado correctamente.", "Eliminación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudieron Eliminar", "Error al Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    dgvClientes.DataSource = AccesoDatos.llenartablaparabuscar("sp_Listado_Clientes");

                    LimpiarCampos();
                }
                // Si el usuario elige 'No', no se hace nada
            }
        }

        private void LimpiarCampos()
        {
            txtidcliente.Text = "";
            txtcedulacliente.Text = "";
            txtnombrescliente.Text = "";
            txtapellidoscliente.Text = "";
            dtpFechaCliente.Text = date.ToString();
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtidcliente.Text = dgvClientes.CurrentRow.Cells[0].Value.ToString();
                txtcedulacliente.Text = dgvClientes.CurrentRow.Cells[1].Value.ToString();
                txtnombrescliente.Text = dgvClientes.CurrentRow.Cells[2].Value.ToString();
                txtapellidoscliente.Text = dgvClientes.CurrentRow.Cells[3].Value.ToString();
                dtpFechaCliente.Text = dgvClientes.CurrentRow.Cells[4].Value.ToString();
                /*if (dgvClientes.CurrentRow.Cells[5].Value.ToString() == "Activo")
                {
                    radioButton2.Checked = true;
                }
                else
                {
                    radioButton1.Checked = true;
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnlimpiardatos_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void txtcedulacliente_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                AccesoDatos.abrirConexion();
                AccesoDatos rt = new AccesoDatos();
                dgvClientes.DataSource = rt.retornaClientebuscar(txtcedulacliente.Text);
                AccesoDatos.CerrarConexion(AccesoDatos.abrirConexion());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtnombrescliente_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                AccesoDatos.abrirConexion();
                AccesoDatos rt = new AccesoDatos();
                dgvClientes.DataSource = rt.retornaClientebuscar(txtnombrescliente.Text);
                AccesoDatos.CerrarConexion(AccesoDatos.abrirConexion());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtapellidoscliente_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                AccesoDatos.abrirConexion();
                AccesoDatos rt = new AccesoDatos();
                dgvClientes.DataSource = rt.retornaClientebuscar(txtapellidoscliente.Text);
                AccesoDatos.CerrarConexion(AccesoDatos.abrirConexion());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtcedulacliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtnombrescliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void txtapellidoscliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }
    }
}
