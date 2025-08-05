using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pokedex_webapp
{
    public partial class Default : System.Web.UI.Page
    {   
        //Creo un paropety para acceder a la misma cuando quiera
        public List<Pokemon> ListaPokemon { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            //Le asigno a la property
            ListaPokemon = negocio.ListarConSP();
        }
    }
}