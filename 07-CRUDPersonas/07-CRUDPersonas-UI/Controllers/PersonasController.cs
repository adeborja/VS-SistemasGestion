using _07_CRUDPersonas_BL.Listados;
using _07_CRUDPersonas_BL.Manejadoras;
using _07_CRUDPersonas_Entidades;
//using _07_CRUDPersonas_UI.ViewModels;
using _07_CRUDPersonas_Entidades.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _07_CRUDPersonas_UI.Controllers
{
    public class PersonasController : Controller
    {
        /// <summary>
        /// Funcion que devuelve un listado de personas que existan en la base de datos
        /// </summary>
        /// <returns></returns>
        public ActionResult listadoCompleto()
        {
            //clsListadoPersonas_BL manejadora = new clsListadoPersonas_BL();
            //List<clsPersona> listado = new List<clsPersona>();

            clsListadoPersonasConNombreDeDepartamento_BL manejadora = new clsListadoPersonasConNombreDeDepartamento_BL();
            List<clsPersonaConNombreDeDepartamento> listado = new List<clsPersonaConNombreDeDepartamento>();

            try //se pone porque vamos a abrir una conexion con la BD
            {
                //listado = manejadora.listadoCompletoPersonas_BL();
                listado = manejadora.listadoCompletoPersonasConNombreDeDepartamento();
            }
            catch(Exception)
            {
                //TODO: mostrar error en la vista con viewbag
            }

            

            return View(listado);
        }

        /// <summary>
        /// ActionResult que devuelve un objeto de la clase clsPersona con informacion de la persona que se desea borrar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            clsPersona persona = null;

            try
            {
                clsManejadoraPersona_BL manejadora = new clsManejadoraPersona_BL();
                persona = manejadora.buscarPersonaPorID_BL(id);
            }
            catch
            {
                //TODO: mostrar error en la vista con viewbag o viewdata
                ViewData["error"] = "error no controlado";
            }

            return View(persona);
        }

        /// <summary>
        /// ActionResult de pulsar el boton borrar en la vista de borrar una persona
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


        /// <summary>
        /// ActionResult para entrar en la vista Create para crear una persona
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }


        /// <summary>
        /// ActionResult que devuelve la lista de personas en la base de datos despues de introducir una nueva persona
        /// </summary>
        /// <param name="oPersona"></param>
        /// <returns></returns>
        [HttpPost, ActionName ("Create")]
        public ActionResult CreatePost(clsPersona oPersona)
        {
            int filasAfectadas = -1;

            clsManejadoraPersona_BL manejadoraBL = new clsManejadoraPersona_BL();
            clsListadoPersonas_BL listadoBL = new clsListadoPersonas_BL();
            List<clsPersona> lista = new List<clsPersona>();

            try
            {
                filasAfectadas = manejadoraBL.crearPersona_BL(oPersona);
                lista = listadoBL.listadoCompletoPersonas_BL();

                ViewData["numFilas"] = $"Se ha creado correctamente {filasAfectadas} persona";
            }
            catch (Exception)
            {
                ViewData["error"] = "error no controlado";
                }


            return View("listadoCompleto", lista);
        }


        /// <summary>
        /// ActionResult que devuelve un objeto de la clase clsPersona con informacion de la persona que se desea editar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            clsPersona persona = null;

            try
            {
                clsManejadoraPersona_BL manejadora = new clsManejadoraPersona_BL();
                persona = manejadora.buscarPersonaPorID_BL(id);
            }
            catch
            {
                //TODO: mostrar error en la vista con viewbag o viewdata
                ViewData["error"] = "error no controlado";
            }

            return View(persona);
        }


        /// <summary>
        /// ActionResult que devuelve la lista de personas en la base de datos despues de editar una persona
        /// </summary>
        /// <param name="oPersona"></param>
        /// <returns></returns>
        [HttpPost, ActionName ("Edit")]
        public ActionResult EditPost(clsPersona oPersona)
        {
            int filasAfectadas = -1;

            clsManejadoraPersona_BL manejadoraBL = new clsManejadoraPersona_BL();
            clsListadoPersonas_BL listadoBL = new clsListadoPersonas_BL();
            List<clsPersona> lista = new List<clsPersona>();

            try
            {
                filasAfectadas = manejadoraBL.editarPersona_BL(oPersona);
                lista = listadoBL.listadoCompletoPersonas_BL();

                ViewData["numFilas"] = $"Se ha editado correctamente {filasAfectadas} persona";
            }
            catch (Exception)
            {
                ViewData["error"] = "error no controlado";
            }


            return View("listadoCompleto", lista);
        }


        /// <summary>
        /// ActionResult que devuelve un objeto de la clase clsPersona con informacion de la persona seleccionada
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            clsPersona persona = null;

            try
            {
                clsManejadoraPersona_BL manejadora = new clsManejadoraPersona_BL();
                persona = manejadora.buscarPersonaPorID_BL(id);
            }
            catch
            {
                //TODO: mostrar error en la vista con viewbag o viewdata
                ViewData["error"] = "error no controlado";
            }

            return View(persona);
        }
    }
}