using RJCodeAdvance.RJControls;
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
        private bool dragging = false;
        private Point dragStartPoint;
        public Form1()
        {
            InitializeComponent();
            lblEncabezadoGS.MouseDown += lblEncabezadoGS_MouseDown;
            lblEncabezadoGS.MouseMove += lblEncabezadoGS_MouseMove;
            lblEncabezadoGS.MouseUp += lblEncabezadoGS_MouseUp;
        }


        private void BtnVenta_Click(object sender, EventArgs e)
        {
            GS_GeneraFactura frmFactura = new GS_GeneraFactura();
            AbrirFormEnPanel(frmFactura);

        }


        private void AbrirFormEnPanel(object formHija)
        {
            // Cerrar formulario actual si hay uno
            if (this.panelForms.Controls.Count > 0)
            {
                Form formularioActual = this.panelForms.Controls[0] as Form;
                formularioActual.Close();
            }

            // Mostrar el nuevo formulario
            Form nuevoForm = formHija as Form;
            nuevoForm.TopLevel = false;
            nuevoForm.Dock = DockStyle.Fill;
            this.panelForms.Controls.Add(nuevoForm);
            this.panelForms.Tag = nuevoForm;
            nuevoForm.Show();
        }


        private void BtnProductos_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new GS_RegistroProducto());
            return;
        }

        private void BtnRegistro_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new GS_RegistroCliente());
            return;
        }

        private void BtnMenu_Click(object sender, EventArgs e)
        {

            if (panelLayoutMenu.Width == 48)
            {
                panelLayoutMenu.Width = 149;
                ptmfotouser.Visible = true;
                lblNombre.Visible = true;
                btnBuscaFactura.Width = 149;
                btnBuscaFactura.TextImageRelation = TextImageRelation.ImageBeforeText;
                btnBuscaFactura.Text = "  Facturas";
            }
            else
            {
                panelLayoutMenu.Width = 48;
                ptmfotouser.Visible = false;
                lblNombre.Visible = false;
                btnBuscaFactura.Width = 48;
                btnBuscaFactura.TextImageRelation = TextImageRelation.Overlay;
                btnBuscaFactura.Text = "";
            }
        }

        private void Btn_cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Btn_Maximizar_Click(object sender, EventArgs e)
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

        private void Btn_Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnCerrarsesion_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panelLayoutMenu.Width = 149;
            ptmfotouser.Visible = true;
            lblNombre.Visible = true;
            AbrirFormEnPanel(new GS_Inicio());
            return;
        }

        private void Ptmfotouser_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new GS_Inicio());
            return;
        }

        private void BtnBuscaFactura_Click(object sender, EventArgs e)
        {
            Open_DropdownMenu(rjcFacturaMenu, sender);
            
        }

        private void Open_DropdownMenu(RJDropdownMenu dropdownMenu, object sender)
        {
            Control control = (Control)sender;
            dropdownMenu.VisibleChanged += new EventHandler((sender2, ev)
                => DropdownMenu_VisibleChanged(sender2, ev, control));
            dropdownMenu.Show(control, control.Width, 0);

        }
        private void DropdownMenu_VisibleChanged(object sender, EventArgs e, Control ctrl)
        {
            RJDropdownMenu dropdownMenu = (RJDropdownMenu)sender;
            if (!DesignMode)
            {
                if (dropdownMenu.Visible)
                {
                    ctrl.BackColor = Color.FromArgb(51, 51, 76);
                }
                else
                {
                    ctrl.BackColor = Color.FromArgb(51, 51, 76);
                }
            }
        }

        private void btnRJBuscarF_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new GS_BuscaFactura());
            return;
        }


        

        private void lblEncabezadoGS_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragStartPoint = new Point(e.X, e.Y);
        }

        private void lblEncabezadoGS_MouseMove(object sender, MouseEventArgs e)
        {
            // Si el mouse está siendo arrastrado
            if (dragging)
            {
                // Calcular la diferencia entre la posición actual y la posición inicial
                int deltaX = e.X - dragStartPoint.X;
                int deltaY = e.Y - dragStartPoint.Y;

                // Mover el formulario
                this.Location = new Point(this.Location.X + deltaX, this.Location.Y + deltaY);
            }
        }

        private void lblEncabezadoGS_MouseUp(object sender, MouseEventArgs e)
        {
            // Al soltar el botón del mouse, detener el arrastre
            dragging = false;
        }

        private void btnRJEliminar_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new GS_EliminaFactura());
            return;
        }

        private void BtnIva_Click(object sender, EventArgs e)
        {

            AbrirFormEnPanel(new GS_Iva());
            return;
        }

        private void btnInformes_Click(object sender, EventArgs e)
        {
            Open_DropdownMenu(rjcIva, sender);
        }

        private void rjcBtnResumen_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new GS_ResumenVentas());
            return;
        }

        private void rjcBtnDetallada_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new GS_DetalladoVenta());
            return;
        }
    }
}
