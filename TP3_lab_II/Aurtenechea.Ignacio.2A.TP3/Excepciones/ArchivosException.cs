using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public  class ArchivosException : Exception
    {
        public ArchivosException(Exception innerException)
            : base("Excepcion de archivos.", innerException)
        {

        }

        ////no va
        //public ArchivosException(string s)
        //    : base(s)
        //{
            
        //}
    }
}
