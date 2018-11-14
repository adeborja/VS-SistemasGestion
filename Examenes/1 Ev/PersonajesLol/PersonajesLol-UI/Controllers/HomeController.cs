using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonajesLol_Entidades;
using PersonajesLol_BL.Listados;
using PersonajesLol_BL.Manejadoras;
using PersonajesLol_UI.Models.ViewModels;

namespace PersonajesLol_UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        /// <summary>
        /// Funcion que rellena la lista de personajes de un objeto de clase clsViewModelIndex con la lista de personajes 
        /// obtenidas de la capa DAL y lo devuelve a la vista
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            clsListadoPersonajes_BL listadoPersonajes_BL = new clsListadoPersonajes_BL();
            List<clsPersonaje> listado = listadoPersonajes_BL.listadoCompletoPersonajes_BL();
            clsViewModelIndex viewModelIndex = new clsViewModelIndex();
            viewModelIndex.listadoPersonajes = listado;

            return View(viewModelIndex);
        }


        /// <summary>
        /// Funcion que recibe un objeto de clase clsViewModelIndex de la vista del cual se utiliza el campo idPersonaje para
        /// para buscar al personaje en la base de datos y devolverlo a la vista
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Index")]
        public ActionResult IndexPost(clsViewModelIndex objeto)
        {

            clsListadoPersonajes_BL listadoPersonajes_BL = new clsListadoPersonajes_BL();
            clsListadoCategorias_BL listadoCategorias_BL = new clsListadoCategorias_BL();
            clsManejadoraPersonajes_BL manejadoraPersonajes_BL = new clsManejadoraPersonajes_BL();

            List<clsPersonaje> listadoPersonajes = listadoPersonajes_BL.listadoCompletoPersonajes_BL();
            List<clsCategoria> listadoCategorias = listadoCategorias_BL.listadoCompletoCategorias_BL();
            clsViewModelIndex viewModelIndex = new clsViewModelIndex();
            viewModelIndex.listadoPersonajes = listadoPersonajes;
            viewModelIndex.listadoCategorias = listadoCategorias;

            clsPersonaje personaje = manejadoraPersonajes_BL.buscarPersonajePorID_BL(objeto.personajeSeleccionado.idPersonaje);

            viewModelIndex.personajeSeleccionado = personaje;

            ViewData["rutaImagenPersonaje"] = "/Assets/" + viewModelIndex.personajeSeleccionado.nombre+ ".png";

            return View(viewModelIndex);
        }

        /// <summary>
        /// Funcion que recibe un objeto de clase clsViewModelIndex de la vista del cual se utiliza el objeto personajeSeleccionado
        /// para editar al personaje en la base de datos y devolver las filas afectadas y el objeto con los nuevos datos
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public ActionResult Edit(clsViewModelIndex objeto)
        {
            int filasAfectadas = -1;
            clsManejadoraPersonajes_BL manejadoraPersonajes_BL = new clsManejadoraPersonajes_BL();
            clsListadoPersonajes_BL listados = new clsListadoPersonajes_BL();

            filasAfectadas = manejadoraPersonajes_BL.editarPersonaje_DAL(objeto.personajeSeleccionado);

            objeto.listadoPersonajes = listados.listadoCompletoPersonajes_BL();

            if(filasAfectadas==1)
            {
                ViewData["resultadoOperacion"] = "Personaje editado correctamente";
            }
            else
            {
                ViewData["resultadoOperacion"] = "Se ha producido un error";
            }


            return View(objeto);
        }
    }
}