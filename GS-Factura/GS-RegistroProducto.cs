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
    public partial class GS_RegistroProducto : Form
    {
        public GS_RegistroProducto()
        {

            InitializeComponent();
            BloqueoControlesInicial();
            //LlenarData();
            
            dgvProductos.CurrentCell = null;
        }
        public void BloqueoControlesInicial()
        {
            dgvProductos.CurrentCell = null;
            btnActualizarProducto.Visible = false;
            btnEliminarProducto.Visible = false;
            lblActualizar.Visible = false;
            lblEliminar.Visible = false;
        }

        //Funcion de Borrar datos en el textbox y el llenado del data Grid con datos actualizar
        public void Limpiar() {
            txtcantidadproducto.Text = "";
            txtnombreproducto.Text = "";
            txtpreciounitario.Text = "";
            txtpreciounitario.Text = "";
            txtbuscarproducto.Texts = "";
            lblIdProducto.Text = "";
            
        }
        
        public void LlenarData()
        {
            dgvProductos.DataSource = AccesoDatos.llenartablaparabuscar("exec sp_Mostrar_PRODUCTOS");
            dgvProductos.CurrentCell = null;
        }
        private void dgvProductos_Click(object sender, EventArgs e)
        {
            //Asignacion de datos de la BD al DataGrid
            
            try
            {
                if(dgvProductos.CurrentCell == null)
                {
                    //BloqueoClickDgv();
                    BloqueoControles();
                    //MessageBox.Show("Debe de seleccionar un celda con informacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {
                    BloqueoClickDgv();
                    lblIdProducto.Text = dgvProductos.CurrentRow.Cells[0].Value.ToString();
                    txtnombreproducto.Text = dgvProductos.CurrentRow.Cells[1].Value.ToString();
                    txtpreciounitario.Text = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                    txtcantidadproducto.Text = dgvProductos.CurrentRow.Cells[3].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtbuscarproducto__TextChanged(object sender, EventArgs e)
        {
            //Busqueda de Producto por el nombre al momento de digitalizar el nombre del producto
            //dgvProductos.DataSource = AccesoDatos.llenartablaparabuscar
            //    ("select RTRIM(IDPRODUCTO) AS IDPRODUCTO, RTRIM(PRODUCTO) AS PRODUCTO, RTRIM(PRECIO_UNITARIO) AS PRECIO_UNITARIO," +
            //    "RTRIM(STOCK) AS STOCK from PRODUCTO WHERE ESTADO = 1 and PRODUCTO like '" + txtbuscarproducto.Texts+"%'");
        }

        private void txtbuscarproducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validacion de que sea solo letras y espacio 
                if (!(char.IsLetter(e.KeyChar) || e.KeyChar == ' ') && (e.KeyChar != (char)Keys.Back))
                {
                    e.Handled = true;
                dgvProductos.DataSource = AccesoDatos.llenartablaparabuscar
              ("EXEC BuscarProducto '" + txtbuscarproducto.Texts + "'");
            }
            else if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                
            }
        }

        private void txtnombreproducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validacion de que sea solo letras y espacio
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == ' ') && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void txtcantidadproducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validacion de que sea solo numeros  y el punto
            if (!(char.IsNumber(e.KeyChar) || e.KeyChar == '.') && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
            else if((e.KeyChar) == 13)
            {
                dgvProductos.DataSource = AccesoDatos.llenartablaparabuscar
               ("EXEC BuscarProducto '" + txtbuscarproducto.Texts + "'");
            }
        }

        private void txtpreciounitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validacion de que sea solo numeros  y el punto
            if (!(char.IsNumber(e.KeyChar) || e.KeyChar == '.') && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            //Ingreso de un nuevo producto
            //Verifica si los txt no estan vacios
            if (txtcantidadproducto.Text != "" && txtnombreproducto.Text != "" && txtpreciounitario.Text != "")
            {
                //Pregunta si esta de acuerdo en agregar un nuevo producto
                DialogResult confirmacion = MessageBox.Show("¿Estás seguro de que quieres agregar estos datos?", "Confirmar adición", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //si presiona si procede con la insersion 
                if (confirmacion == DialogResult.Yes)
                {
                    Producto pProducto = new Producto();
                    pProducto.PRODUCTO1 = txtnombreproducto.Text;
                    pProducto.STOTCK1 = txtcantidadproducto.Text;
                    pProducto.PRECIO_UNITARIO1 = txtpreciounitario.Text;
                    int resultado = CrudProducto.AgregarProducto(pProducto);

                    if (resultado > 0)
                    {
                        MessageBox.Show("Los datos de Guardaron correctamente", "Datos Guardados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudieron Guardar", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    dgvProductos.CurrentCell = null;
                    LlenarData();
                    BloqueoControles();
                    Limpiar();
                }
            }
            //caso contrario advierte que estan vacios los txt
            else
            {
                MessageBox.Show("Debe de llenar todos los Campos Requeridos para Agregar un Nuevo Producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            //Eliminar un producto
            //Verifica si los txt no estan vacios
            if (lblIdProducto.Text != "")
            {
                //Pregunta si esta de acuerdo en eliminar un producto
                DialogResult confirmacion = MessageBox.Show("¿Estás seguro de que quieres eliminar estos datos?", "Confirmar eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmacion == DialogResult.Yes)
                {
                    //si presiona si procede con la eliminacion 
                    Producto pProducto = new Producto();
                    pProducto.IDPRODUCTO1 = int.Parse(lblIdProducto.Text);
                    pProducto.ESTADO1 = '0';
                    int resultado = CrudProducto.EliminarProducto(pProducto);

                    if (resultado > 0)
                    {
                        MessageBox.Show("Los datos de Eliminaron correctamente", "Datos Eliminados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudieron Eliminar", "Error al Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    dgvProductos.CurrentCell = null;
                    LlenarData();
                    BloqueoControles();
                    Limpiar();
                }
            }
            //caso contrario advierte que estan vacios los txt
            else
            {
                MessageBox.Show("Debe de seleccionar un producto para ser Eliminando", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnActualizarProducto_Click(object sender, EventArgs e)
        {
            //Modificacion de un producto
            //Verifica si los txt no estan vacios
            if (txtnombreproducto.Text != "" && txtpreciounitario.Text != "" && txtcantidadproducto.Text != "")
            {
                //Pregunta si esta de acuerdo en modificar un producto
                DialogResult confirmacion = MessageBox.Show("¿Estás seguro de que quieres actualizar estos datos?", "Confirmar modificacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmacion == DialogResult.Yes)
                {
                    //si presiona si procede con la Modificacion
                    Producto pProducto = new Producto();
                    pProducto.IDPRODUCTO1 = int.Parse(lblIdProducto.Text);
                    pProducto.PRODUCTO1 = txtnombreproducto.Text;
                    pProducto.STOTCK1 = txtcantidadproducto.Text;
                    pProducto.PRECIO_UNITARIO1 = txtpreciounitario.Text;
                    int resultado = CrudProducto.ActualizarProducto(pProducto);

                    if (resultado > 0)
                    {
                        MessageBox.Show("Los datos de editaron correctamente", "Datos Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudieron Editar", "Error al editar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    dgvProductos.CurrentCell = null;
                    LlenarData();
                    BloqueoControles();
                    Limpiar();
                }
            }
            //caso contrario advierte que estan vacios los txt
            else
            {
                MessageBox.Show("Debe de seleccionar un producto para ser Actualizado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //Funcion para Limpiar todos los campos en caso de no querrer lo escrito.
        private void btnLimpiarProducto_Click(object sender, EventArgs e)
        {
            Limpiar();
            BloqueoControles();
            dgvProductos.CurrentCell = null;
        }
        public void BloqueoControles()
        {
            btnActualizarProducto.Visible = false;
            btnEliminarProducto.Visible = false;
            lblActualizar.Visible = false;
            lblEliminar.Visible = false;
            btnAgregarProducto.Visible = true;
            lblAgregar.Visible = true;
        }
        public void BloqueoClickDgv()
        {
            btnAgregarProducto.Visible = false;
            btnActualizarProducto.Visible = true;
            btnEliminarProducto.Visible = true;
            lblAgregar.Visible = false;
            lblActualizar.Visible = true;
            lblEliminar.Visible = true;
        }

        private void txtbuscarproducto_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                // Llamar al método para buscar productos
                dgvProductos.DataSource = AccesoDatos.llenartablaparabuscar
               ("EXEC BuscarProducto '" + txtbuscarproducto.Texts + "'");
            }
            
        }
    }
}
