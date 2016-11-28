using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // guardar/leer en archivos.
using Excepciones;
namespace Archivos
{
    
    public class Texto : IArchivo<string>
    {
        

        #region metodos
        
        /// <summary>
        /// Guarda como texto en un archivo llamado como el parametro "archivo" los datos contenidos en el parametro "datos".
        /// Lanza una excepcion ArchivosException si no pudo guardar.
        /// </summary>
        /// <param name="archivo">Nombre del archivo en el que se desea guardar.</param>
        /// <param name="datos">String con los datos a guardar en el archivo.</param>
        /// <returns>
        /// true si se pudo guardar.
        /// false si no. 
        /// </returns>
        public bool guardar(string archivo, string datos)
        {
            bool b = true;
            try
            {
                using (StreamWriter escritor = new StreamWriter(archivo, true))
                {
                    escritor.WriteLine(datos);
                }
            }
            catch 
            {
                b = false;
                //throw new ArchivosException("No se pudo guardar en el archivo.");
                //throw new Exception("No se pudo guardar en el archivo de texto.");
            }
            return b;
        }



        /// <summary>
        /// Lee del archivo llamado como el parametro "archivo" y los guarda en el parametro "datos".
        /// Lanza una excepcion ArchivosException si no pudo leer.
        /// </summary>
        /// <param name="archivo">Nombre del archivo del que se desea leer.</param>
        /// <param name="datos">Donde se cargaran los datos leidos del archivo.</param>
        /// <returns>
        /// true si se pudo Leer.
        /// false si no. 
        /// </returns>
        public bool leer(string archivo, out string datos)
        {
            StreamReader lector = null;
            StringBuilder sb = new StringBuilder();
           
            bool b = true;
            try
            {
                lector = new StreamReader(archivo);
                sb.Append( lector.ReadToEnd() );
            }
            catch
            {
                b = false;
                //throw new ArchivosException("No se pudo leer del archivo.");
                //throw new Exception("No se pudo leer del archivo de texto.");
            }
            datos = sb.ToString();
            return b;
        }

        #endregion 

    }
}
