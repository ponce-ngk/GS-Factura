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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new GS_GeneraFactura());
            return;
        }


        private void AbrirFormEnPanel(object formhija)
        {
            if (this.panelForms.Controls.Count > 0)
                this.panelForms.Controls.RemoveAt(0);
            Form fh = formhija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelForms.Controls.Add(fh);
            this.panelForms.Tag = fh;
            fh.Show();

        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new GS_RegistroProducto());
            return;
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new GS_RegistroCliente());
            return;
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {

            if (panelLayoutMenu.Width == 48)
            {
                panelLayoutMenu.Width = 149;

                ptmfotouser.Visible = true;
                lblNombre.Visible = true;

            }
            else
            {

                panelLayoutMenu.Width = 48;

                ptmfotouser.Visible = false;
                lblNombre.Visible = false;


            }
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_maximizar_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;

            }
            else
            {
                this.WindowState = FormWindowState.Normal;

            }
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrarsesion_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panelLayoutMenu.Width = 48;
            ptmfotouser.Visible = false;
            lblNombre.Visible = false;
            AbrirFormEnPanel(new GS_Inicio());
            return;
        }

        private void ptmfotouser_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new GS_Inicio());
            return;
        }
    }
}
