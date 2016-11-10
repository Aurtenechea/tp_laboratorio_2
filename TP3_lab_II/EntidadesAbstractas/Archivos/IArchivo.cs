using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivo<T> 
    {
        // no se puede usar static en una interfaz
        bool guardar(string archivo, T datos);

        bool leer(string archivo, out T datos);
    }
}
