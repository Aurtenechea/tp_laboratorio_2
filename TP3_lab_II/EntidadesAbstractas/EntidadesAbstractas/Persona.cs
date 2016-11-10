using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Excepciones;

namespace EntidadesAbstractas
{
    [Serializable]
    public abstract class Persona
    {
        public enum ENacionalidad
        { 
            Argentino,
            Extranjero
        }

        private string _nombre;
        private string _apellido;
        private ENacionalidad _nacionalidad;
        private int _dni;
        
        
        #region propiedades
        public string Nombre
        {
            get 
            {
                return this._nombre;
            }
            set 
            {
                // testear.
                Regex RgxUrl = new Regex("[^A-Z a-z]"); 
                bool containsSpecialCharacters = RgxUrl.IsMatch(value);
                if(!containsSpecialCharacters)
                    this._nombre = value;
            }
        }
        public string Apellido
        {
            get
            {
                return this._apellido;
            }
            set
            {
                Regex RgxUrl = new Regex("[^A-Z a-z]");
                bool containsSpecialCharacters = RgxUrl.IsMatch(value);
                if (!containsSpecialCharacters)
                    this._apellido = value;
            }
        }
        public int DNI
        {
            get 
            {
                return this._dni;
            }
            set 
            {
                this._dni = ValidarDni(this.Nacionalidad ,value);
            }
        }
        public ENacionalidad Nacionalidad
        {
            get 
            {
                return this._nacionalidad;
            }
            set 
            {
                this._nacionalidad = value;
            }
        }
        public string StringToDNI
        {
            set 
            {

                this._dni = ValidarDni(this.Nacionalidad, value);

                //int aux  =ValidarDni(this.Nacionalidad, value)
                //if(aux != 0)
                //    this._dni = aux;
                //else 
                //    throw new DniInvalidoException();
            }
        }
        #endregion
        #region constructores


        //eliminar
        public Persona() { }
        //


        protected Persona(string nombre, string apellido, ENacionalidad nacionalidad) 
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        protected Persona(string nombre, string apellido,int dni, ENacionalidad nacionalidad)
            :this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }
        protected Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion
        #region metodos
        public string ToString()
        {
            StringBuilder sb = new StringBuilder(this.Nombre + this.Apellido + this.DNI.ToString() + this.Nacionalidad.ToString());
            return sb.ToString();
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato) 
        {
            if (nacionalidad == ENacionalidad.Argentino && dato <= 89999999 && dato >= 1)
                return dato;
            else if (nacionalidad == ENacionalidad.Extranjero && dato <= 99999999 && dato >= 90000000)
                return dato;
            else
                //throw new DniInvalidoException();
                return 0;
        }
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int numero;
            bool b = int.TryParse(dato, out numero);
            if(b)
                return ValidarDni(nacionalidad, numero);
                return 0;
        }
        #endregion

    }
}
