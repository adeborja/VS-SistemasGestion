﻿using _09_ApiRestPersonas_DAL.Listados;
using _09_ApiRestPersonas_Entidades.Complejas;
using _09_ApiRestPersonas_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_ApiRestPersonas_BL.Listados
{
    public class clsListadoPersonasConNombreDeDepartamento_BL
    {
        //#region Propiedades privadas

        //List<clsPersona> _listadoPersonas;
        //List<clsDepartamento> listadoDepartamentos;
        //List<clsPersonaConNombreDeDepartamento> _listaPersonasConNombreDeDepartamentos;

        //#endregion



        public List<clsPersonaConNombreDeDepartamento> listadoCompletoPersonasConNombreDeDepartamento()
        {
            clsListadoPersonas_DAL listadoPersonas_DAL = new clsListadoPersonas_DAL();
            clsListadoDepartamentos_DAL listadoDepartamentos_DAL = new clsListadoDepartamentos_DAL();

            //Obtener lista de personas
            List<clsPersona> listaPersonas = listadoPersonas_DAL.listadoCompletoPersonas_DAL();

            //Obtener lista de departamentos
            List<clsDepartamento> listaDepartamentos = listadoDepartamentos_DAL.listadoCompletoDepartamentos_DAL();

            //Generar lista de personas con nombres de departamento
            List<clsPersonaConNombreDeDepartamento> listaPersonasConNombreDeDepartamentos = new List<clsPersonaConNombreDeDepartamento>();

            try
            {
                for (int i = 0; i < listaPersonas.Count; i++)
                {
                    listaPersonasConNombreDeDepartamentos.Add(new clsPersonaConNombreDeDepartamento(listaPersonas[i], listaDepartamentos));
                }
            }
            catch(Exception e)
            {
                //TODO
            }

            return listaPersonasConNombreDeDepartamentos;
        }

    }
}
