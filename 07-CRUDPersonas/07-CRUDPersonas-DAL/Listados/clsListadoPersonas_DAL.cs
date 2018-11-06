using _07_CRUDPersonas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_CRUDPersonas_DAL.Listados
{
    public class clsListadoPersonas_DAL
    {
        public List<clsPersona> listadoCompletoPersonas()
        {
            List<clsPersona> lista = new List<clsPersona>();

            //TODO copiar y pegar
            lista.Add(new clsPersona(0, "Angel David", "de Borja", new DateTime(1987, 8, 11), "Calle de mi casa X", "954459123", 1));
            lista.Add(new clsPersona(1, "Menga", "Nito", new DateTime(1999, 9, 9), "Calle Falsa 9", "954999999", 2));
            lista.Add(new clsPersona(2, "Pepe", "Pinazo", new DateTime(2001, 9, 11), "Calle Antigua s/n", "555-4785", 3));


            return lista;
        }
    }
}
