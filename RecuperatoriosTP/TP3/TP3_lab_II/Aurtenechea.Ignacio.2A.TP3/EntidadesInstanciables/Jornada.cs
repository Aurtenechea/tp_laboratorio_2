using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;

namespace EntidadesInstanciables
{
    [Serializable]
    public class Jornada
    {
        #region atributos

        private List<Alumno> _alumnos;
        private Gimnasio.EClases _clase;
        private Instructor _instructor;

        #endregion


        #region para serializar
        public List<Alumno> LsAlumnos
        {
            get { return this._alumnos; }
            set
            {
                this._alumnos = value;
            }
        }
        public Gimnasio.EClases Clase
        {
            get
            {
                return this._clase;
            }
            set
            {
                this._clase = value;
            }
        }
        public Instructor Instructor
        {
            get
            {
                return this._instructor;
            }
            set
            {
                this._instructor = value;
            }
        }
        #endregion

        //el indizador lo pase a gimnasio.

        #region constructores

        /// <summary>
        /// Constructor por defecto. Solo inicializa la lista de alumnos.
        /// </summary>
        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Inicializa los campos clase, instructor y la lista de alumnos de la Jornada.
        /// </summary>
        /// <param name="clase">Clase que se dara en esa jornada.</param>
        /// <param name="instructor">Instructor que dara esa clase.</param>
        public Jornada(Gimnasio.EClases clase, Instructor instructor)
            : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }
        #endregion

        #region metodos

        /// <summary>
        /// Guarda en el archivo Jornada.txt los datos de la Jornada como texto.
        /// </summary>
        /// <param name="jornada">Jornada que se desea guardar.</param>
        /// <returns>
        /// true si se pudo guardar. Si no puede guardar lanzara una excepcion ArchivosException.
        /// false si no.
        /// 
        /// </returns>
        public static bool Guardar(Jornada jornada)
        {
            bool b = false;
            //Archivos.Texto txt = new Archivos.Texto();
            try
            {
                Archivos.Texto objTexto = new Archivos.Texto();
                b = objTexto.guardar("Jornada.txt", jornada.ToString());
                    // el archivo se encontrara en EntidadesInstanciables/bin/Debug/
               
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return b;
        }

        /// <summary>
        /// Lee del archivo Jornada.txt los datos de una Jornada como texto.
        /// </summary>
        /// <returns>
        /// string con los datos del archivo.
        /// Si no puede leer lanzara una excepcion ArchivosException.
        /// </returns>
        public static string Leer ()
        {
            string datos;
            try
            {
                Archivos.Texto objTexto = new Archivos.Texto();
                objTexto.leer("Jornada.txt", out datos);
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return datos;
        }

        /// <summary>
        /// Devuelve un string con los datos de la Jornada.
        /// </summary>
        /// <returns>string con los datos de la Jornada.</returns>
        public override string ToString() 
        {
           StringBuilder sb = new StringBuilder();
           sb.AppendLine("JORNADA:");
           //sb.AppendLine("CLASE DE " + this._clase + " POR NOMBRE COMPLETO: " + this._instructor.Apellido + ", " + this._instructor.Nombre);
           sb.AppendLine("CLASE DE " + this._clase + " POR " + this._instructor.ToString());           
           //sb.AppendLine("NACIONALIDAD: " + this._instructor.Nacionalidad);
           //sb.AppendLine("");
           //sb.AppendLine(this._instructor.ToString());

           sb.AppendLine("\nALUMNOS: ");
           
           foreach (Alumno item in this._alumnos)
           {
               sb.AppendLine(item.ToString());
           }
           sb.AppendLine("<------------------------------------------------------------------------>");
           return sb.ToString();
        }

        /// <summary>
        /// Compara si el alumno "a" no participa de la jornada "j".
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>
        /// false si el alumno participa de la jornada.
        /// true si no.
        /// </returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Compara si el alumno "a" participa de la jornada "j".
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>
        /// true si el alumno participa de la jornada.
        /// false si no.
        /// </returns>
        public static bool operator == (Jornada j, Alumno a)
        {
            bool flag = false;
            
            foreach (Alumno item in j._alumnos)
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
        /// Agrega alumnos a la jornada validando que no esten previamente agregados.
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>
        /// Jornada con el alumno agregado. 
        /// </returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (!(j == a)) // si no existe alumno en la jornada agregarlo. No pide que se valide que el alumno toma esa clase.
            {
                if( ((PersonaGimnasio)a) != ((PersonaGimnasio)j._instructor) )
                     j._alumnos.Add(a);
                
            }
            return j;
        }

        #endregion

    }
}
