using _07_CRUDPersonas_BL.Listados;
using _07_CRUDPersonas_BL.Manejadoras;
using _07_CRUDPersonas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _07_CRUDPersonas_UI.Controllers
{
    public class PersonasController : Controller
    {
        // GET: Personas
        public ActionResult listadoCompleto()
        {
            clsListadoPersonas_BL manejadora = new clsListadoPersonas_BL();
            List<clsPersona> listado = new List<clsPersona>();

            try //se pone porque vamos a abrir una conexion con la BD
            {
                listado = manejadora.listadoCompletoPersonas_BL();
            }
            catch(Exception)
            {
                //TODO: mostrar error en la vista con viewbag
            }

            

            return View(listado);
        }


        public ActionResult Delete(int id)
        {
            clsPersona persona = null;

            try
            {
                clsManejadoraPersona_BL manejadora = new clsManejadoraPersona_BL();
                persona = manejadora.PersonaPorID_BL(id);
            }
            catch
            {
                //TODO: mostrar error en la vista con viewbag o viewdata
                ViewData["error"] = "error no controlado";
            }

            return View(persona);
        }

        /// <summary>
        /// ActionResult de pulsar el boton borrar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName ("Delete")]
        public ActionResult DeletePost(int id)
        {
            int filas = -1;

            clsManejadoraPersona_BL manejadora = new clsManejadoraPersona_BL();
            clsListadoPersonas_BL listado = new clsListadoPersonas_BL();
            List<clsPersona> lista = new List<clsPersona>();

            try //se pone porque vamos a abrir una conexion con la BD
            {
                filas = manejadora.borrarPersonaPorID_BL(id);
                lista = listado.listadoCompletoPersonas_BL();
                //ViewData["numFilas"] = $"filas afectadas: {filas}";
                ViewData["numFilas"] = $"Se ha borrado correctamente: {filas} persona";
            }
            catch (Exception)
            {
                //TODO: mostrar error en la vista con viewbag
                ViewData["error"] = "error no controlado";
            }


            return View("listadoCompleto", lista);
        }



        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ActionName ("Create")]
        public ActionResult CreatePost(clsPersona oPersona)
        {
            int filasAfectadas = -1;



            return View();
        }
    }
}