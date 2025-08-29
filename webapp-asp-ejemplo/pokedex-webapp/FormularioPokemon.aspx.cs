using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace pokedex_webapp
{
    public partial class FormularioPokemon : System.Web.UI.Page
    {
        public string urlImagen { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;

            try
            {
                if (!IsPostBack)
                {
                    //ddlTipo.Items.Add("Planta");
                    //ddlTipo.Items.Add("Fuego");
                    //ddlTipo.Items.Add("Agua");

                    ElementoNegocio negocio = new ElementoNegocio();
                    List<Elemento> lista = negocio.listar();

                    ddlTipo.DataSource = lista;
                    ddlTipo.DataValueField = "Id";
                    ddlTipo.DataTextField = "Descripcion";
                    ddlTipo.DataBind();

                    ddlDebilidad.DataSource = lista;
                    ddlDebilidad.DataValueField = "Id";
                    ddlDebilidad.DataTextField = "Descripcion";
                    ddlDebilidad.DataBind();

                    // Fila seleccionada y Opcion "Modificar" desde la grilla
                    // Recupero el id y los datos
                    if (Request.QueryString["id"] != null)
                    {
                        int id = int.Parse(Request.QueryString["id"].ToString());

                        //...
                    }
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
                // Redirrecion a un pagina de error....
            }

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Pokemon nuevo = new Pokemon();
                PokemonNegocio negocio = new PokemonNegocio();

                nuevo.Numero = int.Parse(txtNumero.Text);
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.UrlImagen = txtUrlImagen.Text;

                //Para los ddl hay que crear un objeto del tipo Elemento, por la cuestion del texto plano, referido al ambito web
                nuevo.Tipo = new Elemento();
                nuevo.Tipo.Id = int.Parse(ddlTipo.SelectedValue);
                nuevo.Debilidad = new Elemento();
                nuevo.Debilidad.Id = int.Parse(ddlDebilidad.SelectedValue);

                negocio.agregarConSP(nuevo);
                Response.Redirect("ListaPokemon.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
                // Redirrecion a un pagina de error....
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            imgUrlImagen.ImageUrl = txtUrlImagen.Text;
        }
    }
}