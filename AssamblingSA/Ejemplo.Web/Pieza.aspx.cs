using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ejemplo.Web
{
    public partial class Pieza : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ActualizarDDLSectorPieza();
                ActualizarGrillaDeDatos();
            }
        }

        protected void ActualizarDDLSectorPieza()
        {
            this.DDLSectorPieza.DataSource = Dominio.Fachada.TraerTodos_SA();
            this.DDLSectorPieza.DataTextField = "Cod_SA";
            this.DDLSectorPieza.DataValueField = "Cod_SA";
            this.DDLSectorPieza.DataBind();
        }
        protected void ActualizarGrillaDeDatos()
        {
            List<Common.Clases.Pieza> lstPieza = Dominio.Fachada.Pieza_TraerTodas();
            List<PiezaPresentacion> lstNew = new List<PiezaPresentacion>();
            foreach(Common.Clases.Pieza pieza in lstPieza)
            {
                PiezaPresentacion piezaNew = new PiezaPresentacion();
                piezaNew.Cod_pieza = pieza.Cod_pieza;
                piezaNew.Nom_pieza = pieza.Nom_pieza;
                piezaNew.Valor_pieza = pieza.Valor_pieza;
                piezaNew.Cod_SA = pieza.SA.Cod_SA;
                lstNew.Add(piezaNew);
            }
            this.grdPieza.DataSource = lstNew;
            this.grdPieza.DataBind();
        }
        protected void LimpiarCampos()
        {
            this.txtId.Text = string.Empty;
            this.txtNombreP.Text = string.Empty;
            this.txtValorP.Text = string.Empty;
        }
        protected void ModoEdicion(bool pVisible)
        {
            this.btnActualizar.Visible = pVisible;
            this.btnCancelar.Visible = pVisible;
            this.btnAgregar.Visible = !pVisible;

            if (!pVisible)
            {
                this.txtId.Text = string.Empty;
                this.txtNombreP.Text = string.Empty;
                this.txtValorP.Text = string.Empty;
                this.grdPieza.SelectedIndex = -1;
            }
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Common.Clases.Pieza pieza = new Common.Clases.Pieza();
            pieza.Cod_pieza = int.Parse(this.txtId.Text);
            pieza.Nom_pieza = this.txtNombreP.Text;
            pieza.Valor_pieza = int.Parse(this.txtValorP.Text);
            Common.Clases.Sector_Actividad sec = new Common.Clases.Sector_Actividad();
            sec.Cod_SA = DDLSectorPieza.SelectedValue;
            pieza.SA = sec;
            try
            {
                Common.Clases.Pieza p = Dominio.Fachada.Pieza_TraerEspecifica(pieza);
                if (p == null)
                {
                    bool resultado = Dominio.Fachada.Pieza_Agregar(pieza);

                    if (resultado)
                    {
                        lblResultado.Text = "Agregada correctamente.";
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
                    lblResultado.Text = "Ya existe una pieza con el mismo id";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Common.Clases.Pieza pieza = new Common.Clases.Pieza();
            pieza.Cod_pieza = int.Parse(this.txtId.Text);
            pieza.Nom_pieza = this.txtNombreP.Text;
            pieza.Valor_pieza = int.Parse(this.txtValorP.Text);
            Common.Clases.Sector_Actividad sec = new Common.Clases.Sector_Actividad();
            sec.Cod_SA = DDLSectorPieza.SelectedValue;
            pieza.SA = sec;

            try
            {
                bool resultado = Dominio.Fachada.Pieza_Modificar(pieza);

                if (resultado)
                {
                    lblResultado.Text = "Modificada correctamente.";
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

        protected void grdPieza_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            this.lblResultado.Text = string.Empty;

            TableCell celdaId = grdPieza.Rows[e.NewSelectedIndex].Cells[1];
            Common.Clases.Pieza pieza = new Common.Clases.Pieza();
            pieza.Cod_pieza = int.Parse(celdaId.Text);
            pieza = Dominio.Fachada.Pieza_TraerEspecifica(pieza);



            if (pieza != null)
            {
                this.txtId.Text = pieza.Cod_pieza.ToString();
                this.txtNombreP.Text = pieza.Nom_pieza.ToString();
                this.txtValorP.Text = pieza.Valor_pieza.ToString();
                DDLSectorPieza.SelectedValue = pieza.SA.Cod_SA.ToString();
                ModoEdicion(true);
            }
            else
            {
                ModoEdicion(false);
                ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('ERROR: No se pudo cargar el dato.')", true);
            }
        }

        protected void grdPieza_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                this.lblResultado.Text = string.Empty;

                TableCell celdaId = grdPieza.Rows[e.RowIndex].Cells[1];
                Common.Clases.Pieza pieza = new Common.Clases.Pieza();
                pieza.Cod_pieza = int.Parse(celdaId.Text);

                bool resultado = Dominio.Fachada.Pieza_Eliminar(pieza);

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

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ModoEdicion(false);
        }
    }
}