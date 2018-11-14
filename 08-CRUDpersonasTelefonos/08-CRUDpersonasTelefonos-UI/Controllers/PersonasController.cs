using _08_CRUDpersonasTelefonos_Entidades.Persistencia;
using _08_CRUDpersonasTelefonos_Entidades.Complejos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _08_CRUDpersonasTelefonos_BL.Listados;
using _08_CRUDpersonasTelefonos_UI.Models.ViewModels;
using _08_CRUDpersonasTelefonos_BL.Manejadoras;

namespace _08_CRUDpersonasTelefonos_UI.Controllers
{
    public class PersonasController : Controller
    {
        // GET: Personas
        public ActionResult Index()
        {
            clsListadoPersonasPorDepartamentoYListadoDepartamentos lista = new clsListadoPersonasPorDepartamentoYListadoDepartamentos();

            return View("listadoPersonas", lista);
        }


        [HttpPost, ActionName("Index")]
        public ActionResult IndexPost(clsListadoPersonasPorDepartamentoYListadoDepartamentos objeto)
        {
            clsListadoPersonas_BL listadoPersonas_BL = new clsListadoPersonas_BL();
            clsListadoPersonasPorDepartamentoYListadoDepartamentos lista = null;

            try
            {
                lista = new clsListadoPersonasPorDepartamentoYListadoDepartamentos(objeto.idDepartamentoSeleccionado);
            }
            catch(Exception e)
            {

            }

            return View("listadoPersonas", lista);
        }


        public ActionResult CambiarTelefono(int id)
        {
            //Llamada para obtener los datos de la persona seleccionada. Crear un viewmodel que reciba un objeto persona con nombre de departamento
            CambiarTelefonoViewModel persona = new CambiarTelefonoViewModel(id);

            ViewData["mensajeAlGuardar"] = "TEXTO DE PRUEBA";

            //Pasar la lista a la vista de cambiar telefono
            return View("CambiarTelefono", persona);
        }
        

        [HttpPost, ActionName("CambiarTelefono")]
        public ActionResult CambiarTelefonoPost(CambiarTelefonoViewModel objeto) //clsPersonaConNombreDeDepartamento CambiarTelefonoViewModel
        {
            int filasAfectadas = -1;
            clsManejadoraPersona_BL manejadora_BL = new clsManejadoraPersona_BL();

            filasAfectadas = manejadora_BL.editarTelefonoPersonaPorID_BL(objeto.personaConNombreDeDepartamento.idPersona, objeto.personaConNombreDeDepartamento.telefono);

            //CambiarTelefonoViewModel persona = new CambiarTelefonoViewModel(objeto.personaConNombreDeDepartamento.idPersona);

            if (filasAfectadas != 1)
            {
                ViewData["mensajeAlGuardar"] = "Se ha producido un error";
            }
            else
            {
                ViewData["mensajeAlGuardar"] = "Se ha guardado el telefono correctamente";
            }

            return View(objeto);
        }



        public ActionResult regresoTablaConIdDepartamento(CambiarTelefonoViewModel objeto)
        {
            clsListadoPersonas_BL listadoPersonas_BL = new clsListadoPersonas_BL();
            clsListadoPersonasPorDepartamentoYListadoDepartamentos lista = null;

            try
            {
                lista = new clsListadoPersonasPorDepartamentoYListadoDepartamentos(objeto.personaConNombreDeDepartamento.idDepartamento);
            }
            catch (Exception e)
            {

            }

            return View("listadoPersonas", lista);
        }

    }
}