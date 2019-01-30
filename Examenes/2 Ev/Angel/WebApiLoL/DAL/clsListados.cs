using _13_WebApiPersonas_DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApiLoL.Entidades;

namespace WebApiLoL.DAL
{
    public class clsListados
    {

        /// <summary>
        /// Función que nos devuelve un listado de todos los personajes
        /// </summary>
        /// <returns>Listado de personajes</returns>

        public List<clsPersonaje> listadoPersonajes()
        {
            List<clsPersonaje> listadoPersonajes = new List<clsPersonaje>();
            clsMyConnection miConexion;

            miConexion = new clsMyConnection();
            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            clsPersonaje oPersonaje;

            try
            {
                conexion = miConexion.getConnection();
                //Creamos el comando (Creamos el comando, le pasamos la sentencia y la conexion, y lo ejecutamos)
                miComando.CommandText = "SELECT * FROM personajes";
                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();
                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oPersonaje = new clsPersonaje();
                        oPersonaje.idPersonaje = (int)miLector["idPersonaje"];
                        oPersonaje.nombre = (string)miLector["nombre"];
                        oPersonaje.alias = (string)miLector["alias"];
                        oPersonaje.vida = (double)miLector["vida"];
                        oPersonaje.regeneracion = (double)miLector["regeneracion"];
                        oPersonaje.danno = (double)miLector["danno"];
                        oPersonaje.armadura = (double)miLector["armadura"];
                        oPersonaje.velAtaque = (double)miLector["velAtaque"];
                        oPersonaje.resistencia = (double)miLector["resistencia"];
                        oPersonaje.velMovimiento = (double)miLector["velMovimiento"];
                        oPersonaje.idCategoria = (int)miLector["idCategoria"];

                        listadoPersonajes.Add(oPersonaje);
                    }
                }

                miConexion.closeConnection(ref conexion);


            }
            catch (SqlException exSql)
            {
                throw exSql;
            }
            catch (Exception ex)
            {

                throw ex;

            }


            return listadoPersonajes;

        }


        
        /// <summary>
        /// Función que nos devuelve los datos de un  personaje
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public clsPersonaje datosPersonaje(int id)
        {
            clsPersonaje oPersonaje=new clsPersonaje();
            clsMyConnection miConexion;

            miConexion = new clsMyConnection();
            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            

            try
            {
                conexion = miConexion.getConnection();
                //Creamos el comando (Creamos el comando, le pasamos la sentencia y la conexion, y lo ejecutamos)
                miComando.CommandText = "SELECT * FROM personajes WHERE idPersonaje=@id";

                //Creamos el comando que afecta a esta consulta
                SqlParameter param;
                param = new System.Data.SqlClient.SqlParameter();
                param.ParameterName = "@id";
                param.SqlDbType = System.Data.SqlDbType.Int;
                param.Value = id;

                miComando.Parameters.Add(param);
                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();
                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    miLector.Read();
                    
                        oPersonaje = new clsPersonaje();
                        oPersonaje.idPersonaje = (int)miLector["IdPersonaje"];
                        oPersonaje.nombre = (string)miLector["nombre"];
                        oPersonaje.alias = (string)miLector["alias"];
                        oPersonaje.vida = (double)miLector["vida"];
                        oPersonaje.regeneracion = (double)miLector["regeneracion"];
                        oPersonaje.danno = (double)miLector["danno"];
                        oPersonaje.armadura = (double)miLector["armadura"];
                        oPersonaje.velAtaque = (double)miLector["velAtaque"];
                        oPersonaje.resistencia = (double)miLector["resistencia"];
                        oPersonaje.velMovimiento = (double)miLector["velMovimiento"];

                                           
                }

                miConexion.closeConnection(ref conexion);


            }
            catch (SqlException exSql)
            {
                throw exSql;
            }
            catch (Exception ex)
            {

                throw ex;

            }


            return oPersonaje;

        }
    }
}
