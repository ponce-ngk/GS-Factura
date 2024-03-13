using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GS_Factura.Clases
{
    public class AccesoDatos
    {
        private IntPtr handle;
        private Component component = new Component();
        private bool disposed = false;
        public static int cont_conex = 0;
        public SqlConnection conexion = null;
        public SqlCommand comando = null;
        private string cadenaconexion;
        private static string cadena;
        public AccesoDatos()
        {
            try
            {
                cadena = "Data Source=(local);Initial Catalog=FACTURAS;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";
                if (cadena.Length != 0)
                {
                    this.cadenaconexion = cadena;
                    this.conexion = new SqlConnection();
                    this.conexion.ConnectionString = this.cadenaconexion;
                }
            }
            catch (ConfigurationException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { }
        }
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {

                if (disposing)
                {
                    component.Dispose();
                }
                CloseHandle(handle);
                handle = IntPtr.Zero;
                disposed = true;
            }
        }
        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private extern static Boolean CloseHandle(IntPtr handle);
        ~AccesoDatos()
        {
            Dispose(false);
        }
        public static SqlConnection AbrirConexion()
        {
            try
            {
                SqlConnection oCon = new SqlConnection(cadena);
                oCon.Open();
                return oCon;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null; // Devuelve null en caso de error.
            }
        }
        public void Desconectar()
        {
            if (this.conexion.State != ConnectionState.Closed)
            {
                this.conexion.Close();
                cont_conex--;
            }
        }
        public void Conectar()
        {
            if (this.conexion == null /*|| this.conexion.State.Equals(ConnectionState.Closed)*/)
            {
                MessageBox.Show("La conexión no está abierta");
            }
            try
            {
                this.conexion.Open();
                cont_conex++;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error de conectividad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
        public void ConectarSiDesconectado()
        {
            if (this.conexion == null /*|| this.conexion.State.Equals(ConnectionState.Closed)*/)
            {
                MessageBox.Show("La conexión no está abierta");
            }
            try
            {
                if (this.conexion.State == ConnectionState.Closed)
                {
                    this.conexion.Open();
                    cont_conex++;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error de conectividad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
        public void CrearComando(string sentenciaSQL)
        {
            this.comando = new SqlCommand();
            this.comando.Connection = this.conexion;
            this.comando.CommandType = CommandType.Text;
            this.comando.CommandText = sentenciaSQL;
        }
        public void CrearComandoStoredProcedure(string sentenciaSQL)
        {
            this.comando = new SqlCommand();
            this.comando.Connection = this.conexion;
            this.comando.CommandType = CommandType.StoredProcedure;
            this.comando.CommandText = sentenciaSQL;
        }
        public int EscalarProcAlm(string sentenciaSQL, List<SqlParameter> parametros, bool cerrar_conexion_al_terminar)
        {
            int ret;
            this.comando = new SqlCommand();
            this.comando.Connection = this.conexion;
            this.comando.CommandType = CommandType.StoredProcedure;
            this.comando.CommandText = sentenciaSQL;
            foreach (SqlParameter p in parametros)
            {
                this.comando.Parameters.Add(p);
            };
            this.ConectarSiDesconectado();
            ret = this.EjecutarEscalar();
            if (cerrar_conexion_al_terminar)
                this.Desconectar();
            return ret;
        }
        public string EscalarProcAlmString(string sentenciaSQL, List<SqlParameter> parametros, bool cerrar_conexion_al_terminar)
        {
            string ret = "";
            CrearComandoStoredProcedure(sentenciaSQL);
            foreach (SqlParameter p in parametros)
            {
                this.comando.Parameters.Add(p);
            };
            this.ConectarSiDesconectado();
            try
            {
                ret = this.EjecutarEscalarString();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ret = null; // Indicar que ocurrió un error
            }
            if (cerrar_conexion_al_terminar)
                this.Desconectar();
            return ret;
        }
        public DataTable EscalarProcAlmTabla(string sentenciaSQL, List<SqlParameter> parametros, bool cerrar_conexion_al_terminar)
        {
            DataTable ret = new DataTable();
            CrearComandoStoredProcedure(sentenciaSQL);
            SqlDataAdapter adapter = new SqlDataAdapter(this.comando);
            foreach (SqlParameter p in parametros)
            {
                this.comando.Parameters.Add(p);
            };
            this.ConectarSiDesconectado();
            adapter.Fill(ret);
            //ret = this.EjecutarEscalar();
            if (cerrar_conexion_al_terminar)
                this.Desconectar();
            return ret;
        }
        public DataTable EscalarProcAlmTablaSinPar(string sentenciaSQL, bool cerrar_conexion_al_terminar)
        {
            DataTable ret = new DataTable();
            CrearComandoStoredProcedure(sentenciaSQL);
            SqlDataAdapter adapter = new SqlDataAdapter(this.comando);
            this.ConectarSiDesconectado();
            adapter.Fill(ret);
            //ret = this.EjecutarEscalar();
            if (cerrar_conexion_al_terminar)
                this.Desconectar();
            return ret;
        }
        public bool EscalarProcAlmBool(string sentenciaSQL, List<SqlParameter> parametros, bool cerrar_conexion_al_terminar)
        {
            bool ret = false;
            CrearComandoStoredProcedure(sentenciaSQL);
            foreach (SqlParameter p in parametros)
            {
                this.comando.Parameters.Add(p);
            };
            this.ConectarSiDesconectado();
            ret = this.EjecutarEscalarBool();
            if (cerrar_conexion_al_terminar)
                this.Desconectar();
            return ret;
        }
        public int EjecutarEscalar()
        {
            int escalar = 0;
            try
            {
                int.TryParse(this.comando.ExecuteScalar().ToString(), out escalar);
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return escalar;
        }
        public bool EjecutarEscalarBool()
        {
            bool escalar = false;
            try
            {
                escalar = bool.Parse(this.comando.ExecuteScalar().ToString());
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return escalar;
        }
        public string EjecutarEscalarString()
        {
            string escalar = "";
            try
            {
                escalar = this.comando.ExecuteNonQuery().ToString().Trim();
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return escalar;
        }
        public string ObetnerDatosFactura(string sentenciaSQL)
        {
            string escalar = "";
            try
            {
                    using (SqlCommand command = new SqlCommand(sentenciaSQL, AccesoDatos.AbrirConexion()))
                    {
                        escalar = command.ExecuteScalar()?.ToString()?.Trim() ?? "";
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return escalar;
        }
        public DataTable ObtenerDatosFactura(int idFactura)
        {
            string sentenciaSQL = "sp_ObtenerDatosFactura";
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                 new SqlParameter("@IDFactura", idFactura)
            };

            return EscalarProcAlmTabla(sentenciaSQL, parametros, true);
        }
        public void XmlVenta(int idCliente, decimal subtotal, decimal iva, decimal valoriva, decimal total, DataGridView detalleVenta)
        {
            try
            {
                string venta = CrearElementoVenta(idCliente, subtotal, iva, valoriva, total, detalleVenta);
                string detalle = venta.ToString();

                using (SqlConnection conexion = AccesoDatos.AbrirConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_VentaProducto", conexion))
                    {
                        cmd.Parameters.Add("@StringXML", SqlDbType.VarChar).Value = detalle;
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("La venta ha sido exitosa.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private String CrearElementoVenta(int idCliente, decimal subtotal, decimal iva, decimal valoriva, decimal total, DataGridView detalleVenta)
        {
            XElement venta = new XElement("FACTURA");
            venta.Add(new XElement("item",
                new XElement("IDCLIENTE", idCliente),
                new XElement("FECHA", DateTime.Now.ToString("yyyy-MM-dd")), 
                new XElement("SUBTOTAL", subtotal),
                new XElement("IVA", iva),
                new XElement("VALORIVA", valoriva),
                new XElement("TOTAL", total)
            ));
            XElement detalle_venta = new XElement("DETALLE_FACTURA");
            foreach (DataGridViewRow row in detalleVenta.Rows)
            {

                detalle_venta.Add(new XElement("item",
                new XElement("IDPRODUCTO", row.Cells["IdProducto"].Value),
                new XElement("CANTIDAD", Convert.ToDecimal(row.Cells["StockProducto"].Value.ToString().Replace(".", ","))),
                new XElement("PRECIO_UNITARIO", Convert.ToDecimal(row.Cells["PrecioVenta"].Value.ToString().Replace(".", ","))),
                new XElement("SUBTOTAL", Convert.ToDecimal(row.Cells["TotalProducto"].Value.ToString().Replace(".", ",")))
                ));
            }
            string consulta = venta.ToString() + detalle_venta.ToString();
            return consulta;
        }
        public decimal RetornarStock(int idProducto)
        {
            decimal stock = 0;

            try
            {
                using (SqlCommand mostrarProdCmd = new SqlCommand("SELECT STOCK FROM PRODUCTO WHERE IDPRODUCTO = @id_product", AccesoDatos.AbrirConexion()))
                {
                    mostrarProdCmd.Parameters.AddWithValue("@id_product", idProducto);
                    stock = Convert.ToDecimal(mostrarProdCmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
                MessageBox.Show("Error al obtener el stock: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return stock;
        }
        public void XmlEditarFactura(int idFactura, int idCliente, decimal subtotal, decimal iva, decimal valoriva, decimal total, DataGridView detalleVenta)
        {
            try
            {
                string xmlFactura = EditarElementoFactura(idFactura, idCliente, subtotal, iva, valoriva, total, detalleVenta);

                using (SqlConnection conexion = AccesoDatos.AbrirConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_EditarFactura", conexion))
                    {
                        cmd.Parameters.Add("@IDFactura", SqlDbType.Int).Value = idFactura;
                        cmd.Parameters.Add("@StringXML", SqlDbType.VarChar).Value = xmlFactura;
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("La factura ha sido editada exitosamente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
    }
        private String EditarElementoFactura(int idFactura, int idCliente, decimal subtotal, decimal iva, decimal valoriva, decimal total, DataGridView detalleVenta)
        {
            XElement factura = new XElement("FACTURA",
                new XElement("item",
                    new XElement("IDFACTURA", idFactura),
                    new XElement("IDCLIENTE", idCliente),
                    new XElement("FECHA", DateTime.Now),
                    new XElement("SUBTOTAL", subtotal),
                    new XElement("IVA", iva),
                    new XElement("VALORIVA", valoriva),
                    new XElement("TOTAL", total)
                )
            );

            XElement detalleFactura = new XElement("DETALLE_FACTURA");
            foreach (DataGridViewRow row in detalleVenta.Rows)
            {
                detalleFactura.Add(new XElement("item",
                    new XElement("IDPRODUCTO", row.Cells["IDPRODUCTO"].Value),
                    new XElement("CANTIDAD", Convert.ToDecimal(row.Cells["CANTIDAD"].Value.ToString().Replace(".", ","))),
                    new XElement("PRECIO_UNITARIO", Convert.ToDecimal(row.Cells["PRECIO_UNITARIO"].Value.ToString().Replace(".", ","))),
                    new XElement("SUBTOTAL", Convert.ToDecimal(row.Cells["TotalProducto"].Value.ToString().Replace(".", ",")))
                ));
            }

            string xmlFactura = factura.ToString() + detalleFactura.ToString();
            return xmlFactura;
        }
        public void EliminarFactura(int idFactura)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("sp_EliminarFactura", this.conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IDFactura", idFactura);

                    if (this.conexion.State != ConnectionState.Open)
                    {
                        this.ConectarSiDesconectado();
                    }

                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.Desconectar();
                }
            }
        }
        public int ObtenerMaxIdFactura()
        {
            int maxIdFactura = 0;

            try
            {
                this.CrearComandoStoredProcedure("sp_ObtenerMaxIdFactura");
                this.ConectarSiDesconectado();

                using (SqlDataReader reader = this.comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        maxIdFactura = reader["MaxIdFactura"] != DBNull.Value ? Convert.ToInt32(reader["MaxIdFactura"]) : 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maxIdFactura = 0; // Indicar que ocurrió un error
            }
            finally
            {
                this.Desconectar();
            }

            return maxIdFactura;
        }
    }
}
