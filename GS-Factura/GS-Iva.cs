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

namespace GS_Factura
{
    public partial class GS_Iva : Form
    {
        BD2 OAD = new BD2();
        List<SqlParameter> par = new List<SqlParameter>();
        int op;
        DataTable tb = new DataTable();
        string sql = "";

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
                // Verificar si la fecha seleccionada es menor que la fecha actual
                if (dtpFechaFinal.Value.Date < dtpFechaInicio.Value.Date)
                {
                    dtpFechaFinal.Value = DateTime.Now;

                    MessageBox.Show("La fecha final no puede ser menor que la fecha actual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (dtpFechaInicio.Value.Date > dtpFechaFinal.Value.Date)
                {
                    MessageBox.Show("La fecha Inicial no puede ser mayor que la fecha Final.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (txtIva.Text == "" || txtIva.Text == "0")
                {
                    MessageBox.Show("El campo Iva está vacío. Por favor, ingrese un valor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    sql = "";
                    par.Clear();
                    par.Add(new SqlParameter("@ValorIVA", decimal.Parse(txtIva.Text.Replace(".", ","))));
                    par.Add(new SqlParameter("@FechaInicio", dtpFechaInicio.Value));
                    par.Add(new SqlParameter("@FechaFinal", dtpFechaFinal.Value));
                    sql = OAD.EscalarProcAlmString("InsertarIVA", par, true);
                    if (sql != null)
                    {
                        dtgIva.DataSource = AccesoDatos.LlenarTablaparaBuscar("EXEC sp_ObtenerIVAPorFecha '" + dtpFechaFinal.Value + "'");
                        BloqueoControles();
                        txtIva.Text = "0";
                        lblIdIva.Text = "0";
                        MessageBox.Show("IVA guardado exitosamente.", "Datos Guardados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo  Guardar", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void BtnLimpiarDatos_Click(object sender, EventArgs e)
        {
            Limpiar();
            BloqueoControles();
            dtgIva.CurrentCell = null;


        }

        public void BloqueoControles()
        {
            btnActualizarIva.Enabled = false;
            btnEliminarIva.Enabled = false;
            lblTextoIva.Visible = false;
            lblIdIva.Visible = false;
            btnGuardarIva.Enabled = true;
            //lblActualizar.Visible = false;
            //lblEliminar.Visible = false;
            //lblAgregar.Visible = true;
        }
        void Limpiar ()
        {
            txtIva.Text = "0";
            lblIdIva.Text = "0";
            if (dtgIva.RowCount != 0)
            {
                dtgIva.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_ObtenerIVAPorFecha ' '");
            }

        }
        private void BtnActualizarIva_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si la fecha seleccionada es menor que la fecha actual
                if (dtpFechaFinal.Value.Date < dtpFechaInicio.Value.Date)
                {
                    dtpFechaFinal.Value = DateTime.Now;

                    MessageBox.Show("La fecha final no puede ser menor que la fecha actual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (dtpFechaInicio.Value.Date > dtpFechaFinal.Value.Date)
                {
                    MessageBox.Show("La fecha Inicial no puede ser mayor que la fecha Final.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (txtIva.Text == "" || txtIva.Text == "0")
                {
                    MessageBox.Show("El campo Iva está vacío. Por favor, ingrese un valor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    DialogResult confirmacion = MessageBox.Show("¿Estás seguro de que quieres actualizar estos datos?", "Confirmar modificacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmacion == DialogResult.Yes)
                    {

              
                        sql = "";
                        par.Clear();
                        par.Add(new SqlParameter("@IDPRODUCTO", int.Parse(lblIdIva.Text)));
                        par.Add(new SqlParameter("@ValorIVA", decimal.Parse(txtIva.Text.Replace(".", ","))));
                        par.Add(new SqlParameter("@FechaInicio", dtpFechaInicio.Value));
                        par.Add(new SqlParameter("@FechaFinal", dtpFechaFinal.Value));
                        sql = OAD.EscalarProcAlmString("EditarIVA", par, true);
                        if (sql != null)
                        {
                            dtgIva.DataSource = AccesoDatos.LlenarTablaparaBuscar("EXEC sp_ObtenerIVAIDFecha '" + int.Parse(lblIdIva.Text) + "'");
                            BloqueoControles();
                            txtIva.Text = "0";
                            lblIdIva.Text = "0";
                            MessageBox.Show("Los datos de editaron correctamente", "Datos Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se pudieron Editar", "Error al editar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }

                }

        }
            catch (Exception)
            {

                throw;
            }
}

        private void BtnEliminarIva_Click(object sender, EventArgs e)
        {
            try
            {
                    DialogResult confirmacion = MessageBox.Show("¿Estás seguro de que quieres eliminar estos datos?", "Confirmar modificacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmacion == DialogResult.Yes)
                    {
                    sql = "";
                    par.Clear();
                    par.Add(new SqlParameter("@IVA_ID", int.Parse(lblIdIva.Text)));
                    sql = OAD.EscalarProcAlmString("InactivarIVA", par, true);
                    if (sql != null)
                    {
                        dtgIva.DataSource = AccesoDatos.LlenarTablaparaBuscar("EXEC sp_ObtenerIVAIDFecha '" + int.Parse(lblIdIva.Text) + "'");
                        BloqueoControles();
                        txtIva.Text = "0";
                        lblIdIva.Text = "0";
                        MessageBox.Show("IVA Eliminado exitosamente.", "Datos Eliminados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudieron Eliminar", "Error al Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }



            }
            catch (Exception)
            {

                throw;
            }


        }

        private void TxtIva_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',' && e.KeyChar != ' ')
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (e.KeyChar == ',')
            {
                e.KeyChar = '.'; // Reemplazar la coma por un punto
            }
            else if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("No se permiten espacios en blanco", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // Verificar si el usuario ha ingresado un punto decimal
            if (e.KeyChar == '.' && txtIva.Text.IndexOf('.') > -1)
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
            dtpSearchFechaInicio.Value = DateTime.Now;
            dtpSearchFechaFinal.Value = DateTime.Now;
            dtpFechaFinal.Value = DateTime.Now;
            //cmbitemsIva.SelectedIndex = 0;          |

        }
        public void BloqueoClickDgv()
        {
            btnGuardarIva.Enabled = false;
            btnActualizarIva.Enabled = true;
            btnEliminarIva.Enabled = true;
            lblTextoIva.Visible = true;
            lblIdIva.Visible = true;

            //lblActualizar.Visible = true;
            //lblEliminar.Visible = true;
        }

        private void DtgIva_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dtgIva.CurrentCell == null)
                {
                    BloqueoControles();
                }
                else
                {
                    BloqueoClickDgv();
                    lblIdIva.Text = dtgIva.CurrentRow.Cells[0].Value.ToString();
                    txtIva.Text = dtgIva.CurrentRow.Cells[1].Value.ToString().Replace(",","."); ;
                    dtpFechaInicio.Text = dtgIva.CurrentRow.Cells[2].Value.ToString();
                    dtpFechaFinal.Text = dtgIva.CurrentRow.Cells[3].Value.ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Btn_BuscarIva_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar que la fecha final no sea menor que la fecha inicial
                if (dtpSearchFechaFinal.Value.Date < dtpSearchFechaInicio.Value.Date)
                {
                    MessageBox.Show("La fecha final no puede ser menor que la fecha inicial.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         
                    return; 
                }
                else if (dtpSearchFechaInicio.Value.Date > dtpSearchFechaFinal.Value.Date)
                {
                    MessageBox.Show("La fecha Inicial no puede ser mayor que la fecha Final.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }
                else
                {

                    dtgIva.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_ObtenerIVAEntreFecha  '" + dtpSearchFechaInicio.Value + "', '" + dtpSearchFechaFinal.Value + "'");

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void TxtbuscarIva_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (txtbuscarIva.Text != "")
                {

                    if (cmbitemsIva.Text == "ID del Iva" )
                    {
                        dtgIva.DataSource = AccesoDatos.LlenarTablaparaBuscar("EXEC sp_ObtenerIVAIDFecha '" + int.Parse(txtbuscarIva.Text) + "'");

                        return;
                    }
                    else if (cmbitemsIva.Text == "Valor del Iva")
                    {
                        dtgIva.DataSource = AccesoDatos.LlenarTablaparaBuscar("EXEC sp_ObtenerValorIVA '" + int.Parse(txtbuscarIva.Text) + "'");

                        return;
                    }
                }
                else if (txtbuscarIva.Text == "" && cmbitemsIva.Text == "ID del Iva" || cmbitemsIva.Text == "Valor del Iva")
                {
                    dtgIva.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_ObtenerIVAPorFecha ' '");
                    return;
                }
                else 
                {
                    dtgIva.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_FullObtenerIVA ");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void cmbitemsIva_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbitemsIva.Text == "ID del Iva" || cmbitemsIva.Text == "Valor del Iva")
            {
                if (dtgIva.RowCount != 0)
                {
                    dtgIva.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_ObtenerIVAPorFecha ' '");
                }
                return;
            }
            else if (cmbitemsIva.Text == "Mostrar Todos")
            {
                dtgIva.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_FullObtenerIVA ");

            }

        }
    }
}
