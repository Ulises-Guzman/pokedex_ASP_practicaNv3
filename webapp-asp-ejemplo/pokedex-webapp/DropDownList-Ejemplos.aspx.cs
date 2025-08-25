using negocio;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pokedex_webapp
{
    public partial class DropDownList_Ejemplos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {  
            PokemonNegocio pokemonNegocio = new PokemonNegocio();

            //< inicio >
            //Para el desplegable enlazado 
            PokemonNegocio negocio  = new PokemonNegocio();
            //aqui el profe tiene un objeto del tipo TipoNegocio, este no esta en las practicas
            //ej. TipoNegocio negocioTipo = new TipoNegocio

            //uso esto a ver si funciona(elemento=tipo)
            ElementoNegocio negocioElemento = new ElementoNegocio();
            //< corte >
            try
            {
                if (!IsPostBack)
                {
                    //Cargo el desplagable desde la DB con un SP
                    ddlPokemons.DataSource = pokemonNegocio.ListarNombreConSP();
                    ddlPokemons.DataValueField = "Id";
                    ddlPokemons.DataTextField = "Nombre";
                    ddlPokemons.DataBind();
                }
            //< corte >
                //Para dropDownList enlazados....
                if (!IsPostBack)
                {
                    //Obtengo los datos y los guardo en sesion
                    List<Pokemon> listaPokemon = negocio.ListarConSP();
                    Session["listaPokemon"] = listaPokemon;

                    //Esta opcion es por si quiero configuarar el ddl, enlazado, para que cargue todo los datos por defecto
                    //ddlPokeFiltrados.DataSource = listaPokemon;
                    //ddlPokeFiltrados.DataTextField = "Nombre";
                    //ddlPokeFiltrados.DataValueField = "Id";
                    //ddlPokeFiltrados.DataBind();


                    //uso esto a ver si funciona(elemento=tipo)
                    List<Elemento> listaElementos = negocioElemento.listar();

                    //configuro desplegable desde db con id y descripcion
                    ddlTipo3.DataSource = listaElementos;
                    ddlTipo3.DataTextField = "Descripcion";
                    ddlTipo3.DataValueField = "Id";
                    ddlTipo3.DataBind();
                }
             //< fin >
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
            }
        }

        protected void ddlTipo3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //aqui ocurre la magia, capturo el valor, el id del item seleccionado en el ddl
            int id = int.Parse(ddlTipo3.SelectedItem.Value);
            //hago una busqueda con el id captura en un lista de pokemons y lo enlazo en el DataSource
            ddlPokeFiltrados.DataSource = ((List<Pokemon>)Session["listaPokemon"]).FindAll(x => x.Tipo.Id == id);
            ddlPokeFiltrados.DataTextField = "Nombre";
            ddlPokeFiltrados.DataValueField = "Id";
            ddlPokeFiltrados.DataBind();


        }
    }
}