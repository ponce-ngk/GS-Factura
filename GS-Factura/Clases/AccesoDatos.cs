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
        public static string ObtenerCadenaConexion()
        {
            return cadenaConexion;
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

        public static DataTable LlenarTablaparaBuscar(string consul)
        {
            DataTable tabla = new DataTable();
            try
            {
                AbrirConexion();
                tabla = new DataTable();
                string consultar = consul;
                SqlCommand comando = new SqlCommand(consultar, AbrirConexion());
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

        public static DataTable LlenarTablaparaBuscarComando(string consulta, SqlParameter[] parametros = null)
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection conexion = AbrirConexion())
                {
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        if (parametros != null)
                        {
                            comando.Parameters.AddRange(parametros);
                        }

                        SqlDataAdapter data = new SqlDataAdapter(comando);
                        data.Fill(tabla);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return tabla;
        }


        public DataTable RetornaClienteBuscar(string buscar)
        {
            DataTable dt = new DataTable();
            try
            {
                AbrirConexion();
                SqlCommand cmd = new SqlCommand("SELECT IDCLIENTE AS ID, RTRIM(CEDULA) AS Cedula, RTRIM(NOMBRE) AS Nombre, RTRIM(APELLIDOS) AS Apellido, FECHA_NACIMIENTO AS 'Fecha Nacimiento', CASE Estado WHEN 0 THEN 'Eliminado' WHEN 1 THEN 'Activo' END AS Estado FROM CLIENTE WHERE (CEDULA like '" + buscar + "%' or NOMBRE LIKE('" + buscar + "%') OR APELLIDOS LIKE '" + buscar + "%') AND Estado = 1;", AbrirConexion());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch (Exception sms)
            {
                MessageBox.Show(sms.Message);
                return dt;
            }
        }

        public static DataTable RetornaRegistros(string Sentencia)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection oCon = AbrirConexion(); // Utiliza el método AbrirConexion para obtener la conexión.
                SqlCommand ocom = new SqlCommand(Sentencia, oCon);
                SqlDataAdapter oDA = new SqlDataAdapter(ocom);
                oDA.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                dt = null;
            }

            return dt;
        }

        
    }
        
}
