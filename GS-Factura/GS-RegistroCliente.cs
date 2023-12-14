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
        string date = DateTime.UtcNow.ToString("yyyy MM dd");

        public GS_RegistroCliente()
        {
            InitializeComponent();
            AccesoDatos fr = new AccesoDatos();
            dgvClientes.DataSource = AccesoDatos.llenartablaparabuscar("sp_Listado_Clientes");
        }

        private void btnGuardarDueño_Click(object sender, EventArgs e)
        {
            
            dtpFechaCliente.CustomFormat = "yyyy MMM dd";
            if (txtcedulacliente.Text != "" || txtnombrescliente.Text != "" || txtapellidoscliente.Text != "" || dtpFechaCliente.Text != date)
            {
                Cliente pClientes = new Cliente();

                pClientes.Cedula = txtcedulacliente.Text;
                pClientes.Nombre = txtnombrescliente.Text;
                pClientes.Apellido = txtapellidoscliente.Text;
                pClientes.FechaNA = dtpFechaCliente.Text;


                int resultado = CrudCliente.AgregarCliente(pClientes);

                if (resultado > 0)
                {
                    MessageBox.Show("Los datos de Guardaron correctamente", "Datos Guardados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudieron Guardar", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                dgvClientes.DataSource = AccesoDatos.llenartablaparabuscar("sp_Listado_Clientes");

                txtidcliente.Text = "";
                txtcedulacliente.Text = "";
                txtnombrescliente.Text = "";
                txtapellidoscliente.Text = "";
                dtpFechaCliente.Text = date.ToString();
            }
            else
            {
                MessageBox.Show("campos vacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEditarCliente_Click(object sender, EventArgs e)
        {
            dtpFechaCliente.CustomFormat = "yyyy MMM dd";
            if (txtcedulacliente.Text != "" || txtnombrescliente.Text != "" || txtapellidoscliente.Text != "")
            {
                Cliente pClientes = new Cliente();

                pClientes.IdCliente = int.Parse(txtidcliente.Text);
                pClientes.Cedula = txtcedulacliente.Text;
                pClientes.Nombre = txtnombrescliente.Text;
                pClientes.Apellido = txtapellidoscliente.Text;
                pClientes.FechaNA = dtpFechaCliente.Text;

                //MessageBox.Show("Hola mundo");
                int resultado = CrudCliente.ActualizarClient(pClientes);

                if (resultado > 0)
                {
                    MessageBox.Show("Los datos de editaron correctamente", "Datos Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudieron Editar", "Error al editar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                dgvClientes.DataSource = AccesoDatos.llenartablaparabuscar("sp_Listado_Clientes");

                txtidcliente.Text = "";
                txtcedulacliente.Text = "";
                txtnombrescliente.Text = "";
                txtapellidoscliente.Text = "";
            }
            else
            {
                MessageBox.Show("campos vacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            if (txtcedulacliente.Text != "" || txtnombrescliente.Text != "" || txtapellidoscliente.Text != "" || dtpFechaCliente.Text != date)
            {
                Cliente pClientes = new Cliente();

                pClientes.IdCliente = int.Parse(txtidcliente.Text);
                pClientes.Estado = '0';


                int resultado = CrudCliente.EliminarClient(pClientes);

                if (resultado > 0)
                {
                    MessageBox.Show("Los datos de Eliminaron correctamente", "Datos Eliminados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudieron Eliminar", "Error al Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                dgvClientes.DataSource = AccesoDatos.llenartablaparabuscar("sp_Listado_Clientes");

                txtidcliente.Text = "";
                txtcedulacliente.Text = "";
                txtnombrescliente.Text = "";
                txtapellidoscliente.Text = "";
                dtpFechaCliente.Text = date.ToString();
            }
            else
            {
                MessageBox.Show("campos vacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
            txtidcliente.Text = "";
            txtcedulacliente.Text = "";
            txtnombrescliente.Text = "";
            txtapellidoscliente.Text = "";
            dtpFechaCliente.Text = date.ToString();
        }
    }
}
