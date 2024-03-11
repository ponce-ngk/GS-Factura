using GS_Factura.Clases;
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
    public partial class GS_RegistroProducto : Form
    {
        BD2 OAD = new BD2();
        List<SqlParameter> par = new List<SqlParameter>();
        int op;
        DataTable tb = new DataTable();
        string sql = "";
        public GS_RegistroProducto()
        {
            InitializeComponent();
            BloqueoControlesInicial();
            Limpiar();
            tb = OAD.EscalarProcAlmTablaSinPar("LeerProductoVacio ", true);
            dgvProductos.DataSource = tb;
            //dgvProductos.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec LeerProductoVacio");
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
        public void Limpiar() {
            txtcantidadproducto.Text = "";
            txtnombreproducto.Text = "";
            txtpreciounitario.Text = "";
            txtpreciounitario.Text = "";
            txtbuscarproducto.Text = "";
            lblIdProducto.Text = "";
            cmbitems.SelectedIndex = -1;
            if (dgvProductos.RowCount != 0)
            {
                tb.Clear();
                tb = OAD.EscalarProcAlmTablaSinPar("LeerProductoVacio ", true);
                dgvProductos.DataSource = tb;
                //dgvProductos.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec LeerProductoVacio");
            }
            else
            {

            }
        }
        public bool Validar_Campos()
        {
            bool verificar = true;
            if (txtnombreproducto.Text == "")
            {
                verificar = false;
                errorProvider1.SetError(txtnombreproducto, "Ingrese El Nombre del producto");
            }
            if (txtcantidadproducto.Text == "")
            {
                verificar = false;
                errorProvider1.SetError(txtcantidadproducto, "Ingrese El Stock del Producto");
            }
            if (txtpreciounitario.Text == "")
            {
                verificar = false;
                errorProvider1.SetError(txtpreciounitario, "Ingrese El Precio Unitario del Producto");
            }
            return verificar;
        }
        public void BorrarMensajeError()
        {
            errorProvider1.SetError(txtnombreproducto, "");
            errorProvider1.SetError(txtcantidadproducto, "");
            errorProvider1.SetError(txtpreciounitario, "");
        }
        public void LlenarData()
        {
            tb = OAD.EscalarProcAlmTablaSinPar("LeerProductoVacio ", true);
            dgvProductos.DataSource = tb;
            //dgvProductos.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec sp_Mostrar_PRODUCTOS");
            dgvProductos.CurrentCell = null;
        }
        private void TxtnombreProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validacion de que sea solo letras y espacio
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == ' ') && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }
        private void TxtcantidadProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Permitir solo números, el caracter de control(para borrar) y el punto decimal
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            //Permitir solo una coma como punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void TxtprecioUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validacion de que sea solo numeros  y el punto
            if (!(char.IsNumber(e.KeyChar) || e.KeyChar == '.') && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }
        private void BtnAgregarProducto_Click(object sender, EventArgs e)
        {
            //Ingreso de un nuevo producto
            //Verifica si los txt no estan vacios
            BorrarMensajeError();
            //if (txtcantidadproducto.Text != "" && txtnombreproducto.Text != "" && txtpreciounitario.Text != "")
            if (Validar_Campos())
            {
                //Pregunta si esta de acuerdo en agregar un nuevo producto
                DialogResult confirmacion = MessageBox.Show("¿Estás seguro de que quieres agregar estos datos?", "Confirmar adición", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //si presiona si procede con la insersion 
                if (confirmacion == DialogResult.Yes)
                {
                    sql = "";
                    par.Clear();
                    par.Add(new SqlParameter("@PRODUCTO", txtnombreproducto.Text.Trim()));
                    par.Add(new SqlParameter("@PRECIO_UNITARIO", txtpreciounitario.Text.Trim()));
                    par.Add(new SqlParameter("@STOCK", txtcantidadproducto.Text.Trim()));
                    sql = OAD.EscalarProcAlmString("sp_Insertar_PRODUCTO", par, true);
                    if (sql != null)
                    {
                        AlertlBoxArtan(Color.LightGray, Color.SeaGreen, "Success", "Los datos de Guardaron correctamente", Properties.Resources.Success);
                        //MessageBox.Show("Los datos de Guardaron correctamente", "Datos Guardados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudieron Guardar", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    dgvProductos.CurrentCell = null;
                    //LlenarData();
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
        private void BtnEliminarProducto_Click(object sender, EventArgs e)
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
                    sql = "";
                    par.Clear();
                    par.Add(new SqlParameter("@IDPRODUCTO", int.Parse(lblIdProducto.Text.Trim())));
                    sql = OAD.EscalarProcAlmString("sp_eliminar_PRODUCTO", par, true);
                    if (sql != null)
                    {
                        MessageBox.Show("Los datos de Eliminaron correctamente", "Datos Eliminados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudieron Eliminar", "Error al Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    dgvProductos.CurrentCell = null;
                    //LlenarData();
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
        private void BtnActualizarProducto_Click(object sender, EventArgs e)
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
                    sql = "";
                    par.Clear();
                    par.Add(new SqlParameter("@IDPRODUCTO", int.Parse(lblIdProducto.Text.Trim())));
                    par.Add(new SqlParameter("@PRODUCTO", txtnombreproducto.Text.Trim()));
                    par.Add(new SqlParameter("@PRECIO_UNITARIO", txtpreciounitario.Text.Trim()));
                    par.Add(new SqlParameter("@STOCK", txtcantidadproducto.Text.Trim()));
                    sql = OAD.EscalarProcAlmString("sp_actualizar_PRODUCTO", par, true);
                    if (sql != null)
                    {
                        MessageBox.Show("Los datos de editaron correctamente", "Datos Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudieron Editar", "Error al editar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    dgvProductos.CurrentCell = null;
                    //LlenarData();
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
        private void BtnLimpiarProducto_Click(object sender, EventArgs e)
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
        void AlertlBoxArtan(Color backColor, Color color, string title, string text, Image icon)
        {
            Notificaciones noti = new Notificaciones();
            noti.BackColor = backColor;
            noti.ColorAlertBox = color;
            noti.TitleAlertBox = title;
            noti.TextAlertBox = text;
            noti.IconeAlertBox = icon;
            noti.Show();
        }

        private void DgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Asignacion de datos de la BD al DataGrid
            try
            {
                if (dgvProductos.CurrentCell == null)
                {
                    BloqueoControles();
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
        private void cmbitems_SelectedIndexChanged(object sender, EventArgs e)
        {
            op = cmbitems.SelectedIndex;
            switch (op)
            {
                case 0:
                    op = 0;
                    break;
                case 1:
                    op = 1;
                    break;
            }
        }
        private void txtpreciounitario_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //Permitir solo números, el caracter de control(para borrar) y el punto decimal
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            //Permitir solo una coma como punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtbuscarproducto_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //Validacion de que sea solo letras y espacio 
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == ' ' || char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                if (txtbuscarproducto.TextLength != 0 && cmbitems.SelectedIndex != -1)
                {
                    if (txtbuscarproducto.TextLength != 0 && cmbitems.SelectedIndex == -1)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Seleccione al menos un campo de Busqueda.");
                    }
                        if (op == 0)
                    {
                        if (txtbuscarproducto.TextLength != 0 && cmbitems.SelectedIndex == -1)
                        {
                            if (txtbuscarproducto.TextLength != 0 && cmbitems.SelectedIndex != -1)
                            {
                                e.Handled = true;
                                tb.Clear();
                                par.Clear();
                                par.Add(new SqlParameter("@Campo", "PRODUCTO"));
                                par.Add(new SqlParameter("@Buscar", txtbuscarproducto.Text.Trim()));
                                tb = OAD.EscalarProcAlmTabla("BuscarProductos ", par, true);
                                dgvProductos.DataSource = tb;
                                if (tb.Rows.Count == 0)
                                {
                                    MessageBox.Show("El Producto no existe o no esta registrado en la base de datos...");
                                }
                            }
                            else
                            {
                                tb = OAD.EscalarProcAlmTablaSinPar("LeerProductoVacio ", true);
                                dgvProductos.DataSource = tb;
                                //dgvProductos.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec LeerProductoVacio");
                                MessageBox.Show("Por favor ingregse al menos un carácter");
                            }
                        }                        
                        
                    }
                    else if (op == 1)
                    {
                        if (txtbuscarproducto.TextLength != 0 && cmbitems.SelectedIndex == -1)
                        {
                            e.Handled = true;
                            tb.Clear();
                            par.Clear();
                            par.Add(new SqlParameter("@Campo", "IDPRODUCTO"));
                            par.Add(new SqlParameter("@Buscar", txtbuscarproducto.Text.Trim()));
                            tb = OAD.EscalarProcAlmTabla("BuscarProductos ", par, true);
                            dgvProductos.DataSource = tb;
                            if (tb.Rows.Count == 0)
                            {
                                MessageBox.Show("El Producto no existe o no esta registrado en la base de datos...");
                            }
                        }
                        else
                        {
                            tb = OAD.EscalarProcAlmTablaSinPar("LeerProductoVacio ", true);
                            dgvProductos.DataSource = tb;
                            //dgvProductos.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec LeerProductoVacio");
                            MessageBox.Show("Por favor ingregse al menos un carácter");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione al menos un campo de Busqueda y Ingrese el dato a Buscar.");
                }
            }
            else if (op == null && txtbuscarproducto.Text == null)
            {
                MessageBox.Show("Por favor ingregse un carácter");
            }
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            if (txtbuscarproducto.TextLength != 0 && cmbitems.SelectedIndex == -1)
            {
                if (op == 0)
                {
                    if (txtbuscarproducto.TextLength != 0 || cmbitems.SelectedIndex == -1)
                    {
                        tb.Clear();
                        par.Clear();
                        par.Add(new SqlParameter("@Campo", "PRODUCTO"));
                        par.Add(new SqlParameter("@Buscar", txtbuscarproducto.Text.Trim()));
                        tb = OAD.EscalarProcAlmTabla("BuscarProductos ", par, true);
                        dgvProductos.DataSource = tb;
                        if (tb.Rows.Count == 0)
                        {
                            MessageBox.Show("El Producto no existe o no esta registrado en la base de datos...");
                        }
                    }
                    else
                    {

                        tb = OAD.EscalarProcAlmTablaSinPar("LeerProductoVacio ", true);
                        dgvProductos.DataSource = tb;
                        //dgvProductos.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec LeerProductoVacio");
                        MessageBox.Show("Por favor ingregse al menos un carácter");
                    }
                }
                else if (op == 1)
                {
                    if (txtbuscarproducto.TextLength != 0 || cmbitems.SelectedIndex == -1)
                    {
                        tb.Clear();
                        par.Clear();
                        par.Add(new SqlParameter("@Campo", "IDPRODUCTO"));
                        par.Add(new SqlParameter("@Buscar", txtbuscarproducto.Text.Trim()));
                        tb = OAD.EscalarProcAlmTabla("BuscarProductos ", par, true);
                        dgvProductos.DataSource = tb;
                        if (tb.Rows.Count == 0)
                        {
                            MessageBox.Show("El Producto no existe o no esta registrado en la base de datos...");
                        }
                    }
                    else
                    {
                        tb = OAD.EscalarProcAlmTablaSinPar("LeerProductoVacio ", true);
                        dgvProductos.DataSource = tb;
                        //dgvProductos.DataSource = AccesoDatos.LlenarTablaparaBuscar("exec LeerProductoVacio");
                        MessageBox.Show("Por favor ingregse al menos un carácter");
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione al menos un campo");
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            AlertlBoxArtan(Color.LightGray, Color.SeaGreen, "Success", "Operacion Completada con exito.", Properties.Resources.Success);
            
        }
    }
}
