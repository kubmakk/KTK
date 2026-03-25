class Program
{
    static void Main()
    {


        int[] numbers = { 10, 20, 30, 40, 50 };
        int roblox = numbers[3];
        Console.WriteLine(roblox);

        // 1. Ввод 5 чисел и вывод
        Console.WriteLine("задание 1");
        int[] arr1 = new int[5];
        for (int i = 0; i < arr1.Length; i++)
        {
            arr1[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine(string.Join(" ", arr1));


        // 2. Сумма 10 чисел12
        Console.WriteLine("задание 2");
        int[] arr2 = new int[10];
        int sum2 = 0;
        for (int i = 0; i < arr2.Length; i++)
        {
            arr2[i] = int.Parse(Console.ReadLine());
            sum2 += arr2[i];
        }
        Console.WriteLine($"Сумма: {sum2}");

        // 3. Вывод нечётных из N 
        Console.WriteLine("задание 3");
        Console.Write("Введите N: ");
        int n3 = int.Parse(Console.ReadLine());
        int[] arr3 = new int[n3];
        for (int i = 0; i < n3; i++)
        {
            arr3[i] = int.Parse(Console.ReadLine());
        }
        foreach (int x in arr3)
        {
            if (x % 2 != 0) Console.Write(x + " ");
        }

        // 4. Min и Max из 5 чисел
        Console.WriteLine("задание 4");
        int[] arr4 = new int[5];
        for (int i = 0; i < 5; i++)
        {
            arr4[i] = int.Parse(Console.ReadLine());
        }

        int min4 = arr4[0], max4 = arr4[0];
        foreach (int x in arr4)
        {
            if (x < min4) min4 = x;
            if (x > max4) max4 = x;
        }
        Console.WriteLine($"Min: {min4}, Max: {max4}");

        // 5. Сумма чётных и нечётных
        Console.WriteLine("задание 5");
        Console.Write("Введите N: ");
        int n5 = int.Parse(Console.ReadLine());
        int sumEven = 0, sumOdd = 0;
        for (int i = 0; i < n5; i++)
        {
            int val = int.Parse(Console.ReadLine());
            if (val % 2 == 0) sumEven += val; else sumOdd += val;
        }
        Console.WriteLine($"Чётные: {sumEven}, Нечётные: {sumOdd}");

        // 6. Инкремент/декремент (4 числа)
        Console.WriteLine("заданрие 6");
        int[] arr6 = new int[4];
        for (int i = 0; i < 4; i++)
        {
            arr6[i] = int.Parse(Console.ReadLine());
            if (arr6[i] < 0) arr6[i]++; else if (arr6[i] > 0) arr6[i]--;
        }

        // 7. Поиск числа X
        Console.WriteLine("задание 7");
        Console.Write("Введите N: ");
        int n7 = int.Parse(Console.ReadLine());
        int[] arr7 = new int[n7];
        for (int i = 0; i < n7; i++) arr7[i] = int.Parse(Console.ReadLine());
        Console.Write("Что ищем? ");
        int x7 = int.Parse(Console.ReadLine());
        Console.WriteLine(Array.IndexOf(arr7, x7) != -1 ? "Найдено" : "Нет");

        // 8. Обратный порядок
        Console.WriteLine("задание 8");
        // ... ввод N ...
        for (int i = n7 - 1; i >= 0; i--) Console.Write(arr7[i] + " ");

        // 9. Среднее арифметическое
        Console.WriteLine("задание 9");
        double avg9 = (double)sum2 / 10; // на примере массива из задачи 2

        // 10. Числа больше среднего
        Console.WriteLine("задание 10");
        double avg10 = 0;
        foreach (int x in arr7) avg10 += x;
        avg10 /= arr7.Length;
        foreach (int x in arr7) if (x > avg10) Console.WriteLine(x);

        // 11. Минимальный элемент и его индекс
        Console.WriteLine("задание 11");
        int minVal = arr7[0], minIdx = 0;
        for (int i = 1; i < arr7.Length; i++)
        {
            if (arr7[i] < minVal) { minVal = arr7[i]; minIdx = i; }
        }
        Console.WriteLine($"Min: {minVal}, Индекс: {minIdx}");

        // 12. Ввод M x N и вывод таблицей
        Console.WriteLine("задание 12");
        Console.Write("Строк M: "); int m12 = int.Parse(Console.ReadLine());
        Console.Write("Столбцов N: "); int n12 = int.Parse(Console.ReadLine());
        int[,] matrix = new int[m12, n12];

        for (int i = 0; i < m12; i++)
            for (int j = 0; j < n12; j++)
                matrix[i, j] = int.Parse(Console.ReadLine());

        for (int i = 0; i < m12; i++)
        {
            for (int j = 0; j < n12; j++) Console.Write(matrix[i, j] + "\t");
            Console.WriteLine();
        }

        // 13. Сумма всех элементов
        Console.WriteLine("задание 13");
        int totalSum = 0;
        foreach (int val in matrix) totalSum += val;

        // 14. Max и его позиция
        Console.WriteLine("задание 14");
        int maxM = matrix[0, 0], rMax = 0, cMax = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < matrix.GetLength(1); j++)
                if (matrix[i, j] > maxM) { maxM = matrix[i, j]; rMax = i; cMax = j; }


        // 15. Суммы строк и столбцов
        Console.WriteLine("задание 15");
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int rowS = 0;
            for (int j = 0; j < matrix.GetLength(1); j++) rowS += matrix[i, j];
            Console.WriteLine($"Строка {i}: {rowS}");
        }
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            int colS = 0;
            for (int i = 0; i < matrix.GetLength(0); i++) colS += matrix[i, j];
            Console.WriteLine($"Столбец {j}: {colS}");
        }

        // 16. Замена: отрицательные -> 0, положительные -> 1
        Console.WriteLine("задание 16");
        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < matrix.GetLength(1); j++)
                matrix[i, j] = matrix[i, j] < 0 ? 0 : (matrix[i, j] > 0 ? 1 : 0);

        // 17. Транспонирование (N x N)
        Console.WriteLine("задание 17");
        int n17 = matrix.GetLength(0);
        int[,] transposed = new int[n17, n17];
        for (int i = 0; i < n17; i++)
            for (int j = 0; j < n17; j++)
                transposed[j, i] = matrix[i, j];

        // 18. Главная диагональ
        Console.WriteLine("задание 18");
        int diagSum = 0;
        for (int i = 0; i < n17; i++) diagSum += matrix[i, i];

        // 19. Симметрия относительно диагонали
        Console.WriteLine("задание 19");
        bool isSym = true;
        for (int i = 0; i < n17; i++)
            for (int j = 0; j < n17; j++)
                if (matrix[i, j] != matrix[j, i]) isSym = false;

        // 20. Поиск X в матрице
        Console.WriteLine("задание 20");
        int target = 5;
        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < matrix.GetLength(1); j++)
                if (matrix[i, j] == target) Console.WriteLine($"Найдено в [{i},{j}]");

        // 21. Сортировка строк по возрастанию (Метод пузырька для каждой строки)
        Console.WriteLine("задание 21");
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                for (int k = 0; k < matrix.GetLength(1) - j - 1; k++)
                    if (matrix[i, k] > matrix[i, k + 1])
                    {
                        int temp = matrix[i, k];
                        matrix[i, k] = matrix[i, k + 1];
                        matrix[i, k + 1] = temp;
                    }
        }
    }
}