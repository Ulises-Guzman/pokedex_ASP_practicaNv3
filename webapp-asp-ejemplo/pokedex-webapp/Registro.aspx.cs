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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", false);
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                Trainee user = new Trainee();
                TraineeNegocio traineeNegocio = new TraineeNegocio();
                EmailService emailService = new EmailService();

                user.Email = txtEmail.Text;
                user.Pass = txtContrasena.Text;
                // Modificacmos y completamos el objeto con el id
                //int id = traineeNegocio.InsertarNuevo(user);
                user.Id = traineeNegocio.InsertarNuevo(user);
                Session.Add("trainee", user); // queda la session cargada y abierta, quedando asi definido el registro con auto login

                emailService.ArmarCorreo(user.Email, "Bienvenida Trainee" ,"Hola te damos la bienvenida a la WepApp...");
                emailService.EnviarEmail();
                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }
    }
}