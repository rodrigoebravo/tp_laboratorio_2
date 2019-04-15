using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;
        public string SetNumero { set { numero = ValidarNumero(value); } }

        /// <summary>
        /// Recorre el string que recibe por parametro, convirtiendolo, si es posible, a Decimal
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>String decimal</returns>
        public string BinarioDecimal(string binario)
        {
            int acumRetorno = 0;
            int pot = 0;
            for (int i = binario.Length - 1; i >= 0; i--)
            {
                if (!(binario[i] == '1' || binario[i] == '0'))
                    return "Valor inválido";
                int valorOut;
                if (binario[i] == '1')
                {
                    if (int.TryParse(Math.Pow(2, pot).ToString(), out valorOut))
                        acumRetorno += valorOut;
                }
                pot++;
            }
            return acumRetorno.ToString();
        }

        /// <summary>
        /// Recorre el string que recibe por parametro, convirtiendolo, si es posible, a Binario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>String binario</returns>
        public string DecimalBinario(double numero)
        {
            string valorOut = string.Empty;
            if (numero.ToString().Length > 10)
                return "Valor inválido";
            int parteEntera = Convert.ToInt32(numero);
            int valorRestante = parteEntera;
            valorRestante = valorRestante < 0 ? valorRestante * -1 : valorRestante;

            while (valorRestante >= 2)
            {
                int resto = valorRestante % 2;
                valorRestante = valorRestante / 2;
                valorOut = string.Format("{0}{1}", resto.ToString(), valorOut);
            }
            valorOut = string.Format("{0}{1}", valorRestante.ToString(), valorOut);
            return valorOut;
        }
        /// <summary>
        /// Convierte el parametro recibido en binario, mediante el metodo sobrecargado DecimalBinario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>String binario</returns>
        public string DecimalBinario(string numero)
        {
            double doubleOut = 0;
            double.TryParse(numero, out doubleOut);
            string valorOut = DecimalBinario(doubleOut);
            return valorOut;
        }
        /// <summary>
        /// Constructor sin parametros, asigna 0 a numero
        /// </summary>
        public Numero()
        {
            this.numero = 0d;
        }
        /// <summary>
        /// Asigna a la variable numero el parametro
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this.numero = numero;
        }
        /// <summary>
        /// Asigna a strNumero, el string pasado por parametro
        /// </summary>
        /// <param name="strNumero"></param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        /// <summary>
        /// Operador para la resta de dos numeros
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>resultado de la resta</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        /// Operador para la multiplicacion de dos numeros
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>resultado de la multiplicacion</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        /// <summary>
        /// Operador para la división de dos numeros, si el segundo es 0, retornará el minimo valor de una variable del tipo double
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>resultado de la suma, o bien el numero menor que puede contener una variable del tipo double</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero == 0)
                return double.MinValue;
            else
                return n1.numero / n2.numero;
        }
        /// <summary>
        /// Operador para la suma de dos numeros
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Resultado de la suma</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        public double ValidarNumero(string strNumero)
        {
            double ret;
            if (double.TryParse(strNumero, out ret))
                return ret;
            return 0d;
        }
    }
}
