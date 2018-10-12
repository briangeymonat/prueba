using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ejemplo.Web
{
    public partial class Trabaja : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Actualizar_DDLs();
                ActualizarGrillaDeDatos();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Common.Clases.Trabaja pTra = new Common.Clases.Trabaja();

            Common.Clases.Automovil auto = new Common.Clases.Automovil();
            auto.Id = int.Parse(this.DDLModelo.SelectedValue);
            pTra.Automovil = auto;

            Common.Clases.Operario ope = new Common.Clases.Operario();
            ope.Ci = this.DDLOperario.SelectedValue;
            pTra.Operario = ope;

            Common.Clases.Sector_Actividad s = new Common.Clases.Sector_Actividad();
            s.Cod_SA = this.DDLSector.SelectedValue;

            pTra.S_A = s;
            pTra.Cant_horas = int.Parse(this.txtCantHoras.Text);

            try
            {
                bool x = Dominio.Fachada.ExisteTrabajo(pTra.Operario, pTra.S_A, pTra.Automovil);
                if (!x)
                {
                    bool resultado = Dominio.Fachada.TrabajaAgregar(pTra);

                    if (resultado)
                    {
                        lblResultado.Text = "Agregado correctamente.";
                        this.txtCantHoras.Text = string.Empty;
                        this.ActualizarGrillaDeDatos();
                    }
                    else
                    {
                        lblResultado.Text = "ERROR: No se pudo agregar";
                        this.txtCantHoras.Text = string.Empty;
                        this.ActualizarGrillaDeDatos();
                    }
                }
                else
                    lblResultado.Text = "No se puede ingresar, el operario ya esta trabajando en el sector ingresado en el auto ingresado";
                this.txtCantHoras.Text = string.Empty;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
        protected void Actualizar_DDLs()
        {
            this.DDLModelo.DataSource = Dominio.Fachada.Automovil_TraerTodas();
            this.DDLModelo.DataTextField = "Modelo";
            this.DDLModelo.DataValueField = "Id";
            this.DDLModelo.DataBind();

            this.DDLOperario.DataSource = Dominio.Fachada.Operario_TraerTodas();
            this.DDLOperario.DataTextField = "Nombre";
            this.DDLOperario.DataValueField = "Ci";
            this.DDLOperario.DataBind();

            this.DDLSector.DataSource = Dominio.Fachada.TraerTodos_SA();
            this.DDLSector.DataTextField = "Cod_SA";
            this.DDLSector.DataValueField = "Cod_SA";
            this.DDLSector.DataBind();
        }
        protected void ActualizarGrillaDeDatos()
        {
            if (DDLModelo.SelectedValue != string.Empty)
            {
                Common.Clases.Trabaja tra = new Common.Clases.Trabaja();
                tra.Automovil = new Common.Clases.Automovil();
                tra.Automovil.Id = int.Parse(DDLModelo.SelectedValue);
                List<Common.Clases.Trabaja> lstTrabajo = Dominio.Fachada.TraerDatos_Trabaja(tra);
                List<JornadaTrabajo> lstNew = new List<JornadaTrabajo>();

                foreach(Common.Clases.Trabaja trabaja in lstTrabajo)
                {
                    JornadaTrabajo trabajaNew = new JornadaTrabajo();
                    trabajaNew.Ci = trabaja.Operario.Ci;
                    trabajaNew.Nom = trabaja.Operario.Nombre;
                    trabajaNew.Cod_SA = trabaja.S_A.Cod_SA;
                    trabajaNew.cantidad_Horas = trabaja.Cant_horas;
                    lstNew.Add(trabajaNew);
                }
                this.grdTrabaja.DataSource = lstNew;
                this.grdTrabaja.DataBind();
            }

        }

        protected void DDLModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarGrillaDeDatos();
        }

        protected void grdTrabaja_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                this.lblResultado.Text = string.Empty;

                Common.Clases.Trabaja pTra = new Common.Clases.Trabaja();
                Common.Clases.Automovil auto = new Common.Clases.Automovil();
                auto.Id = int.Parse(this.DDLModelo.SelectedValue);
                pTra.Automovil = auto;

                TableCell celdaCi = grdTrabaja.Rows[e.RowIndex].Cells[1];
                Common.Clases.Operario ope = new Common.Clases.Operario();
                ope.Ci = celdaCi.Text;
                pTra.Operario = ope;

                TableCell celdaSector = grdTrabaja.Rows[e.RowIndex].Cells[3];
                Common.Clases.Sector_Actividad s = new Common.Clases.Sector_Actividad();
                s.Cod_SA = celdaSector.Text;
                pTra.S_A = s;

                bool resultado = Dominio.Fachada.TrabajaEliminar(pTra);

                if (resultado)
                {
                    ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Eliminado exitosamente.')", true);
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
    }
}