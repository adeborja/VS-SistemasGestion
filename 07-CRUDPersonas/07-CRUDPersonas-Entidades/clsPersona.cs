using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

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

        public clsPersona(clsPersona oPersona)
        {
            this.idPersona = oPersona.idPersona;
            this.nombre = oPersona.nombre;
            this.apellidos = oPersona.apellidos;
            this.fechaNacimiento = oPersona.fechaNacimiento;
            this.direccion = oPersona.direccion;
            this.telefono = oPersona.telefono;
            this.idDepartamento = oPersona.idDepartamento;
        }

        #endregion


        #region atributos y propiedades

        //click derecho en el proyecto de entidades->administrar paquetes NuGet -> Examinar -> buscar "microsoft.asp.", coger microsoft.aspnet.mvc
        //[HiddenInput(DisplayValue =false)]
        public int idPersona { get; set; }

        [Required]
        [Display(Name ="Nombresito")]
        //[HiddenInput(DisplayValue = false)]
        public String nombre { get; set; }

        [Display(Name = "Apellidito")]
        [MaxLength(50), Required(ErrorMessage = "el campo apellido es obligatorio")]
        public String apellidos { get; set; }

        [Display(Name = "Fechita")]
        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}",ApplyFormatInEditMode =true)]
        public DateTime fechaNacimiento { get; set; }

        [Display(Name = "Addressita")]
        [MaxLength(200)]
        public String direccion { get; set; }

        [Display(Name = "Telefonillo")]
        //[RegularExpression(@"^\(?([679]{1})\)?[-. ]?([0-9]{2})[-. ]?([0-9]{2})[-. ]?([0-9]{2})$", ErrorMessage ="Formato de telefono no valido")]
        [RegularExpression(@"^[679]{1}[0-9]{8}$", ErrorMessage ="Formato de telefono no valido, debe empezar por 6, 7 o 9")]
        //[RegularExpression(@"^([679])(d{8})$", ErrorMessage ="Formato de telefono no valido, debe empezar por 6, 7 o 9")]
        public String telefono { get; set; }
        public int idDepartamento { get; set; }


        #endregion
    }
}