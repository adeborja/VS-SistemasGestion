using _07_CRUDPersonas_DAL.Manejadoras;
using _07_CRUDPersonas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_CRUDPersonas_BL.Manejadoras
{
    public class clsManejadoraPersona_BL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public clsPersona PersonaPorID_BL(int id)
        {
            clsManejadoraPersona_DAL manejadora = new clsManejadoraPersona_DAL();
            clsPersona persona = manejadora.personaPorID_DAL(id);

            return persona;
        }

        public int borrarPersonaPorID_BL(int id)
        {
            clsManejadoraPersona_DAL manejadora = new clsManejadoraPersona_DAL();
            int filas = manejadora.borrarPersonaPorID_DAL(id);

            return filas;
        }
    }
}
