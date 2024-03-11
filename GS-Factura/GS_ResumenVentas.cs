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
        BD2 OAD = new BD2();
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
            // Crear una instancia de Excel
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.Sheets[1];

            // Copiar datos del DataGridView a Excel
            for (int i = 0; i < dataGridView.ColumnCount; i++)
            {
                worksheet.Cells[1, i + 1] = dataGridView.Columns[i].HeaderText;
            }
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataGridView.Rows[i].Cells[j].Value;
                }
            }

            // Crear un cuadro de diálogo para seleccionar la ubicación del archivo
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx|All Files (*.*)|*.*";
            saveFileDialog.Title = "Guardar archivo Excel";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Guardar el archivo Excel en la ubicación seleccionada
                workbook.SaveAs(saveFileDialog.FileName);

                // Mostrar mensaje de éxito
                MessageBox.Show("El archivo Excel se ha creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Liberar recursos
            workbook.Close(false);
            excelApp.Quit();
            releaseObject(worksheet);
            releaseObject(workbook);
            releaseObject(excelApp);
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
            // Crear un documento PDF
            Document doc = new Document(PageSize.A4);
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
                    PdfPTable table = new PdfPTable(dgvResumenVenta.Columns.Count);
                    for (int i = 0; i < dgvResumenVenta.Columns.Count; i++)
                    {
                        table.AddCell(new Phrase(dgvResumenVenta.Columns[i].HeaderText));
                    }

                    // Agregar filas
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

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            ExportarPDF();
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel(dgvResumenVenta);
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

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
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
                            //dgvResumenVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_ResumenVentasVacio");
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
                            //dgvResumenVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_ResumenVentasVacio");
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
                            tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasClienteProducto ", par, true);
                            dgvResumenVenta.DataSource = tb;
                            if (tb.Rows.Count == 0)
                            {
                                MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar el dato del producto e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            tb = OAD.EscalarProcAlmTablaSinPar("sp_ResumenVentasVacio ", true);
                            dgvResumenVenta.DataSource = tb;
                            //dgvResumenVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_ResumenVentasVacio");
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
                            tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasClienteProducto ", par, true);
                            dgvResumenVenta.DataSource = tb;
                            if (tb.Rows.Count == 0)
                            {
                                MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar el dato del producto e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            tb = OAD.EscalarProcAlmTablaSinPar("sp_ResumenVentasVacio ", true);
                            dgvResumenVenta.DataSource = tb;
                            //dgvResumenVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_ResumenVentasVacio");
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
                            tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasClienteProducto ", par, true);
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
                            //dgvResumenVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_ResumenVentasVacio");
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
                            tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasClienteProducto ", par, true);
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
                            //dgvResumenVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_ResumenVentasVacio");
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
                            tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasProductoS ", par, true);
                            dgvResumenVenta.DataSource = tb;
                        }
                        else
                        {
                            tb = OAD.EscalarProcAlmTablaSinPar("sp_ResumenVentasVacio ", true);
                            dgvResumenVenta.DataSource = tb;
                            //dgvResumenVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_ResumenVentasVacio");
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
                            tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasProductoS ", par, true);
                            dgvResumenVenta.DataSource = tb;
                        }
                        else
                        {
                            tb = OAD.EscalarProcAlmTablaSinPar("sp_ResumenVentasVacio ", true);
                            dgvResumenVenta.DataSource = tb;
                            //dgvResumenVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_ResumenVentasVacio");
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
                            tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasClienteProducto ", par, true);
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
                            //dgvResumenVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_ResumenVentasVacio");
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
                            tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasClienteProducto ", par, true);
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
                            //dgvResumenVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_ResumenVentasVacio");
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
                            tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasClienteProducto ", par, true);
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
                            //dgvResumenVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_ResumenVentasVacio");
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
                            tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasClienteProducto ", par, true);
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
                            //dgvResumenVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_ResumenVentasVacio");
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
                        tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasCliente ", par, true);
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
                        //dgvResumenVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_ResumenVentasVacio");
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
                            MessageBox.Show("Reporte no encontrado. \n\nSe sugiere al Usuario verificar los dato proporcionados e intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        tb = OAD.EscalarProcAlmTablaSinPar("sp_ResumenVentasVacio ", true);
                        dgvResumenVenta.DataSource = tb;
                        //dgvResumenVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_ResumenVentasVacio");
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
                        tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasProductoS ", par, true);
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
                        //dgvResumenVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_ResumenVentasVacio");
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
                        tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasProductoS ", par, true);
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
                        //dgvResumenVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_ResumenVentasVacio");
                        MessageBox.Show("Por favor ingregse al menos un carácter");
                    }
                }
            }
            else if(txtCliente.Text != null || txtProducto.Text != null)
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
                        tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasClienteProducto ", par, true);
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
                        //dgvResumenVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_ResumenVentasVacio");
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
                        tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasClienteProducto ", par, true);
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
                        //dgvResumenVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_ResumenVentasVacio");
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
                        tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasClienteProducto ", par, true);
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
                        //dgvResumenVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_ResumenVentasVacio");
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
                        tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasClienteProducto ", par, true);
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
                        //dgvResumenVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_ResumenVentasVacio");
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
                        tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasClienteProducto ", par, true);
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
                        //dgvResumenVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_ResumenVentasVacio");
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
                        tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasClienteProducto ", par, true);
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
                        //dgvResumenVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_ResumenVentasVacio");
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
                        tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasClienteProducto ", par, true);
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
                        //dgvResumenVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_ResumenVentasVacio");
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
                        tb = OAD.EscalarProcAlmTabla("sp_ResumenVentasFechasClienteProducto ", par, true);
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
                        //dgvResumenVenta.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_ResumenVentasVacio");
                        MessageBox.Show("Por favor ingregse al menos un carácter");
                    }
                }
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
    }
}
