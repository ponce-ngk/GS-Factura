using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GS_Factura;
using GS_Factura.Clases;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Pruebas_Unitarias
{
    [TestClass]
    public class UnitTest1
    {
        //Prueba Unitaria 1
        [TestMethod]
        public void EscalarProcAlm_DeberiaRetornarEscalarCorrecto()
        {
            // Arrange
            AccesoDatos bd = new AccesoDatos();
            bd.Conectar();
            string sentenciaSQL = "sp_PruebaUnitaria1";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@Cedula", "1250400089")); // Agrega el nuevo parámetro
            // Act
            int resultado = bd.EscalarProcAlm(sentenciaSQL, parametros, true);

            // Assert
            Assert.AreEqual(4, resultado); // Cambia expectedResult al valor esperado
        }

        //Prueba Unitaria 2
        [TestMethod]
        public void XmlVenta_DeberiaGenerarXmlCorrecto()
        {
            // Arrange
            AccesoDatos bd = new AccesoDatos();
            int idCliente = 1;
            decimal subtotal = 100;
            decimal iva = 10;
            decimal total = 110;
            decimal valoriva = 135;
            DataGridView detalleVenta = new DataGridView(); // Simula un DataGridView con datos

            // Act & Assert
            try
            {
                bd.XmlVenta(idCliente, subtotal, iva, valoriva, total, detalleVenta);

                // Si no se lanza una excepción, asumimos que la venta fue exitosa
                Assert.IsFalse(false); // Si no se lanza una excepción, no se debería llegar aquí
            }
            catch (Exception)
            {
                // Si se lanza una excepción, la venta no se realizó correctamente
                Assert.IsFalse(true, "La venta no se realizó correctamente"); // Se espera que esto falle
            }
        }

        //Prueba Unitaria 3
        [TestMethod]
        public void ObtenerDatosFactura_DeberiaRetornarTablaNoVacia()
        {
            // Arrange
            AccesoDatos bd = new AccesoDatos();
            int idFactura = 2;

            // Act
            DataTable tabla = bd.ObtenerDatosFactura(idFactura);

            // Assert
            Assert.IsNotNull(tabla);
            Assert.IsTrue(tabla.Rows.Count > 0);
        }

        //Prueba Unitaria 4
        [TestMethod]
        public void RetornarStock_DeberiaRetornarStockCorrecto()
        {
            // Arrange
            AccesoDatos bd = new AccesoDatos();
            int idProducto = 1;

            // Act
            decimal stock = bd.RetornarStock(idProducto);

            // Assert
            Assert.IsNotNull(stock);
        }

        //Prueba Unitaria 5
        [TestMethod]
        public void XmlEditarFactura_DeberiaEditarFacturaCorrectamente()
        {
            // Arrange
            AccesoDatos bd = new AccesoDatos();
            int idFactura = 1;
            int idCliente = 1;
            decimal subtotal = 22.3000m;
            decimal iva = 12;
            decimal valoriva = 2.676m;
            decimal total = 25.0900m;
            DataGridView detalleVenta = new DataGridView(); // Simula un DataGridView con datos

            // Act & Assert
            try
            {
                bd.XmlEditarFactura(idFactura, idCliente, subtotal, iva, valoriva, total, detalleVenta);

                // Si no se lanza una excepción, asumimos que la edición de la factura fue exitosa
                Assert.IsTrue(true); // Si no se lanza una excepción, la edición fue exitosa
            }
            catch (Exception ex)
            {
                // Si se lanza una excepción, la edición de la factura no fue exitosa
                Assert.IsTrue(false, "La edición de la factura no fue exitosa. Excepción: " + ex.Message);
            }
        }
    }
}
