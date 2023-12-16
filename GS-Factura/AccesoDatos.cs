using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace GS_Factura
{
    internal class AccesoDatos
    {
        private static SqlConnection conexion;
        private SqlDataAdapter oDA;
        private DataSet oDS;
        private SqlCommand ocom;
        private static string cadenaConexion = "Server = . ;Database= FACTURAS ; User Id = sa ; Password = 1234;";

        public AccesoDatos()
        {
            // Cadena de conexión a la base de datos

            // Crear objeto SqlConnection
        }


        //public static SqlConnection abrirConexion()
        //{
        //    string cadena = string.Format(cadenaConexion);
        //    SqlConnection oCon = new SqlConnection(cadena);
        //    oCon.Open();
        //    return oCon;
        //}


        public static SqlConnection abrirConexion()
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

        public static void CerrarConexion(SqlConnection conexion)
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
                using (SqlConnection conexion = abrirConexion())
                {
                    using (SqlCommand ocom = new SqlCommand(Sentencia, conexion))
                    {
                        ocom.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar la consulta: " + ex.Message);
                return false;
            }
        }

        public DataSet retornaRegistros(string Sentencia)
        {
            DataSet oDS = new DataSet();

            if (Sentencia.Length > 0)
            {
                try
                {
                    using (SqlConnection conexion = abrirConexion())
                    {
                        using (SqlCommand ocom = new SqlCommand(Sentencia, conexion))
                        {
                            using (SqlDataAdapter oDA = new SqlDataAdapter(ocom))
                            {
                                oDA.Fill(oDS, "dtRetorna");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al ejecutar la consulta: " + ex.Message);
                    oDS = null;
                }
            }

            return oDS;
        }


        public static DataTable llenartablaparabuscar(string consul)
        {
            DataTable tabla = new DataTable();
            try
            {
                abrirConexion();
                tabla = new DataTable();
                string consultar = consul;
                SqlCommand comando = new SqlCommand(consultar, abrirConexion());
                SqlDataAdapter data = new SqlDataAdapter(comando);
                data.Fill(tabla);
                return tabla;
            }
            catch (Exception sms1)
            {
                MessageBox.Show(sms1.Message);
                return tabla;
            }
        }

    }

}
