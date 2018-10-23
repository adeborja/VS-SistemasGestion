using _03_PasarDatosAVista_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03_PasarDatosAVista_MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //DateTime temp = new DateTime();

            //Construccion del objeto persona
            clsPersona p1 = new clsPersona();
            p1.idPersona = 1;
            p1.nombre = "Angel David";
            p1.apellidos = "de Borja";
            p1.fechaNacimiento = new DateTime(1987, 8, 11); //TryParse("11/8/1987", out temp);
            p1.direccion = "La calle de mi casa";
            p1.telefono = "954459123";

            //Asignar saludo
            ViewData["Saludo"] = cadenaSaludoSegunHora();



            return View(p1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult vistaListado()
        {
            clsListadoPersonas lista = new clsListadoPersonas();



            return View(lista.getListado());
        }



        /// <summary>
        /// Metodo para devolver un saludo dependiendo de la hora del dia
        /// DateTime tiene un intervalo de horas entre 0 y 23
        /// </summary>
        /// <returns>"Buenas dias" si la hora es entre las 5 y las 12:59, "Buenas tardes" si la hora es entre las 13 y las 20:59, "Buenas noches" si la hora es entre las 21 y las 4:59</returns>
        public String cadenaSaludoSegunHora()
        {
            //declaracion de variables
            String saludo = "";
            DateTime fechaActual = DateTime.Today;
            int hora = fechaActual.Hour;
            //int minuto = fechaActual.Minute;

            //Saludo segun la hora del dia
            if (hora >= 5 && hora < 13) saludo = "Buenos dias";
            else if (hora >= 13 && hora < 21) saludo = "Buenas tardes";
            else saludo = "Buenas noches";

            return saludo;
        }
    }
}