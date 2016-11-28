using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    class AccesoSitioWebException : Exception
    {

        public AccesoSitioWebException(string m) 
            :base(m)
        {
            
        }
    }
}
