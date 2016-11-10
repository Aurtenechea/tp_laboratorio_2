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

        private Gimnasio.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        // <para serializar>=========================
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
        // </para serializar>


        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
            this._estadoCuenta = (EEstadoCuenta)1;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases clasesQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, clasesQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

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
        public string ToString()
        {
            StringBuilder sb = new StringBuilder(this.MostrarDatos());
            return sb.ToString();
        }

        protected override string ParticiparEnClase()
        {
            return "TOMA CLASES DE " + this._claseQueToma;
        }

        public static bool operator ==(Alumno a, Gimnasio.EClases clase)
        {
            if ( !(a != clase) && a._estadoCuenta != EEstadoCuenta.Deudor)
                return true;
            else
                return false;
        }
        public static bool operator !=(Alumno a, Gimnasio.EClases clase)
        {
            if (a._claseQueToma != clase)
                return true;
            else
                return false;
        }
       



    }
}
