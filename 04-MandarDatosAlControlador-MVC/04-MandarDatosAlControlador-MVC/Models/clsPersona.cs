using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _04_MandarDatosAlControlador_MVC.Models
{
    public class clsPersona
    {
        #region constructor por defecto

        public clsPersona()
        {
            
        }

        #endregion

        #region constructor por parametros

        public clsPersona(int nIdPersona, String nNombre, String nApellido, DateTime nFechaNacimiento, String nDireccion, String nTelefono)
        {
            this.idPersona = nIdPersona;
            this.nombre = nNombre;
            this.apellidos = nApellido;
            this.fechaNacimiento = nFechaNacimiento;
            this.direccion = nDireccion;
            this.telefono = nTelefono;
        }

        #endregion


        #region atributos y propiedades

        public int idPersona { get; set; }
        public String nombre { get; set; }
        public String apellidos { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public String direccion { get; set; }
        public String telefono { get; set; }

        #endregion
    }
}