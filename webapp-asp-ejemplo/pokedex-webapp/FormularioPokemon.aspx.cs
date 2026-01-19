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
        public bool ConfirmaEliminar { get; set; }
        public string urlImagen { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            ConfirmaEliminar = false;
            try
            {
                // Configuración inicial de la pantalla
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
                    //if (Request.QueryString["id"] != null)
                    //{
                    //    int id = int.Parse(Request.QueryString["id"].ToString());

                    //    //...
                    //}
                }

                // Configuración en modo Modificar
                //Refactorizado...
                //Con Operador ternario:
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != null && !IsPostBack)
                {
                    // Recupero la lista con el unico elemento listado por id
                    PokemonNegocio negocio = new PokemonNegocio();
                    //List<Pokemon> lista = negocio.listar(id);
                    //Pokemon seleccionado = lista[0];
                    //Refactorizado...
                    Pokemon seleccionado = (negocio.listar(id))[0];

                    // Guardo pokemon seleccionado en session
                    Session.Add("pokeSeleccionado", seleccionado);

                    //Precargar todos los campos
                    txtId.Text = id;
                    txtNumero.Text = seleccionado.Numero.ToString();
                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtUrlImagen.Text = seleccionado.UrlImagen;

                    ddlTipo.SelectedValue = seleccionado.Tipo.Id.ToString();
                    ddlDebilidad.SelectedValue = seleccionado.Debilidad.Id.ToString();

                    //Forzar la carga de un metodo (esto es una chanchada... no hacerlo asi)
                    //txtUrlImagen_TextChanged(sender, e);

                    // Esta es la forma correcta
                    RecargarImagen();

                    // Configurar acciones
                    if (!seleccionado.Activo)
                        btnInactivar.Text = "Reactivar";
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                // throw; // [nose porque falla al lanzar la ecepcion, supuestamete es una fallla en en alguna sentencia sql]
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

                if (Request.QueryString["id"] != null)
                {
                    // Agrego el id para realizar la modificacion
                    nuevo.Id = int.Parse(txtId.Text);
                    negocio.modificarConSP(nuevo);
                }
                else
                {
                    negocio.agregarConSP(nuevo);
                }

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
            ConfirmaEliminar = true;
        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            imgUrlImagen.ImageUrl = txtUrlImagen.Text;
        }

        protected void RecargarImagen()
        {
            imgUrlImagen.ImageUrl = txtUrlImagen.Text;
        }

        protected void btnConfirmaEliminacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmarEliminacion.Checked)
                {
                    PokemonNegocio negocio = new PokemonNegocio();
                    negocio.eliminar(int.Parse(txtId.Text));
                    Response.Redirect("ListaPokemon.aspx");
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
            }
        }

        protected void btnInactivar_Click(object sender, EventArgs e)
        {
            try
            {
                PokemonNegocio negocio = new PokemonNegocio();
                // Recupero el poke selecionado que esta guardado en session
                Pokemon seleccionado = (Pokemon)Session["pokeSeleccionado"];
                // Modifico el metodo eliminarLogico, y negando el parametro seleccionado.Activo para mandar el opuesto
                negocio.eliminarLogico(seleccionado.Id, !seleccionado.Activo);
                Response.Redirect("ListaPokemon.aspx");
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
            }
        }
    }
}