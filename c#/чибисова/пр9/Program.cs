using ConsoleApp2;

Student p1 = new("d", 12);
Student p2 = new("Bogsan", 13);

Console.WriteLine();
Book book = new Book("Война и мир", "Лев Толстой", 1869);
book.PrintInfo();
book.Rename("Роблокс истории");
book.PrintInfo();


User user1 = new User("Дима", 12, "Дима@ldksfjsdlkf.com");
User user2 = new User("Коля", 32, "Коля@ldksfjsdlkf.com");
User user3 = new User("Саша", 53, "Саша@ldksfjsdlkf.com");
User user4 = new User("Илья", 21, "Илья@ldksfjsdlkf.com");
User user5 = new User("ваня", 12, "ваня@ldksfjsdlkf.com");
User user6 = new User("Ванилла", 34, "Ванилла@ldksfjsdlkf.com");

user1.PrintHeader();
user2.PrintUser();
user3.PrintUser();
user4.PrintUser();
user5.PrintUser();
user6.PrintUser();
