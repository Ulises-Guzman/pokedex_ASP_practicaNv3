using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailService()
        {
            //server = new SmtpClient();
            //server.Credentials = new NetworkCredential("ulisesguzman.contacto@gmail.com", "wmlqbkhkbhvujdcg"); // Uso esta cuenta, pero para el caso de ejemplo es por notificacion del sistema. EmailDestino
            //server.EnableSsl = true;
            //server.Port = 587; //465 //Funcionó con CdA y P587
            //server.Host = "smtp.gmail.com";

            // Nueva configuracion de EmailService con MailTrap

            server = new SmtpClient();
            server.Credentials = new NetworkCredential("cb1ced2a551fe2", "aaf04c250e7a31"); // Uso esta cuenta, pero para el caso de ejemplo es por notificacion del sistema. EmailDestino
            server.EnableSsl = true;
            server.Port = 2525; //465 //Funcionó con CdA y P587
            server.Host = "sandbox.smtp.mailtrap.io";

            // Nueva configuracion de EmailService con MailTrap
        }

        // Está en funcion de enviar un correo como notificacion de alguna accion
        public void ArmarCorreo(string emailDestino, string asunto, string cuerpo)
        {
            email = new MailMessage();
            //email.From = new MailAddress("noresponder@ecommercetest.com");
            email.From = new MailAddress("noresponder@webapp.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            //email.Body = "<h1>Notificación de acción</h1> <hr /> <p>Hola esta es la notificacion: ################# <p>";
            email.Body = cuerpo; // Cuand lo uso para form de contacto
        }

        public void EnviarEmail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
