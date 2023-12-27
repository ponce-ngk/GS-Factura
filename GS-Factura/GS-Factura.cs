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

        AccesoDatos conexion_sql = new AccesoDatos();
        DataSet oDS = new DataSet();
        private void GS_Factura_Load(object sender, EventArgs e)
        {
            SqlConnection conexion = null;

            try
            {
                // Llamar al método de tu clase AccesoDatos para realizar la consulta
                conexion = AccesoDatos.abrirConexion();

                string consulta = "SELECT MAX(IDFACTURA) FROM FACTURA";
                SqlCommand cmd = new SqlCommand(consulta, conexion);

                // Ejecutar la consulta y obtener el resultado
                object resultado = cmd.ExecuteScalar();

                // Verificar si el resultado no es nulo
                if (resultado != null && resultado != DBNull.Value)
                {
                    // Convertir el resultado a un tipo adecuado (int en este caso)
                    int maxIdVenta = Convert.ToInt32(resultado);

                }
                else
                {
                    // El resultado fue nulo o DBNull.Value
                    MessageBox.Show("No se encontraron registros en la tabla 'venta'.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el máximo id_venta: " + ex.Message);
            }
            finally
            {
                // Asegurarse de cerrar la conexión después de usarla
                if (conexion != null)
                {
                    AccesoDatos.CerrarConexion(conexion);
                }
            }
        }


        public void cargarReporte(string cadena)
        {
            try
            {
                conexion_sql.AbrirConexion1();

                ReportDataSource dataset = new ReportDataSource();
                reporteFactura.LocalReport.DataSources.Clear();
                oDS = conexion_sql.retornaRegistros(cadena);

                this.reporteFactura.RefreshReport();
                reporteFactura.LocalReport.ReportEmbeddedResource = "Factura.rdlc";
                try
                {
                    dataset = new ReportDataSource("DataSet1", oDS.Tables[0]);
                }
                catch
                {
                    MessageBox.Show("Error al generar reporte");
                    conexion_sql.CerrarConexion1();
                }
                reporteFactura.LocalReport.DataSources.Add(dataset);
                reporteFactura.LocalReport.Refresh();
                reporteFactura.RefreshReport();
                conexion_sql.CerrarConexion1();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
                conexion_sql.CerrarConexion1();
            }
        }
    }
}
