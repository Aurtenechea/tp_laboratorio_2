using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_lab_II
{
    public class Calculadora
    {


        /// <summary>
        /// realiza la operacion indicada en operador, con los dos objetos del tipo numero.
        /// </summary>
        /// <param name="numero1">primer numero de la operacion</param>
        /// <param name="numero2">segundo numero de la operacion</param>
        /// <param name="operador">operacion a  realizar, si no es valida sera suma.</param>
        /// <returns>el resultado de la operacion</returns>
        public static double operar(Numero numero1, Numero numero2, string operador) 
        {
            double rta = 0;
            switch (operador)
            { 
                case "+":
                    rta = numero1.getNumero() + numero2.getNumero();
                    break;
                case "-":
                    rta = numero1.getNumero() - numero2.getNumero();
                    break;
                case "*":
                    rta = numero1.getNumero() * numero2.getNumero();
                    break;
                case "/":
                    if (numero2.getNumero() != 0)
                    {
                        rta = numero1.getNumero() / numero2.getNumero();
                    }
                    else
                        rta = 0;
                    break;
            }
            return rta; 
        }


        /// <summary>
        /// valida si la operacion recibida en str es +,-,* o / .
        /// </summary>
        /// <param name="str">string con la operacion</param>
        /// <returns>si es devuelve la misma operacion, sino devuelve +</returns>
        public static string validarOperador(string str) 
        {
            if (str == "+" || str == "-" || str == "*" || str == "/")
            {
                return str;
            }
            else
            {
                return "+";
            }
        }
    }
}
