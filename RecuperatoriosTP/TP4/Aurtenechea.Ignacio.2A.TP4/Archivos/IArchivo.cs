using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivo<T>
    {

        /*
         * Modifique la firma de las funciones para que lancen exepciones en caso de error.
         * Asi ahora retornan void, ya que no tiene sentido que hagan ambas cosas.
         * (return false nunca se ejecutaria).
         */
        void guardar(T datos);
        void leer(out List<T> datos);
    }
}
