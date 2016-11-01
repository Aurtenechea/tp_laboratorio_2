using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;


namespace EntidadesInstanciables
{
    public sealed class Alumno : PersonaGimnasio
    {
       
        private EClases _claseQueToma;
        private EEstadoDeCuenta _estadoCuenta;

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
            this._estadoCuenta = (PersonaGimnasio.EEstadoDeCuenta)1;

        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases clasesQueToma, EEstadoDeCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, clasesQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + this._estadoCuenta.ToString() + this._claseQueToma.ToString();   
        }
        public string ToString()
        {
            StringBuilder sb = new StringBuilder(this.MostrarDatos());
            return sb.ToString();
        }

        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE " + this._claseQueToma;
        }

        public static bool operator == (Alumno a, EClases clase)
        {
            if ( !(a != clase) && a._estadoCuenta != EEstadoDeCuenta.Deudor)
                return true;
            else
                return false;
        }
        public static bool operator !=(Alumno a, EClases clase)
        {
            if (a._claseQueToma != clase)
                return true;
            else
                return false;
        }



    }
}
