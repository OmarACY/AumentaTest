using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * Casos de prueba : 
 * 1. Datos de entrada no enteros: El programa validará si el numero introducido es de tipo entero cuando asi se requiera.
 * 2. Datos de entrada muy grandes: Si el usuario ingresa valores muy grandes, el programa le pedira introducir un valor valido.
 */

namespace AumentaTest.Ejercicio2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Escribe el valor de (a): ");
            var a = GetUserElement();
            Console.Write("Escribe el valor de (b): ");
            var b = GetUserElement();
            var listNumbers = GetOddNumbersToRange(a, b);
            Console.WriteLine($"Los numeros imapres entre {a} y {b} son:");
            PrintListNumbers(listNumbers);
            Console.ReadKey();
        }

        /**
         * <summary>
         * Obtiene los numeros impares encontrados entre "a" y "b"
         * </summary>
         */
        /// <param name="a">Numero entero</param>
        /// <param name="b">Numero entero</param>
        private static List<int> GetOddNumbersToRange(int a , int b)
        {
            var listOddNumbers = new List<int>();
            var high = a > b ? a : b;
            var less = a < b ? a : b;

            for (var i = less; i <= high; i++)
            {
                if(i%2!=0) listOddNumbers.Add(i);
            }

            return listOddNumbers;
        }

        /**
         * <summary>
         * Imprime un listado de numeros en consola separados por coma
         * </summary>
         */
        private static void PrintListNumbers(List<int> list)
        {
            foreach (var item in list)
            {
                Console.Write($"{item}, ");
            }
        }

        /**
         * <summary>
         * Metodo para pedir un elemento de tipo entero al usuario
         * </summary>
         */
        ///<returns>Numero entero</returns>
        private static int GetUserElement()
        {
            bool valid;
            int number;
            do
            {
                valid = int.TryParse(Console.ReadLine(), out number);
                if (valid) continue;
                Console.Write("Por favor introduce un valor entero: ");
            } while (!valid);

            return number;
        }
    }
}
