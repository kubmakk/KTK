using System;

// задани1
interface IGreet
{
    void SayHello();
}
class Person: IGreet
{
    public void SayHello() => Console.WriteLine("Привет!");
}

//Задание 2
interface IAnimal
{
    void Speak();
}
class Dog: IAnimal
{
    public void Speak() => Console.WriteLine("Мяу(гав)");
}
class Cat: IAnimal
{
    public void Speak() => Console.WriteLine("Гав(мяу)");
}
//Задание 3
interface IProduct
{
    string Name { get; set; }
    decimal Price { get; set; }
}
class Book: IProduct
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}
//Задание 6
interface IShape { 
    double GetArea(); 
}
class Circle(double radius): IShape
{
    public double Radius { get; set; }
    public double GetArea() => Math.PI * Radius * Radius;
}
class Rectangle(double width, double height): IShape
{
    public double Width { get; set; }
    public double Height { get; set; }
    public double GetArea() => Width * Height;
}

interface IWorker
{
    void DoWork();
}
class Teacher: IWorker
{
    public void DoWork() => Console.WriteLine("Учитель ведет урок.");
}
class Programmer: IWorker
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
class Duck: IFly, ISwim
{
    public void Fly() => Console.WriteLine("Утка летит в небе.");
    public void Swim() => Console.WriteLine("Утка плывет по озеру.");
}

interface IPrintable
{
    void Print();
}
class Document: IPrintable
{
    public void Print() => Console.WriteLine("Печать текстового документа...");
}
class Photo: IPrintable
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

        //Задание 2 и 4
        IAnimal[] animals = { new Dog(), new Cat() };
        foreach (var animal in animals)
        {
            animal.Speak();
        }

        //Задание 3
        IProduct myBook = new Book { Name = "Программирование на C#", Price = 1500 };
        Console.WriteLine($"Книга: {myBook.Name}, Цена: {myBook.Price} руб.");

        //Задание 5
        MakeSpeak(new Dog());
        MakeSpeak(new Cat());


        //Задание 6
        IShape[] shapes = { new Circle(5), new Rectangle(4, 6) };
        foreach (var shape in shapes)
        {
            Console.WriteLine($"Площадь фигуры: {shape.GetArea():F2}");
        }

        //Задание 7
        IWorker[] workers = { new Teacher(), new Programmer() };
        foreach (var worker in workers)
        {
            worker.DoWork();
        }

        //Задание 8
        Duck donald = new Duck();
        donald.Fly();
        donald.Swim();

        //Задание 9
        IPrintable[] items = { new Document(), new Photo() };
        foreach (var item in items)
        {
            item.Print();
        }

        Console.ReadLine();
    }
}