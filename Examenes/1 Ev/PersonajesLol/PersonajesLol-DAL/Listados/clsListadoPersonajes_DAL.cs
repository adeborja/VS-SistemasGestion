using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonajesLol_DAL.Conexion;
using PersonajesLol_Entidades;

namespace PersonajesLol_DAL.Listados
{
    public class clsListadoPersonajes_DAL
    {
        /// <summary>
        /// Funcion que devuelve un List de objetos clsPersonaje que incluirá todos los personajes de la base de datos lol
        /// </summary>
        /// <returns></returns>
        public List<clsPersonaje> listadoCompletoPersonajes_DAL()
        {
            List<clsPersonaje> listado = new List<clsPersonaje>();

            SqlConnection miConexion = null;
            SqlDataReader miLector = null;
            SqlCommand miComando = new SqlCommand();
            clsMyConnection gestoraConexion = new clsMyConnection();
            clsPersonaje personaje;

            try
            {
                //Obtener conexion abierta
                miConexion = gestoraConexion.getConnection();

                //Definir los parametros del comando
                miComando.CommandText = "SELECT idPersonaje, nombre, alias, vida, regeneracion, danno, armadura, velAtaque, resistencia, velMovimiento, idCategoria FROM Personajes";

                //Definir la conexion
                miComando.Connection = miConexion;

                //Ejecutar la consulta
                miLector = miComando.ExecuteReader();

                //Comprobar si el lector tiene filas, y en caso afirmativo, recorrerlo
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        personaje = new clsPersonaje();
                        //Definir los atributos del objeto
                        personaje.idPersonaje = (int)miLector["idPersonaje"];
                        personaje.nombre = (string)miLector["nombre"];
                        personaje.alias = (string)miLector["alias"];
                        personaje.vida = (double)miLector["vida"];
                        personaje.regeneracion = (double)miLector["regeneracion"];
                        personaje.danno = (double)miLector["danno"];
                        personaje.armadura = (double)miLector["armadura"];
                        personaje.velAtaque = (double)miLector["velAtaque"];
                        personaje.resistencia = (double)miLector["resistencia"];
                        personaje.velMovimiento = (double)miLector["velMovimiento"];
                        personaje.idCategoria = (int)miLector["idCategoria"];

                        //Añadir objeto a la lista
                        listado.Add(personaje);
                    }
                }

            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {

                gestoraConexion.closeConnection(ref miConexion);

                miLector.Close();
            }



            return listado;
        }
    }
}
