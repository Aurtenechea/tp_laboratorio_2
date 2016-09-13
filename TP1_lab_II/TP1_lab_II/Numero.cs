using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_lab_II
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// constructor por defecto
        /// </summary>
        public Numero() 
        {
            numero = 0;
        }

        /// <summary>
        /// sobrecarga del constructor. seteea el atributo numero con el numero contenido en  
        /// strNum. Si str num no es un numero valido el valor sera 0.
        /// </summary>
        /// <param name="strNum">string con el numero con el que se cargara el atributo strNum</param>
        public Numero(String strNum) :this() 
        {
            this.setNumero(strNum);
        }

        /// <summary>
        /// Sin uso. 
        /// </summary>
        /// <param name="dblNum"></param>
        public Numero(Double dblNum) { }

        /// <summary>
        /// recibe un string y si es posible castearlo a double retornara ese valor, de lo contrario devuelve cero.
        /// </summary>
        /// <param name="str">el string a validar</param>
        /// <returns>recibe un string y si es posible castearlo a double retornara ese valor, de lo contrario devuelve cero.</returns>
        private static double validarNumero(string str)
        {
            double num;

            if (double.TryParse(str, out num))
                { return num; }
            else 
                { return 0; }
        }

        /// <summary>
        /// recibe un string y si es posible castearlo a double seteara con ese valor el atributo numero, de lo contrario lo setea en cero.
        /// </summary>
        /// <param name="str">el string con el numero a setear</param>
        private void setNumero(string str) 
        {
            this.numero = Numero.validarNumero(str);
        }

        /// <summary>
        /// devuelve el valor del atributo numero.
        /// </summary>
        /// <returns>el valor del atributo numero.</returns>
        public double getNumero() 
        {
            return this.numero;
        }
    }
}
