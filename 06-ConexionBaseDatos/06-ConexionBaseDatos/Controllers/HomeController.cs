using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using _06_ConexionBaseDatos.Models.Entidades;

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
                miConexion.ConnectionString = "server=personaserver.database.windows.net;database=personasDB;uid=prueba;pwd=123qweasd!;";

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

            IEnumerable<clsPersona> lista = new List<clsPersona>();

            lista.Add(new clsPersona(0, "Angel David", "de Borja", new DateTime(1987, 8, 11), "Calle de mi casa X", "954459123", 1));
            lista.Add(new clsPersona(1, "Menga", "Nito", new DateTime(1999, 9, 9), "Calle Falsa 9", "954999999", 2));
            lista.Add(new clsPersona(2, "Pepe", "Pinazo", new DateTime(2001, 9, 11), "Calle Antigua s/n", "555-4785", 3));



            return View(lista);
        }
    }
}