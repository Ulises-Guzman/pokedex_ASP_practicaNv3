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
    public partial class DropDownList_SeleccionElemento : System.Web.UI.Page
    {
        //Property para cargar la url
        public string urlImagen { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ElementoNegocio negocioElemento = new ElementoNegocio();
            try
            {
                if (!IsPostBack)
                {
                    //Recupero la lista y cargo el ddl
                    List<Elemento> listaElementos = negocioElemento.listar();

                    ddlTipoPreseleccionado.DataSource = listaElementos;
                    ddlTipoPreseleccionado.DataTextField = "Descripcion";
                    ddlTipoPreseleccionado.DataValueField = "Id";
                    ddlTipoPreseleccionado.DataBind();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnSelecionar_Click(object sender, EventArgs e)
        {
            //Tomo el Id del TextBox
            string id = txtIdTipo.Text;

            //Opcion1
            if (!String.IsNullOrEmpty(id))
            {
                ddlTipoPreseleccionado.SelectedIndex = -1;
                ddlTipoPreseleccionado.Items.FindByValue(id).Selected = true;
            }


            //Opcion2
            //Pisando el item
            //ddlTipoPreseleccionado.SelectedIndex = ddlTipoPreseleccionado.Items.IndexOf(
            //ddlTipoPreseleccionado.Items.FindByValue(id));
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            urlImagen = txtUrlImagen.Text;
        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            urlImagen = txtUrlImagen.Text;
        }
    }
}