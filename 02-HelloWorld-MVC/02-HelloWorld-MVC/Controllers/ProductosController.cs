using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02_HelloWorld_MVC.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        /// <summary>
        /// Accion de mi controlador Productos que retorna la vista Listado
        /// </summary>
        /// <returns></returns>
        public ActionResult Listado()
        {
            return View();
        }
    }
}