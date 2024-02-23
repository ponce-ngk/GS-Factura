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
    public partial class GS_BuscaFactura : Form
    {
        public GS_BuscaFactura()
        {
            InitializeComponent();
        }

        private void GS_BuscaFactura_Load(object sender, EventArgs e)
        {

            this.rptFacturaBuscar.RefreshReport();
        }

        private void Btn_busca_factura_Click(object sender, EventArgs e)
        {
            rptFacturaBuscar.LocalReport.DataSources.Clear();

            try
            {
                bool facturaExiste = VerificarExistenciaFactura(int.Parse(txtcedulaCliente.Text));

                if (facturaExiste)
                {


                    string consulta = "Select  F.IDFACTURA, c.CEDULA, C.NOMBRE, C.APELLIDOS, " +
                    "F.FECHA, DF.IDPRODUCTO, DF.CANTIDAD,\r\nP.PRODUCTO, P.PRECIO_UNITARIO, " +
                    "DF.SUBTOTAL, F.SUBTOTAL, F.TOTAL from FACTURA \r\nas " +
                    "F inner join DETALLE_FACTURA as DF on " +
                    "F.IDFACTURA = DF.IDFACTURA\r\ninner join CLIENTE as C on " +
                    "f.IDCLIENTE = c.IDCLIENTE\r\ninner join PRODUCTO as P on" +
                    " DF.IDPRODUCTO = P.IDPRODUCTO\r\nwhere f.IDFACTURA = " + txtcedulaCliente.Text + ""; // Reemplaza TU_TABLA con el nombre de tu tabla
                    DataTable datos = AccesoDatos.RetornaRegistros(consulta);

                    // Configurar el informe
                    rptFacturaBuscar.LocalReport.ReportPath = "factura.rdlc"; // Asegúrate de que coincida con el nombre de tu informe
                    ReportDataSource dataSource = new ReportDataSource("DataSet1", datos); // Reemplaza "DataSet1" con el nombre de tu conjunto de datos en el informe
                    rptFacturaBuscar.LocalReport.DataSources.Add(dataSource);

                    // Actualizar el informe
                    rptFacturaBuscar.RefreshReport();

                }
                else
                {
                    rptFacturaBuscar.LocalReport.DataSources.Clear();
                    rptFacturaBuscar.RefreshReport();
                    rptFacturaBuscar.LocalReport.ReportPath = "FacturaInexistente.rdlc";
                    MessageBox.Show("La factura no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool VerificarExistenciaFactura(int idFactura)
        {
            try
            {
                // Realizar una consulta para verificar si la factura existe
                DataTable resultado = AccesoDatos.RetornaRegistros($"SELECT COUNT(*) FROM FACTURA WHERE IDFACTURA = {idFactura}");

                // Obtener el resultado de la consulta
                int count = Convert.ToInt32(resultado.Rows[0][0]);

                // Devolver true si existe al menos una fila, false si no existe ninguna
                return count > 0;
            }
            catch { return false; } 
            
        }
    }
}
