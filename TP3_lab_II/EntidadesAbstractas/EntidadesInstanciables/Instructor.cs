using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    [Serializable]
    sealed public class Instructor : PersonaGimnasio
    {

        #region atributos

        private Queue <Gimnasio.EClases> _clasesDelDia;
        private static Random _random;

        #endregion

        #region para serializar

        public Gimnasio.EClases[] ClasesDelDia
        {
            get
            {   
                Gimnasio.EClases[] arrayEclases= new Gimnasio.EClases[2] ;
                this._clasesDelDia.CopyTo(arrayEclases, 0);
                return arrayEclases;
            }
            set
            {
                this._clasesDelDia = new Queue<Gimnasio.EClases>(value);
            }

        }
        public Instructor() { }

        #endregion


        #region constructores

        /// <summary>
        /// Inicializa el atributo estatico random del instructor.
        /// </summary>
        static Instructor()
        {   
            // en el pdf es private pero da error.
            // como hereda, implicitamente llama al constructor del padre por defecto al menos que se explicite algun otro.
            _random = new Random();
        }

        /// <summary>
        /// Inicializa los campos id, nombre, apellido, dni, nacionalidad , clases del dia (con 2 clases elegidas de forma aleatoria).
        /// </summary>
        /// <param name="id">Id del instructor</param>
        /// <param name="nombre">Nombre del instructor</param>
        /// <param name="apellido">Apellido del instructor</param>
        /// <param name="dni">Dni del instructor</param>
        /// <param name="nacionalidad">Nacionalidad del instructor</param>
        public Instructor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Gimnasio.EClases>();
            for (int i = 0; i < 2; i++)
            {
                this._randomClases();
            }
        }

        #endregion

        #region metodos
        /// <summary>
        /// Asigna dos clases al azar al aatributo ClasesDelDia del instructor.
        /// </summary>
        private void _randomClases()
        {
            this._clasesDelDia.Enqueue((Gimnasio.EClases)Instructor._random.Next(0, 4));
        }
        

        
        /// <summary>
        /// Devuelve un string con los datos del instructor.
        /// </summary>
        /// <returns>string con los datos del instructor.</returns>
        protected string MostrarDatos()
        { 
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CARNET NUMERO: ");
            sb.AppendLine("CLASES DEL DIA: ");
            sb.AppendLine(this._clasesDelDia.ElementAt(0).ToString());
            sb.AppendLine(this._clasesDelDia.ElementAt(1).ToString());

            return sb.ToString() ;
        }


        /// <summary>
        /// Compara si el instructor "i" da la clase "clase".
        /// </summary>
        /// <param name="i">Instructor.</param>
        /// <param name="clase">Clase que se quiere comparar con el instructor.</param>
        /// <returns>
        /// false si el instructor da esa clase.
        /// true si no la da.
        /// </returns>
        public static bool operator !=(Instructor i, Gimnasio.EClases clase)
        {
            return !(i == clase);
        }


        /// <summary>
        /// Compara si el instructor "i" da la clase "clase".
        /// </summary>
        /// <param name="i">Instructor.</param>
        /// <param name="clase">Clase que se quiere comparar con el instructor.</param>
        /// <returns>
        /// true si el instructor da esa clase.
        /// false si no la da.
        /// </returns>
        public static bool operator ==(Instructor i, Gimnasio.EClases clase)
        {
            bool flag = false;
            foreach (Gimnasio.EClases item in i._clasesDelDia)
            {
                if (item == clase)
                    flag = true;
            }
            return flag;
        }

        /// <summary>
        /// Retorna la cadena "CLASES DEL DÍA " junto al nombre de la clases que da.
        /// </summary>
        /// <returns>
        /// Retorna la cadena "CLASES DEL DÍA " junto al nombre de la clases que da.
        /// </returns>
        protected override string ParticiparEnClase() 
        {
            return "CLASES DEL DIA " + this._clasesDelDia.ToString();
        }


        /// <summary>
        /// Devuelve un string con los datos del instructor.
        /// </summary>
        /// <returns> 
        /// string con los datos del instructor.
        /// </returns>
        public string ToString() 
        {
            return this.MostrarDatos();
        }

        #endregion

    }
}
