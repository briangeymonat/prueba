using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ejemplo.Web
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ActualizarGrillaDeDatos();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Common.Clases.Categoria cat = new Common.Clases.Categoria();
            cat.Nombre = this.txtNombre.Text;

            try
            {
                bool resultado = Dominio.Fachada.Categoria_Agregar(cat);

                if (resultado)
                {
                    lblResultado.Text = "Agregado correctamente.";
                    LimpiarCampos();
                    ActualizarGrillaDeDatos();
                }
                else 
                {
                    lblResultado.Text = "ERROR: No se pudo agregar.";
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void ActualizarGrillaDeDatos() 
        {
            this.grdCategorias.DataSource = Dominio.Fachada.Cateogoria_TraerTodas();
            this.grdCategorias.DataBind();
        }

        protected void LimpiarCampos() 
        {
            this.txtId.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
        }

        protected void grdCategorias_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                this.lblResultado.Text = string.Empty;

                TableCell celdaId = grdCategorias.Rows[e.RowIndex].Cells[1];
                Common.Clases.Categoria cat = new Common.Clases.Categoria();
                cat.Identificador = int.Parse(celdaId.Text);
                
                bool resultado = Dominio.Fachada.Categoria_Eliminar(cat);

                if (resultado)
                {
                    ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Eliminado exitosamente.')", true);
                    ActualizarGrillaDeDatos();
                    ModoEdicion(false);
                }
                else 
                {
                    ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('ERROR: No se pudo eliminar.')", true);
                }
    
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        protected void grdCategorias_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            this.lblResultado.Text = string.Empty;

            TableCell celdaId = grdCategorias.Rows[e.NewSelectedIndex].Cells[1];
            Common.Clases.Categoria cat = new Common.Clases.Categoria();
            cat.Identificador = int.Parse(celdaId.Text);
            cat = Dominio.Fachada.Cateogoria_TraerEspecifica(cat);
            
           

            if (cat != null)
            {
                this.txtId.Text = cat.Identificador.ToString();
                this.txtNombre.Text = cat.Nombre;
                ModoEdicion(true);
            }
            else
            {
                ModoEdicion(false);
                ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('ERROR: No se pudo cargar el dato.')", true);
            }
        }


        protected void ModoEdicion(bool pVisible) 
        {
            this.txtId.Enabled = false;
            this.txtId.Visible = pVisible;
            this.lblIdentificador.Visible = pVisible;
            this.btnActualizar.Visible = pVisible;
            this.btnCancelar.Visible = pVisible;
            this.btnAgregar.Visible = !pVisible;
            
            if(!pVisible)
            {
                this.txtId.Text = string.Empty;
                this.txtNombre.Text = string.Empty;
                this.grdCategorias.SelectedIndex = -1;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ModoEdicion(false);
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Common.Clases.Categoria cat = new Common.Clases.Categoria();
            cat.Identificador = int.Parse(this.txtId.Text);
            cat.Nombre = this.txtNombre.Text;
            
            try
            {
                bool resultado = Dominio.Fachada.Categoria_Modificar(cat);

                if (resultado)
                {
                    lblResultado.Text = "Modificado correctamente.";
                    ActualizarGrillaDeDatos();
                    ModoEdicion(false);
                }
                else
                {
                    lblResultado.Text = "ERROR: No se pudo modificar.";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
     
    }
}
