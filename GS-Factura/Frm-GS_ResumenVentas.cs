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
    public partial class GS_ResumenVentas : Form
    {
        AccesoDatos OAD = new AccesoDatos();
        List<SqlParameter> par = new List<SqlParameter>();
        int opClientes, opProductos;
        DataTable tb = new DataTable();
        string sql = "";

        public GS_ResumenVentas()
        {
            InitializeComponent();
            cbxNombre.Text = "Desabilitado";
            cbxNombre.ForeColor = Color.Red;
            cbxProducto.Text = "Desabilitado";
            cbxProducto.ForeColor = Color.Red;
            cmbitemsClientes.Enabled = false;
            cmbitemsProductos.Enabled = false;
        }
        private void ExportToExcel(DataGridView dataGridView)
        {
            try
            {
                if (dataGridView.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook workbook = excelApp.Workbooks.Add();
                Excel.Worksheet worksheet = workbook.Sheets[1];
                Excel.Range titleRange = worksheet.Cells[1, 1] as Excel.Range;
                titleRange.Value = "Resumen de informe de venta";
                titleRange.Font.Size = 35;
                titleRange.Font.Bold = true;
                titleRange.EntireRow.AutoFit();

                // Copiar datos del DataGridView a Excel
                for (int i = 0; i < dataGridView.ColumnCount; i++)
                {
                    worksheet.Cells[4, i + 1] = dataGridView.Columns[i].HeaderText;
                    Excel.Range cellRange = worksheet.Cells[4, i + 1] as Excel.Range;
                    cellRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    cellRange.Borders.Weight = Excel.XlBorderWeight.xlThin;
                }
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 5, j + 1] = dataGridView.Rows[i].Cells[j].Value;
                        Excel.Range cellRange = worksheet.Cells[i + 5, j + 1] as Excel.Range;
                        cellRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        cellRange.Borders.Weight = Excel.XlBorderWeight.xlThin;
                    }
                }
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx|All Files (*.*)|*.*";
                saveFileDialog.Title = "Guardar archivo Excel";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    SaveExcelFile(saveFileDialog.FileName, workbook);
                }
                releaseObject(worksheet);
                releaseObject(workbook);
                releaseObject(excelApp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        // Método para liberar los objetos COM de Excel
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
        private void ExportarPDF()
        {
            if (dgvResumenVenta.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            BaseFont fuente = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1250, true);
            iTextSharp.text.Font fontTitle = new iTextSharp.text.Font(fuente, 30f, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            Document doc = new Document(PageSize.A4.Rotate());
            doc.SetMargins(1.27f, 1.27f, 1.27f, 1.27f);
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                    doc.Open();
                    Paragraph header = new Paragraph("Resumen de informe de venta", fontTitle);
                    header.Alignment = Element.ALIGN_CENTER;
                    doc.Add(header);
                    doc.Add(new Paragraph("\n"));
                    doc.Add(new Paragraph("\n"));
                    doc.Add(new Paragraph("\n"));
                    PdfPTable table = new PdfPTable(dgvResumenVenta.Columns.Count);
                    for (int i = 0; i < dgvResumenVenta.Columns.Count; i++)
                    {
                        table.AddCell(new Phrase(dgvResumenVenta.Columns[i].HeaderText));
                    }
                    for (int i = 0; i < dgvResumenVenta.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvResumenVenta.Columns.Count; j++)
                        {
                            if (dgvResumenVenta[j, i].Value != null)
                            {
                                table.AddCell(new Phrase(dgvResumenVenta[j, i].Value.ToString()));
                            }
                        }
                    }
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
        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            ExportarPDF();
        }
        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel(dgvResumenVenta);
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
        private void cbxNombre_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxNombre.Checked)
            {
                txtCliente.Enabled = true;
                cbxNombre.Text = "Habilitado";
                cbxNombre.ForeColor = Color.Green;
                cmbitemsClientes.Enabled = true;
            }
            else
            {
                txtCliente.Enabled = false;
                cbxNombre.Text = "Desabilitado";
                cbxNombre.ForeColor = Color.Red;
                cmbitemsClientes.Enabled = false;
                txtCliente.Text = "";
                cmbitemsClientes.SelectedIndex = -1;
            }
        }
        private void cbxProducto_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxProducto.Checked)
            {
                txtProducto.Enabled = true;
                cbxProducto.Text = "Habilitado";
                cbxProducto.ForeColor = Color.Green;
                cmbitemsProductos.Enabled = true;
            }
            else
            {
                txtProducto.Enabled = false;
                cbxProducto.Text = "Desabilitado";
                cbxProducto.ForeColor = Color.Red;
                cmbitemsProductos.Enabled = false;
                txtProducto.Text = "";
                cmbitemsProductos.SelectedIndex = -1;
            }
        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                tb.Clear();
                par.Clear();
                par.Add(new SqlParameter("@Fecha_Inicio", dateTimePicker1.Text.Trim()));
                par.Add(new SqlParameter("@Fecha_Fin", dateTimePicker2.Text.Trim()));
                tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechas ", par, true);
                dgvResumenVenta.DataSource = tb;
                if (tb.Rows.Count == 0)
                {
                    MessageBox.Show("Reporte no Encontrado en ese rango de fechas. \n\nSe sugiere verificar el rango de fechas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        private void txtCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //Validacion de que sea solo letras y espacio 
                if (!(char.IsLetter(e.KeyChar) || e.KeyChar == ' ' || char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
                {
                    //CheckBox que indica que va a buscar solo por el lado del cliente
                    if (cbxNombre.Checked == true && cbxProducto.Checked == false)
                    {
                        //MessageBox.Show("chebox 1 Cliente ");
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
                                    tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasCliente ", par, true);
                                    dgvResumenVenta.DataSource = tb;
                                    if (tb.Rows.Count == 0)
                                    {
                                        MessageBox.Show("No se encontro reporte. \n\nSe sugiere al Usuario verificar el dato del cliente e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    tb = OAD.EscalarProcAlmTablaSinPar("sp_ResumenVentasVacio ", true);
                                    dgvResumenVenta.DataSource = tb;
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
                                    tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasCliente ", par, true);
                                    dgvResumenVenta.DataSource = tb;
                                    if (tb.Rows.Count == 0)
                                    {
                                        MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar el dato del cliente e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    tb = OAD.EscalarProcAlmTablaSinPar("sp_ResumenVentasVacio ", true);
                                    dgvResumenVenta.DataSource = tb;
                                    MessageBox.Show("Por favor ingregse al menos un carácter");
                                }
                            }
                        }
                    }
                    //CheckBox que indica que va a buscar solo por el lado del producto
                    else if (cbxNombre.Checked == false && cbxProducto.Checked == true)
                    {
                        if (txtProducto.Text != null)
                        {
                            if (opProductos == 0)
                            {
                                if (txtProducto.TextLength != 0 || cmbitemsProductos.SelectedIndex == -1)
                                {
                                    e.Handled = true;
                                    tb.Clear();
                                    par.Clear();
                                    par.Add(new SqlParameter("@Fecha_Inicio", dateTimePicker1.Text.Trim()));
                                    par.Add(new SqlParameter("@Fecha_Fin", dateTimePicker2.Text.Trim()));
                                    par.Add(new SqlParameter("@Campo", "IDPRODUCTO"));
                                    par.Add(new SqlParameter("@Valor", txtProducto.Text.Trim()));
                                    tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasProductoS", par, true);
                                    dgvResumenVenta.DataSource = tb;
                                    if (tb.Rows.Count == 0)
                                    {
                                        MessageBox.Show("No se encontro reporte. \n\nSe sugiere al Usuario verificar el dato del cliente e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    tb = OAD.EscalarProcAlmTablaSinPar("sp_ResumenVentasVacio", true);
                                    dgvResumenVenta.DataSource = tb;
                                    MessageBox.Show("Por favor ingregse al menos un carácter");
                                }
                            }
                            else if (opProductos == 1)
                            {
                                if (txtProducto.TextLength != 0 || cmbitemsProductos.SelectedIndex == -1)
                                {
                                    e.Handled = true;
                                    tb.Clear();
                                    par.Clear();
                                    par.Add(new SqlParameter("@Fecha_Inicio", dateTimePicker1.Text.Trim()));
                                    par.Add(new SqlParameter("@Fecha_Fin", dateTimePicker2.Text.Trim()));
                                    par.Add(new SqlParameter("@Campo", "PRODUCTO"));
                                    par.Add(new SqlParameter("@Valor", txtProducto.Text.Trim()));
                                    tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasProductoS", par, true);
                                    dgvResumenVenta.DataSource = tb;
                                    if (tb.Rows.Count == 0)
                                    {
                                        MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar el dato del cliente e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    tb = OAD.EscalarProcAlmTablaSinPar("sp_ResumenVentasVacio", true);
                                    dgvResumenVenta.DataSource = tb;
                                    MessageBox.Show("Por favor ingregse al menos un carácter");
                                }
                            }
                        }
                    }
                    //CheckBox que indica que va a buscar por el lado del cliente y producto
                    else if (cbxNombre.Checked == true && cbxProducto.Checked == true)
                    {
                        //MessageBox.Show(" los 2 chebox estan habilitado ");
                        if (txtProducto.Text != null)
                        {
                            if (opProductos == 0 && opClientes == 0)
                            {
                                if (txtProducto.TextLength != 0 || cmbitemsClientes.SelectedIndex == -1 && cmbitemsProductos.SelectedIndex == -1)
                                {
                                    e.Handled = true;
                                    tb.Clear();
                                    par.Clear();
                                    par.Add(new SqlParameter("@Fecha_Inicio", dateTimePicker1.Text.Trim()));
                                    par.Add(new SqlParameter("@Fecha_Fin", dateTimePicker2.Text.Trim()));
                                    par.Add(new SqlParameter("@Campo", "CEDULA"));
                                    par.Add(new SqlParameter("@Campo2", "IDPRODUCTO"));
                                    par.Add(new SqlParameter("@Valor2", txtProducto.Text.Trim()));
                                    par.Add(new SqlParameter("@Valor", txtCliente.Text.Trim()));
                                    tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasClienteProducto", par, true);
                                    dgvResumenVenta.DataSource = tb;
                                    if (tb.Rows.Count == 0)
                                    {
                                        MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar los dato proporcionados e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    tb = OAD.EscalarProcAlmTablaSinPar("sp_ResumenVentasVacio ", true);
                                    dgvResumenVenta.DataSource = tb;
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
                                    par.Add(new SqlParameter("@Campo", "NOMBRE"));
                                    par.Add(new SqlParameter("@Campo2", "IDPRODUCTO"));
                                    par.Add(new SqlParameter("@Valor2", txtProducto.Text.Trim()));
                                    par.Add(new SqlParameter("@Valor", txtCliente.Text.Trim()));
                                    tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasClienteProducto", par, true);
                                    dgvResumenVenta.DataSource = tb;
                                    if (tb.Rows.Count == 0)
                                    {
                                        MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar los dato proporcionados e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    tb = OAD.EscalarProcAlmTablaSinPar("sp_ResumenVentasVacio", true);
                                    dgvResumenVenta.DataSource = tb;
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
                                    par.Add(new SqlParameter("@Campo", "CEDULA"));
                                    par.Add(new SqlParameter("@Campo2", "PRODUCTO"));
                                    par.Add(new SqlParameter("@Valor2", txtProducto.Text.Trim()));
                                    par.Add(new SqlParameter("@Valor", txtCliente.Text.Trim()));
                                    tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasClienteProducto", par, true);
                                    dgvResumenVenta.DataSource = tb;
                                    if (tb.Rows.Count == 0)
                                    {
                                        MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar los dato proporcionados e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    tb = OAD.EscalarProcAlmTablaSinPar("sp_ResumenVentasVacio", true);
                                    dgvResumenVenta.DataSource = tb;
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
                                    par.Add(new SqlParameter("@Campo", "NOMBRE"));
                                    par.Add(new SqlParameter("@Campo2", "PRODUCTO"));
                                    par.Add(new SqlParameter("@Valor2", txtProducto.Text.Trim()));
                                    par.Add(new SqlParameter("@Valor", txtCliente.Text.Trim()));
                                    tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasClienteProducto", par, true);
                                    dgvResumenVenta.DataSource = tb;
                                    if (tb.Rows.Count == 0)
                                    {
                                        MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar los dato proporcionados e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    tb = OAD.EscalarProcAlmTablaSinPar("sp_ResumenVentasVacio", true);
                                    dgvResumenVenta.DataSource = tb;
                                    MessageBox.Show("Por favor ingregse al menos un carácter");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Seleccione al menos un campo");
                        }
                    }
                }
                else if (opClientes == null && txtCliente.Text == null)
                {
                    MessageBox.Show("No se Permite el ingreso de  caracteres especiales");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        private void cmbitemsProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        private void txtProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //Validacion de que sea solo letras y espacio 
                if (!(char.IsLetter(e.KeyChar) || e.KeyChar == ' ' || char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
                {
                    if (cbxNombre.Checked == true && cbxProducto.Checked == false)
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
                                    tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasCliente ", par, true);
                                    dgvResumenVenta.DataSource = tb;
                                    if (tb.Rows.Count == 0)
                                    {
                                        MessageBox.Show("No se encontro reporte. \n\nSe sugiere al Usuario verificar el dato del cliente e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    tb = OAD.EscalarProcAlmTablaSinPar("sp_ResumenVentasVacio ", true);
                                    dgvResumenVenta.DataSource = tb;
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
                                    tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasCliente ", par, true);
                                    dgvResumenVenta.DataSource = tb;
                                    if (tb.Rows.Count == 0)
                                    {
                                        MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar el dato del cliente e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    tb = OAD.EscalarProcAlmTablaSinPar("sp_ResumenVentasVacio ", true);
                                    dgvResumenVenta.DataSource = tb;
                                    MessageBox.Show("Por favor ingregse al menos un carácter");
                                }
                            }
                        }
                    }
                    else if (cbxNombre.Checked == false && cbxProducto.Checked == true)
                    {
                        if (txtProducto.Text != null)
                        {
                            if (opProductos == 0)
                            {
                                if (txtProducto.TextLength != 0 || cmbitemsProductos.SelectedIndex == -1)
                                {
                                    e.Handled = true;
                                    tb.Clear();
                                    par.Clear();
                                    par.Add(new SqlParameter("@Fecha_Inicio", dateTimePicker1.Text.Trim()));
                                    par.Add(new SqlParameter("@Fecha_Fin", dateTimePicker2.Text.Trim()));
                                    par.Add(new SqlParameter("@Campo", "IDPRODUCTO"));
                                    par.Add(new SqlParameter("@Valor", txtProducto.Text.Trim()));
                                    tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasProductoS", par, true);
                                    dgvResumenVenta.DataSource = tb;
                                    if (tb.Rows.Count == 0)
                                    {
                                        MessageBox.Show("No se encontro reporte. \n\nSe sugiere al Usuario verificar el dato del cliente e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    tb = OAD.EscalarProcAlmTablaSinPar("sp_ResumenVentasVacio", true);
                                    dgvResumenVenta.DataSource = tb;
                                    MessageBox.Show("Por favor ingregse al menos un carácter");
                                }
                            }
                            else if (opProductos == 1)
                            {
                                if (txtProducto.TextLength != 0 || cmbitemsProductos.SelectedIndex == -1)
                                {
                                    e.Handled = true;
                                    tb.Clear();
                                    par.Clear();
                                    par.Add(new SqlParameter("@Fecha_Inicio", dateTimePicker1.Text.Trim()));
                                    par.Add(new SqlParameter("@Fecha_Fin", dateTimePicker2.Text.Trim()));
                                    par.Add(new SqlParameter("@Campo", "PRODUCTO"));
                                    par.Add(new SqlParameter("@Valor", txtProducto.Text.Trim()));
                                    tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasProductoS", par, true);
                                    dgvResumenVenta.DataSource = tb;
                                    if (tb.Rows.Count == 0)
                                    {
                                        MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar el dato del cliente e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    tb = OAD.EscalarProcAlmTablaSinPar("sp_ResumenVentasVacio", true);
                                    dgvResumenVenta.DataSource = tb;
                                    MessageBox.Show("Por favor ingregse al menos un carácter");
                                }
                            }
                        }
                    }
                    else if (cbxNombre.Checked == true && cbxProducto.Checked == true)
                    {
                        if (txtProducto.Text != null && txtCliente.Text != null)
                        {
                            if (opProductos == 0 && opClientes == 0)
                            {
                                if (txtProducto.TextLength != 0 || cmbitemsClientes.SelectedIndex == -1 && cmbitemsProductos.SelectedIndex == -1)
                                {
                                    e.Handled = true;
                                    tb.Clear();
                                    par.Clear();
                                    par.Add(new SqlParameter("@Fecha_Inicio", dateTimePicker1.Text.Trim()));
                                    par.Add(new SqlParameter("@Fecha_Fin", dateTimePicker2.Text.Trim()));
                                    par.Add(new SqlParameter("@Campo", "CEDULA"));
                                    par.Add(new SqlParameter("@Campo2", "IDPRODUCTO"));
                                    par.Add(new SqlParameter("@Valor2", txtProducto.Text.Trim()));
                                    par.Add(new SqlParameter("@Valor", txtCliente.Text.Trim()));
                                    tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasClienteProducto", par, true);
                                    dgvResumenVenta.DataSource = tb;
                                    if (tb.Rows.Count == 0)
                                    {
                                        MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar los dato proporcionados e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    tb = OAD.EscalarProcAlmTablaSinPar("sp_ResumenVentasVacio ", true);
                                    dgvResumenVenta.DataSource = tb;
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
                                    par.Add(new SqlParameter("@Campo", "NOMBRE"));
                                    par.Add(new SqlParameter("@Campo2", "IDPRODUCTO"));
                                    par.Add(new SqlParameter("@Valor2", txtProducto.Text.Trim()));
                                    par.Add(new SqlParameter("@Valor", txtCliente.Text.Trim()));
                                    tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasClienteProducto", par, true);
                                    dgvResumenVenta.DataSource = tb;
                                    if (tb.Rows.Count == 0)
                                    {
                                        MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar los dato proporcionados e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    tb = OAD.EscalarProcAlmTablaSinPar("sp_ResumenVentasVacio", true);
                                    dgvResumenVenta.DataSource = tb;
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
                                    par.Add(new SqlParameter("@Campo", "CEDULA"));
                                    par.Add(new SqlParameter("@Campo2", "PRODUCTO"));
                                    par.Add(new SqlParameter("@Valor2", txtProducto.Text.Trim()));
                                    par.Add(new SqlParameter("@Valor", txtCliente.Text.Trim()));
                                    tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasClienteProducto", par, true);
                                    dgvResumenVenta.DataSource = tb;
                                    if (tb.Rows.Count == 0)
                                    {
                                        MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar los dato proporcionados e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    tb = OAD.EscalarProcAlmTablaSinPar("sp_ResumenVentasVacio", true);
                                    dgvResumenVenta.DataSource = tb;
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
                                    par.Add(new SqlParameter("@Campo", "NOMBRE"));
                                    par.Add(new SqlParameter("@Campo2", "PRODUCTO"));
                                    par.Add(new SqlParameter("@Valor2", txtProducto.Text.Trim()));
                                    par.Add(new SqlParameter("@Valor", txtCliente.Text.Trim()));
                                    tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasClienteProducto", par, true);
                                    dgvResumenVenta.DataSource = tb;
                                    if (tb.Rows.Count == 0)
                                    {
                                        MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar los dato proporcionados e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    tb = OAD.EscalarProcAlmTablaSinPar("sp_ResumenVentasVacio", true);
                                    dgvResumenVenta.DataSource = tb;
                                    MessageBox.Show("Por favor ingregse al menos un carácter");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Seleccione al menos un campo");
                        }
                    }
                }
                else if (txtProducto.Text == null && txtCliente.Text == null)
                {
                    MessageBox.Show("Por favor ingregse un carácter");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        private void btnBuscarItems_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxNombre.Checked == true && cbxProducto.Checked == false)
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
                                tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasCliente ", par, true);
                                dgvResumenVenta.DataSource = tb;
                                if (tb.Rows.Count == 0)
                                {
                                    //AlertlBoxArtan(Color.LightPink, Color.DarkRed, "Error", "Reporte no encontrado.", Properties.Resources.Error);
                                    MessageBox.Show("No se encontro reporte. \n\nSe sugiere al Usuario verificar el dato del cliente e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                tb = OAD.EscalarProcAlmTablaSinPar("sp_ResumenVentasVacio ", true);
                                dgvResumenVenta.DataSource = tb;
                                //AlertlBoxArtan(Color.LightBlue, Color.DodgerBlue, "Información", "Por favor ingrese al menos un carácter.", Properties.Resources.Information);
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
                                tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasCliente ", par, true);
                                dgvResumenVenta.DataSource = tb;
                                if (tb.Rows.Count == 0)
                                {
                                    //AlertlBoxArtan(Color.LightPink, Color.DarkRed, "Error", "Reporte no encontrado.", Properties.Resources.Error);
                                    MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar el dato del cliente e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                tb = OAD.EscalarProcAlmTablaSinPar("sp_ResumenVentasVacio ", true);
                                dgvResumenVenta.DataSource = tb;
                                //AlertlBoxArtan(Color.LightBlue, Color.DodgerBlue, "Información", "Por favor ingrese al menos un carácter.", Properties.Resources.Information);
                                MessageBox.Show("Por favor ingregse al menos un carácter");
                            }
                        }
                    }
                }
                else if (cbxNombre.Checked == false && cbxProducto.Checked == true)
                {
                    if (txtProducto.Text != null)
                    {
                        if (opProductos == 0)
                        {
                            if (txtProducto.TextLength != 0 || cmbitemsProductos.SelectedIndex == -1)
                            {
                                tb.Clear();
                                par.Clear();
                                par.Add(new SqlParameter("@Fecha_Inicio", dateTimePicker1.Text.Trim()));
                                par.Add(new SqlParameter("@Fecha_Fin", dateTimePicker2.Text.Trim()));
                                par.Add(new SqlParameter("@Campo", "IDPRODUCTO"));
                                par.Add(new SqlParameter("@Valor", txtProducto.Text.Trim()));
                                tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasProductoS", par, true);
                                dgvResumenVenta.DataSource = tb;
                                if (tb.Rows.Count == 0)
                                {
                                    //AlertlBoxArtan(Color.LightPink, Color.DarkRed, "Error", "Reporte no encontrado.", Properties.Resources.Error);
                                    MessageBox.Show("No se encontro reporte. \n\nSe sugiere al Usuario verificar el dato del cliente e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                tb = OAD.EscalarProcAlmTablaSinPar("sp_ResumenVentasVacio", true);
                                dgvResumenVenta.DataSource = tb;
                                //AlertlBoxArtan(Color.LightBlue, Color.DodgerBlue, "Información", "Por favor ingrese al menos un carácter.", Properties.Resources.Information);
                                MessageBox.Show("Por favor ingregse al menos un carácter");
                            }
                        }
                        else if (opProductos == 1)
                        {
                            if (txtProducto.TextLength != 0 || cmbitemsProductos.SelectedIndex == -1)
                            {
                                tb.Clear();
                                par.Clear();
                                par.Add(new SqlParameter("@Fecha_Inicio", dateTimePicker1.Text.Trim()));
                                par.Add(new SqlParameter("@Fecha_Fin", dateTimePicker2.Text.Trim()));
                                par.Add(new SqlParameter("@Campo", "PRODUCTO"));
                                par.Add(new SqlParameter("@Valor", txtProducto.Text.Trim()));
                                tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasProductoS", par, true);
                                dgvResumenVenta.DataSource = tb;
                                if (tb.Rows.Count == 0)
                                {
                                    //AlertlBoxArtan(Color.LightPink, Color.DarkRed, "Error", "Reporte no encontrado.", Properties.Resources.Error);
                                    MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar el dato del cliente e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                tb = OAD.EscalarProcAlmTablaSinPar("sp_ResumenVentasVacio", true);
                                dgvResumenVenta.DataSource = tb;
                                //AlertlBoxArtan(Color.LightBlue, Color.DodgerBlue, "Información", "Por favor ingrese al menos un carácter.", Properties.Resources.Information);
                                MessageBox.Show("Por favor ingregse al menos un carácter");
                            }
                        }
                    }
                }
                else if (cbxNombre.Checked == true && cbxProducto.Checked == true)
                {
                    if (txtProducto.Text != null && txtCliente.Text != null)
                    {
                        if (opProductos == 0 && opClientes == 0)
                        {
                            if (txtProducto.TextLength != 0 || cmbitemsClientes.SelectedIndex == -1 && cmbitemsProductos.SelectedIndex == -1)
                            {
                                tb.Clear();
                                par.Clear();
                                par.Add(new SqlParameter("@Fecha_Inicio", dateTimePicker1.Text.Trim()));
                                par.Add(new SqlParameter("@Fecha_Fin", dateTimePicker2.Text.Trim()));
                                par.Add(new SqlParameter("@Campo", "CEDULA"));
                                par.Add(new SqlParameter("@Campo2", "IDPRODUCTO"));
                                par.Add(new SqlParameter("@Valor2", txtProducto.Text.Trim()));
                                par.Add(new SqlParameter("@Valor", txtCliente.Text.Trim()));
                                tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasClienteProducto", par, true);
                                dgvResumenVenta.DataSource = tb;
                                if (tb.Rows.Count == 0)
                                {
                                    //AlertlBoxArtan(Color.LightPink, Color.DarkRed, "Error", "Reporte no encontrado.", Properties.Resources.Error);
                                    MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar los dato proporcionados e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                tb = OAD.EscalarProcAlmTablaSinPar("sp_ResumenVentasVacio ", true);
                                dgvResumenVenta.DataSource = tb;
                                //AlertlBoxArtan(Color.LightBlue, Color.DodgerBlue, "Información", "Por favor ingrese al menos un carácter.", Properties.Resources.Information);
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
                                par.Add(new SqlParameter("@Campo", "NOMBRE"));
                                par.Add(new SqlParameter("@Campo2", "IDPRODUCTO"));
                                par.Add(new SqlParameter("@Valor2", txtProducto.Text.Trim()));
                                par.Add(new SqlParameter("@Valor", txtCliente.Text.Trim()));
                                tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasClienteProducto", par, true);
                                dgvResumenVenta.DataSource = tb;
                                if (tb.Rows.Count == 0)
                                {
                                    //AlertlBoxArtan(Color.LightPink, Color.DarkRed, "Error", "Reporte no encontrado.", Properties.Resources.Error);
                                    MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar los dato proporcionados e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                tb = OAD.EscalarProcAlmTablaSinPar("sp_ResumenVentasVacio", true);
                                dgvResumenVenta.DataSource = tb;
                                //AlertlBoxArtan(Color.LightBlue, Color.DodgerBlue, "Información", "Por favor ingrese al menos un carácter.", Properties.Resources.Information);
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
                                par.Add(new SqlParameter("@Campo", "CEDULA"));
                                par.Add(new SqlParameter("@Campo2", "PRODUCTO"));
                                par.Add(new SqlParameter("@Valor2", txtProducto.Text.Trim()));
                                par.Add(new SqlParameter("@Valor", txtCliente.Text.Trim()));
                                tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasClienteProducto", par, true);
                                dgvResumenVenta.DataSource = tb;
                                if (tb.Rows.Count == 0)
                                {
                                    //AlertlBoxArtan(Color.LightPink, Color.DarkRed, "Error", "Reporte no encontrado.", Properties.Resources.Error);
                                    MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar los dato proporcionados e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                tb = OAD.EscalarProcAlmTablaSinPar("sp_ResumenVentasVacio", true);
                                dgvResumenVenta.DataSource = tb;
                                //AlertlBoxArtan(Color.LightBlue, Color.DodgerBlue, "Información", "Por favor ingrese al menos un carácter.", Properties.Resources.Information);
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
                                par.Add(new SqlParameter("@Campo", "NOMBRE"));
                                par.Add(new SqlParameter("@Campo2", "PRODUCTO"));
                                par.Add(new SqlParameter("@Valor2", txtProducto.Text.Trim()));
                                par.Add(new SqlParameter("@Valor", txtCliente.Text.Trim()));
                                tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasClienteProducto", par, true);
                                dgvResumenVenta.DataSource = tb;
                                if (tb.Rows.Count == 0)
                                {
                                    //AlertlBoxArtan(Color.LightPink, Color.DarkRed, "Error", "Reporte no encontrado.", Properties.Resources.Error);
                                    MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar los dato proporcionados e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                tb = OAD.EscalarProcAlmTablaSinPar("sp_ResumenVentasVacio", true);
                                dgvResumenVenta.DataSource = tb;
                                //AlertlBoxArtan(Color.LightBlue, Color.DodgerBlue, "Información", "Por favor ingrese al menos un carácter.", Properties.Resources.Information);
                                MessageBox.Show("Por favor ingregse al menos un carácter");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Seleccione al menos un campo");
                    }
                }
                else if (cbxNombre.Checked == false && cbxProducto.Checked == false)
                {
                    try
                    {
                        tb.Clear();
                        par.Clear();
                        par.Add(new SqlParameter("@Fecha_Inicio", dateTimePicker1.Text.Trim()));
                        par.Add(new SqlParameter("@Fecha_Fin", dateTimePicker2.Text.Trim()));
                        tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechas ", par, true);
                        dgvResumenVenta.DataSource = tb;
                        if (tb.Rows.Count == 0)
                        {
                            MessageBox.Show("Reporte no Encontrado en ese rango de fechas. \n\nSe sugiere verificar el rango de fechas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        private void btnInstrucciones_Click(object sender, EventArgs e)
        {
            try
            {
                GS_Informacion FormInformacion = new GS_Informacion();
                FormInformacion.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        private void cmbitemsClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
    }
}