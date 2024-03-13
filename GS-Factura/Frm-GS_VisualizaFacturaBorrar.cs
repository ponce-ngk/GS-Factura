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

namespace GS_Factura
{
    public partial class VisualizaFacturaBorrar : Form
    {
        private int idFactura;

        // Constructor que acepta el ID de la factura
        public VisualizaFacturaBorrar(int idFactura)
        {
            InitializeComponent();
            this.idFactura = idFactura; // Guarda el ID de la factura para usarlo en el evento Load
        }

        private void VisualizaFacturaBorrar_Load(object sender, EventArgs e)
        {
            try
            {
                // Obtener el ID máximo de la factura
                BD2 bd2 = new BD2();
                int maxIdVenta = idFactura;

                // Verificar si se obtuvo correctamente el ID máximo
                if (maxIdVenta > 0)
                {
                    // Llamar al procedimiento almacenado para obtener los datos de la factura
                    List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@IDFactura", maxIdVenta)
            };

                    DataTable datos = bd2.EscalarProcAlmTabla("sp_ObtenerDatosFacturaPorID", parametros, false);

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
        
    }
}
