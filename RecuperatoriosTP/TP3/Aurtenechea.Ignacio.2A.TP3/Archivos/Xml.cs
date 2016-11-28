using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{

    public class Xml<T> : IArchivo<T> where T : class
    {

        #region metodos

        /// <summary>
        /// Guarda como Xml en un archivo llamado como el parametro "archivo" los datos contenidos en el parametro "datos".
        /// Lanza una excepcion ArchivosException si no pudo guardar.
        /// </summary>
        /// <param name="archivo">Nombre del archivo en el que se desea guardar.</param>
        /// <param name="datos">Datos a guardar en el archivo.</param>
        /// <returns>
        /// true si se pudo guardar.
        /// false si no. 
        /// </returns>
        public bool guardar(string archivo, T datos)
        {
            bool aux = false;
            try
            {
                using (XmlTextWriter escritor = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(T));
                    serializador.Serialize(escritor, datos);
                    aux = true;
                }
            }
            catch
            {
                throw new Exception("No se pudo guardar el archivo como Xml.");
                //throw new ArchivosException("No se pudo guardar en el archivo.");
            }
            return aux;
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
        public bool leer(string archivo, out T datos) 
        {
            bool result = false;
            try
            {
                using (XmlTextReader lector = new XmlTextReader(archivo))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(T));
                    datos = (T)serializador.Deserialize(lector);
                    result = true;
                }
            }
            catch 
            {
                datos = null;
                throw new Exception("No se pudo leer del archivo.");
                //throw new ArchivosException("No se pudo leer del archivo.");
            }
            
            return result;
        }

        #endregion

    }
}
