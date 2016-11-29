using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_12_Library
{
    public class Concecionaria 
    {
        List<Vehiculo> _vehiculos;
        int _espacioDisponible;
        public enum ETipo
        {
            Moto, Camion, Automovil, Todos
        }

        #region "Constructores"
        
        /// <summary>
        /// Constructor por defecto. Solo es utillizado por otros constructores.
        /// </summary>
        private Concecionaria()
        {
            this._vehiculos = new List<Vehiculo>();
        }

        /// <summary>
        /// Constructor publico, inicializa los campos de la concecionaria.
        /// </summary>
        /// <param name="espacioDisponible"></param>
        public Concecionaria(int espacioDisponible) :this()
        {
            this._espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro la concecionaria y TODOS los vehículos
        /// </summary>
        /// <returns>String con todos los datos de la concecionaria.</returns>
        public string ToString()
        {
            return Concecionaria.Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos de la concesionaria y sus vehículos (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="concecionaria">Concecionaria a exponer</param>
        /// <param name="ETipo">Tipos de Vehiculos a mostrar</param>
        /// <returns>String con los datos que se pidio mostrar segun lo que se haya pasado como parametro.</returns>
        public static string Mostrar(Concecionaria concecionaria, ETipo tipoDeVehiculo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", concecionaria._vehiculos.Count, concecionaria._espacioDisponible);
            sb.AppendLine("");
            foreach (Vehiculo v in concecionaria._vehiculos)
            {
                switch (tipoDeVehiculo)
                {
                    case ETipo.Automovil:
                        if(v is Automovil)
                        sb.AppendLine(v.Mostrar());
                        break;
                    case ETipo.Moto:
                        if (v is Moto)                        
                        sb.AppendLine(v.Mostrar());
                        break;
                    case ETipo.Camion:
                        if (v is Camion)
                        sb.AppendLine(v.Mostrar());
                        break;
                    default:
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }
            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un vehículo a la concecionaria, siempre que haya espacio disponible y este no este cargado previamete.
        /// </summary>
        /// <param name="concecionaria">Objeto del tipo Concecionaria donde se agregará el vehículo</param>
        /// <param name="vehiculo">Objeto del tipo Vehículo a agregar</param>
        /// <returns>Concecionaria con el vehiculo cargado o no segun corresponda.</returns>
        public static Concecionaria operator +(Concecionaria concecionaria, Vehiculo vehiculo)
        {
            bool hayLugar = false;
            bool yaExiste = false;
            if (concecionaria._vehiculos.Count < concecionaria._espacioDisponible)
            {
                hayLugar = true;
                foreach (Vehiculo v in concecionaria._vehiculos)
                {
                    if (v == vehiculo)
                    {
                        yaExiste = true;
                        break;
                    }
                }
            }
            if(!yaExiste && hayLugar)
                concecionaria._vehiculos.Add(vehiculo);
            return concecionaria;
        }


        /// <summary>
        /// Quitará un vehículo de la concecionaria
        /// </summary>
        /// <param name="concecionaria">Objeto del tipo Concecionaria donde se agregará el vehículo</param>
        /// <param name="vehiculo">Objeto del tipo Vehículo a agregar</param>
        /// <returns></returns>
        public static Concecionaria operator -(Concecionaria concecionaria, Vehiculo vehiculo)
        {
            foreach (Vehiculo v in concecionaria._vehiculos  )
            {
                if (v == vehiculo)
                {
                    concecionaria._vehiculos.Remove(v);
                    break;
                }
            }
            return concecionaria;
        }
        #endregion
    }
}
