
using _07_CRUDPersonas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _07_CRUDPersonas_UI.ViewModels
{
    public class clsPersonaConListaDeDepartamentos : clsPersona
    {
        #region constructor por defecto

        public clsPersonaConListaDeDepartamentos() : base()
        {
            
        }

        #endregion

        #region constructor por parametros

        /*public clsPersonaConListaDeDepartamentos(int nIdPersona, String nNombre, String nApellido, DateTime nFechaNacimiento,
                                                    String nDireccion, String nTelefono, int nIdDepartamento) //, List<clsDepartamento> nLista
                                                    : base(nIdPersona, nNombre, nApellido, nFechaNacimiento,
                                                    nDireccion, nTelefono, nIdDepartamento)
        {
            //this.listadoDepartamentos = nLista;

            //instancia un objeto tipo clsListadoDeDepartamentos y lo inicializa con la lista recibida
            //clsListadoDeDepartamentos listado = new clsListadoDeDepartamentos();
            //listadoDepartamentos = listado.listadoCompletoDepartamentos(); //cambiar a atributo recibido

            clsListadoDeDepartamentos listado = new clsListadoDeDepartamentos();
            listadoDepartamentos = listado.listadoCompletoDepartamentos(); //cambiar a atributo recibido
        }*/

        #endregion


        #region atributos y propiedades

        public List<clsDepartamento> listadoDepartamentos { get; set; }
        

        #endregion
    }
}