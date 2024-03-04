﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS_Factura.Clases
{
    public class BD2
    {
        // Pointer to an external unmanaged resource.
        private IntPtr handle;
        // Other managed resource this class uses.
        private Component component = new Component();
        // Track whether Dispose has been called.
        private bool disposed = false;
        public static int cont_conex = 0;
        public SqlConnection conexion = null;
        public SqlCommand comando = null;
        private string cadenaconexion;
        public BD2()
        {
            try
            {
                string cadena = "";
                cadena = "Data Source=.;Initial Catalog=FACTURAS;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";

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
        // Implement IDisposable.
        // Do not make this method virtual.
        // A derived class should not be able to override this method.
        public void Dispose()
        {
            Dispose(true);
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }
        // Dispose(bool disposing) executes in two distinct scenarios.
        // If disposing equals true, the method has been called directly
        // or indirectly by a user's code. Managed and unmanaged resources
        // can be disposed.
        // If disposing equals false, the method has been called by the
        // runtime from inside the finalizer and you should not reference
        // other objects. Only unmanaged resources can be disposed.
        private void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if (disposing)
                {
                    // Dispose managed resources.
                    component.Dispose();
                }
                // Call the appropriate methods to clean up
                // unmanaged resources here.
                // If disposing is false,
                // only the following code is executed.
                CloseHandle(handle);
                handle = IntPtr.Zero;
                // Note disposing has been done.
                disposed = true;
            }
        }
        // Use interop to call the method necessary
        // to clean up the unmanaged resource.
        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private extern static Boolean CloseHandle(IntPtr handle);
        // Use C# destructor syntax for finalization code.
        // This destructor will run only if the Dispose method
        // does not get called.
        // It gives your base class the opportunity to finalize.
        // Do not provide destructors in types derived from this class.
        ~BD2()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            Dispose(false);
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
            this.comando = new SqlCommand();
            this.comando.Connection = this.conexion;
            this.comando.CommandType = CommandType.StoredProcedure;
            this.comando.CommandText = sentenciaSQL;
            foreach (SqlParameter p in parametros)
            {
                this.comando.Parameters.Add(p);
            };
            this.ConectarSiDesconectado();
            ret = this.EjecutarEscalarString();
            if (cerrar_conexion_al_terminar)
                this.Desconectar();
            return ret;
        }
        public DataTable EscalarProcAlmTabla(string sentenciaSQL, List<SqlParameter> parametros, bool cerrar_conexion_al_terminar)
        {
            DataTable ret = new DataTable();
            this.comando = new SqlCommand();
            this.comando.Connection = this.conexion;
            this.comando.CommandType = CommandType.StoredProcedure;
            this.comando.CommandText = sentenciaSQL;
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
    }
}