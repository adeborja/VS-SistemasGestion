using PersonajesLol_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonajesLol_DAL.Listados;

namespace PersonajesLol_BL.Listados
{
    public class clsListadoPersonajes_BL
    {
        /// <summary>
        /// Funcion que llama al metodo listadoCompletoPersonajes_DAL() de la clase clsListadoPersonajes_DAL para rellenar una lista de objetos clsPersonaje y devolverla
        /// </summary>
        /// <returns></returns>
        public List<clsPersonaje> listadoCompletoPersonajes_BL()
        {
            clsListadoPersonajes_DAL listadoPersonajes_DAL = new clsListadoPersonajes_DAL();
            List<clsPersonaje> listado = listadoPersonajes_DAL.listadoCompletoPersonajes_DAL();

            return listado;
        }
    }
}
