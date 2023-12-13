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

namespace GS_Factura.Clases
{
    internal class Producto
    {
        int IDPRODUCTO;
        string PRODUCTO;
        string PRECIO_UNITARIO;
        string STOTCK;
        char ESTADO;
        public Producto(int iDPRODUCTO, string pRODUCTO, string pRECIO_UNITARIO, string sTOTCK, char eSTADO)
        {
            IDPRODUCTO = iDPRODUCTO;
            PRODUCTO = pRODUCTO;
            PRECIO_UNITARIO = pRECIO_UNITARIO;
            STOTCK = sTOTCK;
            ESTADO = eSTADO;
        }

        public int IDPRODUCTO1 { get => IDPRODUCTO; set => IDPRODUCTO = value; }
        public string PRODUCTO1 { get => PRODUCTO; set => PRODUCTO = value; }
        public string PRECIO_UNITARIO1 { get => PRECIO_UNITARIO; set => PRECIO_UNITARIO = value; }
        public string STOTCK1 { get => STOTCK; set => STOTCK = value; }
        public char ESTADO1 { get => ESTADO; set => ESTADO = value; }

    }
}
class CrudProducto
{
    public static int AgregarProducto(Producto pProducto)
    {
        int retorno = 0;
        try
        {
            using (SqlConnection conex = AccesoDatos.abrirConexion())
            {
                SqlCommand comando = new SqlCommand(string.Format("exec sp_Insertar_CLIENTE '{0}','{1}','{2}','{3}'",
                                pProducto.PRODUCTO1, pProducto.PRECIO_UNITARIO1, pProducto.STOTCK1), conex);
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

    public static int ActualizarClient(Producto pProducto)
    {
        int retorno = 0;
        try
        {
            using (SqlConnection conex = AccesoDatos.abrirConexion())
            {
                SqlCommand comando = new SqlCommand(string.Format("exec sp_actualizar_CLIENTE '{0}','{1}','{2}','{3}','{4}'",
                                pProducto.PRODUCTO1, pProducto.PRECIO_UNITARIO1, pProducto.STOTCK1), conex);
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

    public static int EliminarClient(Producto pProducto)
    {
        int retorno = 0;
        try
        {
            using (SqlConnection conex = AccesoDatos.abrirConexion())
            {
                SqlCommand comando = new SqlCommand(string.Format("exec sp_eliminar_CLIENTE '{0}','{1}'",
                                pProducto.IDPRODUCTO1, pProducto.ESTADO1), conex);
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
}