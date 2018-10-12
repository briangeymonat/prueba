using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ejemplo.Web
{
    public partial class Fabricacion_Automovil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ActualizarDDLModelo();
                ActualizarGrillaCantTipo();
                ActualizarGrillaPieza();
                ActualizarLabels();
                ModoEdicion(true);
            }
        }
        protected void ActualizarDDLModelo()
        {
            this.DDLModelo.DataSource = Dominio.Fachada.Automovil_TraerTodas();
            this.DDLModelo.DataTextField = "Modelo";
            this.DDLModelo.DataValueField = "Id";
            this.DDLModelo.DataBind();
        }
        protected void ModoEdicion(bool pVisible)
        {
            this.grdPiezaAuto.SelectedIndex = -1;
            this.grdTipoOpAuto.SelectedIndex = -1;
        }

        #region ACTUALIZAR DATOS DEL MODELO

        protected void ActualizarGrillaPieza()
        {
            if (DDLModelo.SelectedValue != string.Empty)
            {
                Common.Clases.Automovil auto = new Common.Clases.Automovil();
                auto.Id = int.Parse(DDLModelo.SelectedValue);
                List<Common.Clases.Pieza_Automovil> lstPA = Dominio.Fachada.TraerPiezaXAutomovil(auto);
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
        protected void ActualizarGrillaCantTipo()
        {
            if ( DDLModelo.SelectedValue != string.Empty)
            { 
                Common.Clases.Automovil auto = new Common.Clases.Automovil();
                auto.Id = int.Parse(DDLModelo.SelectedValue);
                List<Common.Clases.CantTipoXAutomovil> lstTO = Dominio.Fachada.CantTipoXAutomovil(auto);
                this.grdTipoOpAuto.DataSource = lstTO;
                this.grdTipoOpAuto.DataBind();
            }
        }
        protected void ActualizarLabels()
        {
            if (DDLModelo.SelectedValue != string.Empty)
            {
                Common.Clases.Automovil auto = new Common.Clases.Automovil();
                auto.Id = int.Parse(DDLModelo.SelectedValue);
                this.lblCantOpe.Text = Dominio.Fachada.CantOpXAutomovil(auto).ToString();
                this.lblTiempoFabricacion.Text = Dominio.Fachada.HorasXAutomovil(auto).ToString();
                this.lblCosto.Text = Dominio.Fachada.CostoXAutomovil(auto).ToString();
            }
        }

        #endregion

        protected void DDLModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarGrillaCantTipo();
            ActualizarGrillaPieza();
            ActualizarLabels();
            
        }
    }
}