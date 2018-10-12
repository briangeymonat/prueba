using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ejemplo.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SesionIniciada(bool pVisible)
        {
            this.tableLogin.Visible = !pVisible;
        }
        protected void LimpiarCampos()
        {
            this.usuario.Text = string.Empty;
            this.pass.Text = string.Empty;
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Common.Clases.Cuenta pCuenta = new Common.Clases.Cuenta();
            pCuenta.Usuario = this.usuario.Text;
            pCuenta.Contraseña = this.pass.Text;
            Common.Clases.Cuenta existe = Dominio.Fachada.Verificar(pCuenta);
            if (existe != null)
            {
                SesionIniciada(true);
                LimpiarCampos();
                Response.Redirect("Default.aspx");
            }
            else
            {
                SesionIniciada(false);
                lblresultado.Text = "Usuario o contraseña incorrecta.";
                LimpiarCampos();
            }
        }
}
}