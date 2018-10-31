using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace _06_ConexionBaseDatos.Models
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost,ActionName ("Index")]
        public ActionResult IndexPost()
        {
            SqlConnection miConexion = new SqlConnection();
            

            try
            {
                miConexion.ConnectionString = "server=personaserver.database.windows.net;database=personasDB;uid=Prueba;pwd=123qweasd!;";

                miConexion.Open();

                //Personas

                ViewData["Estado"] = miConexion.State;
            }
            catch(SqlException e)
            {
                if (e.Number == 18456)
                {
                    ViewData["Estado"] = "Error, usuario o contraseña incorrectos en la BD. ";
                }
                else
                    ViewData["Estado"] = "Error al conectar a la BD." + e.ToString();


            }
            catch(Exception e)
            {
                ViewData["Estado"] = "Error al conectar a la BD." + e.ToString();
            }
            finally
            {
                try
                {
                    miConexion.Close();
                }
                catch(Exception e)
                {
                    
                }
            }


            return View();
        }

        public ActionResult listadoPersonas()
        {
            //Aqui va el ejercicio de lista de personas




            return View();
        }
    }
}