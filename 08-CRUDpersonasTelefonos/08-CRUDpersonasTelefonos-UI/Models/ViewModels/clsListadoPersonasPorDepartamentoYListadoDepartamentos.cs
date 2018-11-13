using _08_CRUDpersonasTelefonos_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _08_CRUDpersonasTelefonos_BL.Listados;
using _08_CRUDpersonasTelefonos_Entidades.Complejos;

namespace _08_CRUDpersonasTelefonos_UI.Models.ViewModels
{
    public class clsListadoPersonasPorDepartamentoYListadoDepartamentos
    {
        #region constructor por defecto

        public clsListadoPersonasPorDepartamentoYListadoDepartamentos(int idDepartamento)
        {
            //instanciar clases para obtener listas de la capa BL
            clsListadoPersonas_BL listadoPersonas_BL = new clsListadoPersonas_BL();
            clsListadoDepartamentos_BL listadoDepartamentos = new clsListadoDepartamentos_BL();

            this.listaPersonas = listadoPersonas_BL.listadoPersonasPorDepartamento_BL(idDepartamento);
            this.listaDepartamentos = listadoDepartamentos.listadoCompletoDepartamentos_BL();
            idDepartamentoSeleccionado = idDepartamento;
        }

        #endregion
        

        #region atributos y propiedades

        //public List<clsPersonaConNombreDeDepartamento> listaPersonasConNombreDeDepartamento { get; }
        public List<clsPersona> listaPersonas { get; }
        public List<clsDepartamento> listaDepartamentos { get; }
        public int idDepartamentoSeleccionado { get; set; }

        #endregion

    }
}