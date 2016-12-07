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
        /// Si falla lanza una excepcion ArchivosException.
        /// </summary>
        /// <param name="datos">Datos a guardar en el archivo.</param>
        public void guardar(string datos)
        {
            try
            {
                using (StreamWriter escritor = new StreamWriter(this.direccionArchivo, true))
                {
                    escritor.WriteLine(datos.Remove((int)datos.LongCount() - 1));
                }
            }
            catch
            {
                throw new ArchivosException("No se pudo guardar en el archivo de texto.");
            }
            
        }

        /// <summary>
        /// Lee los datos del archivo con el que se inicializo el objeto de la clase y los guarda en la lista 
        /// pasada como parametro (out datos). 
        /// Si falla lanza una excepcion ArchivosException.
        /// </summary>
        /// <param name="datos">Lista donde se cargaran los datos leidos del archivo.</param>
        public void leer(out List<string> datos)
        {
            StreamReader lector = null;
            datos = new List<string>();
            string s;
            try
            {
                lector = new StreamReader(this.direccionArchivo);
                while (null != (s = lector.ReadLine()))
                {
                    datos.Add(s);
                }
            }
            catch
            {
                throw new ArchivosException("No se pudo leer del archivo de texto.");
            }
            finally
            {
                lector.Close();
            }
        }
    }
}
