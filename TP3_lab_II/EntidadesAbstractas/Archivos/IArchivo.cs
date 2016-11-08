using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivo<T> 
    {
        public bool guardar(string archivo, T datos);

        public bool leer(string archivo, out T datos);
    }
}
