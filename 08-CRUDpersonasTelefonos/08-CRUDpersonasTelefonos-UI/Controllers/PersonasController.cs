using _08_CRUDpersonasTelefonos_Entidades.Persistencia;
using _08_CRUDpersonasTelefonos_Entidades.Complejos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _08_CRUDpersonasTelefonos_BL.Listados;
using _08_CRUDpersonasTelefonos_UI.Models.ViewModels;

namespace _08_CRUDpersonasTelefonos_UI.Controllers
{
    public class PersonasController : Controller
    {
        // GET: Personas
        public ActionResult Index()
        {
            //clsListadoDepartamentos_BL listadoDepartamentos_BL = new clsListadoDepartamentos_BL();
            //List<clsDepartamento> listadoDepartamentos = listadoDepartamentos_BL.listadoCompletoDepartamentos_BL();
            clsListadoPersonasPorDepartamentoYListadoDepartamentos lista = new clsListadoPersonasPorDepartamentoYListadoDepartamentos(1);

            return View("listadoPersonas", lista);
        }


        [HttpPost, ActionName("Index")]
        public ActionResult IndexPost(clsListadoPersonasPorDepartamentoYListadoDepartamentos objeto)
        {
            List<clsPersona> lista = null;
            clsListadoPersonas_BL listadoPersonas_BL = new clsListadoPersonas_BL();

            try
            {
                lista = listadoPersonas_BL.listadoPersonasPorDepartamento_BL(objeto.idDepartamentoSeleccionado);
            }
            catch(Exception e)
            {

            }

            return View("listadoPersonas", lista);
        }


        //[HttpPost, ActionName("listado")]
        //public ActionResult ListadoPost(clsListadoPersonasYListadoDepartamentos)


        //public ActionResult listadoPersonas()
        //{
        //    //clsListadoPersonasConNombreDeDepartamento_BL listadoPersonas_BL = new clsListadoPersonasConNombreDeDepartamento_BL();
        //    clsListadoDepartamentos_BL listadoDepartamentos_BL = new clsListadoDepartamentos_BL();

        //    //List<clsPersonaConNombreDeDepartamento> listaPersonas = listadoPersonas_BL.listadoCompletoPersonasConNombreDeDepartamento();
        //    List<clsDepartamento> listaDepartamentos = listadoDepartamentos_BL.listadoCompletoDepartamentos_BL();
        //    List<clsPersonaConNombreDeDepartamento> listaPersonas = new List<clsPersonaConNombreDeDepartamento>();

        //    //necesario hacer un viewmodel que coja las personas y los deps
        //    return View();
        //}


        //public ActionResult listadoPersonas()
        //{
        //    clsListadoPersonasConNombreDeDepartamento_BL listadoPersonas_BL = new clsListadoPersonasConNombreDeDepartamento_BL();
        //    clsListadoDepartamentos_BL listadoDepartamentos_BL = new clsListadoDepartamentos_BL();

        //    List<clsPersonaConNombreDeDepartamento> listaPersonas = listadoPersonas_BL.listadoCompletoPersonasConNombreDeDepartamento();
        //    List<clsDepartamento> listaDepartamentos = listadoDepartamentos_BL.listadoCompletoDepartamentos_BL();

        //    //necesario hacer un viewmodel que coja las personas y los deps
        //    return View();
        //}


    }
}