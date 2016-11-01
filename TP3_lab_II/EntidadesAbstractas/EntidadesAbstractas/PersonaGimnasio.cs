using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class PersonaGimnasio :Persona
    {
        public enum EClases
        {
            CrossFit,
            Natacion,
            Pilates
        }
        public enum EEstadoDeCuenta
        {
            Deudor,
            Sarasa
        }

        private int _identificador;

        public PersonaGimnasio(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) 
            :base( nombre, apellido, dni,  nacionalidad)
        {
            this._identificador = id;
        }

        public bool Equals(object obj)
        {
            if (obj is PersonaGimnasio)
                return (((PersonaGimnasio)obj) == this);
            else
                return false;
        }

        protected virtual string MostrarDatos()
        {
            return this.ToString() + this._identificador.ToString();

        }


        protected abstract string ParticiparEnClase();

        


        public static bool operator == (PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            if (pg1.DNI == pg2.DNI || pg1._identificador == pg2._identificador)
                return true;
                return false;
        }
        public static bool operator !=(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            return !(pg1 == pg2);
        }


    }
}
