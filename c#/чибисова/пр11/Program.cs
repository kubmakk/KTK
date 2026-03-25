using System;

// задани1
interface IGreet
{
    void SayHello();
}
class Person : IGreet
{
    public void SayHello() => Console.WriteLine("Привет!");
}

//Задание 2
interface IAnimal
{
    void Speak();
}
class Dog : IAnimal
{
    public void Speak() => Console.WriteLine("Гав");
}
class Cat : IAnimal
{
    public void Speak() => Console.WriteLine("Мяу");
}
//Задание 3
interface IProduct
{
    string Name { get; set; }
    decimal Price { get; set; }
}
class Book : IProduct
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}
//Задание 6
interface IShape { double GetArea(); }
class Circle : IShape
{
    public double Radius { get; set; }
    public Circle(double radius) => Radius = radius;
    public double GetArea() => Math.PI * Radius * Radius;
}
class Rectangle : IShape
{
    public double Width { get; set; }
    public double Height { get; set; }
    public Rectangle(double width, double height) { Width = width; Height = height; }
    public double GetArea() => Width * Height;
}

interface IWorker
{
    void DoWork();
}
class Teacher : IWorker
{
    public void DoWork() => Console.WriteLine("Учитель ведет урок.");
}
class Programmer : IWorker
{
    public void DoWork() => Console.WriteLine("Программист пишет код.");
}

interface IFly
{
    void Fly();
}
interface ISwim
{
    void Swim();
}
class Duck : IFly, ISwim
{
    public void Fly() => Console.WriteLine("Утка летит в небе.");
    public void Swim() => Console.WriteLine("Утка плывет по озеру.");
}

interface IPrintable
{
    void Print();
}
class Document : IPrintable
{
    public void Print() => Console.WriteLine("Печать текстового документа...");
}
class Photo : IPrintable
{
    public void Print() => Console.WriteLine("Печать цветной фотографии...");
}

// Запуск программы

class Program
{
    static void MakeSpeak(IAnimal animal)
    {
        animal.Speak();
    }

    static void Main()
    {
        //Задание 1
        IGreet person = new Person();
        person.SayHello();

        Console.WriteLine("\n--- Задания 2 и 4 ---");
        IAnimal[] animals = { new Dog(), new Cat() };
        foreach (var animal in animals)
        {
            animal.Speak();
        }

        Console.WriteLine("\n--- Задание 3 ---");
        IProduct myBook = new Book { Name = "Программирование на C#", Price = 1500.50m };
        Console.WriteLine($"Книга: {myBook.Name}, Цена: {myBook.Price} руб.");

        Console.WriteLine("\n--- Задание 5 ---");
        MakeSpeak(new Dog());
        MakeSpeak(new Cat());


        Console.WriteLine("\n--- Задание 6 ---");
        IShape[] shapes = { new Circle(5), new Rectangle(4, 6) };
        foreach (var shape in shapes)
        {
            Console.WriteLine($"Площадь фигуры: {shape.GetArea():F2}");
        }

        Console.WriteLine("\n--- Задание 7 ---");
        IWorker[] workers = { new Teacher(), new Programmer() };
        foreach (var worker in workers)
        {
            worker.DoWork();
        }

        Console.WriteLine("\n--- Задание 8 ---");
        Duck donald = new Duck();
        donald.Fly();
        donald.Swim();

        Console.WriteLine("\n--- Задание 9 ---");
        IPrintable[] items = { new Document(), new Photo() };
        foreach (var item in items)
        {
            item.Print();
        }

        Console.ReadLine();
    }
}