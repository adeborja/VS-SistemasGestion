using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonajesLol_Entidades
{
    public class clsPersonaje
    {

        #region constructor por defecto

        public clsPersonaje()
        {

        }

        #endregion

        #region constructor por parametros

        public clsPersonaje(int nIdPersonaje, String nNombre, String nAlias, double nVida, double nRegeneracion, double nDanno, double nArmadura, double nVelAtaque, double nResistencia, double nVelMovimiento, int nIdCategoria)
        {
            this.idPersonaje = nIdPersonaje;
            this.nombre = nNombre;
            this.alias = nAlias;
            this.vida = nVida;
            this.regeneracion = nRegeneracion;
            this.danno = nDanno;
            this.armadura = nArmadura;
            this.velAtaque = nVelAtaque;
            this.resistencia = nResistencia;
            this.velMovimiento = nVelMovimiento;
            this.idCategoria = nIdCategoria;
        }

        #endregion


        #region atributos y propiedades

        public int idPersonaje { get; set; }
        public String nombre { get; set; }
        public String alias { get; set; }
        public double vida { get; set; }
        public double regeneracion { get; set; }
        public double danno { get; set; }
        public double armadura { get; set; }
        public double velAtaque { get; set; }
        public double resistencia { get; set; }
        public double velMovimiento { get; set; }
        public int idCategoria { get; set; }

        #endregion

    }
}
