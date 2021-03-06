﻿using _09_ApiRestPersonas_BL.Listados;
using _09_ApiRestPersonas_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _09_ApiRestPersonas_API.Controllers
{
    public class DepartamentosController : ApiController
    {
        /// <summary>
        /// Verbo get para peticiones de un listado completo de personas
        /// </summary>
        /// <returns>List---Listado completo de personas</returns>
        public List<clsDepartamento> Get()
        {
            clsListadoDepartamentos_BL listadoDepartamentos_BL = new clsListadoDepartamentos_BL();
            return listadoDepartamentos_BL.listadoCompletoDepartamentos_BL();
        }

        /*
        /// <summary>
        /// Verbo get para pedir una persona por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>clsPersona---objeto</returns>
        public clsPersona Get(int id)
        {
            clsManejadoraPersona_BL manejadoraPersonas_BL = new clsManejadoraPersona_BL();
            return manejadoraPersonas_BL.buscarPersonaPorID_BL(id);
        }

        /// <summary>
        /// Verbo 
        /// </summary>
        /// <param name="oPersona"></param>
        /// <returns></returns>
        public int Post([FromBody]clsPersona oPersona)
        {
            clsManejadoraPersona_BL manejadoraPersonas_BL = new clsManejadoraPersona_BL();
            int filasAfectadas = manejadoraPersonas_BL.crearPersona_BL(oPersona);
            return filasAfectadas;
        }

        /// <summary>
        /// Verbo 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            clsManejadoraPersona_BL manejadoraPersonas_BL = new clsManejadoraPersona_BL();
            int filasAfectadas = manejadoraPersonas_BL.borrarPersonaPorID_BL(id);
            return filasAfectadas;
        }
        */
    }
}
