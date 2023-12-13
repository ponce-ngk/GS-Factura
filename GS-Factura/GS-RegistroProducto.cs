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
    public partial class GS_RegistroProducto : Form
    {
        public GS_RegistroProducto()
        {
            InitializeComponent();
            dtgProducto.DataSource = AccesoDatos.llenartablaparabuscar("exec sp_Mostrar_PRODUCTOS");
        }

        private void btnAñadirProducto_Click(object sender, EventArgs e)
        {
            GS_RP_ADD gS_RP_ADD = new GS_RP_ADD();
            gS_RP_ADD.ShowDialog();

        }
    }
}
