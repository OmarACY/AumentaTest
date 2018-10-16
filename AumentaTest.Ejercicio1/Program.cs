using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AumentaTest.Ejercicio1
{
    class Program
    {
        private static readonly int[] Items = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

        static void Main(string[] args)
        {
            Console.WriteLine("Introduzca el valor a validar: ");

            var inputVal = Console.ReadLine();

            if (int.TryParse(inputVal, out var number))
            {
                Console.WriteLine(Items.Contains(number) ? "SI ESTA" : "NO ESTA");
            }
            else
            {
                Console.WriteLine("El valor introducido debe de ser un entero.");
            }

            Console.ReadKey();
        }
    }
}
