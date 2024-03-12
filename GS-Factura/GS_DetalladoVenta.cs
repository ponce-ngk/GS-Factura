using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using GS_Factura.Clases;
using System.Data.SqlClient;

namespace GS_Factura
{
    public partial class GS_DetalladoVenta : Form
    {
        BD2 OAD = new BD2();
        List<SqlParameter> par = new List<SqlParameter>();
        int opClientes, opProductos;
        DataTable tb = new DataTable();
        string sql = "";

        public GS_DetalladoVenta()
        {
            InitializeComponent();
            cbxNombre.Text = "Desabilitado";
            cbxNombre.ForeColor = Color.Red;
            cbxProducto.Text = "Desabilitado";
            cbxProducto.ForeColor = Color.Red;
            cmbitemsClientes.Enabled = false;
            cmbitemsProductos.Enabled = false;
        }

        private void SaveExcelFile(string fileName, Excel.Workbook workbook)
        {
            Excel.Application excelApp = new Excel.Application();

            try
            {
                // Verificar si el archivo de Excel está abierto
                foreach (Excel.Workbook wb in excelApp.Workbooks)
                {
                    if (wb.FullName == fileName)
                    {
                        // Cerrar el archivo existente
                        wb.Close(true);
                        break;
                    }
                }

                // Guardar el archivo Excel en la ubicación seleccionada
                workbook.SaveAs(fileName);

                // Mostrar mensaje de éxito
                MessageBox.Show("El archivo Excel se ha creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el archivo Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (excelApp != null)
                {
                    workbook.Close(false);
                    excelApp.Quit();
                    releaseObject(workbook);
                    releaseObject(excelApp);
                }
            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel(dgvDetalladoVenta);
        }

        private void ExportToExcel(DataGridView dataGridView)
        {
            if (dataGridView.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Crear una instancia de Excel
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.Sheets[1];

            // Agregar título en la primera fila
            Excel.Range titleRange = worksheet.Cells[1, 1] as Excel.Range;
            titleRange.Value = "Resumen de informe de venta";
            titleRange.Font.Size = 35;
            titleRange.Font.Bold = true;
            titleRange.EntireRow.AutoFit();

            // Copiar datos del DataGridView a Excel
            for (int i = 0; i < dataGridView.ColumnCount; i++)
            {
                worksheet.Cells[4, i + 1] = dataGridView.Columns[i].HeaderText;

                // Agregar bordes a la celda de la cabecera
                Excel.Range cellRange = worksheet.Cells[4, i + 1] as Excel.Range;
                cellRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                cellRange.Borders.Weight = Excel.XlBorderWeight.xlThin;
            }
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView.Columns.Count; j++)
                {
                    worksheet.Cells[i + 5, j + 1] = dataGridView.Rows[i].Cells[j].Value;

                    // Agregar bordes a las celdas de datos
                    Excel.Range cellRange = worksheet.Cells[i + 5, j + 1] as Excel.Range;
                    cellRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    cellRange.Borders.Weight = Excel.XlBorderWeight.xlThin;
                }
            }

            // Crear un cuadro de diálogo para seleccionar la ubicación del archivo
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx|All Files (*.*)|*.*";
            saveFileDialog.Title = "Guardar archivo Excel";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Guardar el archivo Excel
                SaveExcelFile(saveFileDialog.FileName, workbook);
            }

            // Liberar recursos
            releaseObject(worksheet);
            releaseObject(workbook);
            releaseObject(excelApp);
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Error al liberar el objeto Excel: " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            ExportarPDF();
        }

        private void cbxNombre_CheckedChanged(object sender, EventArgs e)
        {
            // Verificar si el CheckBox está marcado
            if (cbxNombre.Checked)
            {
                // Deshabilitar el TextBox si el CheckBox está marcado
                txtCliente.Enabled = true;
                cbxNombre.Text = "Habilitado";
                cbxNombre.ForeColor = Color.Green;
                cmbitemsClientes.Enabled = true;
            }
            else
            {
                // Habilitar el TextBox si el CheckBox está desmarcado
                txtCliente.Enabled = false;
                cbxNombre.Text = "Desabilitado";
                cbxNombre.ForeColor = Color.Red;
                cmbitemsClientes.Enabled = false;
            }
        }

        private void cbxProducto_CheckedChanged(object sender, EventArgs e)
        {
            // Verificar si el CheckBox está marcado
            if (cbxProducto.Checked)
            {
                // Deshabilitar el TextBox si el CheckBox está marcado
                txtProducto.Enabled = true;
                cbxProducto.Text = "Habilitado";
                cbxProducto.ForeColor = Color.Green;
                cmbitemsProductos.Enabled = true;
            }
            else
            {
                // Habilitar el TextBox si el CheckBox está desmarcado
                txtProducto.Enabled = false;
                cbxProducto.Text = "Desabilitado";
                cbxProducto.ForeColor = Color.Red;
                cmbitemsProductos.Enabled = false;
            }
        }

        private void cmbitemsClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            opClientes = cmbitemsClientes.SelectedIndex;
            switch (opClientes)
            {
                case 0:
                    opClientes = 0;
                    break;
                case 1:
                    opClientes = 1;
                    break;
            }
        }

        private void cmbitemsProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            opProductos = cmbitemsProductos.SelectedIndex;
            switch (opProductos)
            {
                case 0:
                    opProductos = 0;
                    break;
                case 1:
                    opProductos = 1;
                    break;
            }
        }

        private void txtCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validacion de que sea solo letras y espacio 
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == ' ' || char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                if (txtCliente.Text != null)
                {
                    if (opClientes == 0)
                    {
                        if (txtCliente.TextLength != 0 || cmbitemsClientes.SelectedIndex == -1)
                        {
                            e.Handled = true;
                            tb.Clear();
                            par.Clear();
                            par.Add(new SqlParameter("@Fecha_Inicio", dateTimePicker1.Text.Trim()));
                            par.Add(new SqlParameter("@Fecha_Fin", dateTimePicker2.Text.Trim()));
                            par.Add(new SqlParameter("@Campo", "CEDULA"));
                            par.Add(new SqlParameter("@Valor", txtCliente.Text.Trim()));
                            tb = OAD.EscalarProcAlmTabla("sp_DetalladoVentasFechasClientes ", par, true);
                            dgvDetalladoVenta.DataSource = tb;
                            if (tb.Rows.Count == 0)
                            {
                                MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar los dato proporcionados e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            tb = OAD.EscalarProcAlmTablaSinPar("sp_DetalladoVentasVacio ", true);
                            dgvDetalladoVenta.DataSource = tb;
                            //dgvDetalladoVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_DetalladoVentasVacio");
                            MessageBox.Show("Por favor ingregse al menos un carácter");
                        }
                    }
                    else if (opClientes == 1)
                    {
                        if (txtCliente.TextLength != 0 || cmbitemsClientes.SelectedIndex == -1)
                        {
                            e.Handled = true;
                            tb.Clear();
                            par.Clear();
                            par.Add(new SqlParameter("@Fecha_Inicio", dateTimePicker1.Text.Trim()));
                            par.Add(new SqlParameter("@Fecha_Fin", dateTimePicker2.Text.Trim()));
                            par.Add(new SqlParameter("@Campo", "NOMBRE"));
                            par.Add(new SqlParameter("@Valor", txtCliente.Text.Trim()));
                            tb = OAD.EscalarProcAlmTabla("sp_DetalladoVentasFechasClientes ", par, true);
                            dgvDetalladoVenta.DataSource = tb;
                            if (tb.Rows.Count == 0)
                            {
                                MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar los dato proporcionados e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            tb = OAD.EscalarProcAlmTablaSinPar("sp_DetalladoVentasVacio ", true);
                            dgvDetalladoVenta.DataSource = tb;
                            //dgvDetalladoVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_DetalladoVentasVacio");
                            MessageBox.Show("Por favor ingregse al menos un carácter");
                        }
                    }
                    else if (opClientes == 0 && opProductos == 0)
                    {
                        if (txtCliente.TextLength != 0 || cmbitemsClientes.SelectedIndex == -1 && cmbitemsProductos.SelectedIndex == -1)
                        {
                            e.Handled = true;
                            tb.Clear();
                            par.Clear();
                            par.Add(new SqlParameter("@Fecha_Inicio", dateTimePicker1.Text.Trim()));
                            par.Add(new SqlParameter("@Fecha_Fin", dateTimePicker2.Text.Trim()));
                            par.Add(new SqlParameter("@Campo", "CEDULA"));
                            par.Add(new SqlParameter("@Campo2", "IDPRODUCTO"));
                            par.Add(new SqlParameter("@Valor", txtCliente.Text.Trim()));
                            par.Add(new SqlParameter("@Valor2", txtProducto.Text.Trim()));
                            tb = OAD.EscalarProcAlmTabla("sp_DetalladoVentasFechasClientesProductos ", par, true);
                            dgvDetalladoVenta.DataSource = tb;
                            if (tb.Rows.Count == 0)
                            {
                                MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar los dato proporcionados e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            tb = OAD.EscalarProcAlmTablaSinPar("sp_DetalladoVentasVacio ", true);
                            dgvDetalladoVenta.DataSource = tb;
                            //dgvDetalladoVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_DetalladoVentasVacio");
                            MessageBox.Show("Por favor ingregse al menos un carácter");
                        }
                    }
                    else if (opClientes == 0 && opProductos == 1)
                    {
                        if (txtCliente.TextLength != 0 || cmbitemsClientes.SelectedIndex == -1 && cmbitemsProductos.SelectedIndex == -1)
                        {
                            e.Handled = true;
                            tb.Clear();
                            par.Clear();
                            par.Add(new SqlParameter("@Fecha_Inicio", dateTimePicker1.Text.Trim()));
                            par.Add(new SqlParameter("@Fecha_Fin", dateTimePicker2.Text.Trim()));
                            par.Add(new SqlParameter("@Campo", "CEDULA"));
                            par.Add(new SqlParameter("@Campo2", "PRODUCTO"));
                            par.Add(new SqlParameter("@Valor", txtCliente.Text.Trim()));
                            par.Add(new SqlParameter("@Valor2", txtProducto.Text.Trim()));
                            tb = OAD.EscalarProcAlmTabla("sp_DetalladoVentasFechasClientesProductos ", par, true);
                            dgvDetalladoVenta.DataSource = tb;
                            if (tb.Rows.Count == 0)
                            {
                                MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar los dato proporcionados e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            tb = OAD.EscalarProcAlmTablaSinPar("sp_DetalladoVentasVacio ", true);
                            dgvDetalladoVenta.DataSource = tb;
                            //dgvDetalladoVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_DetalladoVentasVacio");
                            MessageBox.Show("Por favor ingregse al menos un carácter");
                        }
                    }
                    else if (opClientes == 1 && opProductos == 0)
                    {
                        if (txtCliente.TextLength != 0 || cmbitemsClientes.SelectedIndex == -1 && cmbitemsProductos.SelectedIndex == -1)
                        {
                            e.Handled = true;
                            tb.Clear();
                            par.Clear();
                            par.Add(new SqlParameter("@Fecha_Inicio", dateTimePicker1.Text.Trim()));
                            par.Add(new SqlParameter("@Fecha_Fin", dateTimePicker2.Text.Trim()));
                            par.Add(new SqlParameter("@Campo", "NOMBRE"));
                            par.Add(new SqlParameter("@Campo2", "IDPRODUCTO"));
                            par.Add(new SqlParameter("@Valor", txtCliente.Text.Trim()));
                            par.Add(new SqlParameter("@Valor2", txtProducto.Text.Trim()));
                            tb = OAD.EscalarProcAlmTabla("sp_DetalladoVentasFechasClientesProductos ", par, true);
                            dgvDetalladoVenta.DataSource = tb;
                            if (tb.Rows.Count == 0)
                            {
                                MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar los dato proporcionados e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            tb = OAD.EscalarProcAlmTablaSinPar("sp_DetalladoVentasVacio ", true);
                            dgvDetalladoVenta.DataSource = tb;
                            //dgvDetalladoVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_DetalladoVentasVacio");
                            MessageBox.Show("Por favor ingregse al menos un carácter");
                        }
                    }
                    else if (opClientes == 1 && opProductos == 1)
                    {
                        if (txtCliente.TextLength != 0 || cmbitemsClientes.SelectedIndex == -1 && cmbitemsProductos.SelectedIndex == -1)
                        {
                            e.Handled = true;
                            tb.Clear();
                            par.Clear();
                            par.Add(new SqlParameter("@Fecha_Inicio", dateTimePicker1.Text.Trim()));
                            par.Add(new SqlParameter("@Fecha_Fin", dateTimePicker2.Text.Trim()));
                            par.Add(new SqlParameter("@Campo", "NOMBRE"));
                            par.Add(new SqlParameter("@Campo2", "PRODUCTO"));
                            par.Add(new SqlParameter("@Valor", txtCliente.Text.Trim()));
                            par.Add(new SqlParameter("@Valor2", txtProducto.Text.Trim()));
                            tb = OAD.EscalarProcAlmTabla("sp_DetalladoVentasFechasClientesProductos ", par, true);
                            dgvDetalladoVenta.DataSource = tb;
                            if (tb.Rows.Count == 0)
                            {
                                MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar los dato proporcionados e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            tb = OAD.EscalarProcAlmTablaSinPar("sp_DetalladoVentasVacio ", true);
                            dgvDetalladoVenta.DataSource = tb;
                            //dgvDetalladoVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_DetalladoVentasVacio");
                            MessageBox.Show("Por favor ingregse al menos un carácter");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione al menos un campo");
                }
            }
            else if (opClientes == null && txtCliente.Text == null)
            {
                MessageBox.Show("Por favor ingregse un carácter");
            }
        }

        private void txtProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validacion de que sea solo letras y espacio 
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == ' ' || char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                if (txtProducto.Text != null)
                {
                    if (opProductos == 0)
                    {
                        if (txtProducto.TextLength != 0 || cmbitemsClientes.SelectedIndex == -1)
                        {
                            e.Handled = true;
                            tb.Clear();
                            par.Clear();
                            par.Add(new SqlParameter("@Fecha_Inicio", dateTimePicker1.Text.Trim()));
                            par.Add(new SqlParameter("@Fecha_Fin", dateTimePicker2.Text.Trim()));
                            par.Add(new SqlParameter("@Campo", "IDPRODUCTO"));
                            par.Add(new SqlParameter("@Valor", txtProducto.Text.Trim()));
                            tb = OAD.EscalarProcAlmTabla("sp_DetalladoVentasFechasProductos ", par, true);
                            dgvDetalladoVenta.DataSource = tb;
                            if (tb.Rows.Count == 0)
                            {
                                MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar los dato proporcionados e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            tb = OAD.EscalarProcAlmTablaSinPar("sp_DetalladoVentasVacio ", true);
                            dgvDetalladoVenta.DataSource = tb;
                            //dgvDetalladoVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_DetalladoVentasVacio");
                            MessageBox.Show("Por favor ingregse al menos un carácter");
                        }
                    }
                    else if (opProductos == 1)
                    {
                        if (txtProducto.TextLength != 0 || cmbitemsClientes.SelectedIndex == -1)
                        {
                            e.Handled = true;
                            tb.Clear();
                            par.Clear();
                            par.Add(new SqlParameter("@Fecha_Inicio", dateTimePicker1.Text.Trim()));
                            par.Add(new SqlParameter("@Fecha_Fin", dateTimePicker2.Text.Trim()));
                            par.Add(new SqlParameter("@Campo", "PRODUCTO"));
                            par.Add(new SqlParameter("@Valor", txtProducto.Text.Trim()));
                            tb = OAD.EscalarProcAlmTabla("sp_DetalladoVentasFechasProductos ", par, true);
                            dgvDetalladoVenta.DataSource = tb;
                            if (tb.Rows.Count == 0)
                            {
                                MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar los dato proporcionados e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            tb = OAD.EscalarProcAlmTablaSinPar("sp_DetalladoVentasVacio ", true);
                            dgvDetalladoVenta.DataSource = tb;
                            //dgvDetalladoVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_DetalladoVentasVacio");
                            MessageBox.Show("Por favor ingregse al menos un carácter");
                        }
                    }
                    else if (opProductos == 0 && opClientes == 0)
                    {
                        if (txtProducto.TextLength != 0 || cmbitemsClientes.SelectedIndex == -1 && cmbitemsProductos.SelectedIndex == -1)
                        {
                            e.Handled = true;
                            tb.Clear();
                            par.Clear();
                            par.Add(new SqlParameter("@Fecha_Inicio", dateTimePicker1.Text.Trim()));
                            par.Add(new SqlParameter("@Fecha_Fin", dateTimePicker2.Text.Trim()));
                            par.Add(new SqlParameter("@Campo", "IDPRODUCTO"));
                            par.Add(new SqlParameter("@Campo2", "NOMBRE"));
                            par.Add(new SqlParameter("@Valor", txtProducto.Text.Trim()));
                            par.Add(new SqlParameter("@Valor2", txtCliente.Text.Trim()));
                            tb = OAD.EscalarProcAlmTabla("sp_DetalladoVentasFechasClientesProductos ", par, true);
                            dgvDetalladoVenta.DataSource = tb;
                            if (tb.Rows.Count == 0)
                            {
                                MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar los dato proporcionados e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            tb = OAD.EscalarProcAlmTablaSinPar("sp_DetalladoVentasVacio ", true);
                            dgvDetalladoVenta.DataSource = tb;
                            //dgvDetalladoVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_DetalladoVentasVacio");
                            MessageBox.Show("Por favor ingregse al menos un carácter");
                        }
                    }
                    else if (opProductos == 0 && opClientes == 1)
                    {
                        if (txtProducto.TextLength != 0 || cmbitemsClientes.SelectedIndex == -1 && cmbitemsProductos.SelectedIndex == -1)
                        {
                            e.Handled = true;
                            tb.Clear();
                            par.Clear();
                            par.Add(new SqlParameter("@Fecha_Inicio", dateTimePicker1.Text.Trim()));
                            par.Add(new SqlParameter("@Fecha_Fin", dateTimePicker2.Text.Trim()));
                            par.Add(new SqlParameter("@Campo", "IDPRODUCTO"));
                            par.Add(new SqlParameter("@Campo2", "CEDULA"));
                            par.Add(new SqlParameter("@Valor", txtProducto.Text.Trim()));
                            par.Add(new SqlParameter("@Valor2", txtCliente.Text.Trim()));
                            tb = OAD.EscalarProcAlmTabla("sp_DetalladoVentasFechasClientesProductos ", par, true);
                            dgvDetalladoVenta.DataSource = tb;
                            if (tb.Rows.Count == 0)
                            {
                                MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar los dato proporcionados e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            tb = OAD.EscalarProcAlmTablaSinPar("sp_DetalladoVentasVacio ", true);
                            dgvDetalladoVenta.DataSource = tb;
                            //dgvDetalladoVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_DetalladoVentasVacio");
                            MessageBox.Show("Por favor ingregse al menos un carácter");
                        }
                    }
                    else if (opProductos == 1 && opClientes == 0)
                    {
                        if (txtProducto.TextLength != 0 || cmbitemsClientes.SelectedIndex == -1 && cmbitemsProductos.SelectedIndex == -1)
                        {
                            e.Handled = true;
                            tb.Clear();
                            par.Clear();
                            par.Add(new SqlParameter("@Fecha_Inicio", dateTimePicker1.Text.Trim()));
                            par.Add(new SqlParameter("@Fecha_Fin", dateTimePicker2.Text.Trim()));
                            par.Add(new SqlParameter("@Campo", "PRODUCTO"));
                            par.Add(new SqlParameter("@Campo2", "NOMBRE"));
                            par.Add(new SqlParameter("@Valor", txtProducto.Text.Trim()));
                            par.Add(new SqlParameter("@Valor2", txtCliente.Text.Trim()));
                            tb = OAD.EscalarProcAlmTabla("sp_DetalladoVentasFechasClientesProductos ", par, true);
                            dgvDetalladoVenta.DataSource = tb;
                            if (tb.Rows.Count == 0)
                            {
                                MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar los dato proporcionados e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            tb = OAD.EscalarProcAlmTablaSinPar("sp_DetalladoVentasVacio ", true);
                            dgvDetalladoVenta.DataSource = tb;
                            //dgvDetalladoVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_DetalladoVentasVacio");
                            MessageBox.Show("Por favor ingregse al menos un carácter");
                        }
                    }
                    else if (opProductos == 1 && opClientes == 1)
                    {
                        if (txtProducto.TextLength != 0 || cmbitemsClientes.SelectedIndex == -1 && cmbitemsProductos.SelectedIndex == -1)
                        {
                            e.Handled = true;
                            tb.Clear();
                            par.Clear();
                            par.Add(new SqlParameter("@Fecha_Inicio", dateTimePicker1.Text.Trim()));
                            par.Add(new SqlParameter("@Fecha_Fin", dateTimePicker2.Text.Trim()));
                            par.Add(new SqlParameter("@Campo", "PRODUCTO"));
                            par.Add(new SqlParameter("@Campo2", "CEDULA"));
                            par.Add(new SqlParameter("@Valor", txtProducto.Text.Trim()));
                            par.Add(new SqlParameter("@Valor2", txtCliente.Text.Trim()));
                            tb = OAD.EscalarProcAlmTabla("sp_DetalladoVentasFechasClientesProductos ", par, true);
                            dgvDetalladoVenta.DataSource = tb;
                            if (tb.Rows.Count == 0)
                            {
                                MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar los dato proporcionados e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            tb = OAD.EscalarProcAlmTablaSinPar("sp_DetalladoVentasVacio ", true);
                            dgvDetalladoVenta.DataSource = tb;
                            //dgvDetalladoVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_DetalladoVentasVacio");
                            MessageBox.Show("Por favor ingregse al menos un carácter");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione al menos un campo");
                }
            }
            else if (opProductos == null && txtProducto.Text == null)
            {
                MessageBox.Show("Por favor ingregse un carácter");
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            tb.Clear();
            par.Clear();
            par.Add(new SqlParameter("@Fecha_Inicio", dateTimePicker1.Text.Trim()));
            par.Add(new SqlParameter("@Fecha_Fin", dateTimePicker2.Text.Trim()));
            tb = OAD.EscalarProcAlmTabla("sp_DetalladoVentasFechas ", par, true);
            dgvDetalladoVenta.DataSource = tb;
            if (tb.Rows.Count == 0)
            {
                MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar los dato proporcionados e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarItems_Click(object sender, EventArgs e)
        {
            if (txtCliente.Text != null)
            {
                if (opClientes == 0)
                {
                    if (txtCliente.TextLength != 0 || cmbitemsClientes.SelectedIndex == -1)
                    {
                        tb.Clear();
                        par.Clear();
                        par.Add(new SqlParameter("@Fecha_Inicio", dateTimePicker1.Text.Trim()));
                        par.Add(new SqlParameter("@Fecha_Fin", dateTimePicker2.Text.Trim()));
                        par.Add(new SqlParameter("@Campo", "CEDULA"));
                        par.Add(new SqlParameter("@Valor", txtCliente.Text.Trim()));
                        tb = OAD.EscalarProcAlmTabla("sp_DetalladoVentasFechasClientes ", par, true);
                        dgvDetalladoVenta.DataSource = tb;
                        if (tb.Rows.Count == 0)
                        {
                            MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar los dato proporcionados e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        tb = OAD.EscalarProcAlmTablaSinPar("sp_DetalladoVentasVacio ", true);
                        dgvDetalladoVenta.DataSource = tb;
                        //dgvDetalladoVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_DetalladoVentasVacio");
                        MessageBox.Show("Por favor ingregse al menos un carácter");
                    }
                }
                else if (opClientes == 1)
                {
                    if (txtCliente.TextLength != 0 || cmbitemsClientes.SelectedIndex == -1)
                    {
                        tb.Clear();
                        par.Clear();
                        par.Add(new SqlParameter("@Fecha_Inicio", dateTimePicker1.Text.Trim()));
                        par.Add(new SqlParameter("@Fecha_Fin", dateTimePicker2.Text.Trim()));
                        par.Add(new SqlParameter("@Campo", "NOMBRE"));
                        par.Add(new SqlParameter("@Valor", txtCliente.Text.Trim()));
                        tb = OAD.EscalarProcAlmTabla("sp_DetalladoVentasFechasClientes ", par, true);
                        dgvDetalladoVenta.DataSource = tb;
                        if (tb.Rows.Count == 0)
                        {
                            MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar los dato proporcionados e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        tb = OAD.EscalarProcAlmTablaSinPar("sp_DetalladoVentasVacio ", true);
                        dgvDetalladoVenta.DataSource = tb;
                        //dgvDetalladoVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_DetalladoVentasVacio");
                        MessageBox.Show("Por favor ingregse al menos un carácter");
                    }
                }
            }
            else if (txtProducto.Text != null)
            {
                if (opProductos == 0)
                {
                    if (txtProducto.TextLength != 0 || cmbitemsClientes.SelectedIndex == -1)
                    {
                        tb.Clear();
                        par.Clear();
                        par.Add(new SqlParameter("@Fecha_Inicio", dateTimePicker1.Text.Trim()));
                        par.Add(new SqlParameter("@Fecha_Fin", dateTimePicker2.Text.Trim()));
                        par.Add(new SqlParameter("@Campo", "IDPRODUCTO"));
                        par.Add(new SqlParameter("@Valor", txtProducto.Text.Trim()));
                        tb = OAD.EscalarProcAlmTabla("sp_DetalladoVentasFechasProductos ", par, true);
                        dgvDetalladoVenta.DataSource = tb;
                        if (tb.Rows.Count == 0)
                        {
                            MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar los dato proporcionados e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        tb = OAD.EscalarProcAlmTablaSinPar("sp_DetalladoVentasVacio ", true);
                        dgvDetalladoVenta.DataSource = tb;
                        //dgvDetalladoVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_DetalladoVentasVacio");
                        MessageBox.Show("Por favor ingregse al menos un carácter");
                    }
                }
                else if (opProductos == 1)
                {
                    if (txtProducto.TextLength != 0 || cmbitemsClientes.SelectedIndex == -1)
                    {
                        tb.Clear();
                        par.Clear();
                        par.Add(new SqlParameter("@Fecha_Inicio", dateTimePicker1.Text.Trim()));
                        par.Add(new SqlParameter("@Fecha_Fin", dateTimePicker2.Text.Trim()));
                        par.Add(new SqlParameter("@Campo", "PRODUCTO"));
                        par.Add(new SqlParameter("@Valor", txtProducto.Text.Trim()));
                        tb = OAD.EscalarProcAlmTabla("sp_DetalladoVentasFechasProductos ", par, true);
                        dgvDetalladoVenta.DataSource = tb;
                        if (tb.Rows.Count == 0)
                        {
                            MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar los dato proporcionados e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        tb = OAD.EscalarProcAlmTablaSinPar("sp_DetalladoVentasVacio ", true);
                        dgvDetalladoVenta.DataSource = tb;
                        //dgvDetalladoVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_DetalladoVentasVacio");
                        MessageBox.Show("Por favor ingregse al menos un carácter");
                    }
                }
            }
            else if (txtCliente.Text != null || txtProducto.Text != null)
            {
                if (opClientes == 0 && opProductos == 0)
                {
                    if (txtCliente.TextLength != 0 || cmbitemsClientes.SelectedIndex == -1 && cmbitemsProductos.SelectedIndex == -1)
                    {
                        tb.Clear();
                        par.Clear();
                        par.Add(new SqlParameter("@Fecha_Inicio", dateTimePicker1.Text.Trim()));
                        par.Add(new SqlParameter("@Fecha_Fin", dateTimePicker2.Text.Trim()));
                        par.Add(new SqlParameter("@Campo", "CEDULA"));
                        par.Add(new SqlParameter("@Campo2", "IDPRODUCTO"));
                        par.Add(new SqlParameter("@Valor", txtCliente.Text.Trim()));
                        par.Add(new SqlParameter("@Valor2", txtProducto.Text.Trim()));
                        tb = OAD.EscalarProcAlmTabla("sp_DetalladoVentasFechasClientesProductos ", par, true);
                        dgvDetalladoVenta.DataSource = tb;
                        if (tb.Rows.Count == 0)
                        {
                            MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar los dato proporcionados e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        tb = OAD.EscalarProcAlmTablaSinPar("sp_DetalladoVentasVacio ", true);
                        dgvDetalladoVenta.DataSource = tb;
                        //dgvDetalladoVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_DetalladoVentasVacio");
                        MessageBox.Show("Por favor ingregse al menos un carácter");
                    }
                }
                else if (opClientes == 0 && opProductos == 1)
                {
                    if (txtCliente.TextLength != 0 || cmbitemsClientes.SelectedIndex == -1 && cmbitemsProductos.SelectedIndex == -1)
                    {
                        tb.Clear();
                        par.Clear();
                        par.Add(new SqlParameter("@Fecha_Inicio", dateTimePicker1.Text.Trim()));
                        par.Add(new SqlParameter("@Fecha_Fin", dateTimePicker2.Text.Trim()));
                        par.Add(new SqlParameter("@Campo", "CEDULA"));
                        par.Add(new SqlParameter("@Campo2", "PRODUCTO"));
                        par.Add(new SqlParameter("@Valor", txtCliente.Text.Trim()));
                        par.Add(new SqlParameter("@Valor2", txtProducto.Text.Trim()));
                        tb = OAD.EscalarProcAlmTabla("sp_DetalladoVentasFechasClientesProductos ", par, true);
                        dgvDetalladoVenta.DataSource = tb;
                        if (tb.Rows.Count == 0)
                        {
                            MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar los dato proporcionados e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        tb = OAD.EscalarProcAlmTablaSinPar("sp_DetalladoVentasVacio ", true);
                        dgvDetalladoVenta.DataSource = tb;
                        //dgvDetalladoVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_DetalladoVentasVacio");
                        MessageBox.Show("Por favor ingregse al menos un carácter");
                    }
                }
                else if (opClientes == 1 && opProductos == 0)
                {
                    if (txtCliente.TextLength != 0 || cmbitemsClientes.SelectedIndex == -1 && cmbitemsProductos.SelectedIndex == -1)
                    {
                        tb.Clear();
                        par.Clear();
                        par.Add(new SqlParameter("@Fecha_Inicio", dateTimePicker1.Text.Trim()));
                        par.Add(new SqlParameter("@Fecha_Fin", dateTimePicker2.Text.Trim()));
                        par.Add(new SqlParameter("@Campo", "NOMBRE"));
                        par.Add(new SqlParameter("@Campo2", "IDPRODUCTO"));
                        par.Add(new SqlParameter("@Valor", txtCliente.Text.Trim()));
                        par.Add(new SqlParameter("@Valor2", txtProducto.Text.Trim()));
                        tb = OAD.EscalarProcAlmTabla("sp_DetalladoVentasFechasClientesProductos ", par, true);
                        dgvDetalladoVenta.DataSource = tb;
                        if (tb.Rows.Count == 0)
                        {
                            MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar los dato proporcionados e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        tb = OAD.EscalarProcAlmTablaSinPar("sp_DetalladoVentasVacio ", true);
                        dgvDetalladoVenta.DataSource = tb;
                        //dgvDetalladoVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_DetalladoVentasVacio");
                        MessageBox.Show("Por favor ingregse al menos un carácter");
                    }
                }
                else if (opClientes == 1 && opProductos == 1)
                {
                    if (txtCliente.TextLength != 0 || cmbitemsClientes.SelectedIndex == -1 && cmbitemsProductos.SelectedIndex == -1)
                    {
                        tb.Clear();
                        par.Clear();
                        par.Add(new SqlParameter("@Fecha_Inicio", dateTimePicker1.Text.Trim()));
                        par.Add(new SqlParameter("@Fecha_Fin", dateTimePicker2.Text.Trim()));
                        par.Add(new SqlParameter("@Campo", "NOMBRE"));
                        par.Add(new SqlParameter("@Campo2", "PRODUCTO"));
                        par.Add(new SqlParameter("@Valor", txtCliente.Text.Trim()));
                        par.Add(new SqlParameter("@Valor2", txtProducto.Text.Trim()));
                        tb = OAD.EscalarProcAlmTabla("sp_DetalladoVentasFechasClientesProductos ", par, true);
                        dgvDetalladoVenta.DataSource = tb;
                        if (tb.Rows.Count == 0)
                        {
                            MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar los dato proporcionados e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        tb = OAD.EscalarProcAlmTablaSinPar("sp_DetalladoVentasVacio ", true);
                        dgvDetalladoVenta.DataSource = tb;
                        //dgvDetalladoVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_DetalladoVentasVacio");
                        MessageBox.Show("Por favor ingregse al menos un carácter");
                    }
                }
                else if (opProductos == 0 && opClientes == 0)
                {
                    if (txtProducto.TextLength != 0 || cmbitemsClientes.SelectedIndex == -1 && cmbitemsProductos.SelectedIndex == -1)
                    {
                        tb.Clear();
                        par.Clear();
                        par.Add(new SqlParameter("@Fecha_Inicio", dateTimePicker1.Text.Trim()));
                        par.Add(new SqlParameter("@Fecha_Fin", dateTimePicker2.Text.Trim()));
                        par.Add(new SqlParameter("@Campo", "IDPRODUCTO"));
                        par.Add(new SqlParameter("@Campo2", "NOMBRE"));
                        par.Add(new SqlParameter("@Valor", txtProducto.Text.Trim()));
                        par.Add(new SqlParameter("@Valor2", txtCliente.Text.Trim()));
                        tb = OAD.EscalarProcAlmTabla("sp_DetalladoVentasFechasClientesProductos ", par, true);
                        dgvDetalladoVenta.DataSource = tb;
                        if (tb.Rows.Count == 0)
                        {
                            MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar los dato proporcionados e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        tb = OAD.EscalarProcAlmTablaSinPar("sp_DetalladoVentasVacio ", true);
                        dgvDetalladoVenta.DataSource = tb;
                        //dgvDetalladoVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_DetalladoVentasVacio");
                        MessageBox.Show("Por favor ingregse al menos un carácter");
                    }
                }
                else if (opProductos == 0 && opClientes == 1)
                {
                    if (txtProducto.TextLength != 0 || cmbitemsClientes.SelectedIndex == -1 && cmbitemsProductos.SelectedIndex == -1)
                    {
                        tb.Clear();
                        par.Clear();
                        par.Add(new SqlParameter("@Fecha_Inicio", dateTimePicker1.Text.Trim()));
                        par.Add(new SqlParameter("@Fecha_Fin", dateTimePicker2.Text.Trim()));
                        par.Add(new SqlParameter("@Campo", "IDPRODUCTO"));
                        par.Add(new SqlParameter("@Campo2", "CEDULA"));
                        par.Add(new SqlParameter("@Valor", txtProducto.Text.Trim()));
                        par.Add(new SqlParameter("@Valor2", txtCliente.Text.Trim()));
                        tb = OAD.EscalarProcAlmTabla("sp_DetalladoVentasFechasClientesProductos ", par, true);
                        dgvDetalladoVenta.DataSource = tb;
                        if (tb.Rows.Count == 0)
                        {
                            MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar los dato proporcionados e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        tb = OAD.EscalarProcAlmTablaSinPar("sp_DetalladoVentasVacio ", true);
                        dgvDetalladoVenta.DataSource = tb;
                        //dgvDetalladoVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_DetalladoVentasVacio");
                        MessageBox.Show("Por favor ingregse al menos un carácter");
                    }
                }
                else if (opProductos == 1 && opClientes == 0)
                {
                    if (txtProducto.TextLength != 0 || cmbitemsClientes.SelectedIndex == -1 && cmbitemsProductos.SelectedIndex == -1)
                    {
                        tb.Clear();
                        par.Clear();
                        par.Add(new SqlParameter("@Fecha_Inicio", dateTimePicker1.Text.Trim()));
                        par.Add(new SqlParameter("@Fecha_Fin", dateTimePicker2.Text.Trim()));
                        par.Add(new SqlParameter("@Campo", "PRODUCTO"));
                        par.Add(new SqlParameter("@Campo2", "NOMBRE"));
                        par.Add(new SqlParameter("@Valor", txtProducto.Text.Trim()));
                        par.Add(new SqlParameter("@Valor2", txtCliente.Text.Trim()));
                        tb = OAD.EscalarProcAlmTabla("sp_DetalladoVentasFechasClientesProductos ", par, true);
                        dgvDetalladoVenta.DataSource = tb;
                        if (tb.Rows.Count == 0)
                        {
                            MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar los dato proporcionados e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        tb = OAD.EscalarProcAlmTablaSinPar("sp_DetalladoVentasVacio ", true);
                        dgvDetalladoVenta.DataSource = tb;
                        //dgvDetalladoVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_DetalladoVentasVacio");
                        MessageBox.Show("Por favor ingregse al menos un carácter");
                    }
                }
                else if (opProductos == 1 && opClientes == 1)
                {
                    if (txtProducto.TextLength != 0 || cmbitemsClientes.SelectedIndex == -1 && cmbitemsProductos.SelectedIndex == -1)
                    {
                        tb.Clear();
                        par.Clear();
                        par.Add(new SqlParameter("@Fecha_Inicio", dateTimePicker1.Text.Trim()));
                        par.Add(new SqlParameter("@Fecha_Fin", dateTimePicker2.Text.Trim()));
                        par.Add(new SqlParameter("@Campo", "PRODUCTO"));
                        par.Add(new SqlParameter("@Campo2", "CEDULA"));
                        par.Add(new SqlParameter("@Valor", txtProducto.Text.Trim()));
                        par.Add(new SqlParameter("@Valor2", txtCliente.Text.Trim()));
                        tb = OAD.EscalarProcAlmTabla("sp_DetalladoVentasFechasClientesProductos ", par, true);
                        dgvDetalladoVenta.DataSource = tb;
                        if (tb.Rows.Count == 0)
                        {
                            MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar los dato proporcionados e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        tb = OAD.EscalarProcAlmTablaSinPar("sp_DetalladoVentasVacio ", true);
                        dgvDetalladoVenta.DataSource = tb;
                        //dgvDetalladoVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_DetalladoVentasVacio");
                        MessageBox.Show("Por favor ingregse al menos un carácter");
                    }
                }
            }
        }

        private void ExportarPDF()
        {
            if (dgvDetalladoVenta.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            BaseFont fuente = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1250, true);
            iTextSharp.text.Font fontTitle = new iTextSharp.text.Font(fuente, 30f, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            // Crear un documento PDF
            Document doc = new Document(PageSize.A4.Rotate());
            doc.SetMargins(1.27f, 1.27f, 1.27f, 1.27f);
            try
            {
                // Especificar la ubicación del archivo PDF
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    // Crear el archivo PDF en la ruta seleccionada
                    PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                    doc.Open();


                    // Agregar encabezado
                    Paragraph header = new Paragraph("Resumen de informe de venta", fontTitle);
                    header.Alignment = Element.ALIGN_CENTER;
                    doc.Add(header);

                    // Agregar espacio entre el encabezado y la tabla
                    doc.Add(new Paragraph("\n"));
                    doc.Add(new Paragraph("\n"));
                    doc.Add(new Paragraph("\n"));


                    PdfPTable table = new PdfPTable(dgvDetalladoVenta.Columns.Count);
                    for (int i = 0; i < dgvDetalladoVenta.Columns.Count; i++)
                    {
                        table.AddCell(new Phrase(dgvDetalladoVenta.Columns[i].HeaderText));
                    }

                    // Agregar filas
                    for (int i = 0; i < dgvDetalladoVenta.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvDetalladoVenta.Columns.Count; j++)
                        {
                            if (dgvDetalladoVenta[j, i].Value != null)
                            {
                                table.AddCell(new Phrase(dgvDetalladoVenta[j, i].Value.ToString()));
                            }
                        }
                    }

                    // Agregar la tabla al documento
                    doc.Add(table);
                    MessageBox.Show("Datos exportados correctamente a PDF.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar a PDF: " + ex.Message);
            }
            finally
            {
                doc.Close();
            }
        }
    }
}