using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_12_Library
{
    public class Automovil : Vehiculo
    {
        #region constructores
        /// <summary>
        /// Constructor de la clase Automovil. Inicializa los campos del Automovil.
        /// </summary>
        /// <param name="marca">Marca del Automovil.</param>
        /// <param name="patente">Patente del Automovil.</param>
        /// <param name="color">Color de Automovil.</param>
        public Automovil(EMarca marca, string patente, ConsoleColor color)
            : base(patente, marca, color)
        {
        }
        #endregion

        #region propiedades
        /// <summary>
        /// Devuelve la cantidad de ruedas del Automovil. Los automoviles tienen 4 ruedas
        /// </summary>
        public override short CantidadRuedas
        {
            get
            {
                return 4;
            }
        }
        #endregion  

        #region metodos
        /// <summary>
        /// Devuelve los datos de un automovil.
        /// </summary>
        /// <returns>String con los datos del automovil.</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("AUTOMOVIL");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("RUEDAS : {0}", this.CantidadRuedas);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
