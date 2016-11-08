using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public class Jornada
    {

        private List<Alumno> _alumnos;
        private Gimnasio.EClases _clase;
        private Instructor _instructor;

        // lo lleve a gimnasio.
        //public Jornada this[int i]
        //{
        //    get
        //    {
        //        return this._alumnos[i];
        //    }
        //}

        public bool Guardar(Jornada jornada)
        {
            // completar
            return true;
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
            // completar
           StringBuilder sb = new StringBuilder();
           sb.AppendLine("JORNADA:");
           sb.AppendLine("CLASE DE: " + this._clase + " POR NOMBRE COMPLETO: " + this._instructor.Apellido + ", " + this._instructor.Nombre);
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
