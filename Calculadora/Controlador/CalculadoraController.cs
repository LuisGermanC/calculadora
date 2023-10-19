using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculadora.Modelo;

namespace Calculadora.Controlador
{
    public class CalculadoraController
    {
        private readonly Calculador calculadora;
        public CalculadoraController()
        {
            calculadora = new Calculador();
        }
        public string OperarNumero1(double num1, char operacion)
        {
            double resultado = 0;
            switch (operacion)
            {
                case '²':
                    resultado = calculadora.Potencia(num1);
                    break;
                case '√':
                    resultado = calculadora.Raiz(num1);
                    break;
                case 's':
                    resultado = calculadora.Seno(num1);
                    break;
                case 'c':
                    resultado = calculadora.Coseno(num1);
                    break;
                default:
                    return "0";
            }
            return resultado.ToString();
        }


        public string RealizarOperacion(double num1, double num2, char operacion)
        {
            double resultado = 0;        
            switch (operacion)
            {
                case '+':
                    resultado = calculadora.Sumar(num1, num2);
                    break;
                case '-':
                    resultado = calculadora.Restar(num1, num2);
                    break;
                case 'x':
                    resultado = calculadora.Multiplicar(num1, num2);
                    break;
                case '/':
                    try
                    {
                        resultado = calculadora.Dividir(num1, num2);
                    }
                    catch (ArgumentException ex)
                    {                       
                        return "No se puede dividir por cero";
                    }
                    break;
                default:
                    return "0";
            }
            return resultado.ToString();
        }

    }
}
