using _09_ApiRestPersonas_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _09_ApiRestPersonas_Entidades.Complejas
{
    public class clsPersonaConNombreDeDepartamento : clsPersona
    {
        #region constructor por defecto

        public clsPersonaConNombreDeDepartamento() : base()
        {

        }

        #endregion

        #region constructor por parametros

        public clsPersonaConNombreDeDepartamento(clsPersona oPersona, List<clsDepartamento> listaDepartamentos)
                                                    : base(oPersona)
        {
            //coger el nombre del departamento segun el id
            for(int i=1;i<=oPersona.idDepartamento; i++)
            {
                if (i == oPersona.idDepartamento)
                {
                    this.nombreDepartamento = listaDepartamentos[i-1].nombreDepartamento;
                }
            }

        }



        #endregion


        #region atributos y propiedades

        public String nombreDepartamento { get; set; }


        #endregion
    }
}