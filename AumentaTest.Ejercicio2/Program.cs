using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AumentaTest.Ejercicio2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Escribe el valor de (a): ");
            var a = Console.ReadLine();
            Console.Write("Escribe el valor de (b): ");
            var b = Console.ReadLine();
            var listNumbers = GetOddNumbersToRange(Convert.ToInt32(a), Convert.ToInt32(b));
            PrintListNumbers(listNumbers);
            Console.ReadKey();
        }

        private static List<int> GetOddNumbersToRange(int a , int b)
        {
            var listOddNumbers = new List<int>();
            int high, less;
            if (a > b)
            {
                high = a;
                less = b;
            }
            else
            {
                high = b;
                less = a;
            }

            for (var i = less; i < high; i++)
            {
                if(i%2!=0)
                    listOddNumbers.Add(i);
            }

            return listOddNumbers;
        }

        private static void PrintListNumbers(List<int> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
