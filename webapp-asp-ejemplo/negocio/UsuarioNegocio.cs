using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using negocio; //Para utilizar el acceso a datos. En el ejemplo la capa datos esta diferenciada.

namespace negocio
{
    public class UsuarioNegocio
    {
        public bool Loguear(Usuario usuario)
        {	
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setearConsulta("SELECT Id, TipoUser FROM Usuarios WHERE Usuario = @user AND Pass = @pass"); // La cnsulta ya esta filtrando en el WHERE
				datos.setearParametro("@user", usuario.User);
				datos.setearParametro("@pass", usuario.Pass);
				datos.ejecutarLectura();
				while (datos.Lector.Read())
				{
					usuario.Id = (int)datos.Lector["Id"];
					usuario.TipoUsuario = (int)datos.Lector["TipoUser"] == 2 ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;
                    // usuario.TipoUsuario = (TipoUsuario)(int)datos.Lector["TipoUser"]; Para probar
                    return true;
				}
				return false;
			}
			catch (Exception ex)
			{

				throw ex;
			}
			finally
			{
				datos.cerrarConexion();
			}
        }
    }
}
