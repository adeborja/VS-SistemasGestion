using _07_CRUDPersonas_Entidades;
using _07_CRUDPersonas_Entidades.Conexion;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_CRUDPersonas_DAL.Listados
{
    public class clsListadoPersonas_DAL
    {
        /// <summary>
        /// funcion que devuelve un List de objetos clsPersona, Lista vacia si no hay datos en la base de datos o no se han podido acceder a ellos
        /// </summary>
        /// <returns>List de clsPersona</returns>
        public List<clsPersona> listadoCompletoPersonas_DAL()
        {
            List<clsPersona> lista = new List<clsPersona>();
            SqlConnection miConexion = null;
            SqlDataReader miLector = null;
            SqlCommand miComando = new SqlCommand();
            clsMyConnection gestoraConexion = new clsMyConnection();
            clsPersona persona;

            try //try no obligatorio porque lo controlamos en la clase myConnection
            {
                //Obtener conexion abierta
                miConexion = gestoraConexion.getConnection();

                //Definir los parametros del comando
                miComando.CommandText = "SELECT IDPersona, nombrePersona, apellidosPersona, fechaNacimiento," +
                    "telefono, direccion, IDDepartamento FROM Personas"; //cambiar el asterisco

                //Definir la conexion
                miComando.Connection = miConexion;

                //Ejecutar la consulta
                miLector = miComando.ExecuteReader();

                //Comprobar si el lector tiene filas, y en caso afirmativo, recorrerlo
                if (miLector.HasRows)
                {
                    while(miLector.Read())
                    {
                        persona = new clsPersona();
                        //Definir los atributos del objeto
                        persona.idPersona = (int)miLector["IDPersona"];
                        persona.nombre = (string)miLector["nombrePersona"];
                        persona.apellidos = (string)miLector["apellidosPersona"];
                        persona.fechaNacimiento = (DateTime)miLector["fechaNacimiento"];
                        persona.telefono = (string)miLector["telefono"];
                        persona.direccion = (string)miLector["direccion"];
                        persona.idDepartamento = (int)miLector["IDDepartamento"];

                        //Añadir objeto a la lista
                        lista.Add(persona);
                    }
                }

            }
            catch(SqlException e)
            {
                throw e;
            }
            finally
            {

                gestoraConexion.closeConnection(ref miConexion);

                miLector.Close();
            }

            return lista;
        }
    }
}
