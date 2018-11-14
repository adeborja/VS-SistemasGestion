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
    public class clsListadoCategorias_DAL
    {
        /// <summary>
        /// Funcion que devuelve un List de objetos clsCategoria que incluirá todas las categorias de la base de datos lol
        /// </summary>
        /// <returns></returns>
        public List<clsCategoria> listadoCompletoCategorias_DAL()
        {
            List<clsCategoria> listado = new List<clsCategoria>();

            SqlConnection miConexion = null;
            SqlDataReader miLector = null;
            SqlCommand miComando = new SqlCommand();
            clsMyConnection gestoraConexion = new clsMyConnection();
            clsCategoria categoria;

            try
            {
                //Obtener conexion abierta
                miConexion = gestoraConexion.getConnection();

                //Definir los parametros del comando
                miComando.CommandText = "SELECT idCategoria, nombreCategoria FROM Categorias";

                //Definir la conexion
                miComando.Connection = miConexion;

                //Ejecutar la consulta
                miLector = miComando.ExecuteReader();

                //Comprobar si el lector tiene filas, y en caso afirmativo, recorrerlo
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        categoria = new clsCategoria();
                        //Definir los atributos del objeto
                        categoria.idCategoria = (int)miLector["idCategoria"];
                        categoria.nombreCategoria = (string)miLector["nombreCategoria"];

                        //Añadir objeto a la lista
                        listado.Add(categoria);
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
