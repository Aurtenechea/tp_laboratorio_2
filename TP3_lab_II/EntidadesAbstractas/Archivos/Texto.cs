using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    class Texto : IArchivo<Texto>
    {
    
        public bool guardar(string archivo, Texto datos)
        {
    	    throw new NotImplementedException();
        }

        public bool leer(string archivo, out Texto datos)
        {
    	    throw new NotImplementedException();
        }
    }
}
