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

        private List<Alumno> _alumnos;
        private List<Instructor> _instructores;
        private List<Jornada> _jornadas;
        
        // <para serializar> ======================
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
        // </para serializar> =====================


        public Jornada this[int i] // lo cambie de lugar. De jornada a gimnasio
        {
            get
            {
                return this._jornadas[i];
            }
        }

        public Gimnasio()
        {
            this._alumnos = new List<Alumno>();
            this._instructores = new List<Instructor>();
            this._jornadas = new List<Jornada>();
        }

        public static bool Guardar(Gimnasio gim)
        {
            // hacer que use guardar de xml no de texto. Tiene que guardar serializado.
            Archivos.Xml<Gimnasio> objXml = new Archivos.Xml<Gimnasio>();
            if ( objXml.guardar("Gimnasio.xml",gim) )
                return true;
                return false; 
        }

        private static string MostrarDatos(Gimnasio gim)
        { 
            
            StringBuilder sb=new StringBuilder();
            foreach (var item in gim._jornadas)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }

        
        public static bool operator !=(Gimnasio g, Alumno a)
        {
            return !(g == a);
        }

        public static Instructor operator !=(Gimnasio g, EClases clase )
        {
            foreach (Instructor item in g._instructores)
            {
                if (item != clase)
                    return item;
            }
            return null;
         }

        public static bool operator !=(Gimnasio g, Instructor i)
        {
            return !(g == i);
        }


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
            if(!flag)
                g._alumnos.Add(a);
            return g; 
        }

        public static Gimnasio operator +(Gimnasio g, EClases clase)
        {
            Jornada j;
            Instructor instructorDesignado = (g == clase);
            
            if (!Object.Equals(instructorDesignado, null))
            {
                j = new Jornada(clase, instructorDesignado);
                
            }
            else
                throw new SinInstructorException();

            foreach (Alumno item in g._alumnos)
            {
                if (item == clase)
                { // en el apunte dice segun ClaseQueToma, sin embargo es mas logico que no tome la clase si su estado es deudor, como lo hace el operador...
                    //g._alumnos.Add(item);
                    j += item;
                }
            }

                g._jornadas.Add(j);

            return g;
        }

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

        public static Instructor operator ==(Gimnasio g, EClases clase)
        {
            foreach (Instructor item in g._instructores)
            {
                if (item == clase)
                    return item;
            }
            return null;
        }

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


        public string ToString()
        {   
            StringBuilder sb = new StringBuilder(Gimnasio.MostrarDatos(this));
            return sb.ToString();
        }



    }
}
