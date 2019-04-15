using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// De acuerdo al parametro "operador" se realizará la operación entre num1 y num2, si no puede identificarse el operador, por defecto será suma
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns>Resultado de la operacion deseada</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double valorRet = 0;
            operador = ValidarOperador(operador);
            switch (operador)
            {
                case "+":
                    valorRet = num1 + num2;
                    break;
                case "-":
                    valorRet = num1 - num2;
                    break;
                case "*":
                    valorRet = num1 * num2;
                    break;
                case "/":
                    valorRet = num1 / num2;
                    break;
            }
            return valorRet;
        }
        /// <summary>
        /// Valida el operador que recibe por parametro, si no lo identifica como valido devuelve "+"(suma)
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>El operador valido</returns>
        private static string ValidarOperador(string operador)
        {
            if (!(operador.Equals("+") || operador.Equals("-") || operador.Equals("*") || operador.Equals("/")))
                operador = "+";
            return operador;
        }
    }
}
