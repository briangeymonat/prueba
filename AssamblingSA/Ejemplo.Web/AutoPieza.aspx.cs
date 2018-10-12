using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ejemplo.Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { 
                ActualizarDDLAuto();
                ActualizarDDLPieza();
                ActualizarGrillaDeDatos();
            }
        }
        protected void ActualizarGrillaDeDatos()
        {
            if (DDLAuto.SelectedValue != string.Empty)
            {
                Common.Clases.Automovil pAuto = new Common.Clases.Automovil();
                pAuto.Id = int.Parse(DDLAuto.SelectedValue);
                List<Common.Clases.Pieza_Automovil> lstPA = Dominio.Fachada.TraerPiezaXAutomovil(pAuto);
                List<PiezaAutomovilPresentacion> lstNew = new List<PiezaAutomovilPresentacion>();
                foreach(Common.Clases.Pieza_Automovil pieza in lstPA)
                {
                    PiezaAutomovilPresentacion piezaNew = new PiezaAutomovilPresentacion();
                    piezaNew.Cod_pieza = pieza.Pieza.Cod_pieza;
                    piezaNew.Nom_pieza = pieza.Pieza.Nom_pieza;
                    piezaNew.Valor_pieza = pieza.Pieza.Valor_pieza;
                    piezaNew.Cod_SA = pieza.Pieza.SA.Cod_SA;
                    piezaNew.Cantidad = pieza.Cantidad;
                    lstNew.Add(piezaNew);
                }

                this.grdPiezaAuto.DataSource = lstNew;
                this.grdPiezaAuto.DataBind();
            }
        }
        protected void ActualizarDDLAuto()
        {
            this.DDLAuto.DataSource = Dominio.Fachada.Automovil_TraerTodas();
            this.DDLAuto.DataTextField = "Modelo";
            this.DDLAuto.DataValueField = "Id";
            this.DDLAuto.DataBind();
        }
        protected void ActualizarDDLPieza()
        {
            this.DDLPieza.DataSource = Dominio.Fachada.Pieza_TraerTodas();
            this.DDLPieza.DataTextField = "Nom_pieza";
            this.DDLPieza.DataValueField = "Cod_pieza";
            this.DDLPieza.DataBind();
        }
        
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Common.Clases.Automovil pAuto = new Common.Clases.Automovil();
            pAuto.PiezasAuto = new List<Common.Clases.Pieza_Automovil>();
            pAuto.Id = int.Parse(DDLAuto.SelectedValue);
            Common.Clases.Pieza_Automovil pPiezaA = new Common.Clases.Pieza_Automovil();
            Common.Clases.Pieza piezaSola = new Common.Clases.Pieza();
            piezaSola.Cod_pieza = int.Parse(DDLPieza.SelectedValue);
            pPiezaA.Pieza = piezaSola;
            pPiezaA.Cantidad = int.Parse(txtCantPieza.Text);
            pAuto.PiezasAuto.Add(pPiezaA);

            try
            {
                bool x = Dominio.Fachada.ExistePiezaAutomovil(pAuto, piezaSola);
                if (!x)
                {

                    bool resultado = Dominio.Fachada.AgregarPiezaAutomovil(pAuto);

                    if (resultado)
                    {
                        lblResultado.Text = "Agregado Correctamente. ";
                        ActualizarGrillaDeDatos();
                    }
                    else
                    {
                        lblResultado.Text = "ERROR: No se pudo agregar. ";
                    }
                }
                else
                    lblResultado.Text = "Ya hay un registro de esa pieza en el auto indicado";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdPiezaAuto_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                this.lblResultado.Text = string.Empty;

                Common.Clases.Pieza_Automovil pPiezaA = new Common.Clases.Pieza_Automovil();
                TableCell celdaId = grdPiezaAuto.Rows[e.RowIndex].Cells[1];
                Common.Clases.Automovil auto = new Common.Clases.Automovil();
                auto.Id = int.Parse(DDLAuto.Text);
                pPiezaA.Pieza = new Common.Clases.Pieza();
                pPiezaA.Pieza.Cod_pieza = int.Parse(celdaId.Text);
                auto.PiezasAuto = new List<Common.Clases.Pieza_Automovil>();
                auto.PiezasAuto.Add(pPiezaA);
                bool resultado = Dominio.Fachada.EliminarPiezaAutomovil(auto);

                if (resultado)
                {
                    ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Eliminado exitosamente. ')", true);
                    ActualizarGrillaDeDatos();
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

        protected void DDLAuto_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ActualizarGrillaDeDatos();
        }

    }
}