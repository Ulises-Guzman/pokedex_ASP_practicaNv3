using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pokedex_webapp
{
    public partial class FormularioPokemon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlTipo.Items.Add("Planta");
                ddlTipo.Items.Add("Fuego");
                ddlTipo.Items.Add("Agua");
  

                // Fila seleccionada y Opcion "Modificar" desde la grilla
                // Recupero el id y los datos
                if (Request.QueryString["id"] != null)
                {   
                    int id = int.Parse(Request.QueryString["id"].ToString());
                    
                    //...
                }
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}