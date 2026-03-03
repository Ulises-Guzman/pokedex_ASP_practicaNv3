using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;

namespace pokedex_webapp
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //imgAvatar.ImageUrl = "https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_1280.png";
            // Aqui manejo la logica para producir la validadcion en todas la Page con estan conteidas en la masterPage.
            if (!(Page is Login || Page is Registro || Page is Default || Page is Error)) //Exceptuo estas Pages de la seguridad.
            {
                if (!Seguridad.sessionActiva(Session["trainee"]))
                    Response.Redirect("Login.aspx", false);
                else
                {
                    Trainee user = (Trainee)Session["trainee"];

                    if (!string.IsNullOrEmpty(user.ImagenPerfil))
                    {
                        imgAvatar.ToolTip = user.Email;
                        imgAvatar.ImageUrl = "~/Images/" + user.ImagenPerfil;
                        //imgAvatar.ImageUrl = "~/Images/" + ((Trainee)Session["trainee"]).ImagenPerfil;
                    }
                }

                //// Refactoring
                //if (!Seguridad.sessionActiva(Session["trainee"]))
                //{
                //    imgAvatar.ImageUrl = "https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_1280.png";
                //}
                //else if (Seguridad.sessionActiva(Session["trainee"]) && (((Trainee)Session["trainee"]).ImagenPerfil) is null)
                //    imgAvatar.ImageUrl = "https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_1280.png";
                //else
                //    imgAvatar.ImageUrl = "~/Images/" + ((Trainee)Session["trainee"]).ImagenPerfil;
            }

            // Para precargar la imagen default
            // Accedo al objeto imgAvatar de tipo Image creado en el front de la MasterPage , a su atributo .ImageUrl,
            // para crear la ruta de la imagen de perfil
            //if (Seguridad.sessionActiva(Session["trainee"]))
            //    imgAvatar.ImageUrl = "~/Images/" + ((Trainee)Session["trainee"]).ImagenPerfil; (esto se puede resolver en un metodo de Accesorio/helper)
            //else
            //    imgAvatar.ImageUrl = "https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_1280.png";

            // Refactoring
            //if (!Seguridad.sessionActiva(Session["trainee"]))
            //    imgAvatar.ImageUrl = "https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_1280.png";
            //else if (Seguridad.sessionActiva(Session["trainee"]) && (((Trainee)Session["trainee"]).ImagenPerfil) is null)
            //    imgAvatar.ImageUrl = "https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_1280.png";
            //else
            //    imgAvatar.ImageUrl = "~/Images/" + ((Trainee)Session["trainee"]).ImagenPerfil;
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear(); // el profe usa solo este
            Session.Abandon();
            Session.RemoveAll();
            Response.Redirect("Login.aspx", false);
        }
    }
}