class Program
{
    static void Main(string[] args)
    {
        // 1
        line();

        // 2
        SayHello("Никита");

        line();

        // 3
        Console.WriteLine($"Квадрат числа 5: {Square(5)}");
        Console.WriteLine($"Квадрат числа 10: {Square(10)}");

        line();

        // 4
        Console.WriteLine($"Число 4 четное? {IsEven(4)}");
        Console.WriteLine($"Число 5 четное? {IsEven(5)}");

        line();

        // 5
        Repeat("Колокольчики", 3);

        line();

        // 6
        int[] intArray = { 1, 33, 54, 234, 4 };
        PrintArray(intArray);

        line();

        // 7
        double[] doubleArray = { 12.53, 23.17, 45.3 };
        PrintArray(doubleArray);

        line();

        // 8
        Console.WriteLine($"Большее число: {Max(5, 10)}");

        line();

        // 9
        int[] oddCountArray = { 1, 2, 3, 4, 5 };
        Console.WriteLine($"Количество нечетных элементов: {OddCount(oddCountArray)}");

        line();

        // 10
        Console.WriteLine($"Знак числа -5: {Sign(-5)}");
        Console.WriteLine($"Знак числа 0: {Sign(0)}");
        Console.WriteLine($"Знак числа 5: {Sign(5)}");
    }


    //Functions

    // 1
    static void line()
    {
        Console.WriteLine(new string('-', 20));
    }

    // 2
    static void SayHello(string name)
    {
        Console.WriteLine($"Привет, {name}!");
    }

    // 3
    static int Square(int x)
    {
        return x * x;
    }

    // 4
    static bool IsEven(int x)
    {
        return x % 2 == 0;
    }

    // 5
    static void Repeat(string text, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(text);
        }
    }

    // 6
    static void PrintArray(int[] arr)
    {
        Console.WriteLine("Массив int: " + string.Join(", ", arr));
    }

    // 7
    static void PrintArray(double[] arr)
    {
        Console.WriteLine("Массив double: " + string.Join(", ", arr));
    }

    // 8
    static int Max(int a, int b)
    {
        return a > b ? a : b;
    }

    // 9
    static int OddCount(int[] arr)
    {
        int glob = 0;
        foreach (var item in arr)
        {
            if (item % 2 != 0)
            {
                glob++;
            }
        }
        return glob;
    }

    // 10
    static int Sign(int x)
    {
        if (x < 0) return -1;
        else if (x > 0) return 1;
        else return 0;
    }
}