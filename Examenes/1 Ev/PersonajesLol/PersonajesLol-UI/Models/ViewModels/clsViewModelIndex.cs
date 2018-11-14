using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonajesLol_Entidades;

namespace PersonajesLol_UI.Models.ViewModels
{
    public class clsViewModelIndex
    {
        #region constructor por defecto

        public clsViewModelIndex()
        {
            listadoPersonajes = new List<clsPersonaje>();
            listadoCategorias = new List<clsCategoria>();
            personajeSeleccionado = new clsPersonaje();
        }

        #endregion

        #region atributos y propiedades

        public List<clsPersonaje> listadoPersonajes { get; set; }
        public List<clsCategoria> listadoCategorias { get; set; }
        public clsPersonaje personajeSeleccionado { get; set; }

        #endregion
    }
}