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
    public partial class GS_RegistroCliente : Form
    {
        public GS_RegistroCliente()
        {
            InitializeComponent();
            AccesoDatos fr = new AccesoDatos();
            dgvClientes.DataSource = AccesoDatos.llenartablaparabuscar("select IDCLIENTE, CEDULA, NOMBRE, FECHA_NACIMIENTO from CLIENTE");
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnlimpiardatos_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {

        }
    }
}
