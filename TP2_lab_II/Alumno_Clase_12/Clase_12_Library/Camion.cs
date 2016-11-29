using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_12_Library
{
    public class Camion :Vehiculo
    {
        #region constructores
        /// <summary>
        /// Constructor de la clase camion. Inicializa los campos del camion.
        /// </summary>
        /// <param name="marca">Marca del camion.</param>
        /// <param name="patente">Patente del camion.</param>
        /// <param name="color">Color de camion.</param>
        public Camion(EMarca marca, string patente, ConsoleColor color)
            : base(patente, marca, color)
        {
        }
        #endregion

        #region propiedades
        /// <summary>
        /// Devuelve la cantidad de ruedas de un camion. Los camiones tienen 8 ruedas
        /// </summary>
        public override short CantidadRuedas
        {
            get
            {
                return 8;
            }
        }
        #endregion

        #region metodos
        /// <summary>
        /// Devuelve los datos de un camion.
        /// </summary>
        /// <returns>String con lso datos del camion.</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CAMION");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("RUEDAS : {0}", this.CantidadRuedas);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
