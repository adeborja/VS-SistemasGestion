
using _08_CRUDpersonasTelefonos_DAL.Listados;
using _08_CRUDpersonasTelefonos_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_CRUDpersonasTelefonos_BL.Listados
{
    public class clsListadoPersonas_BL
    {
        /// <summary>
        /// Funcion que devuelve una lista de personas obtenidas de la capa DAL
        /// </summary>
        /// <returns></returns>
        public List<clsPersona> listadoCompletoPersonas_BL()
        {
            List<clsPersona> lista = new List<clsPersona>();

            //instanciar un objeto
            clsListadoPersonas_DAL objeto = new clsListadoPersonas_DAL();

            lista = objeto.listadoCompletoPersonas_DAL();

            return lista;
        }



        public List<clsPersona> listadoPersonasPorDepartamento_BL(int id)
        {
            clsListadoPersonas_DAL listadoPersonas_DAL = new clsListadoPersonas_DAL();
            List<clsPersona> lista = listadoPersonas_DAL.listadoPersonasPorDepartamento_DAL(id);

            return lista;
        }
    }
}
