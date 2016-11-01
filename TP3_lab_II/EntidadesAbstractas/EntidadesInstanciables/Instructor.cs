using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    sealed class Instructor : PersonaGimnasio  
    {

        private Queue <EClases> _clasesDelDia;
        private static Random _random;


        private void _randomClases()
        {
            this._clasesDelDia.Enqueue( (EClases) Instructor._random.Next(1, 3) );
        }


        static Instructor()
        {   // en el pdf es private pero da error.
            // como hereda, implicitamente llama al constructor del padre por defecto al menos que se explicite algun otro.
            _random = new Random();
        }

        public Instructor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<EClases>();
            for (int i = 0; i < 2; i++)
            {
                this._randomClases();
            }
        }

        protected string MostrarDatos()
        {
            return base.MostrarDatos() + this._clasesDelDia.ToString();
        }
    
        public static bool operator != (Instructor i, EClases clase)
        {
            return !(i == clase);
        }

        public static bool operator ==(Instructor i, EClases clase)
        {
            bool flag = false;
            foreach (EClases item in i._clasesDelDia)
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
