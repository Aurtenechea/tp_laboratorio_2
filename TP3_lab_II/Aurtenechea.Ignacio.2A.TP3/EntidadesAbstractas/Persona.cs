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

        #region atributos

        private string _nombre;
        private string _apellido;
        private ENacionalidad _nacionalidad;
        private int _dni;

        #endregion

        #region propiedades

        /// <summary>
        /// Devuelve el nombre de la persona o bien guarda el nombre de la persona analizando previamente si el string contiene caracteres
        /// especiales. Si contiene esos caracteres no guardara nada en nombre.
        /// </summary>
        public string Nombre
        {
            get 
            {
                return this._nombre;
            }
            set 
            {
                if (ValidarNombreApellido(value))
                {
                    this._nombre = value;
                }
                else 
                {
                    throw new Exception("Nombre invalido.");
                }
            }
        }
       
        /// <summary>
        /// Devuelve el apellido de la persona o bien guarda el apellido de la persona analizando previamente si el string contiene caracteres
        /// especiales. Si contiene esos caracteres no guardara nada en apellido.
        /// </summary>
        public string Apellido
        {
            get
            {
                return this._apellido;
            }
            set
            {
                if (ValidarNombreApellido(value))
                {
                    this._apellido = value;
                }
                else
                {
                    throw new Exception("Apellido invalido.");
                }
            }
        }

        /// <summary>
        /// Retornara o guardara el dni de la persona. Al guardarlo previamente sera validado segun su nacionalidad.
        /// </summary>
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

        /// <summary>
        /// Retornara o guardara la nacionalidad de la persona.
        /// </summary>
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


        /// <summary>
        /// Guarda el dni de la persona pasado como string. Antes de guardarlo lo valida segun su nacionalidad.
        /// </summary>
        public string StringToDNI
        {
            set 
            {
                this._dni = ValidarDni(this.Nacionalidad, value);
            }
        }

        #endregion

        #region constructores

        
        #region para serializar
        /// <summary>
        /// constructor por defecto usado para serializar.
        /// </summary>
        public Persona() { }
        #endregion
       

        /// <summary>
        /// Inicializa los campos nombre, apellido y nacionalidad al crear una persona.
        /// </summary>
        /// <param name="nombre">Nombre de la persona.</param>
        /// <param name="apellido">Apellido de la persona.</param>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        protected Persona(string nombre, string apellido, ENacionalidad nacionalidad) 
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Inicializa los campos nombre, apellido, dni (como int) y nacionalidad al crear una persona.
        /// </summary>
        /// <param name="nombre">Nombre de la persona.</param>
        /// <param name="apellido">Apellido de la persona.</param>
        /// <param name="dni">Dni de la persona como int.</param>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        protected Persona(string nombre, string apellido,int dni, ENacionalidad nacionalidad)
            :this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Inicializa los campos nombre, apellido, dni (como string) y nacionalidad al crear una persona.
        /// </summary>
        /// <param name="nombre">Nombre de la persona.</param>
        /// <param name="apellido">Apellido de la persona.</param>
        /// <param name="dni">Dni de la persona como string.</param>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        protected Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region metodos

        /// <summary>
        /// Devuelve un string con los datos de la persona.
        /// </summary>
        /// <returns>string con los datos de la persona.</returns>
        public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("NOMBRE COMPLETO: " + this.Apellido + ", " + this.Nombre);
            sb.AppendLine("NACIONALIDAD: " + this.Nacionalidad);
            return sb.ToString();
        }

        /// <summary>
        /// Valida el dni de una persona segun su nacionalidad.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        /// <param name="dato">Dni de la persona como int</param>
        /// <returns>
        /// Dni. Si dato es un entero entre 1 y 89999999 y la nacionalidad es argentino, o si dni esta entre 90000000 y 99999999 y 
        /// la nacionalidad es extranjero.
        /// 0. Si no es ninguno de los casos anteriores. 
        /// </returns>
        private static int ValidarDni(ENacionalidad nacionalidad, int dato) 
        {
            if (nacionalidad == ENacionalidad.Argentino && (dato > 89999999 || dato < 1))
                throw new NacionalidadInvalidaException();
            if (nacionalidad == ENacionalidad.Extranjero && (dato > 99999999 || dato < 90000000))
                throw new NacionalidadInvalidaException();
            return dato;

            /*
             * sigo pensando que esta mal. Si a uno le pasan una persona en la que no se corresponden los datos
             * no se tiene como determinar si lo que esta mal es el dni o su nacionalidad.
             * Y no esta explicitado en el PDF. Solo que el main captura NacionalidadInvalidaException,
             * con lo cual para mi también esta mal.
             * Por ej podrian poner una nacionalidad extranjero. Al ingresar el dni se comen un numero y ahi sale la excepcion 
             * nacionalidad invalida, cosa que no es cierta. La nacionalidad es correcta, es el dni el que es invalido para esa nacionalidad.
             * Yo crearia una excepcion: NacionalidadDniNoCorrespondientesException()
             */
        }


        /// <summary>
        /// Valida el dni de una persona segun su nacionalidad.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        /// <param name="dato">Dni de la persona como int</param>
        /// <returns>
        /// Dni. Si dato es un entero entre 1 y 89999999 y la nacionalidad es argentino, o si dni esta entre 90000000 y 99999999 y 
        /// la nacionalidad es extranjero.
        /// 0. Si no es ninguno de los casos anteriores, o si el string pasado no es un numero.
        /// </returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int numero;
            if (!int.TryParse(dato, out numero))
                throw new DniInvalidoException();
            return ValidarDni(nacionalidad, numero);
        }

        private bool ValidarNombreApellido(string value) 
        {
            Regex RgxUrl = new Regex("[^A-Z a-záéíóú]");
            bool containsSpecialCharacters = RgxUrl.IsMatch(value);
            if (!containsSpecialCharacters)
                return true;
            return false;
        }



        #endregion

    }
}
