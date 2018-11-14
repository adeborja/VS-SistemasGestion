using PersonajesLol_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonajesLol_DAL.Listados;

namespace PersonajesLol_BL.Listados
{
    public class clsListadoCategorias_BL
    {
        /// <summary>
        /// Funcion que llama al metodo listadoCompletoCategorias_DAL() de la clase clsListadoCategorias_DAL para rellenar una lista de objetos clsCategoria y devolverla
        /// </summary>
        /// <returns></returns>
        public List<clsCategoria> listadoCompletoCategorias_BL()
        {
            clsListadoCategorias_DAL listadoCategorias_DAL = new clsListadoCategorias_DAL();
            List<clsCategoria> listado = listadoCategorias_DAL.listadoCompletoCategorias_DAL();

            return listado;
        }
    }
}
