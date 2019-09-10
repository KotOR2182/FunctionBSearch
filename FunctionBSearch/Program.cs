using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace FunctionBSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество чисел в массиве: ");
            List<int> listNumber = GenerationNumber(NumberInput());
            int[] orderByArray = SortingArray(listNumber);
            Console.Write("Введите X : ");
            int index = BSearch(orderByArray, NumberInput());
            ExitProgramm($"Индекс равен {index}");
        }
        static int NumberInput()
        {
            int numInput = 0;
            try
            {
                while (numInput == 0)
                {
                    if (!int.TryParse(Console.ReadLine(), out numInput))
                        Console.Write("\nВведенное значение не является целым числом.Попробуйте еще раз : ");
                }
            }
            catch (Exception ex)
            {
                ExitProgramm($"\nОй ошибочка {ex.Message}");
            }
            return numInput;
        }
        static List<int> GenerationNumber(int amount)
        {
            Random genNumber = new Random();
            try
            {
                List<int> listNumber = new List<int>();
                Console.Write("Заполнение массива случайными числами: ");
                for (int i = 0; i < amount; i++)
                {
                    var num = genNumber.Next(-50, 50);
                    listNumber.Add(num);
                    Console.Write($"{num} ");
                }
                Console.WriteLine();
                return listNumber;
            }
            catch (Exception ex)
            {
                ExitProgramm($"Ой ошибочка {ex.Message}");
            }
            return null;
        }
        static int[] SortingArray(List<int> listNum)
        {
            int[] array = listNum.OrderBy(x => x).ToArray();
            Console.Write("Сортировка массива по возрастанию: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();
            return array;
        }
        // насчет не обязательных параметров, не совсем понял что с ними делать поэтому сделал не обязательный параметр y
        static int BSearch(int[] array, int x, object[] y = null)
        {
            if (!array.Any(item => item > x))
                ExitProgramm($"В массиве нет элементов больше {x}.");

            int index = 0;
            foreach (var item in array)
            {
                if (item > x)
                    break;

                index++;
            }
            return index;
        }
        static void ExitProgramm(string msg)
        {
            Console.WriteLine(msg);
            Console.ReadKey();
            Environment.Exit(1);
        }

    }
}