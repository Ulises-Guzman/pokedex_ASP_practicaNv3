using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace pokedex_webapp
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Recupero el objeto Trainee guardado en session
            //Trainee trainee = Session["trainee"] != null ? (Trainee)Session["trainee"] : null;
            //if (!(trainee != null && trainee.Id != 0))
            //{
            //    Response.Redirect("Login.aspx", false);
            //}

            // Nueva logica con clase seguridad, niega la condicion reformulando a... (!) si es verdad que no hay session activa
            //if (!Seguridad.sessionActiva(Session["trainee"]))
            //    Response.Redirect("Login.aspx", false);

            //Para no estar escribiendo en cada pagina la seguridad, utilizado las propiedades de la masterPage

            // Recuperar los datos para los controles 
            if (!IsPostBack) // Si es la primera vez que se carga la Page. Osea GET.
            {
                if (Seguridad.sessionActiva(Session["trainee"]))
                {
                    Trainee user = (Trainee)Session["trainee"];
                    txtEmail.Text = user.Email;
                    txtNombre.Text = user.Nombre;
                    txtApellido.Text = user.Apellido;
                    //txtFechaNac.Text = user.FechaNacimiento.ToShortDateString() == "01/01/0001" ? "dd/mm/aaa" : user.FechaNacimiento.ToString("yyyy-MM-dd");

                    if (user.FechaNacimiento.ToShortDateString() == "01/01/0001") // Mejor legibilidad
                        txtFechaNac.Text = "dd/mm/aaaa";
                    else
                        txtFechaNac.Text = user.FechaNacimiento.ToString("yyyy-MM-dd");

                    if (!string.IsNullOrEmpty(user.ImagenPerfil)) // me parece que esta validacion la estaba haciendo por master page
                        imgImagenPerfil.ImageUrl = "~/Images/" + user.ImagenPerfil;
                }
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Esto ya es PostBack, se cargan los datos modificados por el usuario

                // Validar si los cajas no son validas, corta con el hilo de ejecucion
                Page.Validate();
                if (!Page.IsValid)
                    return;

                // Escribir img
                TraineeNegocio negocio = new TraineeNegocio();
                Trainee user = (Trainee)Session["trainee"];

                // Escribibe el path de la imagen si se seleccionó alguna
                if (txtImagenPerfil.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Images/");
                    txtImagenPerfil.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".png");
                    user.ImagenPerfil = "perfil-" + user.Id + ".png";
                }

                // Completo el objeto  Trainee user 
                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;
                user.FechaNacimiento = DateTime.Parse(txtFechaNac.Text);
                // falta completar la fecha al objeto

                negocio.actualizar(user);

                // Actualizar la imagen en el avatar
                // Leer img // Acceder a los controles desde el CodeBehind al Front.
                Image imagenAvatar = (Image)Master.FindControl("imgAvatar");
                imagenAvatar.ImageUrl = "~/Images/" + user.ImagenPerfil;

                //Image imgImagenPerfil = (Image)Master.FindControl("imgImagenPerfil");
                imgImagenPerfil.ImageUrl = "~/Images/" + user.ImagenPerfil;
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }

    }
}