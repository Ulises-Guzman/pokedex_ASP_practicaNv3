using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using System.Runtime.InteropServices;
using System.Threading;

namespace pokedex_webapp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            // Fue utilizado para los ejemplos de aprendisaje //
            //Usuario usuario;
            //UsuarioNegocio negocio = new UsuarioNegocio();
            //try
            //{
            //    usuario = new Usuario(txtUsuario.Text, txtContrasena.Text, false); // Le paso false porque tiene que estar el parametro por el contructor que lo pide. Despues la DB lo pisa cuado completa el objeto.
            //    if (negocio.Loguear(usuario))
            //    {
            //        Session.Add("usuario", usuario);
            //        Response.Redirect("MenuLogin.aspx", false);
            //    }
            //    else
            //    {
            //        Session.Add("error", "Usuario o Contrseña incorrectos");
            //        Response.Redirect("Error.aspx", false);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Session.Add("error", ex.ToString());
            //    Response.Redirect("Error.aspx");
            //}

            // Nueva Logica para la WebApp //
            Trainee trainee = new Trainee();
            TraineeNegocio negocio = new TraineeNegocio();
            try
            {
                //if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtContrasena.Text))
                //{
                //    Session.Add("error", "Debes completar todo los campos...");
                //    Response.Redirect("Error.aspx", false);
                //}

                //Refactorizacion
                if (Validacion.validaTextVacio(txtEmail) || Validacion.validaTextVacio(txtContrasena))
                {
                    Session.Add("error", "Debes completar todos los campos...");
                    //Response.Redirect("Error.aspx", false); // verificar aca, porque si no corta el hilo va a seguir con el hilode ejecucion
                    Response.Redirect("Error.aspx");
                }

                trainee.Email = txtEmail.Text;
                trainee.Pass = txtContrasena.Text;
                if (negocio.Login(trainee)) // Esto va a comprobar si logueó: (true or false), y devolver: el id del user, y si es admin.
                {
                    Session.Add("trainee", trainee); // Guardo en session el obj trainee. 
                    // A partir de aca... diseñar la logica de seguridad para la navegacion entre paginas
                    Response.Redirect("MiPerfil.aspx", false);
                }
                else
                {
                    Session.Add("error", "Usuario o Contraseña incorrectos...");
                    Response.Redirect("Error.aspx", false);
                }
            }
            //catch (System.Threading.ThreadAbortException ex) { } // truco 1  // Considero el corte de hilo de ejecucion de la validacion de campos vacios
            catch (Exception ex)
            {
                if (!(ex is ThreadAbortException)) // truco 2
                {
                    Session.Add("error", ex.ToString());
                    Response.Redirect("Error.aspx", false);
                }
            }
        }
    }
}