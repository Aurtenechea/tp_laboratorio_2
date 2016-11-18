using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;


namespace EntidadesInstanciables
{
    [Serializable]
    public sealed class Alumno : PersonaGimnasio
    {

        public enum EEstadoCuenta
        {
            Deudor,
            MesPrueba,
            AlDia
        }

        #region atributos

        private Gimnasio.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        #endregion

        #region para serializar
        public Alumno() { }

        public Gimnasio.EClases ClaseQueToma
        {
            get
            {
                return this._claseQueToma;
            }
            set 
            {
                this._claseQueToma = value;
            }
                
        }
            public EEstadoCuenta EstadoCuenta
        {
            get
            {
                return this._estadoCuenta;
            }
            set
            {
                this._estadoCuenta = value;
            }
        }
        #endregion

        #region constructores
        /// <summary>
        /// inicializa los campos de un Alumno.
        /// </summary>
        /// <param name="id">Id del Alumno.</param>
        /// <param name="nombre">Nombre del Alumno.</param>
        /// <param name="apellido">Apellido del Alumno.</param>
        /// <param name="dni">Dni del Alumno.</param>
        /// <param name="nacionalidad">Nacionalidad del Alumno.</param>
        /// <param name="claseQueToma">Clase que toma el Alumno.</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
            this._estadoCuenta = (EEstadoCuenta)1;
        }

        /// <summary>
        /// inicializa los campos de un Alumno.
        /// </summary>
        /// <param name="id">Id del Alumno.</param>
        /// <param name="nombre">Nombre del Alumno.</param>
        /// <param name="apellido">Apellido del Alumno.</param>
        /// <param name="dni">Dni del Alumno.</param>
        /// <param name="nacionalidad">Nacionalidad del Alumno.</param>
        /// <param name="claseQueToma">Clase que toma el Alumno.</param>
        /// <param name="estadoCuenta">Estado de la cuenta del Alumno.</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases clasesQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, clasesQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        #endregion

        #region metodos

        /// <summary>
        /// Devuelve un string con los datos del Alumno.
        /// </summary>
        /// <returns>string con los datos del Alumno.</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("NOMBRE COMPLETO: " + this.Apellido + ", " + this.Nombre);
            sb.AppendLine("NACIONALIDAD: " + this.Nacionalidad);
            sb.AppendLine("CARNET NUMERO: ");
            // falta id
            string s = "";
            switch (this._estadoCuenta)
            {
                case EEstadoCuenta.Deudor:
                    s = "Deudor";
                    break;
                case EEstadoCuenta.MesPrueba:
                    s="Mes de prueba";
                    break;
                case EEstadoCuenta.AlDia:
                    s = "Cuota al dia";
                    break;
            }
            sb.AppendLine("ESTADO DE LA CUENTA: " + s);
            sb.AppendLine(this.ParticiparEnClase());
            
            return sb.ToString();   
        }

        /// <summary>
        /// Devuelve un string con los datos del Alumno.
        /// </summary>
        /// <returns>string con los datos del Alumno.</returns>
        public string ToString()
        {
            StringBuilder sb = new StringBuilder(this.MostrarDatos());
            return sb.ToString();
        }


        /// <summary>
        /// Retorna la cadena "TOMA CLASE DE " junto al nombre de la clase que toma el Alumno.
        /// </summary>
        /// <returns>Retorna la cadena "TOMA CLASE DE " junto al nombre de la clase que toma el Alumno.</returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASES DE " + this._claseQueToma;
        }


        /// <summary>
        /// Compara si el alumno "a" toma la clase "clase".
        /// </summary>
        /// <param name="a">Alumno del cual se quiere saber si toma cierta clase.</param>
        /// <param name="clase">Clase que se quiere saber si el alumno toma.</param>
        /// <returns>
        /// true si el alumno toma la clase y su estado no es deudor.
        /// false si no la toma o su estado es deudor.
        /// </returns>
        public static bool operator ==(Alumno a, Gimnasio.EClases clase)
        {
            if ( !(a != clase) && a._estadoCuenta != EEstadoCuenta.Deudor)
                return true;
            else
                return false;
        }


        /// <summary>
        /// Compara si el alumno "a" no toma la clase "clase".
        /// </summary>
        /// <param name="a">Alumno del cual se quiere saber si toma cierta clase.</param>
        /// <param name="clase">Clase que se quiere saber si el alumno toma.</param>
        /// <returns>
        /// false si el alumno toma la clase y su estado no es deudor.
        /// true si no la toma o su estado es deudor.
        /// </returns>
        public static bool operator !=(Alumno a, Gimnasio.EClases clase)
        {
            if (a._claseQueToma != clase)
                return true;
            else
                return false;
        }

        #endregion



    }
}
