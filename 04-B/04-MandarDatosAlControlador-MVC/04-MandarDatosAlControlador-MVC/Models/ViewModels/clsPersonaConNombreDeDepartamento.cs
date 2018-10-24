using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _04_MandarDatosAlControlador_MVC.Models.ViewModels
{
    public class clsPersonaConNombreDeDepartamento : clsPersona
    {
        #region constructor por defecto

        public clsPersonaConNombreDeDepartamento() : base()
        {

        }

        #endregion

        #region constructor por parametros

        public clsPersonaConNombreDeDepartamento(int nIdPersona, String nNombre, String nApellido, DateTime nFechaNacimiento,
                                                    String nDireccion, String nTelefono, int nIdDepartamento, String nNombreDepartamento) //, List<clsDepartamento> nLista
                                                    : base(nIdPersona, nNombre, nApellido, nFechaNacimiento,
                                                    nDireccion, nTelefono, nIdDepartamento)
        {
            this.nombreDepartamento = nNombreDepartamento;

            //coger el nombre del departamento segun el id
        }

        #endregion


        #region atributos y propiedades

        public String nombreDepartamento { get; set; }


        #endregion
    }
}