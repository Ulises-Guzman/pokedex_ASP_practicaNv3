using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace pokedex_webapp
{
    public partial class EnvioEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            EmailService emailService = new EmailService();
            emailService.ArmarCorreo(txtEmail.Text, txtAsunto.Text, txtMensaje.Text);

            try
            {
                emailService.EnviarEmail();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }
    }
}