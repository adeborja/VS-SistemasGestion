
using _08_CRUDpersonasTelefonos_DAL.Listados;
using _08_CRUDpersonasTelefonos_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_CRUDpersonasTelefonos_BL.Listados
{
    public class clsListadoDepartamentos_BL
    {
        public List<clsDepartamento> listadoCompletoDepartamentos_BL()
        {
            List<clsDepartamento> lista = new List<clsDepartamento>();

            //instanciar un objeto
            clsListadoDepartamentos_DAL objeto = new clsListadoDepartamentos_DAL();

            lista = objeto.listadoCompletoDepartamentos_DAL();

            return lista;
        }
    }
}
