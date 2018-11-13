using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using _08_CRUDpersonasTelefonos_Entidades.Persistencia;
using _08_CRUDpersonasTelefonos_DAL.Conexion;

namespace _08_CRUDpersonasTelefonos_DAL.Listados
{
    public class clsListadoDepartamentos_DAL
    {
        public List<clsDepartamento> listadoCompletoDepartamentos_DAL()
        {
            List<clsDepartamento> lista = new List<clsDepartamento>();

            SqlConnection miConexion = null;
            SqlDataReader miLector = null;
            SqlCommand miComando = new SqlCommand();
            clsMyConnection gestoraConexion = new clsMyConnection();
            clsDepartamento departamento = null;

            try
            {
                //Obtener conexion abierta
                miConexion = gestoraConexion.getConnection();

                //Definir los parametros del comando
                miComando.CommandText = "SELECT IDDepartamento, nombreDepartamento FROM Departamentos";

                //Definir la conexion
                miComando.Connection = miConexion;

                //Ejecutar la consulta
                miLector = miComando.ExecuteReader();

                //Comprobar si el lector tiene filas, y en caso afirmativo, recorrerlo
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        departamento = new clsDepartamento();
                        //Definir los atributos del objeto
                        departamento.idDepartamento = (int)miLector["IDDepartamento"];
                        departamento.nombreDepartamento = (string)miLector["nombreDepartamento"];
                        //Añadir objeto a la lista
                        lista.Add(departamento);
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



            return lista;
        }
    }
}
