using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;
using System.Xml;
using System.Xml.Serialization;

namespace EntidadesInstanciables
{


    [Serializable]
    public class Gimnasio
    {
        public enum EClases
        {
            CrossFit,
            Natacion,
            Pilates,
            Yoga
        }

        #region atributos

        private List<Alumno> _alumnos;
        private List<Instructor> _instructores;
        private List<Jornada> _jornadas;

        #endregion

        #region para serializar
        public List<Alumno> LsAlumno
        {
            get
            {
                return this._alumnos;
            }
            set 
            {
                this._alumnos = value;
            }
        }

        
        public List<Instructor> LsInstr
        {
            get { return this._instructores; }
            set
            {
                this._instructores = value;
            }
        }
        public List<Jornada> LsJorn
        {
            get { return this._jornadas; }
            set
            {
                this._jornadas = value;
            }
        }
        #endregion

        #region propiedades
        /// <summary>
        /// Indizador de la lista de Jornadas.
        /// </summary>
        /// <param name="i">indice</param>
        /// <returns>La jornada de la lista en el indice i</returns>
        public Jornada this[int i] // lo cambie de lugar. De jornada a gimnasio
        {
            get
            {
                return this._jornadas[i];
            }
        }
        #endregion

        #region constructores
        public Gimnasio()
        {
            this._alumnos = new List<Alumno>();
            this._instructores = new List<Instructor>();
            this._jornadas = new List<Jornada>();
        }
        #endregion

        #region metodos

        /// <summary>
        /// Guarda el gim en un archivo Xml llamado Gimnasio.xml.
        /// El archivo se encontrara en EntidadesInstanciables/bin/Debug/
        /// </summary>
        /// <param name="gim">Gimansio que se desea guardar.</param>
        /// <returns>
        /// true si se pudo guardar.
        /// false si no.
        /// Si no puede guardar lanza un ArchivosException
        /// </returns>
        public static bool Guardar(Gimnasio gim)
        {
            bool b = false;
            try
            {
                Archivos.Xml<Gimnasio> objXml = new Archivos.Xml<Gimnasio>();
                b = objXml.guardar("Gimnasio.xml", gim);
                
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return b;
        }



        /// <summary>
        /// Lee del archivo Gimnasio.xml los datos de un gimnasio y devuelve un gimnasio con los datos cargados.
        /// </summary>
        /// <returns>
        /// Devuelve un gimnasio con los datos cargados del archivo.
        /// Si no puede leer lanzara una excepcion ArchivosException.
        /// </returns>
        public static Gimnasio Leer()
        {
            Gimnasio gim;
            try
            {
                Archivos.Xml<Gimnasio> auxLeer = new Archivos.Xml<Gimnasio>();
                auxLeer.leer("Gimnasio.xml", out gim);
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return gim;
        }

        /// <summary>
        /// Devuelve un string con los datos de un gimnasio.
        /// </summary>
        /// <param name="gim"> Gimnasio del que se desea ver los datos.</param>
        /// <returns>string con los datos de un gimnasio.</returns>
        private static string MostrarDatos(Gimnasio gim)
        { 
            StringBuilder sb=new StringBuilder();
            foreach (var item in gim._jornadas)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Compara si el alumno "a" esta inscripto en el gimnasio "g".
        /// </summary>
        /// <param name="g">Gimnasio</param>
        /// <param name="a">Alumno</param>
        /// <returns>
        /// false si el alumno esta inscripto en el gimnasio.
        /// true si no.
        /// </returns>
        public static bool operator !=(Gimnasio g, Alumno a)
        {
            return !(g == a);
        }


        /// <summary>
        /// Esta comparacion retorna el primer instructor del gimnasio "g" que no es capaz de dar la clase del parametro "clase".
        /// </summary>
        /// <param name="g">Gimnasio</param>
        /// <param name="clase">Clase</param>
        /// <returns>
        /// Retorna el primer instructor del gimnasio "g" que no es capaz de dar la clase del parametro "clase".
        /// Si no encuentra un instructor que no es capaz de dar la clase retorna null.
        /// </returns>
        public static Instructor operator !=(Gimnasio g, EClases clase )
        {
            foreach (Instructor item in g._instructores)
            {
                if (item != clase)
                    return item;
            }
            return null;
         }


        /// <summary>
        /// Compara si el instructor "i" esta dando clases en el gimnasio "g".\
        /// </summary>
        /// <param name="g">Gimnasio.</param>
        /// <param name="i">Instructor.</param>
        /// <returns>
        /// false si el instructor da clases en el gimnasio.
        /// true si no.
        /// </returns>
        public static bool operator !=(Gimnasio g, Instructor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Agrega un alumno a un gimnasio validando que no este previamente cargado.
        /// </summary>
        /// <param name="g">Gimnasio.</param>
        /// <param name="a">Alumno a agregar.</param>
        /// <returns>
        /// Gimnasio con el alumno cargado.
        /// Lanza la excepcion AlumnoRepetidoException si el alumno ya se encuentra cargado.
        /// </returns>
        public static Gimnasio operator +(Gimnasio g, Alumno a)
        {
            bool flag = false;
            foreach (Alumno item in g._alumnos)
            {
                if (item == a) 
                { 
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                g._alumnos.Add(a);
                return g;
            }
            else
                throw new AlumnoRepetidoException();
        }

        /// <summary>
        /// Agrega una clase a un Gimnasio. Esto hace que se agrege una nueva jornada de esa clase con el instructor que dara esa clase y los alumnos que la tomaran. 
        /// </summary>
        /// <param name="g">Gimnasio al cual se desea agregar la clase.</param>
        /// <param name="clase">Clase a agregar al gimnasio</param>
        /// <returns>
        /// Gimnasio con la clase (es decir la jornada de esa clase) agregada.
        /// </returns>
        public static Gimnasio operator +(Gimnasio g, EClases clase)
        {
            Jornada j = null;
            Instructor instructorDesignado = (g == clase);

            if (!Object.Equals(instructorDesignado, null))
            {
                j = new Jornada(clase, instructorDesignado);

            }

            foreach (Alumno item in g._alumnos)
            {
                if (item == clase)
                { 
                    // en el apunte dice segun ClaseQueToma, sin embargo es mas logico que no tome la clase si su estado es deudor, como lo hace el operador...
                    //g._alumnos.Add(item);
                    j += item;
                }
            }

                g._jornadas.Add(j);

            return g;
        }


        /// <summary>
        /// Agrega un instructor a un gimnasio validando que no este previamente cargado.
        /// </summary>
        /// <param name="g">Gimnasio.</param>
        /// <param name="a">Instructor a agregar.</param>
        /// <returns>
        /// Gimnasio con el Instructor cargado.
        /// </returns>
        public static Gimnasio operator +(Gimnasio g, Instructor i)
        {
            bool flag = false;
            foreach (Instructor item in g._instructores)
            {
                if (item == i)
                {
                    flag = true;
                }
            }
            if (!flag)
                g._instructores.Add(i);
            return g; 
        }

        /// <summary>
        /// Compara si el alumno "a" esta inscripto en el gimnasio "g".
        /// </summary>
        /// <param name="g">Gimnasio</param>
        /// <param name="a">Alumno</param>
        /// <returns>
        /// true si el alumno esta inscripto en el gimnasio.
        /// false si no.
        /// </returns>
        public static bool operator ==(Gimnasio g, Alumno a)
        {
            bool flag = false;
            
            foreach (Alumno item in g._alumnos)
            {
                if ((PersonaGimnasio)item == (PersonaGimnasio)a)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }


        /// <summary>
        /// Esta comparacion retorna el primer instructor del gimnasio "g" capaz de dar la clase del parametro "clase".
        /// </summary>
        /// <param name="g">Gimnasio</param>
        /// <param name="clase">Clase</param>
        /// <returns>
        /// Retorna el primer instructor del gimnasio "g" capaz de dar la clase del parametro "clase".
        /// Si no se encuentra un instructor capaz de dar la clase lanza la excepcion SinInstructorException.
        /// </returns>
        public static Instructor operator ==(Gimnasio g, EClases clase)
        {
            foreach (Instructor item in g._instructores)
            {
                if (item == clase)
                    return item;
            }
            throw new SinInstructorException();
            
        }

        /// <summary>
        /// Compara si el instructor "i" esta dando clases en el gimnasio "g".\
        /// </summary>
        /// <param name="g">Gimnasio.</param>
        /// <param name="i">Instructor.</param>
        /// <returns>
        /// true si el instructor da clases en el gimnasio
        /// false si no.
        /// </returns>
        public static bool operator ==(Gimnasio g, Instructor i)
        {
            bool flag = false;
            
            foreach (Instructor item in g._instructores)
            {
                if ((PersonaGimnasio)item == (PersonaGimnasio)i)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        /// <summary>
        /// Retorna un string con los datos del gimansio.
        /// </summary>
        /// <returns>String con los datos del gimansio.</returns>
        public string ToString()
        {   
            StringBuilder sb = new StringBuilder(Gimnasio.MostrarDatos(this));
            return sb.ToString();
        }

        #endregion


    }
}
