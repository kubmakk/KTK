using System;

namespace PracticalWork7_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Задание 1 ---");
            Console.WriteLine(ToUpperCase("hello world"));

            Console.WriteLine("--- Задание 2 ---");
            Console.WriteLine($"Факториал 5: {FactorialIterative(5)}");

            Console.WriteLine("--- Задание 3 ---");
            Console.WriteLine($"Цифр в числе 12345: {CountDigits(12345)}");
            Console.WriteLine($"Цифр в числе 7: {CountDigits(7)}");

            Console.WriteLine("--- Задание 4 ---");
            int[] nums = { 2, 4, 6, 8, 10 };
            Console.WriteLine($"Среднее: {Average(nums)}");

            Console.WriteLine("--- Задание 5 ---");
            Console.WriteLine($"Площадь квадрата (ст. 5): {Area(5)}");
            Console.WriteLine($"Площадь прямоугольника (4x6): {Area(4, 6)}");
            Console.WriteLine($"Площадь круга (радиус 3.0): {Area(3.0):F2}");

            Console.WriteLine("--- Задание 6 ---");
            Console.WriteLine($"Sum int: {Sum(10, 20)}");
            Console.WriteLine($"Sum double: {Sum(5.5, 2.3)}");

            Console.WriteLine("--- Задание 7 ---");
            int a = 1, b = 9;
            Swap(ref a, ref b);
            Console.WriteLine($"a = {a}, b = {b}");

            Console.WriteLine("--- Задание 8 ---");
            int q, r;
            Divide(10, 3, out q, out r);
            Console.WriteLine($"10 / 3 = {q} (остаток {r})");

            Console.WriteLine("--- Задание 9 ---");
            Console.WriteLine($"Массив содержит 6? {Contains(nums, 6)}");
            Console.WriteLine($"Массив содержит 99? {Contains(nums, 99)}");

            Console.WriteLine("--- Задание 10 ---");
            int minVal, maxVal;
            MinMax(nums, out minVal, out maxVal);
            Console.WriteLine($"Min: {minVal}, Max: {maxVal}");

            Console.ReadKey();
        }
//1
        static string ToUpperCase(string text)
        {
            return text.ToUpper();
        }
//2
        static int FactorialIterative(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
//3
        static int CountDigits(int n)
        {
            int count = 0;
            int temp = n; 

            if (temp == 0) return 1;

            while (temp > 1)
            {
                temp = temp / 10;
                count++;
            }

            return count;
        }
//4
        static double Average(int[] arr)
        {
            double sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum = sum + arr[i];
            }
            return sum / arr.Length;
        }
//5
        static int Area(int side)
        {
            return side * side;
        }
        static int Area(int width, int height)
        {
            return width * height;
        }

        static double Area(double radius)
        {
            return Math.PI * radius * radius;
        }
//6
        static int Sum(int a, int b)
        {
            return a + b;
        }

        static double Sum(double a, double b)
        {
            return a + b;
        }
//7
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
//8
        static void Divide(int a, int b, out int quotient, out int remainder)
        {
            quotient = a / b;
            remainder = a % b;
        }

        static bool Contains(int[] arr, int value)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == value) return true;
            }
            return false;
        }


        static void MinMax(int[] arr, out int min, out int max)
        {
            min = arr[0];
            max = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < min) min = arr[i];
                if (arr[i] > max) max = arr[i];
            }
        }
    }
}