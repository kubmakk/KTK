using System;

class Program
{
    static void Main()
    {
        Task1();
        Task2();
        Task3();
        Console.WriteLine(ReadInt());
        Task5();
        Task6();
        Console.WriteLine(Divide(10, 0));
        Task8();
        Task9();
        Task10();
        Task11();
        Task12();
    }

    // 1. Квадрат числа
    static void Task1()
    {
        Console.Write("Введите число: ");
        string input = Console.ReadLine();
        try
        {
            int num = int.Parse(input);
            Console.WriteLine($"Квадрат: {num * num}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Бро, это не число. Введи цифры");
        }
    }

    // 2. Деление и две ошибки
    static void Task2()
    {
        try
        {
            Console.Write("Число 1: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Число 2: ");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine($"Результат: {a / b}");
        }
        catch (DivideByZeroException) { Console.WriteLine("На ноль делить нелья"); }
        catch (FormatException) { Console.WriteLine("Вводи только целые числа"); }
    }

    // 3. Возраст (throw вручную)
    static void Task3()
    {
        Console.Write("Твой возраст: ");
        try
        {
            int age = int.Parse(Console.ReadLine());
            if (age < 0 || age > 120) throw new Exception("Некорректный возраст");
            Console.WriteLine("Возраст принят.");
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
    }

    // 4. Метод ReadInt
    static int ReadInt()
    {
        try
        {
            Console.Write("Введите число: ");
            return int.Parse(Console.ReadLine());
        }
        catch { return 0; }
    }

    // 5. Массив и индекс
    static void Task5()
    {
        int[] nums = { 1, 2, 3, 4, 5 };
        try
        {
            Console.Write("Какой индекс вывести? ");
            int idx = int.Parse(Console.ReadLine());
            Console.WriteLine(nums[idx]);
        }
        catch (IndexOutOfRangeException) { Console.WriteLine("Нет такого индекса"); }
        catch (FormatException) { Console.WriteLine("Индекс должен быть числом."); }
    }

    // 6. Длина массива (проверки)
    static void Task6()
    {
        Console.Write("Длина массива: ");
        string input = Console.ReadLine();
        try
        {
            if (int.TryParse(input, out int length)) throw new FormatException();
            if (length < 0) throw new ArgumentException("Длина не может быть отрицательной");

            int[] arr = new int[length];
            Console.WriteLine("Массив создан");
        }
        catch (FormatException) { Console.WriteLine("Это не число"); }
        catch (ArgumentException ex) { Console.WriteLine(ex.Message); }
    }

    // 7. Метод Divide с обработкой внутри
    static int Divide(int a, int b)
    {
        try { return a / b; }
        catch { return 0; }
    }

    // 8. Свое исключение
    class NegativeNumberException : Exception
    {
        public NegativeNumberException(string message) : base(message) { }
    }

    static void Task8()
    {
        try
        {
            Console.Write("Введите число: ");
            int n = int.Parse(Console.ReadLine());
            if (n < 0) throw new NegativeNumberException("Отрицательное Ай-яй-яй.");
        }
        catch (NegativeNumberException ex) { Console.WriteLine(ex.Message); }
    }

    // 9. Сумма до stop
    static void Task9()
    {
        int sum = 0;
        while (true)
        {
            Console.Write("Введи число : ");
            string s = Console.ReadLine();
            if (s == "stop") break;
            try { sum += int.Parse(s); }
            catch { Console.WriteLine("Ошибка ввода, давай еще раз."); }
        }
        Console.WriteLine($"Сумма: {sum}");
    }

    // 10. Мини-калькулятор
    static void Task10()
    {
        try
        {
            Console.Write("A: "); double a = double.Parse(Console.ReadLine());
            Console.Write("Оп (+, -, *, /): "); string op = Console.ReadLine();
            Console.Write("B: "); double b = double.Parse(Console.ReadLine());

            if (op == "/" && b == 0) throw new DivideByZeroException();

            if (op == "+") Console.WriteLine(a + b);
            else if (op == "-") Console.WriteLine(a - b);
            else if (op == "*") Console.WriteLine(a * b);
            else if (op == "/") Console.WriteLine(a / b);
            else Console.WriteLine("Не та операция");
        }
        catch (Exception ex) { Console.WriteLine("Ошибка: " + ex.Message); }
    }

    // 11. Деление массива на число
    static void Task11()
    {
        int[] arr = { 10, 20, 30 };
        try
        {
            Console.Write("Делитель: ");
            int d = int.Parse(Console.ReadLine());
            foreach (int x in arr) Console.WriteLine(x / d);
        }
        catch (DivideByZeroException) { Console.WriteLine("На ноль нельзя"); }
        catch (FormatException) { Console.WriteLine("Нужно число"); }
    }

    // 12. Поиск элемента
    static void Task12()
    {
        try
        {
            int[] arr = { 1, 5, 10 };
            Console.Write("Что ищем? ");
            int val = int.Parse(Console.ReadLine());
            int index = -1;
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] == val) index = i;

            if (index == -1) throw new Exception("Элемент не найден");
            Console.WriteLine("Индекс: " + index);
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
    }
}
