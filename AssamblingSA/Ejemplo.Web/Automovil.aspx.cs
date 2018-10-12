using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ejemplo.Web
{
    public partial class Automovil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ModoEdicion(false);
            ActualizarGrillaDeDatos();
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
         {
            Common.Clases.Automovil auto = new Common.Clases.Automovil();
            auto.Modelo = this.txtModelo.Text;
            try
            {
                bool resultado = Dominio.Fachada.Automovil_Agregar(auto);

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
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void ActualizarGrillaDeDatos()
        {
            this.grdAutomovil.DataSource = Dominio.Fachada.Automovil_TraerTodas();
            this.grdAutomovil.DataBind();
        }
        protected void LimpiarCampos()
        {
           this.txtModelo.Text = string.Empty;
        }
        protected void grdAutomovil_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                this.lblResultado.Text = string.Empty;

                TableCell celdaId = grdAutomovil.Rows[e.RowIndex].Cells[1];
                Common.Clases.Automovil auto = new Common.Clases.Automovil();
                auto.Id = int.Parse(celdaId.Text);

                bool resultado = Dominio.Fachada.Automovil_Eliminar(auto);

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
        protected void ModoEdicion(bool pVisible)
        {
            this.btnActualizar.Visible = pVisible;
            this.btnCancelar.Visible = pVisible;
            this.btnAgregar.Visible = !pVisible;

            if (!pVisible)
            {
                
                this.grdAutomovil.SelectedIndex = -1;
            }
        }
        protected void grdAutomovil_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            this.lblResultado.Text = string.Empty;

            TableCell celdaId = grdAutomovil.Rows[e.NewSelectedIndex].Cells[1];
            Common.Clases.Automovil auto = new Common.Clases.Automovil();
            auto.Id = int.Parse(celdaId.Text);
            auto = Dominio.Fachada.Automovil_TraerEspecifica(auto);



            if (auto != null)
            {
                this.txtId.Text = auto.Id.ToString();
                this.txtModelo.Text = auto.Modelo.ToString();
                ModoEdicion(true);
            }
            else
            {
                ModoEdicion(false);
                ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('ERROR: No se pudo cargar el dato.')", true);
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ModoEdicion(false);
        }
        protected void btnActualizar_Click(object sender, EventArgs e)
        {

            Common.Clases.Automovil auto = new Common.Clases.Automovil();
            auto.Id = int.Parse(this.txtId.Text);
            auto.Modelo = this.txtModelo.Text;
            try
            {
                bool resultado = Dominio.Fachada.Automovil_Modificar(auto);

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