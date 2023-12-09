using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GS_Factura
{
    internal class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlDataAdapter oDA;
        private DataSet oDS;
        private SqlCommand ocom;
        private static string cadenaConexion = "Server = . ;Database= FACTURAS ; User Id = sa ; Password = 1234;";

        public AccesoDatos()
        {
            // Cadena de conexión a la base de datos

            // Crear objeto SqlConnection
            conexion = new SqlConnection(cadenaConexion);
        }


        public SqlConnection AbrirConexion()
        {
            try
            {
                if (conexion == null)


                if (conexion.State != System.Data.ConnectionState.Open)
                {
                    conexion.Open();
                }

                return true;
                //return conexion;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void CerrarConexion()
        {
            try
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool ejecutarSQL(string Sentencia)
        {
            try
            {
                ocom = new SqlCommand(Sentencia, conexion);
                ocom.ExecuteNonQuery();
                CerrarConexion();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public DataSet retornaRegistros(string Sentencia)
        {
            if (Sentencia.Length > 0)
            {
                try
                {
                    ocom = new SqlCommand(Sentencia, conexion);
                    oDA = new SqlDataAdapter(ocom);
                    oDS = new DataSet();
                    oDA.Fill(oDS, "dtRetorna");
                    CerrarConexion();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    oDS = null;
                }
            }
            return oDS;

        }

    }

}
