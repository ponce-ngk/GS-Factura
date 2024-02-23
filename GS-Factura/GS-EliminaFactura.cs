using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS_Factura
{
    public partial class GS_EliminaFactura : Form
    {
        public GS_EliminaFactura()
        {
            InitializeComponent();
        }

        private void txtBuscaFacturaCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GS_EliminaFactura_Load(object sender, EventArgs e)
        {

        }

        private void txtBuscarFacturaCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                // Verificar si la tecla presionada no es un número o la tecla de retroceso
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                {
                    // Si no es un número o la tecla de retroceso, cancelar la entrada de caracteres
                    e.Handled = true;
                }
                else
                {
                    // Verificar si la longitud después de la pulsación de tecla excede 10 caracteres
                    if ((txtBuscarFacturaCedula.Text + e.KeyChar).Length > 10 && e.KeyChar != (char)Keys.Back)
                    {
                        // Si excede 10 caracteres, cancelar la entrada de caracteres
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción aquí, por ejemplo, mostrar un mensaje de error
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener valores de los TextBox
                string cedula = txtBuscarFacturaCedula.Text;
                int? numeroFactura = null;

                // Intentar convertir el texto a un número entero
                if (int.TryParse(txtBuscaFacturaCliente.Text, out int tempNumeroFactura))
                {
                    numeroFactura = tempNumeroFactura;
                }

                DataTable resultados;

                // Lógica de búsqueda basada en los valores de los TextBox
                if (!string.IsNullOrWhiteSpace(cedula) && numeroFactura.HasValue)
                {
                    // Buscar por número de factura y cédula
                    resultados = AccesoDatos.BuscarFacturas(cedula, numeroFactura);
                }
                else if (!string.IsNullOrWhiteSpace(cedula))
                {
                    // Buscar solo por cédula
                    resultados = AccesoDatos.BuscarFacturas(cedula, null);
                }
                else if (numeroFactura.HasValue && numeroFactura > 0)
                {
                    // Buscar solo por número de factura
                    resultados = AccesoDatos.BuscarFacturas(null, numeroFactura);
                }
                else
                {
                    // Buscar todas las facturas
                    resultados = AccesoDatos.BuscarFacturas(null, null);
                }

                // Mostrar los resultados en un control DataGridView, por ejemplo
                dtgFactura.DataSource = resultados;
                LimpiaDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LimpiaDatos()
        {
            txtBuscaFacturaCliente.Text = "";
            txtBuscarFacturaCedula.Text = "";
        }

        private void dtgFactura_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && (e.ColumnIndex == dtgFactura.Columns["EliminarFila"].Index || e.ColumnIndex == dtgFactura.Columns["VerFactura"].Index))
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    // Obtener el icono deseado según la columna
                    Icon icono = null;

                    if (e.ColumnIndex == dtgFactura.Columns["EliminarFila"].Index)
                    {
                        // Icono para la columna "EliminarFila"
                        icono = Properties.Resources.remove;
                    }
                    else if (e.ColumnIndex == dtgFactura.Columns["VerFactura"].Index)
                    {
                        // Icono para la columna "VerFactura"
                        icono = Properties.Resources.ver_nuevo;
                    }

                    // Calcular la posición para centrar el icono en la celda
                    int x = e.CellBounds.Left + (e.CellBounds.Width - icono.Width) / 2;
                    int y = e.CellBounds.Top + (e.CellBounds.Height - icono.Height) / 2;

                    // Dibujar el icono en la celda
                    e.Graphics.DrawIcon(icono, x, y);

                    // Indicar que no es necesario pintar la celda estándar
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción (puedes mostrar un mensaje, registrarla, etc.)
                MessageBox.Show($"Error en CellPainting: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtgFactura_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dtgFactura.Columns["VerFactura"].Index)
            {
                try
                {
                    // Obtener el ID de la factura de la fila seleccionada
                    int idFactura = Convert.ToInt32(dtgFactura.Rows[e.RowIndex].Cells["IDFACTURA"].Value);

                    // Llamar al formulario de visualización de factura con el ID de la factura
                    VisualizaFacturaBorrar visualizaForm = new VisualizaFacturaBorrar(idFactura);

                    // Establecer el formulario como no independiente (TopLevel = false)
                    visualizaForm.TopLevel = false;

                    // Limpiar los controles existentes en el panelFactura
                    panelFactura.Controls.Clear();

                    // Establecer el tamaño del formulario al tamaño del panelFactura
                    visualizaForm.Size = panelFactura.Size;

                    // Agregar el formulario al panelFactura
                    panelFactura.Controls.Add(visualizaForm);

                    // Mostrar el formulario dentro del panelFactura
                    visualizaForm.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (e.RowIndex >= 0 && e.ColumnIndex == dtgFactura.Columns["Eliminarfila"].Index)
            {
                try
                {
                    int idFactura = Convert.ToInt32(dtgFactura.Rows[e.RowIndex].Cells["IDFACTURA"].Value);

                    // Llamada al método para eliminar la factura
                    AccesoDatos.EliminarFactura(idFactura);

                    // Cerrar el formulario de visualización después de la eliminación
                    if (panelFactura.Controls.Count > 0 && panelFactura.Controls[0] is VisualizaFacturaBorrar)
                    {
                        ((VisualizaFacturaBorrar)panelFactura.Controls[0]).Close();
                    }

                    // Recargar los datos en el DataGridView u otras acciones según sea necesario
                    CargarDatosFacturas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void CargarDatosFacturas()
        {
            DataTable resultados;
            try
            {
                resultados = AccesoDatos.BuscarFacturas(null, null);
                dtgFactura.DataSource = resultados;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }

}
