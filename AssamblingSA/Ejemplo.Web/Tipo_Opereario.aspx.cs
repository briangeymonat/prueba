using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ejemplo.Web
{
    public partial class Tipo_Opereario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ModoEdicion(false);
            ActualizarGrillaDeDatos();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Common.Clases.Tipo_Operario tipo = new Common.Clases.Tipo_Operario();
            tipo.Nom_TO = this.txtNombre.Text;
            tipo.Valor_hora_TO = int.Parse(this.txtValor.Text);

            try
            {
                Common.Clases.Tipo_Operario to = Dominio.Fachada.TipoOperario_TraerEspecifica(tipo);
                if (to == null)
                {
                    bool resultado = Dominio.Fachada.TipoOperario_Agregar(tipo);

                    if (resultado)
                    {
                        lblResultado.Text = "Agregado Correctamente. ";
                        LimpiarCampos();
                        ActualizarGrillaDeDatos();
                    }
                    else
                    {
                        lblResultado.Text = "ERROR: No se pudo agregar.";
                    }
                }
                else
                {
                    lblResultado.Text = "Hay un tipo de operario con ese nombre ya agregado";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ActualizarGrillaDeDatos()
        {
            this.grdTipoOp.DataSource = Dominio.Fachada.TipoOperario_TraerTodos();
            this.grdTipoOp.DataBind();
        }

        protected void LimpiarCampos()
        {
            this.txtNombre.Text = string.Empty;
            this.txtValor.Text = string.Empty;
        }

        protected void ModoEdicion(bool pVisible)
        {
            this.btnActualizar.Visible = pVisible;
            this.btnCancelar.Visible = pVisible;
            this.btnAgregar.Visible = !pVisible;

            if (!pVisible)
            {
                this.grdTipoOp.SelectedIndex = -1;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ModoEdicion(false);
        }

        protected void grdTipoOp_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                this.lblResultado.Text = string.Empty;

                TableCell celdaId = grdTipoOp.Rows[e.RowIndex].Cells[1];
                Common.Clases.Tipo_Operario tipo = new Common.Clases.Tipo_Operario();
                tipo.Nom_TO = celdaId.Text;

                bool resultado = Dominio.Fachada.TipoOperario_Eliminar(tipo);

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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdTipoOp_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            this.lblResultado.Text = string.Empty;

            TableCell celdaId = grdTipoOp.Rows[e.NewSelectedIndex].Cells[1];
            Common.Clases.Tipo_Operario tipo = new Common.Clases.Tipo_Operario();
            tipo.Nom_TO = celdaId.Text;
            tipo = Dominio.Fachada.TipoOperario_TraerEspecifica(tipo);



            if (tipo != null)
            {
                
                this.txtNombre.Text = tipo.Nom_TO;
                this.txtValor.Text = tipo.Valor_hora_TO.ToString();
                ModoEdicion(true);
            }
            else
            {
                ModoEdicion(false);
                ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('ERROR: No se pudo cargar el dato.')", true);
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Common.Clases.Tipo_Operario tipo = new Common.Clases.Tipo_Operario();
            tipo.Nom_TO = this.txtNombre.Text;
            tipo.Valor_hora_TO = int.Parse(this.txtValor.Text);

            try
            {
                bool resultado = Dominio.Fachada.TipoOperario_Modificar(tipo);

                if (resultado)
                {
                    lblResultado.Text = "Modificado correctamente.";
                    ActualizarGrillaDeDatos();
                    ModoEdicion(false);
                    LimpiarCampos();
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