using System;

class Program
{
    // Задания 8
    class NegativeNumberException : Exception
    {
        public NegativeNumberException(string message) : base(message) { }
    }

    static void Main()
    {
        // --- Задание 1 ---
        Console.WriteLine("Задание 1");
        Console.Write("Введите число: ");
        string input1 = Console.ReadLine();
        try
        {
            int num = int.Parse(input1);
            Console.WriteLine($"Квадрат: {num * num}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Бро, это не число. Введи цифры");
        }

        Console.WriteLine();

        // --- Задание 2 ---
        Console.WriteLine("Задание 2");
        try
        {
            Console.Write("Число 1: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Число 2: ");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine($"Результат: {a / b}");
        }
        catch (DivideByZeroException) { Console.WriteLine("На ноль делить нельзя"); }
        catch (FormatException) { Console.WriteLine("Вводи только целые числа"); }

        Console.WriteLine();

        // --- Задание 3 ---
        Console.WriteLine("Задание 3");
        Console.Write("Твой возраст: ");
        try
        {
            int age = int.Parse(Console.ReadLine());
            if (age < 0 || age > 120) throw new Exception("Некорректный возраст");
            Console.WriteLine("Возраст принят");
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }

        Console.WriteLine();

        // --- Задание 4 (Исправлено: вызов метода) ---
        Console.WriteLine("Задание 4");
        Console.Write("Введите число (для ReadInt): ");
        int readIntResult = ReadInt();
        Console.WriteLine($"Результат ReadInt: {readIntResult}");

        Console.WriteLine();

        // --- Задание 5 ---
        Console.WriteLine("Задание 5");
        int[] nums5 = { 1, 2, 3, 4, 5 };
        try
        {
            Console.Write("Какой индекс вывести? ");
            int idx = int.Parse(Console.ReadLine());
            Console.WriteLine(nums5[idx]);
        }
        catch (IndexOutOfRangeException) { Console.WriteLine("Нет такого индекса"); }
        catch (FormatException) { Console.WriteLine("Индекс должен быть числом."); }

        Console.WriteLine();

        // --- Задание 6 ---
        Console.WriteLine("Задание 6");
        Console.Write("Длина массива: ");
        string input6 = Console.ReadLine();
        try
        {
            if (!int.TryParse(input6, out int length)) throw new FormatException();
            if (length < 0) throw new ArgumentException("Длина не может быть отрицательной");

            int[] arr = new int[length];
            Console.WriteLine("Массив создан");
        }
        catch (FormatException) { Console.WriteLine("Это не число"); }
        catch (ArgumentException ex) { Console.WriteLine(ex.Message); }

        Console.WriteLine();

        // --- Задание 7 (Исправлено: вызов метода) ---
        Console.WriteLine("Задание 7");
        int divA = 10;
        int divB = 0;
        int divideResult = Divide(divA, divB);
        Console.WriteLine($"Результат Divide({divA}, {divB}): {divideResult}");

        Console.WriteLine();

        // --- Задание 8 (Исправлено: вызов метода) ---
        Console.WriteLine("Задание 8");
        try
        {
            Console.Write("Введите число для проверки на минус: ");
            string input8 = Console.ReadLine();
            int parsedNum = ParseNumber(input8);
            Console.WriteLine($"Успешно распарсено: {parsedNum}");
        }
        catch (NegativeNumberException ex) { Console.WriteLine(ex.Message); }
        catch (FormatException) { Console.WriteLine("Некорректный формат числа"); }

        Console.WriteLine();

        // --- Задание 9 ---
        Console.WriteLine("Задание 9");
        int sum9 = 0;
        while (true)
        {
            Console.Write("Введи число : ");
            string s = Console.ReadLine();
            if (s == "stop") break;
            try { sum9 += int.Parse(s); }
            catch { Console.WriteLine("Ошибка ввода, давай еще раз"); }
        }
        Console.WriteLine($"Сумма: {sum9}");

        Console.WriteLine();

        // --- Задание 10 ---
        Console.WriteLine("Задание 10");
        try
        {
            Console.Write("A: "); double calcA = double.Parse(Console.ReadLine());
            Console.Write("Оп (+, -, *, /): "); string op = Console.ReadLine();
            Console.Write("B: "); double calcB = double.Parse(Console.ReadLine());

            if (op == "/" && calcB == 0) throw new DivideByZeroException();

            if (op == "+") Console.WriteLine(calcA + calcB);
            else if (op == "-") Console.WriteLine(calcA - calcB);
            else if (op == "*") Console.WriteLine(calcA * calcB);
            else if (op == "/") Console.WriteLine(calcA / calcB);
            else Console.WriteLine("Не та операция");
        }
        catch (Exception ex) { Console.WriteLine("Ошибка: " + ex.Message); }

        Console.WriteLine();

        // --- Задание 11 ---
        Console.WriteLine("Задание 11");
        int[] arr11 = { 10, 20, 30 };
        try
        {
            Console.Write("Делитель: ");
            int d = int.Parse(Console.ReadLine());
            foreach (int x in arr11) Console.WriteLine(x / d);
        }
        catch (DivideByZeroException) { Console.WriteLine("На ноль нельзя"); }
        catch (FormatException) { Console.WriteLine("Нужно число"); }

        Console.WriteLine();

        // --- Задание 12 (Исправлено: вызов метода) ---
        Console.WriteLine("Задание 12");
        int[] arr12 = { 1, 5, 10 };
        try
        {
            Console.Write("Что ищем? ");
            int val = int.Parse(Console.ReadLine());
            int index = FindElement(arr12, val);
            Console.WriteLine("Индекс: " + index);
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
    }

    // Метод для задания 4
    static int ReadInt()
    {
        try
        {
            return int.Parse(Console.ReadLine());
        }
        catch
        {
            return 0;
        }
    }

    // Метод для задания 7
    static int Divide(int a, int b)
    {
        try
        {
            return a / b;
        }
        catch
        {
            return 0;
        }
    }

    // Метод для задания 8
    static int ParseNumber(string input)
    {
        int n = int.Parse(input);
        if (n < 0) throw new NegativeNumberException("Отрицательное Айяйяй");
        return n;
    }

    // Метод для задания 12
    static int FindElement(int[] arr, int value)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == value) return i;
        }
        throw new Exception("Элемент не найден!");
    }
}