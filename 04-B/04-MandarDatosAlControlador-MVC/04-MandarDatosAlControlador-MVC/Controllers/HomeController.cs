using _04_MandarDatosAlControlador_MVC.Models;
using _04_MandarDatosAlControlador_MVC.Models.DAL;
using _04_MandarDatosAlControlador_MVC.Models.ViewModels;
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
            clsPersona p1 = new clsPersonaConListaDeDepartamentos(1, "Angel", "deBo", new DateTime(1987,8,11), "Calle Lejos", "123456789", 1);

            return View(p1);
        }

        /// <summary>
        /// Envio del usuario submit/post con los datos modificados de la persona
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Editar(clsPersonaConListaDeDepartamentos p)
        {
            //Investigar como llamar a otra vista y pasarle el objeto
            //EditarViewModel model = new EditarViewModel();


            //return View(p);

            //return RedirectToAction("vistaPersona", "Home", p);

            clsListadoDeDepartamentos dep = new clsListadoDeDepartamentos();
            List<clsDepartamento> listaDep = dep.listadoCompletoDepartamentos();
            String nombreDep = "";
            Boolean depEncontrado = false;
            int idPer = p.idDepartamento;

            for (int i=0;i<listaDep.Count && !depEncontrado;i++)
            {
                clsDepartamento oDep = listaDep.ElementAt(i);
                int idDep = oDep.idDepartamento;
                if(idDep==idPer)
                {
                    nombreDep = oDep.nombreDepartamento;
                    depEncontrado = true;
                }
            }

            clsPersonaConNombreDeDepartamento p2 = new clsPersonaConNombreDeDepartamento
                (p.idPersona, p.nombre, p.apellidos, p.fechaNacimiento, p.direccion, p.telefono, p.idDepartamento, nombreDep);

            

            return View("vistaPersona", p2);
        }
    }
}