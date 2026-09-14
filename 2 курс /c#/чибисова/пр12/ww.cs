using System;

class Animal
{
    public virtual void Speak()
    {
        Console.WriteLine("животное издает звук");
    }

    public virtual void MakeSound()
    {
        Console.WriteLine("звук");
    }
}

class Dog : Animal
{
    public override void Speak()
    {
        Console.WriteLine("гав");
    }

    public override void MakeSound()
    {
        Console.WriteLine("гав гав");
    }
}

class Cat : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("мяу");
    }
}

class Bird : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("чирик");
    }
}

class Bear : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("ррр");
    }
}

class Vehicle
{
    public virtual void Move()
    {
        Console.WriteLine("транспорт движется");
    }
}

class Car : Vehicle
{
    public override void Move()
    {
        Console.WriteLine("машина едет");
    }
}

class Bike : Vehicle
{
    public override void Move()
    {
        Console.WriteLine("велосипед едет");
    }
}

class Boat : Vehicle
{
    public override void Move()
    {
        Console.WriteLine("лодка плывет");
    }
}

abstract class Shape
{
    public abstract double GetPerimeter();
}

class Square : Shape
{
    public double Side { get; set; }
    public override double GetPerimeter() => 4 * Side;
}

class Triangle : Shape
{
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }
    public override double GetPerimeter() => A + B + C;
}

abstract class Creature
{
    public virtual void CastSpell()
    {
        Console.WriteLine("кастует заклинание");
    }
}

class Wizard : Creature
{
    public override void CastSpell()
    {
        Console.WriteLine("огненный шар");
    }
}

class Elf : Creature
{
    public override void CastSpell()
    {
        Console.WriteLine("лечение");
    }
}

class Orc : Creature
{
    public override void CastSpell()
    {
        Console.WriteLine("усиление ярости");
    }
}

class Device
{
    public virtual void TurnOn()
    {
        Console.WriteLine("устройство включается");
    }
}

class Laptop : Device
{
    public override void TurnOn()
    {
        Console.WriteLine("ноутбук включается");
    }
}

class Phone : Device
{
    public override void TurnOn()
    {
        Console.WriteLine("телефон включается");
    }
}

class Tablet : Device
{
    public override void TurnOn()
    {
        Console.WriteLine("планшет включается");
    }
}

abstract class Athlete
{
    public abstract void Compete();
}

class Runner : Athlete
{
    public override void Compete()
    {
        Console.WriteLine("бегун бежит");
    }
}

class Swimmer : Athlete
{
    public override void Compete()
    {
        Console.WriteLine("пловец плывет");
    }
}

class Cyclist : Athlete
{
    public override void Compete()
    {
        Console.WriteLine("велосипедист едет");
    }
}

abstract class Character
{
    public int Health { get; set; } = 100;
    public abstract void Attack(Character target);
    public virtual void ReceiveDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine("получен урон осталось здоровья " + Health);
    }
}

class Warrior : Character
{
    public override void Attack(Character target)
    {
        Console.WriteLine("воин атакует");
        target.ReceiveDamage(10);
    }
}

class Mage : Character
{
    public override void Attack(Character target)
    {
        Console.WriteLine("маг атакует");
        target.ReceiveDamage(15);
    }
}

class Archer : Character
{
    public override void Attack(Character target)
    {
        Console.WriteLine("лучник атакует");
        target.ReceiveDamage(12);
    }
}

abstract class FarmAnimal
{
    public string Name { get; set; }
    public virtual void MakeSound()
    {
        Console.WriteLine("звук животного");
    }
    public virtual void Eat()
    {
        Console.WriteLine("животное ест");
    }
    public abstract void GetProduct();
}

class Cow : FarmAnimal
{
    public override void MakeSound()
    {
        Console.WriteLine("муу");
    }
    public override void GetProduct()
    {
        Console.WriteLine("получено молоко");
    }
}

class Sheep : FarmAnimal
{
    public override void MakeSound()
    {
        Console.WriteLine("бее");
    }
    public override void GetProduct()
    {
        Console.WriteLine("получена шерсть");
    }
}

class Chicken : FarmAnimal
{
    public override void MakeSound()
    {
        Console.WriteLine("кококо");
    }
    public override void GetProduct()
    {
        Console.WriteLine("получено яйцо");
    }
}

class Pig : FarmAnimal
{
    public override void MakeSound()
    {
        Console.WriteLine("хрю");
    }
    public override void GetProduct()
    {
        Console.WriteLine("получено мясо");
    }
}

class Program
{
    static void MakeSound(Animal animal)
    {
        animal.MakeSound();
    }

    static void Main()
    {
        //задание 1
        Animal animal = new Animal();
        animal.Speak();
        Dog dog = new Dog();
        dog.Speak();

        //задание 2
        Vehicle[] vehicles = new Vehicle[] { new Car(), new Bike(), new Boat() };
        foreach (Vehicle v in vehicles)
        {
            v.Move();
        }

        //задание 3
        Square square = new Square();
        Triangle triangle = new Triangle();

        //задание 4
        Wizard wizard = new Wizard();
        Elf elf = new Elf();
        Orc orc = new Orc();

        //задание 5
        MakeSound(new Dog());
        MakeSound(new Cat());
        MakeSound(new Bird());
        MakeSound(new Bear());

        //задание 6
        Laptop laptop = new Laptop();
        laptop.TurnOn();
        Phone phone = new Phone();
        phone.TurnOn();
        Tablet tablet = new Tablet();
        tablet.TurnOn();

        //задание 7
        Runner runner = new Runner();
        runner.Compete();
        Swimmer swimmer = new Swimmer();
        swimmer.Compete();
        Cyclist cyclist = new Cyclist();
        cyclist.Compete();

        //задание 8
        Warrior warrior = new Warrior();
        Mage mage = new Mage();
        Archer archer = new Archer();

        warrior.Attack(mage);
        mage.Attack(archer);
        archer.Attack(warrior);

        //задание 9
        Cow cow = new Cow { Name = "буренка" };
        Sheep sheep = new Sheep { Name = "долли" };
        Chicken chicken = new Chicken { Name = "ряба" };
        Pig pig = new Pig { Name = "пеппа" };

        Console.WriteLine("добро пожаловать на ферму");
        bool isPlaying = true;
        while (isPlaying)
        {
            Console.WriteLine("выберите животное 1 корова 2 овца 3 курица 4 свинья 5 выход");
            string choice = Console.ReadLine();
            FarmAnimal selectedAnimal = null;

            if (choice == "1") selectedAnimal = cow;
            else if (choice == "2") selectedAnimal = sheep;
            else if (choice == "3") selectedAnimal = chicken;
            else if (choice == "4") selectedAnimal = pig;
            else if (choice == "5") isPlaying = false;
            else Console.WriteLine("ошибка ввода");

            if (selectedAnimal != null)
            {
                Console.WriteLine("выберите действие 1 звук 2 кормить 3 собрать продукт");
                string action = Console.ReadLine();
                if (action == "1") selectedAnimal.MakeSound();
                else if (action == "2") selectedAnimal.Eat();
                else if (action == "3") selectedAnimal.GetProduct();
                else Console.WriteLine("ошибка ввода");
            }
        }
    }
}