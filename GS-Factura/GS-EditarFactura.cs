using GS_Factura.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS_Factura
{
    public partial class GS_EditarFactura : Form
    {
        private int idFactura;

        public GS_EditarFactura(int idFactura)
        {
            InitializeComponent();
            this.idFactura = idFactura;
            CargarDatosFactura(idFactura);
        }


        private void CargarDatosFactura(int idFactura)
        {
            DataTable datosFactura = new BD2().ObtenerDatosFactura(idFactura);

            if (datosFactura.Rows.Count > 0)
            {
                lblcedulacliente.Text = datosFactura.Rows[0]["CEDULA"].ToString();
                lblnombrecliente.Text = datosFactura.Rows[0]["ClienteNombre"].ToString();
                txtSearchCliente.Text = datosFactura.Rows[0]["CEDULA"].ToString();
                lblApellidocliente.Text = datosFactura.Rows[0]["ClienteApellidos"].ToString();
                lblnumerofactura.Text = datosFactura.Rows[0]["IDFACTURA"].ToString();
                lblFingresoVenta.Text = datosFactura.Rows[0]["FechaEmision"].ToString();

                dtgVenta.DataSource = datosFactura;


                dtgVenta.Columns["ClienteNombre"].Visible = false;
                dtgVenta.Columns["ClienteApellidos"].Visible = false;
                dtgVenta.Columns["FechaEmision"].Visible = false;
                dtgVenta.Columns["CEDULA"].Visible = false;
                dtgVenta.Columns["IDFACTURA"].Visible = false;
                dtgVenta.Columns["IDDETALLEFACTURA"].Visible = false;
                // Obtener la fecha y hora actual
                DateTime fechaHoraActual = DateTime.Now;
                lblEdicion.Text = Convert.ToString(fechaHoraActual);
            }
        }

        private void dtgVenta_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex >= 0 && this.dtgVenta.Columns[e.ColumnIndex].Name == "Eliminarfila" && e.RowIndex >= 0)
                {
                    e.CellStyle.BackColor = Color.Red;

                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    // Ajusta las dimensiones del icono para hacer el botón más pequeño
                    int iconWidth = 30;
                    int iconHeight = 30;
                    //extrae la imagen remove.ico  imagen ico
                    //Icon icoAtomico = new Icon(Environment.CurrentDirectory + @"\\remove.ico", iconWidth, iconHeight);

                    System.Drawing.Icon icoAtomico = new System.Drawing.Icon(Properties.Resources.remove, iconWidth, iconHeight);

                    e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + (e.CellBounds.Width - iconWidth) / 2, e.CellBounds.Top + (e.CellBounds.Height - iconHeight) / 2);

                    // Ajusta las dimensiones de la celda para que coincidan con el tamaño del botón
                    this.dtgVenta.Rows[e.RowIndex].Height = iconHeight + 4;
                    this.dtgVenta.Columns[e.ColumnIndex].Width = iconWidth + 9;

                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

}
