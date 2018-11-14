using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonajesLol_DAL.Conexion;
using PersonajesLol_Entidades;

namespace PersonajesLol_DAL.Manejadoras
{
    public class clsManejadoraPersonajes_DAL
    {
        /// <summary>
        /// Funcion que busca un personaje por su idPersonaje en la base de datos y lo devuelve
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public clsPersonaje buscarPersonajePorID_DAL(int id)
        {
            SqlConnection miConexion = null;
            SqlDataReader miLector = null;
            SqlCommand miComando = new SqlCommand();
            clsMyConnection gestoraConexion = new clsMyConnection();
            clsPersonaje personaje = new clsPersonaje();

            SqlParameter param = null;

            try
            {
                //Obtener conexion abierta
                miConexion = gestoraConexion.getConnection();

                //Definir los parametros del comando
                miComando.CommandText = "SELECT idPersonaje, nombre, alias, vida, regeneracion, danno, armadura, velAtaque, resistencia, velMovimiento, idCategoria FROM Personajes WHERE idPersonaje=@id";

                //Crear el parametro que afecta a la consulta

                param = new SqlParameter();
                param.ParameterName = "@id";
                param.SqlDbType = System.Data.SqlDbType.Int;
                param.Value = id;

                miComando.Parameters.Add(param);


                //Definir la conexion
                miComando.Connection = miConexion;

                //Ejecutar la consulta
                miLector = miComando.ExecuteReader();

                //Comprobar si el lector tiene filas, y en caso afirmativo, recorrerlo
                if (miLector.HasRows)
                {
                    miLector.Read();

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

            return personaje;
        }

        /// <summary>
        /// Funcion que manda a la base de datos una actualizacion de datos de un personaje y devuelve las filas afectadas por la operacion
        /// </summary>
        /// <returns></returns>
        public int editarPersonaje_DAL(clsPersonaje oPersonaje)
        {
            int filasAfectadas = -1;

            SqlConnection miConexion = null;
            SqlCommand miComando = new SqlCommand();
            clsMyConnection gestoraConexion = new clsMyConnection();


            try
            {
                //Añadir los parametros necesarios para hacer la insercion
                miComando.Parameters.Add("@idPersona", System.Data.SqlDbType.Int).Value = oPersonaje.idPersonaje;
                miComando.Parameters.Add("@idPersona", System.Data.SqlDbType.Int).Value = oPersonaje.idPersonaje;
                miComando.Parameters.Add("@idCategoria", System.Data.SqlDbType.Int).Value = oPersonaje.idCategoria;

                //Obtener conexion abierta
                miConexion = gestoraConexion.getConnection();


                //Definir los parametros del comando
                miComando.CommandText = "UPDATE Personas SET nombrePersona = @nombrePersona, apellidosPersona=@apellidosPersona, fechaNacimiento=@fechaNacimiento, telefono=@telefono, direccion=@direccion, idDepartamento=@idDepartamento where idPersona=@idPersona";


                //Definir la conexion
                miComando.Connection = miConexion;

                //Ejecutar la consulta
                filasAfectadas = miComando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                gestoraConexion.closeConnection(ref miConexion);
            }



            return filasAfectadas;
        }
    }
}
