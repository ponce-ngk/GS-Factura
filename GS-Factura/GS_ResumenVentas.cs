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

namespace GS_Factura
{
    public partial class GS_ResumenVentas : Form
    {
        public GS_ResumenVentas()
        {
            InitializeComponent();
            cbxNombre.Text = "Desabilitado";
            cbxNombre.ForeColor = Color.Red;
            cbxProducto.Text = "Desabilitado";
            cbxProducto.ForeColor = Color.Red;
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
            }
            else
            {
                // Habilitar el TextBox si el CheckBox está desmarcado
                txtCliente.Enabled = false;
                cbxNombre.Text = "Desabilitado";
                cbxNombre.ForeColor = Color.Red;
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
            }
            else
            {
                // Habilitar el TextBox si el CheckBox está desmarcado
                txtProducto.Enabled = false;
                cbxProducto.Text = "Desabilitado";
                cbxProducto.ForeColor = Color.Red;
            }
        }
    }
}
