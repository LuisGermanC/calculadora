using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora.Modelo
{
    public class Calculador
    {
        public double Sumar(double num1, double num2)
        {
            return num1 + num2;
        }

        public double Restar(double num1, double num2)
        {
            return num1 - num2;
        }

        public double Multiplicar(double num1, double num2)
        {
            return num1 * num2;
        }

        public double Dividir(double num1, double num2)
        {
            if (num2 == 0)
            {
                throw new ArgumentException("No se puede dividir por cero.");
            }
            return num1 / num2;
        }

        public double Potencia(double num1)
        {
            num1 = Math.Pow(num1, 2);
            return num1;
        }

        public double Raiz(double num1)
        {
            num1 = Math.Sqrt(num1);
            return num1;
        }

        public double Seno(double num1)
        {
            num1 = Math.Sin(num1 * Math.PI / 180);
            return num1;
        }

        public double Coseno(double num1)
        {
            num1 = Math.Cos(num1 * Math.PI / 180);
            return num1;
        }
    }
}
