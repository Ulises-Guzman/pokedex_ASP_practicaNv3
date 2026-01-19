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
    public partial class ListaPokemon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            gvPokemon.DataSource = negocio.ListarConSP();
            gvPokemon.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioPokemon.aspx");
        }

        protected void gvPokemon_SelectedIndexChanged(object sender, EventArgs e)
        {   
            //Pasa el id del elemento 
            string id = gvPokemon.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioPokemon.aspx?id=" + id);
        }

        protected void gvPokemon_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //Capturo el PageIndex que viene por valor del parametro GrigViewPageEventArgs
            gvPokemon.PageIndex = e.NewPageIndex;
            gvPokemon.DataBind();
        }
    }
}