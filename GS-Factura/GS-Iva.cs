using GS_Factura.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS_Factura
{
    public partial class GS_Iva : Form
    {
        bool verificarFecha = false;
        BD2 OAD = new BD2();
        List<SqlParameter> par = new List<SqlParameter>();
        int op;
        DataTable tb = new DataTable();
        string sql = "";

        public GS_Iva()
        {
            InitializeComponent();
        }
        void AlertlBoxArtan(Color backColor, Color color, string title, string text, System.Drawing.Image icon)
        {
            Notificaciones noti = new Notificaciones();
            noti.BackColor = backColor;
            noti.ColorAlertBox = color;
            noti.TitleAlertBox = title;
            noti.TextAlertBox = text;
            noti.IconeAlertBox = icon;
            noti.ShowDialog();
        }
        private void BtnGuardarIva_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si la fecha seleccionada es menor que la fecha actual
                if (dtpFechaFinal.Value.Date < dtpFechaInicio.Value.Date)
                {
                    dtpFechaFinal.Value = DateTime.Now;
                    AlertlBoxArtan(Color.LightPink, Color.DarkRed, "Error", "Fecha final debe ser mayor.", Properties.Resources.Error);
                    //MessageBox.Show("La fecha final no puede ser menor que la fecha actual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (dtpFechaInicio.Value.Date > dtpFechaFinal.Value.Date)
                {
                    AlertlBoxArtan(Color.LightPink, Color.DarkRed, "Error", "Fecha inicial debe ser mayor.", Properties.Resources.Error);
                    //MessageBox.Show("La fecha Inicial no puede ser mayor que la fecha Final.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (txtIva.Text == "" || txtIva.Text == "0")
                {
                    AlertlBoxArtan(Color.LightGoldenrodYellow, Color.DarkGoldenrod, "Advertencia", "El campo Iva está vacío.", Properties.Resources.Warning);
                    //MessageBox.Show("El campo Iva está vacío. Por favor, ingrese un valor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    verificarFecha = false;
                    par.Clear();
                    par.Add(new SqlParameter("@FechaInicio", dtpFechaInicio.Value));
                    par.Add(new SqlParameter("@FechaFinal", dtpFechaFinal.Value));
                    verificarFecha = OAD.EscalarProcAlmBool("VerificarRangoFechaIVA", par, true);
                    // Verificar si la cédula ya existe en la base de datos
                    if (verificarFecha)
                    {
                        AlertlBoxArtan(Color.LightGoldenrodYellow, Color.DarkGoldenrod, "Advertencia", "Ya existe una fecha registrada.", Properties.Resources.Warning);
                        //MessageBox.Show("Ya existe una fecha registrada en emision.", "Fecha Duplicada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Salir del método para evitar continuar con la operación de guardado
                    }
                    else
                    {
                        // Se confirmar antes de agregar al cliente
                        DialogResult resultado = MessageBox.Show("¿Estás seguro de que quieres agregar este nuevo valor de IVA?", "Confirmar adición", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (resultado == DialogResult.Yes)
                        {
                            sql = "";
                            par.Clear();
                            par.Add(new SqlParameter("@ValorIVA", decimal.Parse(txtIva.Text.Replace(".", ","))));
                            par.Add(new SqlParameter("@FechaInicio", dtpFechaInicio.Value));
                            par.Add(new SqlParameter("@FechaFinal", dtpFechaFinal.Value));
                            sql = OAD.EscalarProcAlmString("InsertarIVA", par, true);
                            if (sql != null)
                            {
                                BloqueoControles();
                                txtIva.Text = "0";
                                lblIdIva.Text = "0";
                                AlertlBoxArtan(Color.LightGray, Color.SeaGreen, "Éxito", "Los datos de Guardaron correctamente.", Properties.Resources.Success);
                                //MessageBox.Show("IVA guardado exitosamente.", "Datos Guardados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                AlertlBoxArtan(Color.LightPink, Color.DarkRed, "Error", "No se pudieron Guardar.", Properties.Resources.Error);
                                //MessageBox.Show("No se pudo  Guardar", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
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

        }
        void Limpiar()
        {
            txtIva.Text = "0";
            lblIdIva.Text = "0";
            if (dtgIva.RowCount != 0)
            {
                tb = OAD.EscalarProcAlmTablaSinPar("sp_IVAvacio", true);
                dtgIva.DataSource = tb;
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
                    AlertlBoxArtan(Color.LightPink, Color.DarkRed, "Error", "Fecha final debe ser mayor.", Properties.Resources.Error);
                    //MessageBox.Show("La fecha final no puede ser menor que la fecha actual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (dtpFechaInicio.Value.Date > dtpFechaFinal.Value.Date)
                {
                    AlertlBoxArtan(Color.LightPink, Color.DarkRed, "Error", "Fecha inicial debe ser mayor.", Properties.Resources.Error);
                    //MessageBox.Show("La fecha Inicial no puede ser mayor que la fecha Final.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (txtIva.Text == "" || txtIva.Text == "0")
                {
                    AlertlBoxArtan(Color.LightGoldenrodYellow, Color.DarkGoldenrod, "Advertencia", "El campo Iva está vacío.", Properties.Resources.Warning);
                    //MessageBox.Show("El campo Iva está vacío. Por favor, ingrese un valor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    DialogResult confirmacion = MessageBox.Show("¿Estás seguro de que quieres actualizar estos datos?", "Confirmar modificacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmacion == DialogResult.Yes)
                    {
                        sql = "";
                        par.Clear();
                        par.Add(new SqlParameter("@ID_IVA", int.Parse(lblIdIva.Text)));
                        par.Add(new SqlParameter("@ValorIVA", decimal.Parse(txtIva.Text.Replace(".", ","))));
                        par.Add(new SqlParameter("@FechaInicio", dtpFechaInicio.Value));
                        par.Add(new SqlParameter("@FechaFinal", dtpFechaFinal.Value));
                        sql = OAD.EscalarProcAlmString("EditarIVA", par, true);
                        if (sql != null)
                        {
                            BloqueoControles();
                            txtIva.Text = "0";
                            lblIdIva.Text = "0";
                            AlertlBoxArtan(Color.LightGray, Color.SeaGreen, "Éxito", "Los datos de Guardaron correctamente.", Properties.Resources.Success);
                            //MessageBox.Show("Los datos de editaron correctamente", "Datos Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            AlertlBoxArtan(Color.LightPink, Color.DarkRed, "Error", "No se pudieron Guardar.", Properties.Resources.Error);
                            //MessageBox.Show("No se pudieron Editar", "Error al editar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    par.Add(new SqlParameter("@ID_iva", int.Parse(lblIdIva.Text)));
                    sql = OAD.EscalarProcAlmString("InactivarIVA", par, true);
                    if (sql != null)
                    {
                        BloqueoControles();
                        txtIva.Text = "0";
                        lblIdIva.Text = "0";
                        AlertlBoxArtan(Color.LightGray, Color.SeaGreen, "Éxito", "IVA Eliminado exitosamente.", Properties.Resources.Success);
                        //MessageBox.Show("IVA Eliminado exitosamente.", "Datos Eliminados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        AlertlBoxArtan(Color.LightPink, Color.DarkRed, "Error", "No se pudieron Eliminar.", Properties.Resources.Error);
                        //MessageBox.Show("No se pudieron Eliminar", "Error al Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                AlertlBoxArtan(Color.LightGoldenrodYellow, Color.DarkGoldenrod, "Advertencia", "Solo se permiten números.", Properties.Resources.Warning);
                //MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (e.KeyChar == ',')
            {
                e.KeyChar = '.'; // Reemplazar la coma por un punto
            }
            else if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                AlertlBoxArtan(Color.LightGoldenrodYellow, Color.DarkGoldenrod, "Advertencia", "No se permiten espacios en blanco.", Properties.Resources.Warning);
                //MessageBox.Show("No se permiten espacios en blanco", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        }
        public void BloqueoClickDgv()
        {
            btnGuardarIva.Enabled = false;
            btnActualizarIva.Enabled = true;
            btnEliminarIva.Enabled = true;
            lblTextoIva.Visible = true;
            lblIdIva.Visible = true;
        }
        private void Btn_BuscarIva_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar que la fecha final no sea menor que la fecha inicial
                if (dtpSearchFechaFinal.Value.Date < dtpSearchFechaInicio.Value.Date)
                {
                    AlertlBoxArtan(Color.LightPink, Color.DarkRed, "Error", "Fecha final debe ser mayor.", Properties.Resources.Error);
                    //MessageBox.Show("La fecha final no puede ser menor que la fecha inicial.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (dtpSearchFechaInicio.Value.Date > dtpSearchFechaFinal.Value.Date)
                {
                    AlertlBoxArtan(Color.LightPink, Color.DarkRed, "Error", "Fecha inicial debe ser mayor.", Properties.Resources.Error);
                    //MessageBox.Show("La fecha Inicial no puede ser mayor que la fecha Final.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    tb.Clear();
                    par.Clear();
                    par.Add(new SqlParameter("@FechaInicio", dtpFechaInicio.Value));
                    par.Add(new SqlParameter("@FechaFinal", dtpFechaFinal.Value));
                    tb = OAD.EscalarProcAlmTabla("sp_ObtenerIVAEntreFecha", par, true);
                    dtgIva.DataSource = tb;
                    if (tb.Rows.Count == 0)
                    {
                        AlertlBoxArtan(Color.LightPink, Color.DarkRed, "Error", "IVA no encontrado.", Properties.Resources.Error);
                        //MessageBox.Show("IVA no encontrado. \n\nSe sugiere al Usuario verificar el dato del IVA e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //dtgIva.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_ObtenerIVAEntreFecha'" + dtpSearchFechaInicio.Value + "', '" + dtpSearchFechaFinal.Value + "'");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void cmbitemsIva_SelectedIndexChanged(object sender, EventArgs e)
        {
            op = cmbitemsIva.SelectedIndex;
            switch (op)
            {
                case 0:
                    txtbuscarIva.Text = "";
                    txtbuscarIva.Enabled = false;
                    tb.Clear();
                    tb = OAD.EscalarProcAlmTablaSinPar("sp_FullObtenerIVA", true);
                    dtgIva.DataSource = tb;
                    if (txtbuscarIva.TextLength > 0)
                    {
                        tb = OAD.EscalarProcAlmTablaSinPar("sp_IVAvacio", true);
                        dtgIva.DataSource = tb;
                        AlertlBoxArtan(Color.LightPink, Color.DarkRed, "Error", "Debe tener el campo de busqueda vacio.", Properties.Resources.Error);
                        //MessageBox.Show("Debe tener el campo de busqueda vacio ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cmbitemsIva.SelectedIndex = -1;
                    }
                    break;
                case 1:
                    txtbuscarIva.Enabled = true;
                    op = 1;
                    tb.Clear();
                    break;
                case 2:
                    txtbuscarIva.Enabled = true;
                    op = 2;
                    tb.Clear();
                    break;
            }
        }

        private void txtbuscarIva_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == ' ' || char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                if (txtbuscarIva.Text != null)
                {
                    if (op == 1)
                    {
                        if (txtbuscarIva.TextLength != 0 || cmbitemsIva.SelectedIndex == -1)
                        {
                            e.Handled = true;
                            tb.Clear();
                            par.Clear();
                            par.Add(new SqlParameter("@Campo", "ID_IVA"));
                            par.Add(new SqlParameter("@Buscar", txtbuscarIva.Text.Trim()));
                            tb = OAD.EscalarProcAlmTabla("sp_BuscarIVA ", par, true);
                            dtgIva.DataSource = tb;
                            if (tb.Rows.Count == 0)
                            {
                                AlertlBoxArtan(Color.LightPink, Color.DarkRed, "Error", "IVA no encontrado.", Properties.Resources.Error);
                                //MessageBox.Show("IVA no encontrado. \n\nSe sugiere al Usuario verificar el dato del IVA e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            tb = OAD.EscalarProcAlmTablaSinPar("sp_IVAvacio", true);
                            dtgIva.DataSource = tb;
                            AlertlBoxArtan(Color.LightGoldenrodYellow, Color.DarkGoldenrod, "Advertencia", "Por favor ingregse al menos un carácter.", Properties.Resources.Warning);
                            //MessageBox.Show("Por favor ingregse al menos un carácter");
                        }
                    }
                    else if (op == 2)
                    {
                        if (txtbuscarIva.TextLength != 0 || cmbitemsIva.SelectedIndex == -1)
                        {
                            e.Handled = true;
                            tb.Clear();
                            par.Clear();
                            par.Add(new SqlParameter("@Campo", "ValorIVA"));
                            par.Add(new SqlParameter("@Buscar", txtbuscarIva.Text.Trim()));
                            tb = OAD.EscalarProcAlmTabla("sp_BuscarIVA ", par, true);
                            dtgIva.DataSource = tb;
                            if (tb.Rows.Count == 0)
                            {
                                AlertlBoxArtan(Color.LightPink, Color.DarkRed, "Error", "IVA no encontrado.", Properties.Resources.Error);
                                //MessageBox.Show("Cliente no encontrado. \n\nSe sugiere al Usuario verificar el dato del cliente e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            tb = OAD.EscalarProcAlmTablaSinPar("sp_IVAvacio ", true);
                            dtgIva.DataSource = tb;
                            AlertlBoxArtan(Color.LightGoldenrodYellow, Color.DarkGoldenrod, "Advertencia", "Por favor ingregse al menos un carácter.", Properties.Resources.Warning);
                            //MessageBox.Show("Por favor ingregse al menos un carácter");
                        }
                    }
                }
                else
                {
                    AlertlBoxArtan(Color.LightGoldenrodYellow, Color.DarkGoldenrod, "Advertencia", "Seleccione al menos un campo.", Properties.Resources.Warning);
                    //MessageBox.Show("Seleccione al menos un campo");
                }
            }
            else if (op == null && txtbuscarIva.Text == null)
            {
                AlertlBoxArtan(Color.LightGoldenrodYellow, Color.DarkGoldenrod, "Advertencia", "Por favor ingregse al menos un carácter.", Properties.Resources.Warning);
                //MessageBox.Show("Por favor ingregse un carácter");
            }
        }

        private void dtgIva_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
                    txtIva.Text = dtgIva.CurrentRow.Cells[1].Value.ToString().Replace(",", "."); ;
                    dtpFechaInicio.Text = dtgIva.CurrentRow.Cells[2].Value.ToString();
                    dtpFechaFinal.Text = dtgIva.CurrentRow.Cells[3].Value.ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

