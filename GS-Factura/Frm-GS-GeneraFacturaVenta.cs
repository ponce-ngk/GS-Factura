using GS_Factura.Clases;
using Microsoft.Reporting.WinForms;
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
using System.Windows.Media.Media3D;

namespace GS_Factura
{
    public partial class GS_Factura : Form
    {
        public GS_Factura()
        {
            InitializeComponent();
        }

        private void GS_Factura_Load(object sender, EventArgs e)
        {
            try
            {
                // Obtener el ID máximo de la factura
                BD2 bd2 = new BD2();
                int maxIdVenta = bd2.ObtenerMaxIdFactura();

                // Verificar si se obtuvo correctamente el ID máximo
                if (maxIdVenta > 0)
                {
                    // Llamar al procedimiento almacenado para obtener los datos de la factura
                    List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@IDFactura", maxIdVenta)
            };

                    DataTable datos = bd2.EscalarProcAlmTabla("ObtenerDatosFacturaPorID", parametros, false);

                    // Configurar el informe
                    reporteFactura.LocalReport.ReportPath = "factura.rdlc"; // Asegúrate de que coincida con el nombre de tu informe
                    ReportDataSource dataSource = new ReportDataSource("DataSet1", datos); // Reemplaza "DataSet1" con el nombre de tu conjunto de datos en el informe
                    reporteFactura.LocalReport.DataSources.Add(dataSource);

                    // Actualizar el informe
                    reporteFactura.RefreshReport();
                }
                else
                {
                    MessageBox.Show("No se pudo obtener el ID máximo de la factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            // Acceder al formulario actual si ya está creado
            GS_GeneraFactura gS_GeneraFactura = Application.OpenForms.OfType<GS_GeneraFactura>().FirstOrDefault();

            // Verificar si el formulario está abierto antes de intentar acceder a sus controles
            if (gS_GeneraFactura != null)
            {
                // Cambiar las dimensiones de las columnas en el formulario actual
                gS_GeneraFactura.tblVentayFactura.ColumnStyles[0].Width = 99.50f;
                gS_GeneraFactura.tblVentayFactura.ColumnStyles[1].Width = 0.50f;
                this.Close();
            }
        }

        internal class Clases
        {
        }
    }
}
