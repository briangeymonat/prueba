using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ejemplo.Web
{
    public partial class Operario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ModoEdicion(false);
                ActualizarGrillaDeDatos();
                ActualizarDDLTipo();
            }
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Common.Clases.Operario ope = new Common.Clases.Operario();
            ope.Ci = this.txtCi.Text;
            ope.Nombre = this.txtNombre.Text;
            ope.Direccion = this.txtDireccion.Text;
            ope.Telefono = this.txtTelefono.Text;
            Common.Clases.Tipo_Operario pTo = new Common.Clases.Tipo_Operario();
            pTo.Nom_TO = DDLTipo.SelectedItem.ToString();
            ope.Tipo_op = pTo;

            try
            {
                Common.Clases.Operario op = Dominio.Fachada.Operario_TraerEspecifica(ope);
                if (op == null)
                {
                    bool resultado = Dominio.Fachada.Operario_Agregar(ope);

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
                    lblResultado.Text = "Ya existe un operario con esta ci";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void ActualizarDDLTipo()
        {
            this.DDLTipo.DataSource = Dominio.Fachada.TipoOperario_TraerTodos();
            this.DDLTipo.DataTextField = "Nom_TO";
            this.DDLTipo.DataValueField = "Nom_TO";
            this.DDLTipo.DataBind();
        }
        protected void ActualizarGrillaDeDatos()
        {
            List<Common.Clases.Operario> lstOp = Dominio.Fachada.Operario_TraerTodas();
            List<OperarioPresentacion> lstNew = new List<OperarioPresentacion>();
            foreach(Common.Clases.Operario operario in lstOp)
            {
                OperarioPresentacion opNew = new OperarioPresentacion();
                opNew.Ci = operario.Ci;
                opNew.Nombre = operario.Nombre;
                opNew.Direccion = operario.Direccion;
                opNew.Telefono = operario.Telefono;
                opNew.Nom_TO = operario.Tipo_op.Nom_TO;
                lstNew.Add(opNew);
            }

            this.grdOperarios.DataSource = lstNew;
            this.grdOperarios.DataBind();
        }
        protected void LimpiarCampos()
        {
            this.txtCi.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            DDLTipo.SelectedIndex = 0;
        }
        protected void grdOperarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                this.lblResultado.Text = string.Empty;

                TableCell celdaId = grdOperarios.Rows[e.RowIndex].Cells[1];
                Common.Clases.Operario ope = new Common.Clases.Operario();
                ope.Ci = celdaId.Text;

                bool resultado = Dominio.Fachada.Operario_Eliminar(ope);

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
        protected void grdOperarios_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            this.lblResultado.Text = string.Empty;

            TableCell celdaId = grdOperarios.Rows[e.NewSelectedIndex].Cells[1];
            Common.Clases.Operario ope = new Common.Clases.Operario();
            ope.Ci = celdaId.Text;
            ope = Dominio.Fachada.Operario_TraerEspecifica(ope);



            if (ope != null)
            {
                this.txtCi.Text = ope.Ci.ToString();
                this.txtNombre.Text = ope.Nombre;
                this.txtDireccion.Text = ope.Direccion;
                this.txtTelefono.Text = ope.Telefono;
                Common.Clases.Tipo_Operario pTo = new Common.Clases.Tipo_Operario();
                pTo.Nom_TO = ope.Tipo_op.Nom_TO;
                this.DDLTipo.SelectedValue = pTo.Nom_TO;
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
            this.btnActualizar.Visible = pVisible;
            this.btnCancelar.Visible = pVisible;
            this.btnAgregar.Visible = !pVisible;

            if (!pVisible)
            {
               this.grdOperarios.SelectedIndex = -1;
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ModoEdicion(false);
            LimpiarCampos();
        }
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Common.Clases.Operario ope = new Common.Clases.Operario();
            ope.Ci = this.txtCi.Text;
            ope.Nombre = this.txtNombre.Text;
            ope.Direccion = this.txtDireccion.Text;
            ope.Telefono = this.txtTelefono.Text;
            Common.Clases.Tipo_Operario pTo = new Common.Clases.Tipo_Operario();
            pTo.Nom_TO = DDLTipo.SelectedItem.Text;
            ope.Tipo_op = pTo;

            try
            {
                bool resultado = Dominio.Fachada.Operario_Modificar(ope);

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
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}