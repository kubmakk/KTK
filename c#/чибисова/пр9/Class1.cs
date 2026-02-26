using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Student
    {
        private string _name;
        private int _age;

        public void PrintInfo()
        {
            Console.WriteLine($"Меня зовут {_name} мне {_age}");
        }

        // 3 
        public Student() { }
        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public Student(int age)
        {
            _age = 19;
        }
        // 4 and 5  
        public string Name
        { 
            get { return _name; }
            set { if (value.Length < 2)
                {
                    Console.WriteLine("Имя меньше двух символов");
                    return;
                }
            _name = value;
            }
        }
        public int Age
        {
            get { return _age; }
            set { if (value > 16 || value < 60) {
                    Console.WriteLine("Возраст должен быть от 16 до 60 лет");
                    return;
                };
                _age = value;
            }
        }
        public static void PrintUniversity()
        {
            Console.WriteLine("Казанский Технический Колледж");
        }


    }

    class Book 
    {

        private string _title;
        private string _autor;
        private int _year;

        public Book(string title, string autor, int year) 
        {
            this._title = title;
            this._autor = autor;
            this._year = year;
        }


        public void Rename(string newTitle) 
        { 
            _title = newTitle;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Название: {_title}");
            Console.WriteLine($"Автор: {_autor}");
            Console.WriteLine($"Год издания: {_year}");
            Console.WriteLine("-------------------");
        }
    }

    class User 
    {
        private static int _nextId = 1;  
        private int _id { get; }
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length < 2)
                {
                    Console.WriteLine("Имя меньше двух символов");
                    return;
                }
                _name = value;
            }
        }
        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                if (value < 0 || value > 120)
                {
                    Console.WriteLine("Возраст должен быть от 0 до 120 лет");
                    return;
                }
                ;
                _age = value;
            }
        }
        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                if (value.Contains("@"))
                {
                    _email = value;
                }
            }
        }

        public User()
        {
            _id = _nextId++;
            Name = "Без имени";
            Age = 0;
            Email = "";
        }
        public User(string name, int age, string email)
        {
            _id = _nextId++;
            Name = name;
            Age = age;
            Email = email;
        }

        public void PrintUser()
        {
            Console.WriteLine($" {_id,3} |  {Name,-15} | {Age} | {Email}");
        }

        public void PrintHeader() 
        {
            Console.WriteLine("Список пользователей:");
            Console.WriteLine("ID   | Имя            | Воз | Email               ");
            Console.WriteLine("--------------------------------------------------");
        }
    }
    class Movie
    {
        private string _title;
        private string _director;
        private int _year;
        private int _duration;
        private bool _watched;

        public string Title
        {
            get => _title;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 2)
                {
                    Console.WriteLine("Название должно быть не короче 2 символов");
                    return;
                }
                _title = value;
            }
        }

        public string Director
        {
            get => _director;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 2)
                {
                    Console.WriteLine("Имя режиссера должно быть не короче 2 символов");
                    return;
                }
                _director = value;
            }
        }

        public int Year
        {
            get => _year;
            set
            {
                if (value < 1900 || value > DateTime.Now.Year)
                {
                    Console.WriteLine($"Год должен быть от 1900 до {DateTime.Now.Year}");
                    return;
                }
                _year = value;
            }
        }

        public int Duration
        {
            get => _duration;
            set
            {
                if (value < 30 || value > 300)
                {
                    Console.WriteLine("Продолжительность должна быть от 30 до 300 минут");
                    return;
                }
                _duration = value;
            }
        }

        public bool Watched
        {
            get => _watched;
            set => _watched = value;
        }

        public bool IsClassic => DateTime.Now.Year - Year > 30;
        public Movie() { }

        public Movie(string title, string director, int year)
        {
            Title = title;
            Director = director;
            Year = year;
            Duration = 120;
            Watched = false;
        }

        public Movie(string title, string director, int year, int duration)
        {
            Title = title;
            Director = director;
            Year = year;
            Duration = duration;
            Watched = false;
        }

        public Movie(string title, string director, int year, int duration, bool watched)
        {
            Title = title;
            Director = director;
            Year = year;
            Duration = duration;
            Watched = watched;
        }


        public void Watch()
        {
            Watched = true;
            Console.WriteLine($"Фильм '{Title}' отмечен как просмотренный");
        }

        public void Rewatch()
        {
            Watched = true;
            Console.WriteLine($"Фильм '{Title}' отмечен как пересмотренный");
        }

        public void UpdateDuration(int newDuration)
        {
            Duration = newDuration;
            Console.WriteLine($"Продолжительность '{Title}' обновлена до {newDuration} минут");
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Название: {Title,-25} | Режиссер: {Director,-15} | Год: {Year,4} | Длительность: {Duration,3}м | Просмотрено: {Watched} | Классика: {IsClassic}");
        }
    }
}