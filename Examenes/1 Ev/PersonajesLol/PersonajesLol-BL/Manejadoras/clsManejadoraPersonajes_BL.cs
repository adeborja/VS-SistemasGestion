using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonajesLol_Entidades;
using PersonajesLol_DAL.Manejadoras;

namespace PersonajesLol_BL.Manejadoras
{
    public class clsManejadoraPersonajes_BL
    {
        /// <summary>
        /// Funcion que pide a la capa DAL que busque un personaje por su idPersonaje y lo devuelve
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public clsPersonaje buscarPersonajePorID_BL(int id)
        {
            clsManejadoraPersonajes_DAL manejadoraPersonajes_DAL = new clsManejadoraPersonajes_DAL();
            clsPersonaje personaje = manejadoraPersonajes_DAL.buscarPersonajePorID_DAL(id);

            return personaje;
        }

        /// <summary>
        /// funcion que manda a la capa DAL un objeto clsPersonaje para que lo edite en la base de datos y devuelve las filas afectadas
        /// </summary>
        /// <returns></returns>
        public int editarPersonaje_DAL(clsPersonaje personaje)
        {
            int filasAfectadas = -1;
            clsManejadoraPersonajes_DAL manejadoraPersonajes_DAL = new clsManejadoraPersonajes_DAL();

            filasAfectadas = manejadoraPersonajes_DAL.editarPersonaje_DAL(personaje);

            return filasAfectadas;
        }

    }
}
