using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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