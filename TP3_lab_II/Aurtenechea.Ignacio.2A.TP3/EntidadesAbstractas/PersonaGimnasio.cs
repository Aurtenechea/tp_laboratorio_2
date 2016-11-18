using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    [Serializable]
    public abstract class PersonaGimnasio :Persona
    {
        #region atributos

        private int _identificador;

        #endregion

        #region para serializar

        public int ID 
        {
            get { return this._identificador; }
            set { this._identificador = value; }
        }

        public PersonaGimnasio() { }

        #endregion

        #region constructores

        /// <summary>
        /// inicializa los campos de PersonaGimnasio
        /// </summary>
        /// <param name="id">id de la PersonaGimnasio</param>
        /// <param name="nombre">nombre de la PersonaGimnasio</param>
        /// <param name="apellido">apellido de la PersonaGimnasio</param>
        /// <param name="dni">dni de la PersonaGimnasio</param>
        /// <param name="nacionalidad">nacionalidad de la PersonaGimnasio</param>
        public PersonaGimnasio(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) 
            :base( nombre, apellido, dni,  nacionalidad)
        {
            this._identificador = id;
        }

        #endregion

        #region metodos

        /// <summary>
        /// Dos PersonaGimnasio son iguales si son del mismo tipo y su id o DNI son iguales.
        /// </summary>
        /// <param name="obj">Objeto con el cual se quiere comparar this.</param>
        /// <returns>
        /// true si son iguales.
        /// false si no lo son.
        /// </returns>
        public bool Equals(object obj)
        {
            if (obj is PersonaGimnasio)
                return (((PersonaGimnasio)obj) == this);
            else
                return false;
        }

        /// <summary>
        /// Retorna un string con los datos de una persona gimnasio.
        /// </summary>
        /// <returns> string con los datos de una persona gimnasio.</returns>
        protected virtual string MostrarDatos()
        {
            return this.ToString() + this._identificador.ToString();

        }

        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Dos PersonaGimnasio son iguales si son del mismo tipo y su id o DNI son iguales.
        /// </summary>
        /// <param name="pg1">PersonaGimnasio a comparar.</param>
        /// <param name="pg2">PersonaGimnasio a comparar.</param>
        /// <returns>
        /// true si son iguales.
        /// false si no lo son.
        /// </returns>
        public static bool operator == (PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            if (pg1.GetType() == pg2.GetType() && (pg1.DNI == pg2.DNI || pg1._identificador == pg2._identificador) )
                return true;
                return false;
        }

        /// <summary>
        /// Dos PersonaGimnasio son iguales si son del mismo tipo y su id o DNI son iguales.
        /// </summary>
        /// <param name="pg1">PersonaGimnasio a comparar.</param>
        /// <param name="pg2">PersonaGimnasio a comparar.</param>
        /// <returns>
        /// true si son distintas.
        /// false si no lo son.
        /// </returns>
        public static bool operator !=(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            return !(pg1 == pg2);
        }

        #endregion
        

    }
}
