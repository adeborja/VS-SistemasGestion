
using _08_CRUDpersonasTelefonos_DAL.Conexion;
using _08_CRUDpersonasTelefonos_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_CRUDpersonasTelefonos_DAL.Manejadoras
{
    public class clsManejadoraPersona_DAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public clsPersona buscarPersonaPorID_DAL(int id)
        {

            SqlConnection miConexion = null;
            SqlDataReader miLector = null;
            SqlCommand miComando = new SqlCommand();
            clsMyConnection gestoraConexion = new clsMyConnection();
            clsPersona persona = null;

            SqlParameter param = null;

            try //try no obligatorio porque lo controlamos en la clase myConnection
            {
                //Obtener conexion abierta
                miConexion = gestoraConexion.getConnection();

                //Definir los parametros del comando
                miComando.CommandText = "SELECT IDPersona, nombrePersona, apellidosPersona, fechaNacimiento, telefono, direccion, IDDepartamento FROM Personas WHERE IDPersona=@id";

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

                    persona = new clsPersona();

                    //Definir los atributos del objeto
                    persona.idPersona = (int)miLector["IDPersona"];
                    persona.nombre = (string)miLector["nombrePersona"];
                    persona.apellidos = (string)miLector["apellidosPersona"];
                    persona.fechaNacimiento = (DateTime)miLector["fechaNacimiento"];
                    persona.telefono = (string)miLector["telefono"];
                    persona.direccion = (string)miLector["direccion"];
                    persona.idDepartamento = (int)miLector["IDDepartamento"];

                    //Control+K+D para que se autotabule bien, EN ESE ORDEN
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




            return persona;
        }

        public int borrarPersonaPorID_DAL(int id)
        {
            SqlConnection miConexion = null;
            SqlCommand miComando = new SqlCommand();
            clsMyConnection gestoraConexion = new clsMyConnection();

            int filas = -1;

            SqlParameter param = null;

            try //try no obligatorio porque lo controlamos en la clase myConnection
            {
                //Obtener conexion abierta
                miConexion = gestoraConexion.getConnection();

                //Definir los parametros del comando
                miComando.CommandText = "DELETE FROM Personas WHERE IDPersona=@id";

                //Crear el parametro que afecta a la consulta

                param = new SqlParameter();
                param.ParameterName = "@id";
                param.SqlDbType = System.Data.SqlDbType.Int;
                param.Value = id;

                miComando.Parameters.Add(param);


                //Definir la conexion
                miComando.Connection = miConexion;

                //Ejecutar la consulta
                filas = miComando.ExecuteNonQuery();

                

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                gestoraConexion.closeConnection(ref miConexion);
            }

            return filas;
        }

        
        public int crearPersona_DAL(clsPersona oPersona)
        {
            int filasAfectadas = -1;

            SqlConnection miConexion = null;
            SqlCommand miComando = new SqlCommand();
            clsMyConnection gestoraConexion = new clsMyConnection();


            try //try no obligatorio porque lo controlamos en la clase myConnection
            {
                //Añadir los parametros necesarios para hacer la insercion
                miComando.Parameters.Add("@nombrePersona", System.Data.SqlDbType.VarChar).Value = oPersona.nombre;
                miComando.Parameters.Add("@apellidosPersona", System.Data.SqlDbType.VarChar).Value = oPersona.apellidos;
                miComando.Parameters.Add("@fechaNacimiento", System.Data.SqlDbType.Date).Value = oPersona.fechaNacimiento;
                miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = oPersona.telefono;
                miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = oPersona.direccion;
                miComando.Parameters.Add("@idDepartamento", System.Data.SqlDbType.VarChar).Value = oPersona.idDepartamento;

                //Obtener conexion abierta
                miConexion = gestoraConexion.getConnection();
                

                //Definir los parametros del comando
                miComando.CommandText = "INSERT INTO Personas (nombrePersona, apellidosPersona, fechaNacimiento, telefono, direccion, idDepartamento) VALUES (@nombrePersona, @apellidosPersona, @fechaNacimiento, @telefono, @direccion, @idDepartamento)";
                

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



        public int editarPersona_DAL(clsPersona oPersona)
        {
            int filasAfectadas = -1;

            SqlConnection miConexion = null;
            SqlCommand miComando = new SqlCommand();
            clsMyConnection gestoraConexion = new clsMyConnection();


            try //try no obligatorio porque lo controlamos en la clase myConnection
            {
                //Añadir los parametros necesarios para hacer la insercion
                miComando.Parameters.Add("@idPersona", System.Data.SqlDbType.VarChar).Value = oPersona.idPersona;
                miComando.Parameters.Add("@nombrePersona", System.Data.SqlDbType.VarChar).Value = oPersona.nombre;
                miComando.Parameters.Add("@apellidosPersona", System.Data.SqlDbType.VarChar).Value = oPersona.apellidos;
                miComando.Parameters.Add("@fechaNacimiento", System.Data.SqlDbType.Date).Value = oPersona.fechaNacimiento;
                miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = oPersona.telefono;
                miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = oPersona.direccion;
                miComando.Parameters.Add("@idDepartamento", System.Data.SqlDbType.VarChar).Value = oPersona.idDepartamento;

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
