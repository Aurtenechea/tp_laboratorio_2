using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    [Serializable]
    public class Jornada
    {

        private List<Alumno> _alumnos;
        private Gimnasio.EClases _clase;
        private Instructor _instructor;

        //eliminar
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



        // lo lleve a gimnasio.
        //public Jornada this[int i]
        //{
        //    get
        //    {
        //        return this._alumnos[i];
        //    }
        //}

        public static bool Guardar(Jornada jornada)
        {
            //Archivos.Texto txt = new Archivos.Texto();
            Archivos.Texto objTexto = new Archivos.Texto();
            
                if (objTexto.guardar("Jornada.txt", jornada.ToString()))
                    // el archivo se encontrara en EntidadesInstanciables/bin/Debug/
                    return true;
                    return false;
        }

        private Jornada() 
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(Gimnasio.EClases clase, Instructor instructor)
            : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }

        public string ToString() 
        {
           StringBuilder sb = new StringBuilder();
           sb.AppendLine("JORNADA:");
           sb.AppendLine("CLASE DE " + this._clase + " POR NOMBRE COMPLETO: " + this._instructor.Apellido + ", " + this._instructor.Nombre);
           sb.AppendLine("NACIONALIDAD: " + this._instructor.Nacionalidad);
           sb.AppendLine("");
           sb.AppendLine(this._instructor.ToString());

           sb.AppendLine("ALUMNOS: ");
           
           foreach (Alumno item in this._alumnos)
           {
               sb.AppendLine(item.ToString());
           }
           sb.AppendLine("<------------------------------------------------------------------------>");
           return sb.ToString();
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static bool operator == (Jornada j, Alumno a)
        {
            bool flag = false;
            //if (a.DNI == 0)
            //{
            //    return false;
            //    // si no tiene un dni no hay como saber si el alumno existe.
            //}
            //foreach (Alumno item in j._alumnos)
            //{
            //    if (item.DNI == a.DNI)
            //    {
            //        flag = true;
            //        break;
            //    }
            //}
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

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (!(j == a)) // si no existe alumno en la jornada agregarlo.
            {
                //return j + a;
                j._alumnos.Add(a);
                return j;
            }
            else
                return j;
        }

    }
}
