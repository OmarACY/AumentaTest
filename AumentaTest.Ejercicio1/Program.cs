using System;
using System.Linq;


/**
 * Casos de prueba : 
 * 1. Datos de entrada no enteros: El programa validará si el numero introducido es de tipo entero cuando asi se requiera.
 * 2. Datos de entrada muy grandes: Si el usuario ingresa valores muy grandes, el programa le pedira introducir un valor valido.
 * 3. No permitir imprimir arreglos muy grandes: Si el usuario intenta imprimir un arreglo que excede los 1000 elementos
 *                                               el programa no lo permitira por cuestiones de memoria.
 * 4. No validar en arreglos vacios: Si el usuario no llena el arreglo o no se crea correctamente, no podra validar elementos.
 * 5. Metodos con tareas especificas: Todos los metodos tiene tareas especificas reduciendo asi la duplicidad de codigo.
 */

namespace AumentaTest.Ejercicio1
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = FillArray();

            if (array != null)
            {
                TaskForArray(array);
            }
        }

        /**
         * <summary>
         * Utilizado como metodo principal para las tareas del arreglo
         * </summary>
         */
        ///<param name="array">Arreglo para trabajar</param>
        private static void TaskForArray(int[] array)
        {
            Console.WriteLine("--- Listo!, ya tienes tu arreglo, ¿Que quieres hacer con el? ---\n");

            string inputKey;

            do
            {
                Console.WriteLine("Elige una de las siguentes opciones: \n");
                Console.WriteLine("1. Validar si existe elemento.");
                Console.WriteLine("2. Imprimir arreglo.");
                Console.WriteLine("Presione cualquier otra tecla para salir...\n");
                Console.Write("-> ");

                inputKey = Console.ReadLine();

                switch (inputKey)
                {
                    case "1":
                        ValidValue(array);
                        break;
                    case "2":
                        PrintArray(array);
                        break;
                    default:
                        inputKey = "s";
                        break;
                }

            } while (inputKey != "s");
        }

        /**
         * <summary>
         * Utilizado como metodo principal para las tareas del arreglo
         * </summary>
         */
        ///<param name="array">Arreglo en donde se buscara el elemento</param>
        private static void ValidValue(int[] array)
        {
            Console.WriteLine("\nIntroduzca el elemento a validar: ");
            var number = GetUserElement();

            Console.Clear();
            Console.WriteLine($"El elemento {number}: ");
            Console.WriteLine(array.Contains(number) ? "SI ESTA" : "NO ESTA");
            Console.Write("\n");
        }

        /**
         * <summary>
         * Metodo para llenar un arreglo de enteros
         * </summary>
         */
        ///<returns>Arreglo de enteros</returns>
        private static int[] FillArray()
        {
            int[] array;
            Console.WriteLine("--- Primero debes crear y llenar tu arreglo ---\n");
            Console.WriteLine("Elige una de la siguientes opciones: \n");
            Console.WriteLine("1. Crear y llenar arreglo automaticamente (Valores entre 1 y 999).");
            Console.WriteLine("2. Crear y llenar arreglo manualmente.");
            Console.WriteLine("Presione cualquier otra tecla para salir...\n");
            Console.Write("-> ");
            var inputKey = Console.ReadLine();

            switch (inputKey)
            {
                case "1":
                    array = FillRandomArray(GetSizeArray());
                    break;
                case "2":
                    array = FillManuallyArray(GetSizeArray());
                    break;
                default:
                    array = null;
                    break;
            }
            Console.Clear();
            return array;
        }

        /**
         * <summary>
         * Metodo para preguntar el tamaño del arreglo
         * </summary>
         */
        ///<returns>Tamaño del arreglo</returns>
        private static int GetSizeArray()
        {
            Console.WriteLine("\n¿De que tamaño quieres tu arreglo?");
            return GetUserElement();
        }

        /**
         * <summary>
         * Metodo para crear y llenar un arreglo de tamaño n de forma aleatoria
         * </summary>
         */
        ///<param name="n">Tamaño del arreglo</param>
        ///<returns>Arreglo de tamaño n</returns>
        private static int[] FillRandomArray(int n)
        {
            var array = new int[n];
            var r = new Random();
            for (var i = 0; i < n; i++)
            {
                array[i] = r.Next(0, 1000);
            }
            return array;
        }

        /**
         * <summary>
         * Metodo para crear y llenar un arreglo de forma manual
         * </summary>
         */
        ///<param name="n">Tamaño del arreglo</param>
        ///<returns>Arreglo de tamaño n</returns>
        private static int[] FillManuallyArray(int n)
        {
            var array = new int[n];
            for (var i = 0; i < n; i++)
            {
               Console.Write($"Valor posición {i}: ");
                array[i] = GetUserElement();
            }

            return array;
        }

        /**
         * <summary>
         * Metodo para imprimir un arreglo en consola
         * </summary>
         */
        ///<param name="array">Arreglo a imprimir</param>
        private static void PrintArray(int[] array)
        {
            if (array.Length < 10000)
            {
                Console.WriteLine("\nLos elementos de tu arreglo son : ");
                foreach (var item in array)
                {
                    Console.Write($"{item}, ");
                }
            }
            else
            {
                Console.WriteLine("\nTu arreglo es demaciado grande para imprimir en consola.");
            }

            Console.WriteLine("\n");
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