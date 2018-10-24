using _04_MandarDatosAlControlador_MVC.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _04_MandarDatosAlControlador_MVC.Models
{
    public class clsPersonaConListaDeDepartamentos : clsPersona
    {
        #region constructor por defecto

        public clsPersonaConListaDeDepartamentos() : base()
        {
            
        }

        #endregion

        #region constructor por parametros

        public clsPersonaConListaDeDepartamentos(int nIdPersona, String nNombre, String nApellido, DateTime nFechaNacimiento,
                                                    String nDireccion, String nTelefono, int nIdDepartamento) //, List<clsDepartamento> nLista
                                                    : base(nIdPersona, nNombre, nApellido, nFechaNacimiento,
                                                    nDireccion, nTelefono, nIdDepartamento)
        {
            //this.listadoDepartamentos = nLista;

            //instancia un objeto tipo clsListadoDeDepartamentos y lo inicializa con la lista recibida
            clsListadoDeDepartamentos listado = new clsListadoDeDepartamentos();
            listadoDepartamentos = listado.listadoCompletoDepartamentos();
        }

        #endregion


        #region atributos y propiedades

        public List<clsDepartamento> listadoDepartamentos { get; set; }
        

        #endregion
    }
}