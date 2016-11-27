using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public string direccionArchivo;

        /// <summary>
        /// Constructor de Texto.
        /// Inicializa el atributo direccionArchivo con lo que haya en el parametro archivo.
        /// </summary>
        /// <param name="archivo">Direccion del archivo desde donde se va a leer/guardar los datos del historial.</param>
        public Texto(string archivo)
        {
            this.direccionArchivo = archivo;
        }


        /// <summary>
        /// Guarda el dato pasado por el parametro datos en el archivo con el que se inicializo el objeto de la clase. 
        /// </summary>
        /// <param name="datos">Datos a guardar en el archivo.</param>
        /// <returns></returns>
        public bool guardar(string datos)
        {
            bool b = true;
            try
            {
                using (StreamWriter escritor = new StreamWriter(this.direccionArchivo, true))
                {
                    escritor.WriteLine(datos.Remove((int)datos.LongCount()-1));
                }
            }
            catch
            {
                b = false;
                throw new ArchivosException("No se pudo guardar en el archivo de texto.");
            }
            return b;
        }

        /// <summary>
        /// Lee los datos del archivo con el que se inicializo el objeto de la clase y los guarda en la lista 
        /// pasada como parametro (out datos). 
        /// </summary>
        /// <param name="datos">Lista donde se cargaran los datos leidos del archivo.</param>
        /// <returns></returns>
        public bool leer(out List<string> datos)
        {
            StreamReader lector = null;
            datos = new List<string>();
            string s;
            bool b = true;
            try
            {
                lector = new StreamReader(this.direccionArchivo);
                while ( null !=  (s = lector.ReadLine()) )
	            {
                    datos.Add(s);
	            }
            }
            catch
            {
                b = false;
                throw new ArchivosException("No se pudo leer del archivo de texto.");
            }
            return b;
        }
    }
}
