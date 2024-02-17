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
using static GS_Factura.ProductoVenta;

namespace GS_Factura
{
    public partial class ClienteVenta : Form
    {
        string date = DateTime.UtcNow.ToString("yyyy-MM-dd");

        public delegate void pasarformFactura(string idproducto, string cedulacliente,
               string namecliente, string apellidocliente);

        public event pasarformFactura pasarCliente;


        public ClienteVenta()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtbuscarproducto_Enter(object sender, EventArgs e)
        {
            try
            {
                if (txtbuscarCliente.Text == "Busca Por Nombre,Apellido,Cedula del Usuario...")
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
                    txtbuscarCliente.Text = "Busca Por Nombre,Apellido,Cedula del Usuario...";
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
                    DgvClientes.DataSource = AccesoDatos.LlenarTablaparaBuscar("EXEC sp_Buscar_Clientes '" + txtcedulacliente.Text + "'");

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
    }

}
