using dominio;
using negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pokedex_webapp
{
    public partial class ListaPokemon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            Session.Add("listaPokemons", negocio.ListarConSP());
            gvPokemon.DataSource = Session["listaPokemons"];
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

            // Enlazo la siguiente pagina del GridView persistiendo los datos filtrados.
            if (chkFiltroAvanzado.Checked)
            {   
                // Forcé el evento, deberia crar un metodo que realice la accion.
                btnBuscar_Click(sender, e);
            }
            
            gvPokemon.DataBind();
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Pokemon> lista = (List<Pokemon>)Session["listaPokemons"];
            List<Pokemon> listaFiltrada = new List<Pokemon>();

            listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            gvPokemon.DataSource = listaFiltrada;
            gvPokemon.DataBind();
        }

        protected void chkFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            txtFiltro.Enabled = !chkFiltroAvanzado.Checked;
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            if (ddlCampo.SelectedItem.ToString() == "Número")
            {
                ddlCriterio.Items.Add("Igual a");
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
            }
            else
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
            }
        }

        protected void ddlCriterio_Init(object sender, EventArgs e)
        {
            ddlCriterio.Items.Add("Contiene");
            ddlCriterio.Items.Add("Comienza con");
            ddlCriterio.Items.Add("Termina con");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                PokemonNegocio negocio = new PokemonNegocio();
                List<Pokemon> listaFiltroAvanzado = new List<Pokemon>();
                listaFiltroAvanzado = negocio.filtrar(
                                                    ddlCampo.SelectedItem.ToString(),
                                                    ddlCriterio.SelectedItem.ToString(),
                                                    txtFiltrar.Text,
                                                    ddlEstado.SelectedItem.ToString());
                gvPokemon.DataSource = listaFiltroAvanzado;
                gvPokemon.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            
            txtFiltrar.Text = "";
            Session.Add("listaPokemons", negocio.ListarConSP());
            gvPokemon.DataSource = null;
            gvPokemon.DataSource = Session["listaPokemons"];
            gvPokemon.DataBind();
        }
    }
}