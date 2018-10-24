using _04_MandarDatosAlControlador_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _04_MandarDatosAlControlador_MVC.Controllers
{
    public class HomeController : Controller
    {
        
        /// <summary>
        /// Primera peticion de la vista Editar
        /// Creamos un objeto de clase clsPersona y lo enviamos
        /// </summary>
        /// <returns>un objeto tipo clsPersona</returns>
        public ActionResult Editar()
        {
            clsPersona p1 = new clsPersona(1, "Angel", "deBo", new DateTime(1987,8,11), "Calle Lejos", "123456789");

            return View(p1);
        }

        /// <summary>
        /// Envio del usuario submit/post con los datos modificados de la persona
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Editar(clsPersona p)
        {
            //Investigar como llamar a otra vista y pasarle el objeto
            //EditarViewModel model = new EditarViewModel();


            //return View(p);

            //return RedirectToAction("vistaPersona", "Home", p);
            return View("vistaPersona", p);
        }
    }
}