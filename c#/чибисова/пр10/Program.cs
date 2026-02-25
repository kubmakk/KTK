using System.Net.Mail;
using ConsoleApp2;

Console.WriteLine($"-----------------------");
ElectronicDevice device1 = new ElectronicDevice("iPhone 13", 20, 5);
ElectronicDevice device2 = new ElectronicDevice("Samsung Galaxy S21", 25, 5);
Laptop laptop1 = new Laptop("MacBook Pro", 85, 20, "Apple M1", 16, "Apple GPU", 12, 150);

device1.ShowInfo();
Console.WriteLine($"-----------------------");
device2.ShowInfo();
Console.WriteLine($"-----------------------");
laptop1.ShowInfo();

Car playerCar = new Car("Lada Racing", 180, 0);
Truck playerTruck = new Truck("Volvo Truck", 120, 5000);
SportBike playerBike = new SportBike("Yamaha R1", 300);

RaceVehicle currentVehicle = playerCar;

bool race = true;
while (race)
{
                Console.WriteLine("\n--- МЕНЮ ---");
                Console.WriteLine($"Текущий транспорт: {currentVehicle.Name}");
                currentVehicle.ShowStatus();
                Console.WriteLine("1. Завести (Start)");
                Console.WriteLine("2. Ускориться (Accelerate)");
                Console.WriteLine("3. Тормозить (Brake)");
                Console.WriteLine("4. Показать статус");
                Console.WriteLine("5. Заправить (для машины)");
                Console.WriteLine("6. Сменить транспорт (на Грузовик)");
                Console.WriteLine("0. Финиш (Выход)");
                Console.Write("Ваш выбор: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        currentVehicle.Start();
                        break;
                    case "2":
                        Console.Write("На сколько ускорить? ");
                        int accVal = int.Parse(Console.ReadLine());
                        currentVehicle.Accelerate(accVal);
                        break;
                    case "3":
                        Console.Write("На сколько тормозить? ");
                        int brakeVal = int.Parse(Console.ReadLine());
                        currentVehicle.Brake(brakeVal);
                        break;
                    case "4":
                        currentVehicle.ShowStatus();
                        break;
                    case "5":
                        if (currentVehicle is Car car)
                        {
                            car.Refuel();
                        }
                        else
                        {
                            Console.WriteLine("Это действие доступно только для машины.");
                        }
                        break;
                    case "6":
                        currentVehicle = playerTruck;
                        Console.WriteLine("Вы пересели в грузовик!");
                        break;
                    case "0":
                        race = false;
                        Console.WriteLine("Гонка окончена!");
                        break;
                    default:
                        Console.WriteLine("Неверная команда.");
                        break;
                }
            }

// Student p1 = new("d", 12);
// Student p2 = new("Bogsan", 13);

// Console.WriteLine();
// Book book = new Book("Война и мир", "Лев Толстой", 1869);
// book.PrintInfo();
// book.Rename("Роблокс истории");
// book.PrintInfo();


// User user1 = new User("Дима", 12, "Дима@ldksfjsdlkf.com");
// User user2 = new User("Коля", 32, "Коля@ldksfjsdlkf.com");
// User user3 = new User("Саша", 53, "Саша@ldksfjsdlkf.com");
// User user4 = new User("Илья", 21, "Илья@ldksfjsdlkf.com");
// User user5 = new User("ваня", 12, "ваня@ldksfjsdlkf.com");
// User user6 = new User("Ванилла", 34, "Ванилла@ldksfjsdlkf.com");

// user1.PrintHeader();
// user2.PrintUser();
// user3.PrintUser();
// user4.PrintUser();
// user5.PrintUser();
// user6.PrintUser();
