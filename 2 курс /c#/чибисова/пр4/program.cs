class Program
{
    static void Main()
    {
        // 1
        Console.Write("1. Введите число: ");
        int n1 = int.Parse(Console.ReadLine());
        Console.WriteLine(n1 % 2 == 0 ? "Четное" : "Нечетное");

        // 2
        Console.Write("2. Введите число: ");
        int n2 = int.Parse(Console.ReadLine());
        if (n2 >= 10 && n2 <= 50)
        {
            Console.WriteLine("Входит в диапазон");
        }
        else
        {
            Console.WriteLine("Не входит");
        }

        // 3
        Console.Write("3. Введите два числа: ");
        int a3 = int.Parse(Console.ReadLine());
        int b3 = int.Parse(Console.ReadLine());
        if (a3 > b3)
        {
            Console.WriteLine($"Большее: {a3}");
        }
        else
        {
            Console.WriteLine($"Большее: {b3}");
        }

        // 4
        Console.Write("4. Введите температуру: ");
        int t = int.Parse(Console.ReadLine());
        if (t < 0)
        {
            Console.WriteLine("Холодно");
        }
        else if (t <= 20)
        {
            Console.WriteLine("Прохладно");
        }
        else
        {
            Console.WriteLine("Тепло");
        }

        // 5
        Console.Write("5. Введите число: ");
        int n5 = int.Parse(Console.ReadLine());
        if (n5 > 0)
        {
            n5++;
        }
        else if (n5 < 0)
        {
            n5 -= 2;
        }
        else
        {
            n5 = 10;
        }
        Console.WriteLine($"Результат: {n5}");

        // 6
        Console.Write("6. Введите два числа: ");
        int a6 = int.Parse(Console.ReadLine());
        int b6 = int.Parse(Console.ReadLine());
        if (a6 > 0 && b6 > 0)
        {
            Console.WriteLine(a6 + b6);
        }
        else if (a6 < 0 && b6 < 0)
        {
            Console.WriteLine(a6 - b6);
        }
        else
        {
            Console.WriteLine(a6 * b6);
        }

        // 7
        Console.WriteLine("7. Введите длины 4 линий:");
        int l1 = int.Parse(Console.ReadLine());
        int l2 = int.Parse(Console.ReadLine());
        int l3 = int.Parse(Console.ReadLine());
        int l4 = int.Parse(Console.ReadLine());
        if (l1 == l2 && l2 == l3 && l3 == l4)
        {
            Console.WriteLine("Можно составить квадрат");
        }
        else
        {
            Console.WriteLine("Нельзя");
        }

        // 8
        Console.Write("8. Введите номер месяца (1-12): ");
        int month = int.Parse(Console.ReadLine());
        switch (month)
        {
            case 1: case 3: case 5: case 7: case 8: case 10: case 12: Console.WriteLine(31); break;
            case 4: case 6: case 9: case 11: Console.WriteLine(30); break;
            case 2: Console.WriteLine(28); break;
            default: Console.WriteLine("Ошибка"); break;
        }

        // 9
        Console.Write("9. Число 1, Операция, Число 2: ");
        double op1 = double.Parse(Console.ReadLine());
        char sign = char.Parse(Console.ReadLine());
        double op2 = double.Parse(Console.ReadLine());
        switch (sign)
        {
            case '+': Console.WriteLine(op1 + op2); break;
            case '-': Console.WriteLine(op1 - op2); break;
            case '*': Console.WriteLine(op1 * op2); break;
            case '/': Console.WriteLine(op2 != 0 ? op1 / op2 : "Деление на 0!"); break;
        }

        // 10
        Console.Write("10. Введите час (0-23): ");
        int h = int.Parse(Console.ReadLine());
        if (h >= 5 && h <= 11)
        {
            Console.WriteLine("Доброе ранку");
        }
        else if (h >= 12 && h <= 17)
        {
            Console.WriteLine("Добрый дiня");
        }
        else if (h >= 18 && h <= 22)
        {
            Console.WriteLine("Добрый вечора");
        }
        else
        {
            Console.WriteLine("Доброй ночi");
        }

        // 11
        int a11 = int.Parse(Console.ReadLine());
        int b11 = int.Parse(Console.ReadLine());
        int max11 = a11 > b11 ? a11 : b11;

        // 12
        int a12 = int.Parse(Console.ReadLine());
        int b12 = int.Parse(Console.ReadLine());
        int c12 = int.Parse(Console.ReadLine());
        int max12 = Math.Max(a12, Math.Max(b12, c12));

        // 13
        int year = int.Parse(Console.ReadLine());
        bool isLeap = (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);

        // 14
        double price = int.Parse(Console.ReadLine());
        double total = price > 1000 ? price * 0.9 : price;

        // 15
        int x1 = int.Parse(Console.ReadLine());
        int x2 = int.Parse(Console.ReadLine());
        int x3 = int.Parse(Console.ReadLine());
        if ((x2 - x1) == (x3 - x2))
        {
            Console.WriteLine("Прогрессия!!!!!!!!!");
        }

        // 16
        Console.WriteLine("16. Введите z, o, v ZOVOZVOZVOZVOZOV:");
        double z = double.Parse(Console.ReadLine());
        double o = double.Parse(Console.ReadLine());
        double v = double.Parse(Console.ReadLine());
        double D = o * o - 4 * z * v; //ZOVZVOZVOZVOZVOZVOZVOZVOVOZVOZOXZVO
        if (D > 0)
        {
            Console.WriteLine("Два корня");
        }
        else if (D == 0)
        {
            Console.WriteLine("Один корень");
        }
        else
        {
            Console.WriteLine("Корней нет");
        }

        // 17
        Console.WriteLine("17. Введите два числа:");
        int z1 = int.Parse(Console.ReadLine());
        int z2 = int.Parse(Console.ReadLine());
        if (z1 > 0 && z2 > 0)
        {
            Console.WriteLine("Оба положительные (знак один)");
        }
        else if (z1 < 0 && z2 < 0)
        {
            Console.WriteLine("Оба отрицательные (знак один)");
        }
        else
        {
            Console.WriteLine("Знаки разные или есть ноль");
        }

        // 18
        Console.Write("18. Введите логин: ");
        string login = Console.ReadLine();
        Console.Write("Введите пароль: ");
        string password = Console.ReadLine();
        if (login == "admin" && password == "1234")
        {
            Console.WriteLine("Вход выполнен");
        }
        else
        {
            Console.WriteLine("Ошибка");
        }

        // 19
        Console.Write("19. Введите число: ");
        int num19 = int.Parse(Console.ReadLine());
        if (num19 % 3 == 0 && num19 % 5 == 0)
        {
            Console.WriteLine("Делится и на 3, и на 5");
        }
        else if (num19 % 3 == 0)
        {
            Console.WriteLine("Делится только на 3");
        }
        else if (num19 % 5 == 0)
        {
            Console.WriteLine("Делится только на 5");
        }
        else
        {
            Console.WriteLine("Не делится ни на что");
        }

        // 20
        Console.WriteLine("20. Введите три числа:");
        int v1 = int.Parse(Console.ReadLine());
        int v2 = int.Parse(Console.ReadLine());
        int v3 = int.Parse(Console.ReadLine());
        if ((v1 > v2 && v1 < v3) || (v1 < v2 && v1 > v3))
        {
            Console.WriteLine($"Среднее: {v1}");
        }
        else if ((v2 > v1 && v2 < v3) || (v2 < v1 && v2 > v3))
        {
            Console.WriteLine($"Среднее: {v2}");
        }
        else
        {
            Console.WriteLine($"Среднее: {v3}");
        }

        // 21
        Console.WriteLine("21. Введите два числа:");
        int x21 = int.Parse(Console.ReadLine());
        int y21 = int.Parse(Console.ReadLine());
        if (x21 > 0 && y21 > 0)
        {
            Console.WriteLine($"Сумма: {x21 + y21}");
        }
        else
        {
            Console.WriteLine($"Произведение: {x21 * y21}");
        }
    }
}
