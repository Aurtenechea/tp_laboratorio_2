using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Constructor de la Excepcion ArchivosException
        /// </summary>
        /// <param name="m">Mensaje que se guardara en la propiedad Message.</param>
        public ArchivosException(string m) 
            :base(m)
        {
            
        }

    }
}
