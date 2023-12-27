﻿using GS_Factura.Clases;
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
            LlenarLimpiar();
        }

        //Funcion de Borrar datos en el textbox y el llenado del data Grid con datos actualizar
        public void LlenarLimpiar() {
            txtcantidadproducto.Text = "";
            txtnombreproducto.Text = "";
            txtpreciounitario.Text = "";
            txtIdProducto.Text = "";
            txtbuscarproducto.Texts = "";
            dgvProductos.DataSource = AccesoDatos.llenartablaparabuscar("exec sp_Mostrar_PRODUCTOS");
        }

        private void dgvProductos_Click(object sender, EventArgs e)
        {
            //Asignacion de datos de la BD al DataGrid
            try
            {                
                txtIdProducto.Text = dgvProductos.CurrentRow.Cells[0].Value.ToString();
                txtnombreproducto.Text = dgvProductos.CurrentRow.Cells[1].Value.ToString();
                txtpreciounitario.Text = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                txtcantidadproducto.Text = dgvProductos.CurrentRow.Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtbuscarproducto__TextChanged(object sender, EventArgs e)
        {
            //Busqueda de Producto por el nombre al momento de digitalizar el nombre del producto
            dgvProductos.DataSource = AccesoDatos.llenartablaparabuscar
                ("select RTRIM(IDPRODUCTO) AS IDPRODUCTO, RTRIM(PRODUCTO) AS PRODUCTO, RTRIM(PRECIO_UNITARIO) AS PRECIO_UNITARIO," +
                "RTRIM(STOCK) AS STOCK from PRODUCTO WHERE ESTADO = 1 and PRODUCTO like '" + txtbuscarproducto.Texts+"%'");
        }

        private void txtbuscarproducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validacion de que sea solo letras y espacio 
                if (!(char.IsLetter(e.KeyChar) || e.KeyChar == ' ') && (e.KeyChar != (char)Keys.Back))
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
                    LlenarLimpiar();
                }
            }
            //caso contrario advierte que estan vacios los txt
            else
            {
                MessageBox.Show("campos vacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            //Eliminar un producto
            //Verifica si los txt no estan vacios
            if (txtIdProducto.Text != "")
            {
                //Pregunta si esta de acuerdo en eliminar un producto
                DialogResult confirmacion = MessageBox.Show("¿Estás seguro de que quieres eliminar estos datos?", "Confirmar eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmacion == DialogResult.Yes)
                {
                    //si presiona si procede con la eliminacion 
                    Producto pProducto = new Producto();
                    pProducto.IDPRODUCTO1 = int.Parse(txtIdProducto.Text);
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
                    LlenarLimpiar();
                }
            }
            //caso contrario advierte que estan vacios los txt
            else
            {
                MessageBox.Show("campos vacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    pProducto.IDPRODUCTO1 = int.Parse(txtIdProducto.Text);
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

                    LlenarLimpiar();
                }
            }
            //caso contrario advierte que estan vacios los txt
            else
            {
                MessageBox.Show("campos vacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //Funcion para Limpiar todos los campos en caso de no querrer lo escrito.
        private void btnLimpiarProducto_Click(object sender, EventArgs e)
        {
            LlenarLimpiar();
        }
    }
}
