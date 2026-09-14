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

namespace ConsoleApp2
{
    class Device
    {
        private string _Model;
        private int _PowerConsumption;
        public static int TotalDevices = 0;

        public Device(string model, int powerConsumption)
        {
            _Model = model;
            _PowerConsumption = powerConsumption;
            TotalDevices++;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Модель: {_Model}, Потребление энергии: {_PowerConsumption} Вт");
        }
    }

    class ElectronicDevice : Device
    {
        private int _Voltage;

        public ElectronicDevice(string model, int powerConsumption, int voltage) : base(model, powerConsumption)
        {
            _Voltage = voltage;
        }

        public void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Напряжение: {_Voltage} В");
        }


    }

    class Computer : ElectronicDevice
    {
        private string _CPU;
        private int _RAM;
        private string _GPU;

        public Computer(string model, int powerConsumption, int voltage, string cpu, int ram, string gpu) : base(model, powerConsumption, voltage)
        {
            _CPU = cpu;
            _RAM = ram;
            _GPU = gpu;
        }

        public void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Процессор: {_CPU}, ОЗУ: {_RAM} ГБ, Видеокарта: {_GPU}");
        }
    }

    class Laptop : Computer
    {
        private int _BatteryCapacity;
        private int _Weight;

        public Laptop(string model, int powerConsumption, int voltage, string cpu, int ram, string gpu, int batteryCapacity, int weight) : base(model, powerConsumption, voltage, cpu, ram, gpu)
        {
            _BatteryCapacity = batteryCapacity;
            _Weight = weight;
        }

        public void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Ёмкость батареи: {_BatteryCapacity} мАч, Вес: {_Weight} кг");
        }
    }

    class RaceVehicle
    {
        public string Name;
        public int MaxSpeed;
        protected int CurrentSpeed;
        bool IsMoving;

        public RaceVehicle(string name, int maxSpeed)
        {
            Name = name;
            MaxSpeed = maxSpeed;
            CurrentSpeed = 0;
            IsMoving = false;
        }
        public void Start()
        {
            if (IsMoving == true)
            {
                Console.WriteLine($"{Name} уже движется");
                return;
            }
            else
            {
                IsMoving = true;
                Console.WriteLine($"{Name} начал движение.");
            }
        }
        public void Accelerate(int value)
        {
            if (IsMoving == false)
            {
                Console.WriteLine($"{Name} сначала надо запуститится");
                return;
            }

            CurrentSpeed += value;
            if (CurrentSpeed > MaxSpeed)
            {
                CurrentSpeed = MaxSpeed;
                Console.WriteLine($"{Name} Ускоряется. Теперь скорость {MaxSpeed} км/ч");
            }
            else
            {
                Console.WriteLine($"Скорость меньше чем максимальная");
            }
        }
        public void Brake(int value)
        {
            if (IsMoving == false)
            {
                Console.WriteLine($"{Name} сначала надо запуститится");
                return;
            }
            CurrentSpeed -= value;
            if (CurrentSpeed <= 0)
            {
                CurrentSpeed = 0;
                IsMoving = false;
                Console.WriteLine($"{Name} Тормозит. Теперь скорость 0 км/ч");
            }
            else
            {
                Console.WriteLine($"Скорость больше чем 0");
            }
        }

        public void Stop()
        {
            IsMoving = false;
            CurrentSpeed = 0;
            Console.WriteLine($"{Name} остановился.");
        }
        public void ShowStatus() { }
    }

    class Car : RaceVehicle
    {
        public int Fuel { get; set; }
        public Car(string name, int maxSpeed, int fuel) : base(name, maxSpeed)
        {
            Fuel = fuel;
        }

        public void Refuel()
        {
            Fuel = 100;
            Console.WriteLine("Бак заправлен!");
        }

        public virtual void Start()
        {
            if (Fuel <= 0)
            {
                Console.WriteLine("Нет топлива!");
                return;
            }
            base.Start();
        }
    }

    class Truck : RaceVehicle
    {
        public int Cargo { get; set; }
        public Truck(string name, int maxSpeed, int cargo) : base(name, maxSpeed)
        {
            Cargo = cargo;
        }
    }

    class SportBike : RaceVehicle
    {
        public SportBike(string name, int maxSpeed) : base(name, maxSpeed) { }
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
