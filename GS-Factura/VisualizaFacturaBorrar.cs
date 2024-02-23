using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
                // Utiliza el ID de la factura almacenado en la variable de instancia
                string consulta = "SELECT F.IDFACTURA, c.CEDULA, C.NOMBRE, C.APELLIDOS, " +
                    "F.FECHA, DF.IDPRODUCTO, DF.CANTIDAD, P.PRODUCTO, P.PRECIO_UNITARIO, " +
                    "DF.SUBTOTAL, F.SUBTOTAL, F.TOTAL FROM FACTURA AS F " +
                    "INNER JOIN DETALLE_FACTURA AS DF ON F.IDFACTURA = DF.IDFACTURA " +
                    "INNER JOIN CLIENTE AS C ON F.IDCLIENTE = C.IDCLIENTE " +
                    "INNER JOIN PRODUCTO AS P ON DF.IDPRODUCTO = P.IDPRODUCTO " +
                    "WHERE F.IDFACTURA = " + idFactura;

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
        
    }
}
