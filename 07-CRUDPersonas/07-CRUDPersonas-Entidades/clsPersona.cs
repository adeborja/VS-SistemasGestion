﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _07_CRUDPersonas_Entidades
{
    public class clsPersona
    {
        #region constructor por defecto

        public clsPersona()
        {
            
        }

        #endregion

        #region constructor por parametros

        public clsPersona(int nIdPersona, String nNombre, String nApellido, DateTime nFechaNacimiento, String nDireccion, String nTelefono, int nIdDepartamento)
        {
            this.idPersona = nIdPersona;
            this.nombre = nNombre;
            this.apellidos = nApellido;
            this.fechaNacimiento = nFechaNacimiento;
            this.direccion = nDireccion;
            this.telefono = nTelefono;
            this.idDepartamento = nIdDepartamento;
        }

        public clsPersona(String nNombre, String nApellido, DateTime nFechaNacimiento, String nDireccion, String nTelefono, int nIdDepartamento)
        {
            this.idPersona = -1;
            this.nombre = nNombre;
            this.apellidos = nApellido;
            this.fechaNacimiento = nFechaNacimiento;
            this.direccion = nDireccion;
            this.telefono = nTelefono;
            this.idDepartamento = nIdDepartamento;
        }

        #endregion


        #region atributos y propiedades

        public int idPersona { get; set; }
        public String nombre { get; set; }
        public String apellidos { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public String direccion { get; set; }
        public String telefono { get; set; }
        public int idDepartamento { get; set; }


        #endregion
    }
}