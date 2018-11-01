using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _01_HelloWorld_WebForms.Entidades
{
    /**
     * nombre de la clase: clsPersona.cs
     * 
     * propiedades basicas:
     *      nombre: string, consultable y modificable
     *      apellido: string, consultable y modificable
     * 
     * propiedades derivadas: nada
     * 
     * Metodos adicionales
     *      
     * 
     */
    public class clsPersona
    {
        #region "Atributos"
        private string _nombre;          //_nombre: al poner el guion bajo se entiende que el atributo es privado
                                         //private string _apellido;

        #endregion



        #region "Propiedades"
        public string nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
            }
        }


        //cuando no se va a validar se hace el siguiente
        //public int MyProperty { get; set; }  // esto se hace escribiendo 'prop' y dandole dos veces al tabulador

        public string apellido { get; set; }    //asi no hace falta declarar la variable

        #endregion



        /*private string nombre, apellido;

        public clsPersona(string nNombre, string nApellido)
        {
            this.nombre = nNombre;
            this.apellido = nApellido;
        }

        public string getNombre()
        {
            return this.nombre;
        }

        public string getApellido()
        {
            return this.apellido;
        }

        public string getNombreApellidos
        {
            get;
        }*/
    }

    /*public class TestClsPersona
    {
        public static void main()
        {
            var persona1 = new clsPersona("Menga", "Nito");

            Console.WriteLine(persona1.getNombre());
            Console.WriteLine(persona1.getNombreApellidos);
        }
    }*/
}
