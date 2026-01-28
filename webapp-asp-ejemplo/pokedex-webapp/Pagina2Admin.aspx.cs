using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pokedex_webapp
{
    public partial class Pagina2Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Validacion si no(!) sos admin. Tambien refactorizar en una funcion, como clase helper o metodo dentro de clase Usuario.
            if (!(Session["usuario"] != null && ((dominio.Usuario)Session["usuario"]).TipoUsuario == dominio.TipoUsuario.ADMIN))
            {
                Session.Add("error","No tienes permiso de administrador...");
                Response.Redirect("Error.aspx", false);
            }

            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes iniciar sesión para ingresar...");
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}