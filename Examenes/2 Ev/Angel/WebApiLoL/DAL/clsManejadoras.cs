using _13_WebApiPersonas_DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApiLoL.Entidades;

namespace WebApiLoL.DAL
{
    public class clsManejadoras
    {
        /// <summary>
        /// Funcion que borra un personaje de la base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns>el numero de filas afectadas al ejecutar la sentencia, o -1 si ha ocurrido un error</returns>
        public int borrarPersonaje(int id)
        {
            clsMyConnection miConexion;

            miConexion = new clsMyConnection();
            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();

            int filasAfectadas = -1;

            miComando.CommandText = "DELETE FROM Personajes WHERE IdPersonaje=@id";

            SqlParameter param = null;

            try
            {
                conexion = miConexion.getConnection();

                param = new System.Data.SqlClient.SqlParameter();
                param.ParameterName = "@id";
                param.SqlDbType = System.Data.SqlDbType.Int;
                param.Value = id;

                miComando.Parameters.Add(param);
                miComando.Connection = conexion;
                filasAfectadas = miComando.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                miConexion.closeConnection(ref conexion);
            }

            return filasAfectadas;
        }

        /// <summary>
        /// Funcion que inserta un nuevo personaje en la base de datos
        /// </summary>
        /// <param name="p"></param>
        /// <returns>el numero de filas afectadas al ejecutar la sentencia, o -1 si ha ocurrido un error</returns>
        public int insertarPersonaje(clsPersonaje p)
        {
            int filasAfectadas = -1;

            SqlConnection miConexion = null;
            SqlCommand miComando = new SqlCommand();
            clsMyConnection gestoraConexion = new clsMyConnection();

            miComando.CommandText = "INSERT INTO Personajes (idPersonaje, nombre, alias, vida, regeneracion, danno, armadura, velAtaque, resistencia, velMovimiento, idCategoria) VALUES (@idPersonaje, @nombre, @alias, @vida, @regeneracion, @danno, @armadura, @velAtaque, @resistencia, @velMovimiento, @idCategoria)";

            miComando.Parameters.Add("@idPersonaje", System.Data.SqlDbType.Int).Value = p.idPersonaje;
            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = p.nombre;
            miComando.Parameters.Add("@alias", System.Data.SqlDbType.VarChar).Value = p.alias;
            miComando.Parameters.Add("@vida", System.Data.SqlDbType.Real).Value = p.vida;
            miComando.Parameters.Add("@regeneracion", System.Data.SqlDbType.Real).Value = p.regeneracion;
            miComando.Parameters.Add("@danno", System.Data.SqlDbType.Real).Value = p.danno;
            miComando.Parameters.Add("@armadura", System.Data.SqlDbType.Real).Value = p.armadura;
            miComando.Parameters.Add("@velAtaque", System.Data.SqlDbType.Real).Value = p.velAtaque;
            miComando.Parameters.Add("@resistencia", System.Data.SqlDbType.Real).Value = p.resistencia;
            miComando.Parameters.Add("@velMovimiento", System.Data.SqlDbType.Real).Value = p.velMovimiento;
            miComando.Parameters.Add("@idCategoria", System.Data.SqlDbType.Int).Value = p.idCategoria;

            try
            { 
                miConexion = gestoraConexion.getConnection();
                
                miComando.Connection = miConexion;

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

        /// <summary>
        /// Funcion para editar los datos de un personaje de la base de datos
        /// </summary>
        /// <param name="p"></param>
        /// <returns>el numero de filas afectadas al ejecutar la sentencia, o -1 si ha ocurrido un error</returns>
        public int editarPersonaje(clsPersonaje p)
        {
            int filasAfectadas = -1;

            SqlConnection miConexion = null;
            SqlCommand miComando = new SqlCommand();
            clsMyConnection gestoraConexion = new clsMyConnection();

            miComando.CommandText = "UPDATE Personajes SET nombre=@nombre, alias=@alias, vida=@vida , regeneracion=@regeneracion, danno=@danno, armadura=@armadura, velAtaque=@velAtaque, resistencia=@resistencia, velMovimiento=@velMovimiento, idCategoria=@idCategoria WHERE idPersonaje=@idPersonaje";

            miComando.Parameters.Add("@idPersonaje", System.Data.SqlDbType.Int).Value = p.idPersonaje;
            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = p.nombre;
            miComando.Parameters.Add("@alias", System.Data.SqlDbType.VarChar).Value = p.alias;
            miComando.Parameters.Add("@vida", System.Data.SqlDbType.Real).Value = p.vida;
            miComando.Parameters.Add("@regeneracion", System.Data.SqlDbType.Real).Value = p.regeneracion;
            miComando.Parameters.Add("@danno", System.Data.SqlDbType.Real).Value = p.danno;
            miComando.Parameters.Add("@armadura", System.Data.SqlDbType.Real).Value = p.armadura;
            miComando.Parameters.Add("@velAtaque", System.Data.SqlDbType.Real).Value = p.velAtaque;
            miComando.Parameters.Add("@resistencia", System.Data.SqlDbType.Real).Value = p.resistencia;
            miComando.Parameters.Add("@velMovimiento", System.Data.SqlDbType.Real).Value = p.velMovimiento;
            miComando.Parameters.Add("@idCategoria", System.Data.SqlDbType.Int).Value = p.idCategoria;

            try
            {
                miConexion = gestoraConexion.getConnection();

                miComando.Connection = miConexion;

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
