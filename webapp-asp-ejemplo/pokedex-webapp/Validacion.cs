using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pokedex_webapp
{
    public static class Validacion
    {
        //public static bool validaTextoVacio(object control)
        //{
        //    if (control is TextBox)
        //    {
        //        if (string.IsNullOrEmpty(((TextBox)control).Text))
        //            return false;
        //        else
        //            return true;
        //    }

        //    return false;
        //}

        //Refactorizado
        public static bool validaTextVacio(object control)
        {
            if (control is TextBox caja)
            {
                if (string.IsNullOrEmpty(caja.Text))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }
}