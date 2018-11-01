using _01_HelloWorld_WebForms.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01_HelloWorld_WebForms
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSaludar_Click(object sender, EventArgs e)
        {
            string nombre;

            nombre = TxbxNombre.Text;
            //nombre = Request.Form["TxbxNombre"]; //no funciona porque al generar el html, cambia el nombre de las claves. La clave sería "ctl00$MainContent$TxbxNombre"

            LblTextoVacio.Text = $"Hola {nombre}, bienvenid@";

            
        }

        protected void btnSaludarClase_Click(object sender, EventArgs e)
        {
            string nombre, apellido;
            clsPersona p1 = new clsPersona();
            p1.nombre = "Menga";
            p1.apellido = "Nito";

            nombre = p1.nombre;
            apellido = p1.apellido;

            nombre = LblTextoVacio.Text = $"Hola, soy {nombre} {apellido}";
        }
    }
}