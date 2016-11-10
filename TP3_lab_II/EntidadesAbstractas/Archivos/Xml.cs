using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{

    public class Xml<T> : IArchivo<T> where T : class
    {

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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
            return aux;
        }

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
            catch (Exception e)
            {
                datos = null;
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
            
            return result;
        }

      
    }
}
