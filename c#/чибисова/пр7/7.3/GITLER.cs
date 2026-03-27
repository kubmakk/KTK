//7.3
using System;

class Program;

namespace PracticalWork7_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1: " + ReverseString("Привет, мир!"));

            Console.Write("2:");
            PrintNumbers(5);
            Console.WriteLine();

            Console.WriteLine("3: " + FactorialRecursive(5));
            int[] testArray = { 1, 2, 3, 4, 5 };
            Console.WriteLine("4: " + SumArrayRecursive(testArray));
            Console.WriteLine("5: " + CountDigits(12345));
            Console.WriteLine("6: " + SumDigits(123));
            Console.WriteLine("7: " + Power(2, 3));
            Console.WriteLine("8: " + Fibonacci(6));
            Console.WriteLine("9: " + RemoveZeros(105020));

            Console.WriteLine("\n--- Задание 10 ---");
            int[] userArray = InputArray();
            ShowAboveAverage(userArray);

            Console.ReadLine();
        }

        // 1
        public static string ReverseString(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;

            char[] charArray = text.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        // 2
        public static void PrintNumbers(int n)
        {
            if (n < 1) return;
            PrintNumbers(n - 1);
            Console.Write(n + " ");
        }

        // 3
        public static int FactorialRecursive(int n)
        {
            // Базовый случай: факториал 0 и 1 равен 1
            if (n == 0 || n == 1) return 1;
            return n * FactorialRecursive(n - 1);
        }

        // 4
        public static int SumArrayRecursive(int[] arr, int index = 0)
        {
            // Если вышли за пределы массива, возвращаем 0
            if (index >= arr.Length) return 0;
            return arr[index] + SumArrayRecursive(arr, index + 1);
        }

        // 5
        public static int CountDigits(int number)
        {
            if (number == 0) return 1;

            number = Math.Abs(number);
            int count = 0;

            while (number > 0)
            {
                count++;
                number /= 10;
            }
            return count;
        }

        // 6
        public static int SumDigits(int n)
        {
            n = Math.Abs(n);
            if (n == 0) return 0;

            return (n % 10) + SumDigits(n / 10);
        }

        // 7
        public static double Power(double x, int n)
        {
            if (n == 0) return 1;

            if (n < 0) return 1.0 / Power(x, -n);

            return x * Power(x, n - 1);
        }

        // 8
        public static int Fibonacci(int n)
        {
            if (n <= 0) return 0;
            if (n == 1 || n == 2) return 1;

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        // 9
        public static int RemoveZeros(int n)
        {
            if (n == 0) return 0;

            int lastDigit = n % 10;
            int recursiveResult = RemoveZeros(n / 10);

            if (lastDigit == 0)
            {
                return recursiveResult;
            }
            else
            {
                return recursiveResult * 10 + lastDigit;
            }
        }
        public static int[] InputArray()
        {
            Console.Write("Введите количество элементов массива: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Ошибка ввода. Будет создан массив из 3 элементов по умолчанию.");
                n = 3;
            }

            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Введите элемент {i + 1}: ");
                int.TryParse(Console.ReadLine(), out arr[i]);
            }
            return arr;
        }

        public static double Average(int[] arr)
        {
            if (arr == null || arr.Length == 0) return 0;

            int sum = 0;
            foreach (int item in arr)
            {
                sum += item;
            }
            return (double)sum / arr.Length;
        }

        public static void ShowAboveAverage(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                Console.WriteLine("Массив пуст.");
                return;
            }

            double avg = Average(arr);
            Console.WriteLine($"\nСреднее значение элементов: {avg:F2}");
            Console.Write("Элементы, которые больше среднего: ");

            bool found = false;
            foreach (int item in arr)
            {
                if (item > avg)
                {
                    Console.Write(item + " ");
                    found = true;
                }
            }

            if (!found) Console.Write("Таких элементов нет.");
            Console.WriteLine();
        }
    }
}


