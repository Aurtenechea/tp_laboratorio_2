using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Clase_12_Library
{
    public class Moto : Vehiculo
    {
        #region constructores
        /// <summary>
        /// Constructor de la clase Moto. Inicializa los campos del Moto.
        /// </summary>
        /// <param name="marca">Marca del Moto.</param>
        /// <param name="patente">Patente del Moto.</param>
        /// <param name="color">Color de Moto.</param>
        public Moto(EMarca marca, string patente, ConsoleColor color)
            : base(patente, marca, color)
        {
        }
        #endregion

        #region propiedades
        /// <summary>
        /// Devuelve la cantidad de ruedas de la moto. Las motos tienen 2 ruedas.
        /// </summary>
        public override short CantidadRuedas
        {
            get
            {
                return 2;
            }
        }
        #endregion

        #region metodos
        /// <summary>
        /// Mostrara los datos de una moto.
        /// </summary>
        /// <returns>String con los datos de la moto.</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MOTO");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("RUEDAS : {0}", this.CantidadRuedas);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
