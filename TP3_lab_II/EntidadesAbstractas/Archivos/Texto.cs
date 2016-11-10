using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // guardar/leer en archivos.

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
            throw new NotImplementedException();
        }
    }
}
