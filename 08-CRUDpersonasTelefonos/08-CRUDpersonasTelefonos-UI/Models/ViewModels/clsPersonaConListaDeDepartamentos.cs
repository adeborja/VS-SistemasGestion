
using _08_CRUDpersonasTelefonos_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _08_CRUDpersonasTelefonos_UI.Models.ViewModels
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
                                                    String nDireccion, String nTelefono, int nIdDepartamento, List<clsDepartamento> nLista)
                                                    : base(nIdPersona, nNombre, nApellido, nFechaNacimiento,
                                                    nDireccion, nTelefono, nIdDepartamento)
        {
            //this.listadoDepartamentos = nLista;

            //instancia un objeto tipo clsListadoDeDepartamentos y lo inicializa con la lista recibida
            //clsListadoDeDepartamentos listado = new clsListadoDeDepartamentos();
            //listadoDepartamentos = listado.listadoCompletoDepartamentos(); //cambiar a atributo recibido
            listadoDepartamentos = nLista;
        }

        #endregion


        #region atributos y propiedades

        public List<clsDepartamento> listadoDepartamentos { get; set; }
        

        #endregion
    }
}