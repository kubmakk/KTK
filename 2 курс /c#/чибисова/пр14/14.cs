using System;
using System.Collections.Generic;

namespace PracticalWork14
{
    // Класс для заданий 3, 4 и 9 (объявлен вне Main, так как C# требует определение типов)
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Настройка кодировки консоли для корректного отображения кириллицы
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            // ==========================================
            // ЗАДАНИЕ 1
            // ==========================================
            Console.WriteLine("=== ЗАДАНИЕ 1 ===");
            List<int> task1List = new List<int>();
            Console.WriteLine("Введите 5 целых чисел:");
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Число {i + 1}: ");
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    task1List.Add(num);
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Добавлено число 0.");
                    task1List.Add(0);
                }
            }
            Console.WriteLine("Вы ввели следующие числа:");
            foreach (int num in task1List)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine("\n");


            // ==========================================
            // ЗАДАНИЕ 2
            // ==========================================
            Console.WriteLine("=== ЗАДАНИЕ 2 ===");
            List<int> task2List = new List<int>();
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                task2List.Add(rand.Next(1, 20)); // Заполнение случайными числами от 1 до 19
            }
            Console.WriteLine("Список случайных чисел (10 элементов):");
            foreach (int num in task2List)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            Console.Write("Введите число для удаления: ");
            if (int.TryParse(Console.ReadLine(), out int numberToRemove))
            {
                try
                {
                    if (!task2List.Contains(numberToRemove))
                    {
                        throw new Exception($"Число {numberToRemove} отсутствует в списке!");
                    }
                    task2List.Remove(numberToRemove);
                    Console.WriteLine("Число успешно удалено.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
            Console.WriteLine("Текущее состояние списка:");
            foreach (int num in task2List)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine("\n");


            // ==========================================
            // ЗАДАНИЕ 3
            // ==========================================
            Console.WriteLine("=== ЗАДАНИЕ 3 ===");
            List<Product> productsList = new List<Product>()
            {
                new Product { Id = 1, Name = "Ноутбук", Price = 75000 },
                new Product { Id = 2, Name = "Мышь", Price = 1500 },
                new Product { Id = 3, Name = "Клавиатура", Price = 3500 },
                new Product { Id = 4, Name = "Монитор", Price = 18000 },
                new Product { Id = 5, Name = "Наушники", Price = 5000 }
            };

            Console.WriteLine("Информация о товарах:");
            foreach (var prod in productsList)
            {
                Console.WriteLine($"ID: {prod.Id} | Наименование: {prod.Name} | Цена: {prod.Price} руб.");
            }
            Console.WriteLine();


            // ==========================================
            // ЗАДАНИЕ 4
            // ==========================================
            Console.WriteLine("=== ЗАДАНИЕ 4 ===");
            Console.Write("Введите ID товара, у которого хотите изменить цену: ");
            if (int.TryParse(Console.ReadLine(), out int searchId))
            {
                Product foundProd = productsList.Find(p => p.Id == searchId);
                if (foundProd != null)
                {
                    Console.Write($"Введите новую цену для товара '{foundProd.Name}': ");
                    if (double.TryParse(Console.ReadLine(), out double newPrice))
                    {
                        foundProd.Price = newPrice;
                        Console.WriteLine("Цена успешно изменена.");
                    }
                    else
                    {
                        Console.WriteLine("Неверный формат цены.");
                    }
                }
                else
                {
                    Console.WriteLine("Товар с таким ID не найден.");
                }
            }
            Console.WriteLine("Обновленный список товаров:");
            foreach (var prod in productsList)
            {
                Console.WriteLine($"ID: {prod.Id} | Наименование: {prod.Name} | Цена: {prod.Price} руб.");
            }
            Console.WriteLine("\n");


            // ==========================================
            // ЗАДАНИЕ 5
            // ==========================================
            Console.WriteLine("=== ЗАДАНИЕ 5 ===");
            Dictionary<string, int> studentsDatabase = new Dictionary<string, int>()
            {
                { "Иван", 5 },
                { "Мария", 4 },
                { "Алексей", 3 }
            };

            Console.WriteLine("Все пары в словаре студентов:");
            foreach (var pair in studentsDatabase)
            {
                Console.WriteLine($"Студент: {pair.Key}, Оценка: {pair.Value}");
            }

            Console.Write("Введите имя студента для поиска оценки: ");
            string searchName = Console.ReadLine();
            try
            {
                if (!studentsDatabase.ContainsKey(searchName))
                {
                    throw new KeyNotFoundException("Такого студента нет в списке.");
                }
                Console.WriteLine($"Оценка студента {searchName}: {studentsDatabase[searchName]}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            Console.WriteLine("\n");


            // ==========================================
            // ЗАДАНИЕ 6 (Интерактивное меню)
            // ==========================================
            Console.WriteLine("=== ЗАДАНИЕ 6 ===");
            Dictionary<string, string> contacts = new Dictionary<string, string>();
            bool exitTask6 = false;

            while (!exitTask6)
            {
                Console.WriteLine("\n--- МЕНЮ КОНТАКТОВ ---");
                Console.WriteLine("1 — добавить контакт");
                Console.WriteLine("2 — найти контакт");
                Console.WriteLine("3 — удалить контакт");
                Console.WriteLine("4 — показать все контакты");
                Console.WriteLine("0 — выход к следующему заданию");
                Console.Write("Выберите действие: ");
                string choice6 = Console.ReadLine();

                switch (choice6)
                {
                    case "1":
                        Console.Write("Введите имя: ");
                        string name = Console.ReadLine();
                        Console.Write("Введите почту: ");
                        string email = Console.ReadLine();
                        if (!contacts.ContainsKey(name))
                        {
                            contacts.Add(name, email);
                            Console.WriteLine("Контакт добавлен.");
                        }
                        else
                        {
                            contacts[name] = email;
                            Console.WriteLine("Контакт обновлен.");
                        }
                        break;
                    case "2":
                        Console.Write("Введите имя для поиска: ");
                        string findName = Console.ReadLine();
                        if (contacts.TryGetValue(findName, out string foundEmail))
                        {
                            Console.WriteLine($"Почта: {foundEmail}");
                        }
                        else
                        {
                            Console.WriteLine("Контакт не найден.");
                        }
                        break;
                    case "3":
                        Console.Write("Введите имя для удаления: ");
                        string deleteName = Console.ReadLine();
                        if (contacts.Remove(deleteName))
                        {
                            Console.WriteLine("Контакт удален.");
                        }
                        else
                        {
                            Console.WriteLine("Контакт не найден.");
                        }
                        break;
                    case "4":
                        Console.WriteLine("Список всех контактов:");
                        if (contacts.Count == 0) Console.WriteLine("Список пуст.");
                        foreach (var pair in contacts)
                        {
                            Console.WriteLine($"Имя: {pair.Key} | Email: {pair.Value}");
                        }
                        break;
                    case "0":
                        exitTask6 = true;
                        Console.WriteLine("Переходим к следующему заданию...");
                        break;
                    default:
                        Console.WriteLine("Неверный пункт меню.");
                        break;
                }
            }
            Console.WriteLine("\n");


            // ==========================================
            // ЗАДАНИЕ 7
            // ==========================================
            Console.WriteLine("=== ЗАДАНИЕ 7 ===");
            Queue<string> clientQueue = new Queue<string>();
            clientQueue.Enqueue("Клиент №1");
            clientQueue.Enqueue("Клиент №2");
            clientQueue.Enqueue("Клиент №3");
            clientQueue.Enqueue("Клиент №4");
            clientQueue.Enqueue("Клиент №5");

            Console.WriteLine($"Текущий клиент (первый в очереди): {clientQueue.Peek()}");
            Console.WriteLine($"Удаляем клиента из очереди: {clientQueue.Dequeue()}");

            Console.WriteLine("Текущее состояние очереди:");
            foreach (var client in clientQueue)
            {
                Console.WriteLine(client);
            }
            Console.WriteLine("\n");


            // ==========================================
            // ЗАДАНИЕ 8
            // ==========================================
            Console.WriteLine("=== ЗАДАНИЕ 8 ===");
            Stack<int> numStack = new Stack<int>();
            while (true)
            {
                Console.Write("Введите число (положительное — в стек, отрицательное — извлечь, 'exit' или '0' — выход): ");
                string input8 = Console.ReadLine();

                if (input8.ToLower() == "exit" || input8 == "0")
                {
                    break;
                }

                if (int.TryParse(input8, out int value8))
                {
                    if (value8 > 0)
                    {
                        numStack.Push(value8);
                        Console.WriteLine($"Число {value8} добавлено в стек.");
                    }
                    else if (value8 < 0)
                    {
                        if (numStack.Count > 0)
                        {
                            int popped = numStack.Pop();
                            Console.WriteLine($"Из стека извлечено число: {popped}");
                        }
                        else
                        {
                            Console.WriteLine("Стек пуст! Нечего извлекать.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод.");
                }
            }

            Console.WriteLine("Итоговое содержимое стека (от верхнего к нижнему):");
            foreach (int item in numStack)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n");


            // ==========================================
            // ЗАДАНИЕ 9 (Интерактивное меню)
            // ==========================================
            Console.WriteLine("=== ЗАДАНИЕ 9 ===");
            List<Product> task9Products = new List<Product>();
            Queue<string> buyersQueue = new Queue<string>();
            Stack<string> operationHistory = new Stack<string>(); // Будем хранить строки-коды операций

            bool exitTask9 = false;
            int productIdCounter = 1;

            while (!exitTask9)
            {
                Console.WriteLine("\n--- ГЛАВНОЕ МЕНЮ СИСТЕМЫ ---");
                Console.WriteLine("1 — добавить товар");
                Console.WriteLine("2 — добавить покупателя в очередь");
                Console.WriteLine("3 — обслужить покупателя");
                Console.WriteLine("4 — показать товары");
                Console.WriteLine("5 — отменить последнюю операцию");
                Console.WriteLine("0 — выход");
                Console.Write("Выберите действие: ");
                string choice9 = Console.ReadLine();

                switch (choice9)
                {
                    case "1":
                        Console.Write("Введите название товара: ");
                        string pName = Console.ReadLine();
                        Console.Write("Введите цену товара: ");
                        if (double.TryParse(Console.ReadLine(), out double pPrice))
                        {
                            task9Products.Add(new Product { Id = productIdCounter++, Name = pName, Price = pPrice });
                            operationHistory.Push("add_product"); // Логируем операцию
                            Console.WriteLine("Товар успешно добавлен.");
                        }
                        else
                        {
                            Console.WriteLine("Неверная цена.");
                        }
                        break;

                    case "2":
                        Console.Write("Введите имя покупателя: ");
                        string buyerName = Console.ReadLine();
                        buyersQueue.Enqueue(buyerName);
                        operationHistory.Push("add_buyer"); // Логируем операцию
                        Console.WriteLine($"Покупатель {buyerName} добавлен в очередь.");
                        break;

                    case "3":
                        if (buyersQueue.Count > 0)
                        {
                            string servedBuyer = buyersQueue.Dequeue();
                            operationHistory.Push($"serve_buyer:{servedBuyer}"); // Логируем операцию и имя
                            Console.WriteLine($"Покупатель {servedBuyer} успешно обслужен.");
                        }
                        else
                        {
                            Console.WriteLine("Очередь покупателей пуста.");
                        }
                        break;

                    case "4":
                        Console.WriteLine("Список всех доступных товаров:");
                        if (task9Products.Count == 0) Console.WriteLine("Товаров нет.");
                        foreach (var prod in task9Products)
                        {
                            Console.WriteLine($"ID: {prod.Id} | Наименование: {prod.Name} | Цена: {prod.Price} руб.");
                        }
                        break;

                    case "5":
                        if (operationHistory.Count > 0)
                        {
                            string lastOp = operationHistory.Pop();

                            if (lastOp == "add_product")
                            {
                                if (task9Products.Count > 0)
                                {
                                    task9Products.RemoveAt(task9Products.Count - 1);
                                    productIdCounter--;
                                    Console.WriteLine("Отменено: Последний добавленный товар удален.");
                                }
                            }
                            else if (lastOp == "add_buyer")
                            {
                                if (buyersQueue.Count > 0)
                                {
                                    // Чтобы убрать последнего добавленного из Queue, пересоберем её без последнего элемента
                                    string[] items = buyersQueue.ToArray();
                                    buyersQueue.Clear();
                                    for (int i = 0; i < items.Length - 1; i++)
                                    {
                                        buyersQueue.Enqueue(items[i]);
                                    }
                                    Console.WriteLine("Отменено: Последний покупатель удален из очереди.");
                                }
                            }
                            else if (lastOp.StartsWith("serve_buyer:"))
                            {
                                // Возвращаем обслуженного покупателя обратно в НАЧАЛО очереди
                                string restoredBuyer = lastOp.Substring(12);
                                string[] currentQueue = buyersQueue.ToArray();
                                buyersQueue.Clear();
                                buyersQueue.Enqueue(restoredBuyer); // Сначала возвращенный
                                foreach (var b in currentQueue)
                                {
                                    buyersQueue.Enqueue(b); // Затем остальные
                                }
                                Console.WriteLine($"Отменено: Покупатель {restoredBuyer} возвращен в начало очереди.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Нет операций для отмены.");
                        }
                        break;

                    case "0":
                        exitTask9 = true;
                        Console.WriteLine("Программа завершена.");
                        break;

                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }
            }
        }
    }
}