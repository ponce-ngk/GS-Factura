using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using GS_Factura.Clases;

namespace GS_Factura
{
    internal class AccesoDatos
    {
        private static SqlConnection conexion;
        private SqlDataAdapter oDA;
        private DataSet oDS;
        private SqlCommand ocom;
        //private static string cadenaConexion = "Server = . ;Database= FACTURAS ; User Id = sa ; Password = 1234;";
        private static string cadenaConexion = "Data Source=(local);Initial Catalog=FACTURAS;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";

        public AccesoDatos()
        {

        }
        public static SqlConnection AbrirConexion()
        {
            try
            {
                SqlConnection oCon = new SqlConnection(cadenaConexion);
                oCon.Open();
                return oCon;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null; // Devuelve null en caso de error.
            }
        }        
    }        
}
