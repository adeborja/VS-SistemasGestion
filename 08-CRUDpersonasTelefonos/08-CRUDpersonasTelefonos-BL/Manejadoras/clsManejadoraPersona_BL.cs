﻿
using _08_CRUDpersonasTelefonos_DAL.Manejadoras;
using _08_CRUDpersonasTelefonos_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_CRUDpersonasTelefonos_BL.Manejadoras
{
    public class clsManejadoraPersona_BL
    {
        /// <summary>
        /// Funcion que devuelve una persona buscada en la base de datos por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public clsPersona buscarPersonaPorID_BL(int id)
        {
            clsManejadoraPersona_DAL manejadora = new clsManejadoraPersona_DAL();
            clsPersona persona = manejadora.buscarPersonaPorID_DAL(id);

            return persona;
        }


        /// <summary>
        /// Funcion que devuelve el numero de filas afectadas tras borrar una persona en la base de datos por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int borrarPersonaPorID_BL(int id)
        {
            clsManejadoraPersona_DAL manejadora = new clsManejadoraPersona_DAL();
            int filas = manejadora.borrarPersonaPorID_DAL(id);

            return filas;
        }


        /// <summary>
        /// Funcion que devuelve el numero de filas afectadas tras crear una persona en la base de datos
        /// </summary>
        /// <param name="oPersona"></param>
        /// <returns></returns>
        public int crearPersona_BL(clsPersona oPersona)
        {
            clsManejadoraPersona_DAL manejadora = new clsManejadoraPersona_DAL();

            int filasAfectadas = manejadora.crearPersona_DAL(oPersona);

            return filasAfectadas;
        }


        /// <summary>
        /// Funcion que devuelve el numero de filas afectadas tras editar una persona en la base de datos
        /// </summary>
        /// <param name="oPersona"></param>
        /// <returns></returns>
        public int editarPersona_BL(clsPersona oPersona)
        {
            clsManejadoraPersona_DAL manejadora = new clsManejadoraPersona_DAL();

            int filasAfectadas = manejadora.editarPersona_DAL(oPersona);

            return filasAfectadas;
        }



        public int editarTelefonoPersonaPorID_BL(int id, String nTelefono)
        {
            int filasAfectadas = -1;

            clsManejadoraPersona_DAL manejadora_DAL = new clsManejadoraPersona_DAL();

            filasAfectadas = manejadora_DAL.editarTelefonoPersonaPorID_DAL(id, nTelefono);


            return filasAfectadas;
        }
    }
}
