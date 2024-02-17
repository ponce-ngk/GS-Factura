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
        AccesoDatos Datos = new AccesoDatos();
        private void GS_Factura_Load(object sender, EventArgs e)
        {
            int maxIdVenta = ObtenerMaxIdVenta();



            try
            {
                string consulta = "Select  F.IDFACTURA, c.CEDULA, C.NOMBRE, C.APELLIDOS, " +
                    "F.FECHA, DF.IDPRODUCTO, DF.CANTIDAD,\r\nP.PRODUCTO, P.PRECIO_UNITARIO, " +
                    "DF.SUBTOTAL, F.SUBTOTAL, F.TOTAL from FACTURA \r\nas " +
                    "F inner join DETALLE_FACTURA as DF on " +
                    "F.IDFACTURA = DF.IDFACTURA\r\ninner join CLIENTE as C on " +
                    "f.IDCLIENTE = c.IDCLIENTE\r\ninner join PRODUCTO as P on" +
                    " DF.IDPRODUCTO = P.IDPRODUCTO\r\nwhere f.IDFACTURA = "+maxIdVenta+ ""; // Reemplaza TU_TABLA con el nombre de tu tabla
                DataTable datos = AccesoDatos.RetornaRegistros(consulta);

                // Configurar el informe
                reporteFactura.LocalReport.ReportPath = "factura.rdlc"; // Asegúrate de que coincida con el nombre de tu informe
                ReportDataSource dataSource = new ReportDataSource("DataSet1", datos); // Reemplaza "DataSet1" con el nombre de tu conjunto de datos en el informe
                reporteFactura.LocalReport.DataSources.Add(dataSource);

                // Actualizar el informe
                reporteFactura.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int ObtenerMaxIdVenta()
        {
            int maxIdVenta = 0;

            try
            {
                using (SqlConnection conexion = AccesoDatos.AbrirConexion())
                {
                    string consulta = "SELECT MAX(IDFACTURA) FROM FACTURA";
                    SqlCommand cmd = new SqlCommand(consulta, conexion);

                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null && resultado != DBNull.Value)
                    {
                        maxIdVenta = Convert.ToInt32(resultado);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el máximo id_venta: " + ex.Message);
            }

            return maxIdVenta;
        }
    }
}
