using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Windows;
using GS_Factura.Clases;
using GS_Factura;
using System.Security.Cryptography.X509Certificates;

namespace GS_Factura.Clases
{
    internal class Cliente
    {
        int idCliente;
        string cedula;
        string nombre;
        string apellido;
        string fechaNA;
        char estado;

        public int IdCliente { get => idCliente; set => idCliente = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string FechaNA { get => fechaNA; set => fechaNA = value; }
        public char Estado { get => estado; set => estado = value; }

        public Cliente() 
        { }

        public Cliente(int idCliente, string cedula, string nombre, string apellido, string fechaNA, char estado)
        {
            this.IdCliente = idCliente;
            this.Cedula = cedula;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.FechaNA = fechaNA;
            Estado = estado;
        }
    }
}

class CrudCliente
{
    public static int AgregarCliente(Cliente pClientes)
    {
        int retorno = 0;
        try
        {
            using (SqlConnection conex = AccesoDatos.AbrirConexion())
            {
                SqlCommand comando = new SqlCommand(string.Format("exec sp_Insertar_CLIENTE '{0}','{1}','{2}','{3}'",
                                pClientes.Cedula, pClientes.Nombre, pClientes.Apellido, pClientes.FechaNA), conex);
                retorno = comando.ExecuteNonQuery();
                conex.Close();

            }
            return retorno;
        }
        catch (Exception sms)
        {
            MessageBox.Show(sms.Message);
            return retorno;
        }
    }

    public static int ActualizarClient(Cliente pClientes)
    {
        int retorno = 0;
        try
        {
            using (SqlConnection conex = AccesoDatos.AbrirConexion())
            {
                SqlCommand comando = new SqlCommand(string.Format("exec sp_actualizar_CLIENTE {0},'{1}','{2}','{3}','{4}'",
                                pClientes.IdCliente,pClientes.Cedula, pClientes.Nombre, pClientes.Apellido, pClientes.FechaNA), conex);
                retorno = comando.ExecuteNonQuery();
                conex.Close();

            }
            return retorno;
        }
        catch (Exception sms)
        {
            MessageBox.Show(sms.Message);
            return retorno;
        }
    }

    public static int EliminarClient(Cliente pClientes)
    {
        int retorno = 0;
        try
        {
            using (SqlConnection conex = AccesoDatos.AbrirConexion())
            {
                SqlCommand comando = new SqlCommand(string.Format("exec sp_eliminar_CLIENTE {0},'{1}'",
                                pClientes.IdCliente, pClientes.Estado), conex);
                retorno = comando.ExecuteNonQuery();
                conex.Close();

            }
            return retorno;
        }
        catch (Exception sms)
        {
            MessageBox.Show(sms.Message);
            return retorno;
        }
    }

    public static bool VerificarExistenciaRegistros(string consultaSQL, string verificaridentificador)
    {
        try
        {
            using (SqlConnection conexion = AccesoDatos.AbrirConexion())
            {
                using (SqlCommand command = new SqlCommand(consultaSQL, conexion))
                {
                    command.Parameters.AddWithValue("@CedulaPerson", verificaridentificador);
                    string cedulaExistente = (string)command.ExecuteScalar();
                    return cedulaExistente != null;
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error al ejecutar la consulta: " + ex.Message);
            return false;
        }
    }

    public static Cliente MostrarDatosCliente(string sentencia)
    {
        SqlCommand command = new SqlCommand(sentencia, AccesoDatos.AbrirConexion());
        SqlDataReader lectora_sentencia = command.ExecuteReader();

        if (lectora_sentencia.Read())
        {
            Cliente datosCliente = new Cliente
            {
                IdCliente = int.Parse(lectora_sentencia["IDCLIENTE"].ToString()),
                Cedula = lectora_sentencia["CEDULA"].ToString(),
                Nombre = lectora_sentencia["NOMBRE"].ToString(),
                Apellido = lectora_sentencia["APELLIDOS"].ToString()
            };

            lectora_sentencia.Close();
            return datosCliente;
        }
        else
        {
            lectora_sentencia.Close();
            MessageBox.Show("No se encontraron datos para el cliente.");
            return null;
        }
    }
}