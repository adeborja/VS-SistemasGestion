using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _08_CRUDpersonasTelefonos_Entidades.Complejos;
using _08_CRUDpersonasTelefonos_Entidades.Persistencia;
using _08_CRUDpersonasTelefonos_BL.Listados;
using _08_CRUDpersonasTelefonos_BL.Manejadoras;

namespace _08_CRUDpersonasTelefonos_UI.Models.ViewModels
{
    public class CambiarTelefonoViewModel
    {

        #region propiedades y atributos

        public clsPersonaConNombreDeDepartamento personaConNombreDeDepartamento { get; set; }
        //public List<clsDepartamento> listaDepartamentos { get; set; }

        #endregion

        #region constructor por parametro

        public CambiarTelefonoViewModel(int id)
        {
            //instanciar elementos para llamar a la capa BL
            clsListadoDepartamentos_BL listadoDepartamentos_BL = new clsListadoDepartamentos_BL();
            clsManejadoraPersona_BL manejadoraPersona_BL = new clsManejadoraPersona_BL();

            //Asignar valores a las variables
            clsPersona persona = manejadoraPersona_BL.buscarPersonaPorID_BL(id);
            List<clsDepartamento> listaDepartamentos = listadoDepartamentos_BL.listadoCompletoDepartamentos_BL();
            personaConNombreDeDepartamento = new clsPersonaConNombreDeDepartamento(persona, listaDepartamentos);
        }


        public CambiarTelefonoViewModel(CambiarTelefonoViewModel objeto)
        {
            this.personaConNombreDeDepartamento = objeto.personaConNombreDeDepartamento;
        }


        #endregion

    }
}