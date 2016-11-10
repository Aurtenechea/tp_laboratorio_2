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
            catch (Exception)
            {
                b = false;
            }
            return b;
        }

        public bool leer(string archivo, out string datos)
        {
            StreamReader lector = null;
            StringBuilder sb = new StringBuilder();
            //datos = "";
           
            bool b = true;
            try
            {
                lector = new StreamReader(archivo);
                //string s = lector.ReadLine();
                sb.Append( lector.ReadToEnd() );
            }
            catch (Exception)
            {
                throw new ArchivosException();
                b = false;
            }
            datos = sb.ToString();
            return b;
           
        }
    }
}
