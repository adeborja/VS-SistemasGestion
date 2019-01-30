using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiLoL.Entidades;
using WebApiLoL.DAL;

namespace WebApiLoL.Controllers
{
    [Route("api/[controller]")]
    public class PersonajesController : Controller
    {
        // GET api/values
        [HttpGet]
        public List<clsPersonaje> Get()
        {
            clsListados listadoPersonajes = new clsListados();
            return listadoPersonajes.listadoPersonajes();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public clsPersonaje Get(int id)
        {
            clsListados listadoPersonajes = new clsListados();
            return listadoPersonajes.datosPersonaje(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            clsManejadoras manejadoraPersonajes = new clsManejadoras();
            manejadoraPersonajes.borrarPersonaje(id);
        }
    }
}
