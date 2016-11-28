using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        #region constructores

        public DniInvalidoException()
            : base("El dni es invalido.")
        {
            
        }

        public DniInvalidoException(Exception e)
            : base("El dni es invalido.", e)
        {

        }

        public DniInvalidoException(string mesagge)
            : base(mesagge)
        {

        }

        public DniInvalidoException(string message, Exception e)
            : base(message, e)
        {

        }

        #endregion


    }
}
