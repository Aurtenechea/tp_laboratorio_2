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

        private Queue <Gimnasio.EClases> _clasesDelDia;
        private static Random _random;

        //eliminar
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
        //</eliminar>


        private void _randomClases()
        {
            this._clasesDelDia.Enqueue((Gimnasio.EClases)Instructor._random.Next(0, 4));
            //Console.WriteLine( Instructor._random.Next(0, 3) );
            
        }
        

        static Instructor()
        {   // en el pdf es private pero da error.
            // como hereda, implicitamente llama al constructor del padre por defecto al menos que se explicite algun otro.
            _random = new Random();
        }

        public Instructor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Gimnasio.EClases>();
            for (int i = 0; i < 2; i++)
            {
                this._randomClases();
            }
        }

        protected string MostrarDatos()
        { 
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CARNET NUMERO: ");
            // falta id
            sb.AppendLine("CLASES DEL DIA: ");
            sb.AppendLine(this._clasesDelDia.ElementAt(0).ToString());
            sb.AppendLine(this._clasesDelDia.ElementAt(1).ToString());

            return sb.ToString() ;
        }

        public static bool operator !=(Instructor i, Gimnasio.EClases clase)
        {
            return !(i == clase);
        }

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

        protected override string ParticiparEnClase() 
        {
            return "CLASES DEL DIA " + this._clasesDelDia.ToString();
        }

        public string ToString() 
        {
            return this.MostrarDatos();
        }

    }
}
