//Agregar la libreria/clase: dominio
using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    //Clase que contiene los Metodos de Acceso a Datos para los Pokemon
    public class PokemonNegocio
    {
        //Creo Metodo listar()
        public List<Pokemon> listar(string id = "")
        {
            //Creo el objeto lista tipo Pokemon
            //Creo el objeto SqlConnection
            //Creo el objeto comando para realizar Acciones
            //Creo el objeto SqlDataReader para realizar un set de Datos, sin instacia
            List<Pokemon> lista = new List<Pokemon>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            //Manejo de Excepciones
            try
            {
                //1-Configuarar la conexion
                //2-Setear el comando SQL y su conexion
                //3-Abro la conexion
                //4-Realizo la lectura
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT P.Numero, P.Nombre, P.Descripcion, P.UrlImagen, E.Descripcion AS Tipo, D.Descripcion AS Debilidad, P.IdTipo, P.IdDebilidad, P.Id, P.Activo FROM POKEMONS P, ELEMENTOS E, ELEMENTOS D WHERE P.IdTipo = E.Id AND D.Id = P.IdDebilidad ";
                // Agrego modificación para lsitar por "id", pasado por parámetro
                if (id != null)
                {
                    comando.CommandText += " AND P.Id = " + id;
                }

                comando.Connection = conexion;
                
                conexion.Open();
                lector = comando.ExecuteReader();

                //Leer el lector y cargar datos al objeto tipo Pokemon aux
                //Aqui modelo la informacion
                while (lector.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Id = (int)lector["Id"];
                    aux.Numero = lector.GetInt32(0);
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];

                    //Validar para que el lector no lea valores null ** Primera Forma
                    //if(!(lector.IsDBNull(lector.GetOrdinal("UrlImagen"))))
                    //    aux.UrlImagen = (string)lector["UrlImagen"];

                    if (!(lector["UrlImagen"] is DBNull))
                        aux.UrlImagen = (string)lector["UrlImagen"];

                    //Entonces*2
                    //Le creo una instacia
                    aux.Tipo = new Elemento();
                    //Agrego el valor de Id al aux.Tipo
                    aux.Tipo.Id = (int)lector["IdTipo"];
                    //El objeto Tipo Elemento no esta instanciado*1
                    aux.Tipo.Descripcion = (string)lector["Tipo"];

                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Id = (int)lector["IdDebilidad"];
                    aux.Debilidad.Descripcion = (string)lector["Debilidad"];

                    // Agrego estado
                    aux.Activo = bool.Parse(lector["Activo"].ToString());

                    //Agrego el objeto Pokemon aux a la lista
                    lista.Add(aux);
                }

                //Cierro la conexion
                conexion.Close();

                return lista;
            }
            catch (Exception)
            {

                throw;
            }



        }

        public List<Pokemon> ListarConSP()
        {
            //Creo una objeto lista tipo Pokemon y un objeto tipo AccesoDatos
            List<Pokemon> lista = new List<Pokemon>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //Armo la consulta SQL para que sea dinaminica
                //string consulta = "SELECT P.Numero, P.Nombre, P.Descripcion, P.UrlImagen, E.Descripcion AS Tipo, D.Descripcion AS Debilidad, P.IdTipo, P.IdDebilidad, P.Id FROM POKEMONS P, ELEMENTOS E, ELEMENTOS D WHERE P.IdTipo = E.Id AND D.Id = P.IdDebilidad AND P.Activo = 1";

                //Realizo el seteo y la ejecucion de la consulta
                //datos.setearConsulta(consulta);

                //Consulto a traves de un SP
                datos.setearProcedimiento("storedListar");
                datos.ejecutarLectura();

                //Modelo la informacion para la dgv
                while (datos.Lector.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Numero = datos.Lector.GetInt32(0);
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    //Validar para que el lector no lea valores null ** Primera Forma
                    //if(!(lector.IsDBNull(lector.GetOrdinal("UrlImagen"))))
                    //    aux.UrlImagen = (string)lector["UrlImagen"];

                    if (!(datos.Lector["UrlImagen"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["UrlImagen"];

                    //Entonces*2
                    //Le creo una instacia
                    aux.Tipo = new Elemento();
                    //Agrego el valor de Id al aux.Tipo
                    aux.Tipo.Id = (int)datos.Lector["IdTipo"];
                    //El objeto Tipo Elemento no esta instanciado*1
                    aux.Tipo.Descripcion = (string)datos.Lector["Tipo"];

                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Id = (int)datos.Lector["IdDebilidad"];
                    aux.Debilidad.Descripcion = (string)datos.Lector["Debilidad"];

                    aux.Activo = bool.Parse(datos.Lector["Activo"].ToString());

                    //Agrego el objeto Pokemon aux a la lista
                    lista.Add(aux);
                }



                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Pokemon> ListarNombreConSP()
        {
            //Creo una objeto lista tipo Pokemon y un objeto tipo AccesoDatos
            List<Pokemon> lista = new List<Pokemon>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //Consulto a traves de un SP
                datos.setearProcedimiento("NombresPoke");
                datos.ejecutarLectura();

                //Modelo la informacion para el desplagable
                while (datos.Lector.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];

                    //Agrego el objeto Pokemon aux a la lista
                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //Metodo agregar(Pokemon...)
        public void agregar(Pokemon nuevo)
        {
            //Aqui escribo la logica para que se conecte a la DB
            //que necesito para conectarme al DB?
            //Un objeto del tipo AccesoDatos :)
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO POKEMONS (Numero, Nombre, Descripcion, Activo, IdTipo, IdDebilidad, urlImagen) VALUES (" + nuevo.Numero + ", '" + nuevo.Nombre + "', '" + nuevo.Descripcion + "', 1, @idTipo, @idDebilidad, @urlImagen)");
                //Llamo a la funcion setearParametro() y le paso el nombre y el valor
                datos.setearParametro("@idtipo", nuevo.Tipo.Id);
                datos.setearParametro("@idDebilidad", nuevo.Debilidad.Id);
                datos.setearParametro("@urlImagen", nuevo.UrlImagen);
                //Necesito ejecutar la Instruccion SQL
                //Llamo al Metodo que ejecutarAccion() esta en AccesoDatos
                datos.ejecutarAccion();


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

        public void agregarConSP(Pokemon nuevo)
        {
            //Aqui escribo la logica para que se conecte a la DB
            //que necesito para conectarme al DB?
            //Un objeto del tipo AccesoDatos :)
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("storedAltaPokemon");
                //Llamo a la funcion setearParametro() y le paso el nombre de los parametros del SP y el valor del nuevo elemento
                datos.setearParametro("@numero", nuevo.Numero);
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@desc", nuevo.Descripcion);
                datos.setearParametro("@img", nuevo.UrlImagen);
                datos.setearParametro("@idTipo", nuevo.Tipo.Id);
                datos.setearParametro("@idDebilidad", nuevo.Debilidad.Id);
                //datos.setearParametro("@idEvolucion", null);
                //Llamo al Metodo que ejecutarAccion() está en AccesoDatos
                datos.ejecutarAccion();


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

        //Metodo modificar(Pokemon...)
        public void modificar(Pokemon poke)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE POKEMONS SET Numero = @numero, Nombre = @nombre, Descripcion = @desc, UrlImagen = @imagen, IdTipo = @idTipo, IdDebilidad = @idDebilidad WHERE Id = @id");
                datos.setearParametro("@numero", poke.Numero);
                datos.setearParametro("@nombre", poke.Nombre);
                datos.setearParametro("@desc", poke.Descripcion);
                datos.setearParametro("@imagen", poke.UrlImagen);
                datos.setearParametro("@idTipo", poke.Tipo.Id);
                datos.setearParametro("@idDebilidad", poke.Debilidad.Id);
                datos.setearParametro("@id", poke.Id);

                datos.ejecutarAccion();
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

        //Metodo Eliminar Fisico, recibe un Id
        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("DELETE FROM POKEMONS WHERE Id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Metodo Eliminar Logico, recibe un Id
        public void eliminarLogico(int id, bool activo)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("UPDATE POKEMONS SET Activo = @activo WHERE Id = @id");
                datos.setearParametro("@id", id);
                datos.setearParametro("@activo", activo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Metodo filtrar de la busqueda avanzada
        public List<Pokemon> filtrar(string campo, string criterio, string filtro, string estado)
        {   //Creo una objeto lista tipo Pokemon y un objeto tipo AccesoDatos
            List<Pokemon> lista = new List<Pokemon>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //Armo la consulta SQL para que sea dinaminica, al final. //Modifico la consulta agregandole P.Activo
                string consulta = "SELECT P.Numero, P.Nombre, P.Descripcion, P.UrlImagen, E.Descripcion AS Tipo, D.Descripcion AS Debilidad, P.IdTipo, P.IdDebilidad, P.Id, P.Activo FROM POKEMONS P, ELEMENTOS E, ELEMENTOS D WHERE P.IdTipo = E.Id AND D.Id = P.IdDebilidad AND ";

                //En el caso con if y switches

                if (campo == "Número")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "Numero > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "Numero < " + filtro;
                            break;
                        default:
                            consulta += "Numero = " + filtro;
                            break;
                    }
                }
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Nombre LIKE '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "Nombre LIKE '%" + filtro + "' ";
                            break;
                        default:
                            consulta += "Nombre LIKE '%" + filtro + "%' ";
                            break;
                    }
                }
                else
                {   
                    // Modifico para que filtre por descripcion del Tipo de pokemon. Osea E.Descripcion
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "E.Descripcion LIKE '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "E.Descripcion LIKE '%" + filtro + "' ";
                            break;
                        default:
                            consulta += "E.Descripcion LIKE '%" + filtro + "%' ";
                            break;
                    }
                }

                // Agrego a la consulta el Estado, leyendo el parametro pasado, que es el Estado.
                if (estado == "Activo")
                {
                    consulta += "AND P.Activo = 1";
                }
                else if (estado == "Inactivo")
                {
                    consulta += "AND P.Activo = 0";
                }

                //Realizo el seteo y la ejecucion de la consulta
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                //Modelo la informacion para la dgv
                while (datos.Lector.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Numero = datos.Lector.GetInt32(0);
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    //Validar para que el lector no lea valores null ** Primera Forma
                    //if(!(lector.IsDBNull(lector.GetOrdinal("UrlImagen"))))
                    //    aux.UrlImagen = (string)lector["UrlImagen"];

                    if (!(datos.Lector["UrlImagen"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["UrlImagen"];

                    //Entonces*2
                    //Le creo una instacia
                    aux.Tipo = new Elemento();
                    //Agrego el valor de Id al aux.Tipo
                    aux.Tipo.Id = (int)datos.Lector["IdTipo"];
                    //El objeto Tipo Elemento no esta instanciado*1
                    aux.Tipo.Descripcion = (string)datos.Lector["Tipo"];

                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Id = (int)datos.Lector["IdDebilidad"];
                    aux.Debilidad.Descripcion = (string)datos.Lector["Debilidad"];

                    //Agrego como propiedad el campo activo. //Forma: casteo explicito.
                    aux.Activo = (bool)datos.Lector["Activo"];
                    //otra forma: parseo
                    //aux.Activo = bool.Parse(datos.Lector["Activo"].ToString());

                    //Agrego el objeto Pokemon aux a la lista
                    lista.Add(aux);
                }


                //En el caso con switches
                //switch (campo)
                //{
                //    case "Número":
                //        switch (criterio)
                //        {
                //            case "Mayor a":
                //                consulta += "Numero > " + filtro;
                //                break;
                //            case "Menor a":
                //                consulta += "Numero < " + filtro;
                //                break;
                //            default:
                //                consulta += "Numero = " + filtro;
                //                break;
                //        }
                //        break;

                //    case "Nombre":
                //        break;

                //    case "Descripción":
                //        break;

                //    default:
                //        break;
                //}

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void modificarConSP(Pokemon poke)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("storedModificarPokemon");
                datos.setearParametro("@numero", poke.Numero);
                datos.setearParametro("@nombre", poke.Nombre);
                datos.setearParametro("@desc", poke.Descripcion);
                datos.setearParametro("@img", poke.UrlImagen);
                datos.setearParametro("@idTipo", poke.Tipo.Id);
                datos.setearParametro("@idDebilidad", poke.Debilidad.Id);
                datos.setearParametro("@id", poke.Id);

                datos.ejecutarAccion();
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
