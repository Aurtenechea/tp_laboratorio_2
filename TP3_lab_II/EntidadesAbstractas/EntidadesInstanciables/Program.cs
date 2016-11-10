using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;

namespace EntidadesInstanciables
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Quisiera aclarar que me resulto bastante confuso el TP.. Lleva mucho tiempo entender que es lo que se pretende que hay que hacer.
             * Entonces uno pasa mas tiempo intentando decifrar eso, que pensando como hacer, o como resolver el problema.
             * Incluso luego de mucho tiempo razonandolo, termina dudando.. Con lo cual se pierde mucho tiempo de trabajo.
             *  
             * En el punto dos de la clase persona, interpreto que debo lazar la excepcion DniInvalidoException siempre que el dni no cumpla con la 
             * condicion descrita... No lo puse por que en el main no hay un catch que este manejando esa excepcion y pincha el programa.
             * 
             * Tambien encontre varios errores, si es que lo son claro.. porque tambien podrian ser errores de interpretacion mios.
             * No detallo todas las dudas que tengo, y los "errores" que creo que encontre sobre el TP porque me llevaria demasiado tiempo..
             * 
             * Tampoco me queda claro si se pueden agregar metodos, propiedades, etc que no esten especificadas en el pdf. En algunos casos lo hice porque no encontre otra manera de resolverlo. 
             * (por ejemplo para serializar)
             * 
             * Asi llegue hasta este punto, faltan cosas. No me dio el tiempo para hacerlas.
             * Saludos!
             * 
             */

            Gimnasio gim = new Gimnasio();
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456",EntidadesAbstractas.Persona.ENacionalidad.Argentino, Gimnasio.EClases.CrossFit, Alumno.EEstadoCuenta.MesPrueba);
            
            gim += a1;
            try
            {   
                // no se si deberia ser cargado o no...
                Alumno a2 = new Alumno(2, "Juana", "Martinez", "12234458", EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Gimnasio.EClases.Natacion, Alumno.EEstadoCuenta.Deudor);
                gim += a2;
            }
            catch (NacionalidadInvalidaException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                Alumno a3 = new Alumno(3, "José", "Gutierrez", "12234456", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Gimnasio.EClases.CrossFit, Alumno.EEstadoCuenta.MesPrueba);
                gim += a3;
            }
            catch (AlumnoRepetidoException e)
            {
                Console.WriteLine(e.Message);
            }
            Alumno a4 = new Alumno(4, "Miguel", "Hernandez", "92264456",EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Gimnasio.EClases.Pilates, Alumno.EEstadoCuenta.AlDia);
            gim += a4;
            Alumno a5 = new Alumno(5, "Carlos", "Gonzalez", "12236456",EntidadesAbstractas.Persona.ENacionalidad.Argentino, Gimnasio.EClases.CrossFit, Alumno.EEstadoCuenta.AlDia);
            //alumno igual al alumno a3
            gim += a5;

            Alumno a6 = new Alumno(6, "Juan", "Perez", "12234656",EntidadesAbstractas.Persona.ENacionalidad.Argentino, Gimnasio.EClases.Natacion, Alumno.EEstadoCuenta.Deudor);
            gim += a6;
            Alumno a7 = new Alumno(7, "Joaquin", "Suarez", "91122456",EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Gimnasio.EClases.Natacion,Alumno.EEstadoCuenta.AlDia);
            gim += a7;
            Alumno a8 = new Alumno(8, "Rodrigo", "Smith", "22236456",EntidadesAbstractas.Persona.ENacionalidad.Argentino, Gimnasio.EClases.Pilates,Alumno.EEstadoCuenta.AlDia);
            gim += a8;
            Instructor i1 = new Instructor(1, "Juan", "Lopez", "12234456", EntidadesAbstractas.Persona.ENacionalidad.Argentino);
            gim += i1;
            Instructor i2 = new Instructor(2, "Roberto", "Juarez", "32234456",EntidadesAbstractas.Persona.ENacionalidad.Argentino);
            gim += i2;

            try
            {
                gim += Gimnasio.EClases.CrossFit;
            }
            catch (SinInstructorException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                gim += Gimnasio.EClases.Natacion;
            }
            catch (SinInstructorException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                gim += Gimnasio.EClases.Pilates;
            }
            catch (SinInstructorException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                gim += Gimnasio.EClases.Yoga;
            }
            catch (SinInstructorException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine(gim.ToString());
            Console.ReadKey();
            try
            {
                Gimnasio.Guardar(gim);
                Console.WriteLine("Archivo de Gimnasio guardado");
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
            int jornada = 0;
            Jornada.Guardar(gim[jornada]); // jornada es un int y vale 0...
            Console.WriteLine("Archivo de Jornada {0} guardado", jornada);
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();


            //agregado por mi ========================================================

            //gim = null;
            //Archivos.Xml<Gimnasio> auxLeer= new Archivos.Xml<Gimnasio>();
            //auxLeer.leer("Gimnasio.xml", out gim);

        }
    }
}
