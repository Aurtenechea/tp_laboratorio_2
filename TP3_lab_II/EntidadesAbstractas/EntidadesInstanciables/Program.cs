using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    class Program
    {
        static void Main(string[] args)
        {
            Alumno test = new Alumno(1, "nacho", "aurtenechea", "35299333", Persona.ENacionalidad.Argentino, PersonaGimnasio.EClases.Natacion, PersonaGimnasio.EEstadoDeCuenta.Sarasa);
            Console.WriteLine(test.ToString());

            if (test == PersonaGimnasio.EClases.CrossFit)
                Console.Write("Toma esa clase.");
            else
                Console.Write("No toma esa clase.");

                
            Console.ReadKey();

                
        }
    }
}
