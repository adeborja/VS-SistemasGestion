using _07_CRUDPersonas_DAL.Listados;
using _07_CRUDPersonas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_CRUDPersonas_BL.Listados
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
    }
}
