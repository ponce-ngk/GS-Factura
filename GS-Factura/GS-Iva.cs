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
    public partial class GS_Iva : Form
    {
        public GS_Iva()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnGuardarIva_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener la fecha actual
                DateTime fechaActual = DateTime.Now;

                // Obtener la fecha seleccionada en dtpFechaFinal
                DateTime fechaSeleccionada = dtpFechaFinal.Value;

                // Verificar si la fecha seleccionada es menor que la fecha actual
                if (fechaSeleccionada < fechaActual)
                {
                    MessageBox.Show("La fecha final no puede ser menor que la fecha actual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Tu lógica para guardar el IVA si la validación pasa
                    // ...

                    // Ejemplo: MessageBox.Show("Guardando IVA...", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void BtnLimpiarDatos_Click(object sender, EventArgs e)
        {
            limpiar();

        }

        public void BloqueoControles()
        {
            btnActualizarIva.Visible = false;
            btnEliminarIva.Visible = false;
            //lblActualizar.Visible = false;
            //lblEliminar.Visible = false;
            //btnAgregarProducto.Visible = true;
            //lblAgregar.Visible = true;
        }
        void limpiar ()
        {
            txtIva.Text = "0";
            lblIdIva.Text = "0";
            //if (dgvProductos.RowCount != 0)
            //{
            //    dgvProductos.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec LeerProductoVacio");
            //}
            //else
            //{

            //}
        }
        private void BtnActualizarIva_Click(object sender, EventArgs e)
        {

        }

        private void BtnEliminarIva_Click(object sender, EventArgs e)
        {

        }

        private void TxtIva_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',' && e.KeyChar != ' ')
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (e.KeyChar == '.')
            {
                e.KeyChar = ','; // Reemplazar la coma por un punto
            }
            else if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("No se permiten espacios en blanco", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // Verificar si el usuario ha ingresado un punto decimal
            if (e.KeyChar == ',' && txtIva.Text.IndexOf(',') > -1)
            {
                // Si ya hay un punto decimal en el cuadro de texto, ignorar el evento
                e.Handled = true;
            }
        }

        private void TxtIva_Enter(object sender, EventArgs e)
        {
            try
            {
                // Si el texto en txtcancelado es "0", lo cambia a vacío y establece el color del texto a negro

                if (txtIva.Text == "0")
                {
                    txtIva.Text = "";
                    txtIva.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void TxtIva_Leave(object sender, EventArgs e)
        {
            try
            {
                // Si el texto en txtcancelado está vacío, establece el texto a "0" y el color del texto a gris oscuro
                if (txtIva.Text == "")
                {
                    txtIva.Text = "0";
                    txtIva.ForeColor = Color.DimGray;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void GS_Iva_Load(object sender, EventArgs e)
        {
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaInicioSearch.Value = DateTime.Now;

        }
    }
}
