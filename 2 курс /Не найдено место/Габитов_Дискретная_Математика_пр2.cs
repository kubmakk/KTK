using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DiscreteMathSuite
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== СБОРНИК ЗАДАЧ ПО ДИСКРЕТНОЙ МАТЕМАТИКЕ ===");
                Console.WriteLine("1. Верификатор ходов коня (BFS)");
                Console.WriteLine("2. Анализатор булевых функций (СДНФ, СКНФ, Пост)");
                Console.WriteLine("3. Код Хаффмана (Сжатие)");
                Console.WriteLine("4. Коммивояжёр (TSP) - Полный перебор");
                Console.WriteLine("5. Изоморфизм графов (Наивный)");
                Console.WriteLine("6. Минимизация ДКА");
                Console.WriteLine("0. Выход");
                Console.Write("\nВыберите задачу: ");


                string choice = Console.ReadLine();
                Console.WriteLine();


                switch (choice)
                {
                    case "1": Task1_Knight(); break;
                    case "2": Task2_Boolean(); break;
                    case "3": Task3_Huffman(); break;
                    case "4": Task4_TSP(); break;
                    case "5": Task5_Isomorphism(); break;
                    case "6": Task6_DFA_Minimization(); break;
                    case "0": return;
                    default: Console.WriteLine("Неверный ввод."); break;
                }
                Console.WriteLine("\nНажмите Enter, чтобы продолжить...");
                Console.ReadLine();
            }
        }


        #region Задача 1: Шахматный конь (BFS)
        static void Task1_Knight()
        {
            Console.WriteLine("--- Задача 1: Ход коня ---");
            Console.Write("Введите старт (например, a1): ");
            var startStr = Console.ReadLine();
            Console.Write("Введите финиш (например, h8): ");
            var endStr = Console.ReadLine();


            if (!ParseCoord(startStr, out int sx, out int sy) || !ParseCoord(endStr, out int ex, out int ey))
            {
                Console.WriteLine("Ошибка координат.");
                return;
            }


            // BFS
            var queue = new Queue<(int x, int y, List<string> path)>();
            queue.Enqueue((sx, sy, new List<string> { startStr }));
            
            var visited = new bool[8, 8];
            visited[sx, sy] = true;


            int[] dx = { 2, 2, -2, -2, 1, 1, -1, -1 };
            int[] dy = { 1, -1, 1, -1, 2, -2, 2, -2 };


            while (queue.Count > 0)
            {
                var (cx, cy, path) = queue.Dequeue();


                if (cx == ex && cy == ey)
                {
                    Console.WriteLine($"Путь найден за {path.Count - 1} ходов!");
                    Console.WriteLine(string.Join(" -> ", path));
                    return;
                }


                for (int i = 0; i < 8; i++)
                {
                    int nx = cx + dx[i];
                    int ny = cy + dy[i];


                    if (nx >= 0 && nx < 8 && ny >= 0 && ny < 8 && !visited[nx, ny])
                    {
                        visited[nx, ny] = true;
                        var newPath = new List<string>(path) { $"{(char)('a' + nx)}{ny + 1}" };
                        queue.Enqueue((nx, ny, newPath));
                    }
                }
            }
            Console.WriteLine("Путь не найден (что странно для коня).");
        }


        static bool ParseCoord(string s, out int x, out int y)
        {
            x = -1; y = -1;
            if (string.IsNullOrEmpty(s) || s.Length != 2) return false;
            x = s[0] - 'a';
            y = s[1] - '1';
            return x >= 0 && x < 8 && y >= 0 && y < 8;
        }
        #endregion


#region Задача 2: Булевы функции
        static void Task2_Boolean()
        {
            Console.WriteLine("--- Задача 2: Булевы функции ---");
            int n = 3;
            int rows = 1 << n; // 2^n
            int[] truthTable = new int[rows];
            
            Console.WriteLine($"Генерация случайной функции для {n} переменных...");
            var rand = new Random();
            for (int i = 0; i < rows; i++) truthTable[i] = rand.Next(2);


            // Вывод таблицы
            Console.WriteLine("x y z | F");
            Console.WriteLine("------+--");
            for (int i = 0; i < rows; i++)
            {
                string binary = Convert.ToString(i, 2).PadLeft(n, '0');
                Console.WriteLine($"{string.Join(" ", binary.ToCharArray())} | {truthTable[i]}");
            }


            // СДНФ
            List<string> sdnf = new List<string>();
            for (int i = 0; i < rows; i++)
            {
                if (truthTable[i] == 1)
                {
                    List<string> term = new List<string>();
                    for (int bit = 0; bit < n; bit++)
                    {
                        char varName = (char)('x' + bit); // x, y, z...
                        bool isSet = ((i >> (n - 1 - bit)) & 1) == 1;
                        term.Add(isSet ? varName.ToString() : $"!{varName}");
                    }
                    sdnf.Add($"({string.Join("&", term)})");
                }
            }
            Console.WriteLine($"\nСДНФ: {(sdnf.Count > 0 ? string.Join(" v ", sdnf) : "0")}");


            // СКНФ
            List<string> sknf = new List<string>();
            for (int i = 0; i < rows; i++)
            {
                if (truthTable[i] == 0)
                {
                    List<string> term = new List<string>();
                    for (int bit = 0; bit < n; bit++)
                    {
                        char varName = (char)('x' + bit);
                        bool isSet = ((i >> (n - 1 - bit)) & 1) == 1;
                        // В СКНФ инверсия, если бит = 1
                        term.Add(isSet ? $"!{varName}" : varName.ToString());
                    }
                    sknf.Add($"({string.Join(" v ", term)})");
                }
            }
            Console.WriteLine($"СКНФ: {(sknf.Count > 0 ? string.Join(" & ", sknf) : "1")}");


            // Классы Поста (упрощенно)
            bool t0 = truthTable[0] == 0;
            bool t1 = truthTable[rows - 1] == 1;
            Console.WriteLine($"\nСвойства:");
            Console.WriteLine($"- Сохраняет 0 (T0): {t0}");
            Console.WriteLine($"- Сохраняет 1 (T1): {t1}");
            // Линейность и монотонность опустим для краткости, но место под них тут
        }
        #endregion


        #region Задача 3: Код Хаффмана
        class HuffmanNode
        {
            public char? Symbol { get; set; }
            public int Frequency { get; set; }
            public HuffmanNode Left { get; set; }
            public HuffmanNode Right { get; set; }
        }


        static void Task3_Huffman()
        {
            Console.WriteLine("--- Задача 3: Код Хаффмана ---");
            Console.Write("Введите строку для сжатия: ");
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) input = "banana";


            var freqs = input.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
            var priorityQueue = freqs.Select(kv => new HuffmanNode { Symbol = kv.Key, Frequency = kv.Value }).ToList();


            // Строим дерево
            while (priorityQueue.Count > 1)
            {
                priorityQueue = priorityQueue.OrderBy(n => n.Frequency).ToList();
                var left = priorityQueue[0];
                var right = priorityQueue[1];
                priorityQueue.RemoveRange(0, 2);


var parent = new HuffmanNode
                {
                    Symbol = null,
                    Frequency = left.Frequency + right.Frequency,
                    Left = left,
                    Right = right
                };
                priorityQueue.Add(parent);
            }
            var root = priorityQueue.FirstOrDefault();


            // Генерируем коды
            var codes = new Dictionary<char, string>();
            GenerateHuffmanCodes(root, "", codes);


            Console.WriteLine("\nКоды символов:");
            foreach (var kv in codes) Console.WriteLine($"'{kv.Key}': {kv.Value}");


            StringBuilder encoded = new StringBuilder();
            foreach (var c in input) encoded.Append(codes[c]);
            
            Console.WriteLine($"\nЗакодировано: {encoded}");
            Console.WriteLine($"Битов исходно: {input.Length * 8}, Сжато: {encoded.Length}");
        }


        static void GenerateHuffmanCodes(HuffmanNode node, string code, Dictionary<char, string> codes)
        {
            if (node == null) return;
            if (node.Symbol != null)
            {
                codes[node.Symbol.Value] = code.Length > 0 ? code : "0"; // случай 1 символа
            }
            GenerateHuffmanCodes(node.Left, code + "0", codes);
            GenerateHuffmanCodes(node.Right, code + "1", codes);
        }
        #endregion


        #region Задача 4: Коммивояжёр (TSP)
        static void Task4_TSP()
        {
            Console.WriteLine("--- Задача 4: Коммивояжёр (TSP) ---");
            int n = 5; // Малое число вершин
            int[,] graph = new int[n, n];
            Random rnd = new Random();


            Console.WriteLine("Матрица весов:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j) graph[i, j] = 0;
                    else graph[i, j] = rnd.Next(1, 20); // Симметричный граф
                    graph[j, i] = graph[i, j]; 
                    Console.Write($"{graph[i, j],3} ");
                }
                Console.WriteLine();
            }


            int[] vertices = Enumerable.Range(1, n - 1).ToArray(); // 0 - старт
            int minCost = int.MaxValue;
            int[] bestPath = null;


            // Перебор перестановок (Брутфорс)
            foreach (var perm in GetPermutations(vertices, vertices.Length))
            {
                int currentCost = 0;
                int currentParams = 0; // Предыдущая вершина (начинаем с 0)
                
                List<int> currentPathList = new List<int> { 0 };
                
                foreach (var v in perm)
                {
                    currentCost += graph[currentParams, v];
                    currentParams = v;
                    currentPathList.Add(v);
                }
                currentCost += graph[currentParams, 0]; // Возврат в 0
                currentPathList.Add(0);


                if (currentCost < minCost)
                {
                    minCost = currentCost;
                    bestPath = currentPathList.ToArray();
                }
            }


            Console.WriteLine($"\nМинимальная стоимость: {minCost}");
            Console.WriteLine($"Путь: {string.Join(" -> ", bestPath)}");
        }


        // Хелпер для перестановок
        static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });
            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }
        #endregion


        #region Задача 5: Изоморфизм графов


static void Task5_Isomorphism()
        {
            Console.WriteLine("--- Задача 5: Изоморфизм графов ---");
            // Пример: два треугольника, изоморфны
            int[][] g1 = new int[][] {
                new int[] {0, 1, 1},
                new int[] {1, 0, 1},
                new int[] {1, 1, 0}
            };
            // Тот же граф, но переименованы вершины (0<->1)
            int[][] g2 = new int[][] {
                new int[] {0, 1, 1},
                new int[] {1, 0, 1},
                new int[] {1, 1, 0}
            };


            Console.WriteLine("Граф 1 и Граф 2 заданы матрицами.");


            // Инвариант 1: Число вершин
            if (g1.Length != g2.Length) { Console.WriteLine("Разное число вершин."); return; }
            int n = g1.Length;


            // Инвариант 2: Степени вершин
            var deg1 = g1.Select(row => row.Sum()).OrderBy(x => x).ToList();
            var deg2 = g2.Select(row => row.Sum()).OrderBy(x => x).ToList();


            if (!deg1.SequenceEqual(deg2)) { Console.WriteLine("Разные степени вершин. Не изоморфны."); return; }


            // Полный перебор биекций
            int[] vertices = Enumerable.Range(0, n).ToArray();
            bool found = false;


            foreach (var perm in GetPermutations(vertices, n))
            {
                var p = perm.ToArray();
                // Проверка: g1[i][j] == g2[p[i]][p[j]]
                bool isIso = true;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (g1[i][j] != g2[p[i]][p[j]])
                        {
                            isIso = false;
                            break;
                        }
                    }
                    if (!isIso) break;
                }


                if (isIso)
                {
                    Console.WriteLine("Графы ИЗОМОРФНЫ!");
                    Console.WriteLine("Отображение (G1 -> G2):");
                    for (int i = 0; i < n; i++) Console.WriteLine($"  {i} -> {p[i]}");
                    found = true;
                    break;
                }
            }


            if (!found) Console.WriteLine("Графы НЕ изоморфны.");
        }
        #endregion


        #region Задача 6: Минимизация ДКА
        static void Task6_DFA_Minimization()
        {
            Console.WriteLine("--- Задача 6: Минимизация ДКА ---");
            // ДКА с избыточными состояниями
            // Алфавит: 0, 1
            // Состояния: 0,1,2,3,4. Финальные: {4}
            // 0 - start. 
            // Эквивалентны: (1, 2) и (3, 4 - нет, 4 финал), (1,3 - если ведут в финал одинаково)
            
            // Простой пример: A->B(0), A->C(1); B->D(0).. 
            // Зададим таблицу переходов: [состояние, символ] -> след. состояние
            int n = 5; // состояния 0..4
            int[,] transition = {
                {1, 2}, // из 0 по '0'->1, по '1'->2
                {3, 3}, // из 1
                {3, 3}, // из 2 (1 и 2 ведут себя одинаково -> они должны склеиться)
                {4, 4}, // из 3
                {4, 4}  // из 4 (ловушка, финал)
            };
            bool[] isFinal = { false, false, false, false, true };


            // Таблица различимости (Table Filling Algorithm)
            // marked[i, j] = true, если i и j различимы
            bool[,] marked = new bool[n, n];


            // Шаг 1: Пометить пары (финальное, нефинальное)
            for (int i = 0; i < n; i++)
                for (int j = i + 1; j < n; j++)
                    if (isFinal[i] != isFinal[j])
                        marked[i, j] = true;


            // Шаг 2: Распространение меток
            bool changed = true;
            while (changed)
            {


changed = false;
                for (int i = 0; i < n; i++)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        if (!marked[i, j])
                        {
                            // Проверяем переходы по всем символам (0 и 1)
                            for (int c = 0; c < 2; c++)
                            {
                                int nextI = transition[i, c];
                                int nextJ = transition[j, c];
                                
                                // Упорядочим индексы для матрицы
                                int u = Math.Min(nextI, nextJ);
                                int v = Math.Max(nextI, nextJ);


                                if (u != v && marked[u, v])
                                {
                                    marked[i, j] = true;
                                    changed = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }


            Console.WriteLine("Группы эквивалентных состояний:");
            bool[] printed = new bool[n];
            for (int i = 0; i < n; i++)
            {
                if (printed[i]) continue;
                List<int> group = new List<int> { i };
                printed[i] = true;
                for (int j = i + 1; j < n; j++)
                {
                    if (!marked[i, j]) // Не различимы = эквивалентны
                    {
                        group.Add(j);
                        printed[j] = true;
                    }
                }
                Console.WriteLine($"{{ {string.Join(", ", group)} }} {(isFinal[i] ? "(Final)" : "")}");
            }
            Console.WriteLine("В примере выше состояния 1 и 2 должны склеиться.");
        }
        #endregion
    }
}
