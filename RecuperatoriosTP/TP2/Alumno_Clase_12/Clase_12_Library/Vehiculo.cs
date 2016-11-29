using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_12_Library
{
    public abstract class Vehiculo
    {
        public enum EMarca
        {
            Yamaha, Chevrolet, Ford, Iveco, Scania, BMW
        }; 

        private EMarca _marca;
        private string _patente;
        private ConsoleColor _color;

        #region constructores
        /// <summary>
        /// Constructor de la clase Vehiculo. Inicializa los campos del Vehiculo.
        /// </summary>
        /// <param name="marca">Marca del Vehiculo.</param>
        /// <param name="patente">Patente del Vehiculo.</param>
        /// <param name="color">Color de Vehiculo.</param>
        public Vehiculo(string patente, EMarca marca, ConsoleColor color)
        {
            this._patente = patente;
            this._marca = marca;
            this._color = color;
        }
        #endregion

        #region propiedades
        /// <summary>
        /// Retornará la cantidad de ruedas del vehículo
        /// </summary>
        public abstract short CantidadRuedas { get; }
        #endregion

        #region metodos
        /// <summary>
        /// Mostrara los datos del vehiculo.
        /// </summary>
        /// <returns>Un string con los datos de vehiculo.</returns>
        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("PATENTE: {0}\r\n", this._patente);
            sb.AppendFormat("MARCA  : {0}\r\n", this._marca.ToString());
            sb.AppendFormat("COLOR  : {0}\r\n", this._color.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion  

        #region operadores  
        /// <summary>
        /// Dos vehículos son iguales si comparten la misma patente
        /// </summary>
        /// <param name="v1">Primer vehiculo a comparar.</param>
        /// <param name="v2">Segundo vehiculo a comparar.</param>
        /// <returns>True si son iguales
        /// false si no lo son.</returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            if(v2._patente == v1._patente)
                return true;
                return false;
        }

        /// <summary>
        /// Dos vehículos son distintos si su patente es distinta
        /// </summary>
        /// <param name="v1">Primer vehiculo a comparar.</param>
        /// <param name="v2">Segundo vehiculo a comparar.</param>
        /// <returns>True si son distintos
        /// false si no lo son.</returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }
        #endregion
    }

}
