using System;

class Program
{
    static void Main()
    {
        //задание 1
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Hello, world!");
        }

        //задание 2
        Console.Write("Введите N: ");
        int n2 = int.Parse(Console.ReadLine());
        for (int i = 1; i <= n2; i++)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();

        //задание 3
        Console.Write("Введите N: ");
        int n3 = int.Parse(Console.ReadLine());
        int sum3 = 0;
        for (int i = 2; i <= n3; i += 2)
        {
            sum3 += i;
            Console.WriteLine($"Сумма чётных чисел: {sum3}");
        }

        //задание 4
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{i}^2 = {i * i}");
        }

        //задание 5:
        Console.Write("Введите N: ");
        int n5 = int.Parse(Console.ReadLine());
        for (int i = n5; i >= 1; i--)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();

        //задание 6
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{i} * 5 = {i * 5}");
        }

        //задание 7
        int sum7 = 0;
        while (true)
        {
            Console.Write("Введите число (отрицательное для выхода): ");
            int num = int.Parse(Console.ReadLine());
            if (num < 0)
            {
                break;
            }
            sum7 += num;
        }
        Console.WriteLine($"Итоговая сумма: {sum7}");

        //задание 8
        Console.Write("Введите число: ");
        int n8 = Math.Abs(int.Parse(Console.ReadLine()));
        int count8 = (n8 == 0) ? 1 : 0;
        while (n8 > 0)
        {
            n8 /= 10;
            count8++;
        }
        Console.WriteLine($"Количество цифр: {count8}");

        //задание 9
        Console.Write("Введите число: ");
        int n9 = Math.Abs(int.Parse(Console.ReadLine()));
        int sum9 = 0;
        while (n9 > 0)
        {
            sum9 += n9 % 10;
            n9 /= 10;
        }
        Console.WriteLine($"Сумма цифр: {sum9}");

        //задание 10
        Console.Write("Введите число: ");
        string s10 = Console.ReadLine();
        for (int i = s10.Length - 1; i >= 0; i--)
        {
            Console.Write(s10[i]);
        }
        Console.WriteLine();

        //задание 11
        Console.Write("Введите N: ");
        int n11 = int.Parse(Console.ReadLine());
        long factorial = 1;
        for (int i = 1; i <= n11; i++)
        {
            factorial *= i;
        }
        Console.WriteLine($"{n11}! = {factorial}");

        //задание 12
        Console.Write("Введите число A: ");
        double a12 = double.Parse(Console.ReadLine());
        Console.Write("Введите степень N: ");
        int n12 = int.Parse(Console.ReadLine());
        for (int i = 1; i <= n12; i++)
        {
            Console.WriteLine($"{a12}^{i} = {Math.Pow(a12, i)}");
        }

        //задание 13
        Console.Write("Введите N: ");
        int n13 = int.Parse(Console.ReadLine());
        int sum13 = 0;
        for (int i = 1; i <= n13; i++)
        {
            if (i % 7 == 0)
            {
                sum13 += i;
            }
        }
        Console.WriteLine($"Сумма кратных 7: {sum13}");

        //задание 14
        Console.Write("Введите A: ");
        int a14 = int.Parse(Console.ReadLine());
        Console.Write("Введите B: ");
        int b14 = int.Parse(Console.ReadLine());
        if (a14 < b14)
        {
            for (int i = a14; i <= b14; i++)
            {
                Console.Write(i + " ");
            }
        }
        else
        {
            for (int i = a14; i >= b14; i--)
            {
                Console.Write(i + " ");
            }
        }
        Console.WriteLine();

        //задание 15
        Console.Write("Введите N: ");
        int n15 = int.Parse(Console.ReadLine());
        double sum15 = 0;
        for (int i = 1; i <= n15; i++)
        {
            sum15 += 1.0 / i;
        }
        Console.WriteLine($"Сумма ряда: {sum15:F4}");

        //задание 16
        double sum16 = 0;
        int count16 = 0;
        while (true)
        {
            Console.Write("Введите число (0 для итога): ");
            double num = double.Parse(Console.ReadLine());
            if (num == 0)
            {
                break; 
            }
            sum16 += num;
            count16++;
        }
        if (count16 > 0)
        {
            Console.WriteLine($"Среднее: {sum16 / count16:F2}");
        }
        else
        {
            Console.WriteLine("Числа не вводились.");
        }

        //задание 17
        Random rnd = new Random();
        int rand = rnd.Next(1, 11); 
        int attempts = 0;
        Console.WriteLine("Я загадал число от 1 до 10. Попробуй угадать!");
        while (true)
        {
            attempts++;
            Console.Write("Твой вариант: ");
            int userNum = int.Parse(Console.ReadLine());
            if (userNum == rand)
            {
                Console.WriteLine($"Победа! Угадано с {attempts} попытки.");
                break; 
            }
            else if (userNum < rand)
            {
                Console.WriteLine("Больше!");
            }
            else
            {
                Console.WriteLine("Меньше!");
            }
        }
    }
}