using System;

delegate double CalcDelegate(int a, int b);
delegate void Operation(int a);
delegate void Step(ref int a);
delegate void ProfDel(int a);

class Professor
{
    public ProfDel myDelegate;

    public void Run(int number)
    {
        if (myDelegate != null)
        {
            myDelegate(number);
        }
    }
}

class Program
{
    static double Calculate(int a, int b, CalcDelegate op)
    {
        return op(a, b);
    }

    static CalcDelegate GetOperation(int code)
    {
        if (code == 1) return (x, y) => x + y;
        if (code == 2) return (x, y) => x * y;
        if (code == 3) return (x, y) => Math.Pow(x, y);
        if (code == 4) return (x, y) => x - y;
        if (code == 5) return (x, y) => (double)x / y;

        Console.WriteLine("ошибка");
        return (x, y) => 0;
    }

    static void PrintNum(int a)
    {
        Console.WriteLine(a);
    }

    static void PrintSq(int a)
    {
        Console.WriteLine(a * a);
    }

    static void AddTen(int a)
    {
        Console.WriteLine(a + 10);
    }

    static void AddFive(ref int a)
    {
        a += 5;
    }

    static void MulTwo(ref int a)
    {
        a *= 2;
    }

    static void SubThree(ref int a)
    {
        a -= 3;
    }

    static void ProfOp1(int a)
    {
        Console.WriteLine(a);
    }

    static void ProfOp2(int a)
    {
        Console.WriteLine(a + 5);
    }

    static void Repeat(int count, Action action)
    {
        for (int i = 0; i < count; i++)
        {
            action();
        }
    }

    static void RegMethod()
    {
        Console.WriteLine("обычный метод");
    }

    static int Execute(Func<int, int> func, int number)
    {
        return func(number);
    }

    static int DoubleMethod(int a)
    {
        return a * 2;
    }

    static int ExtraMethod(int a)
    {
        return a * 10;
    }

    static bool CheckNumber(int number, Predicate<int> pred)
    {
        return pred(number);
    }

    static bool CheckEven(int a)
    {
        return a % 2 == 0;
    }

    static bool CheckPositive(int a)
    {
        return a > 0;
    }

    static void Main()
    {
        //задание 1
        double r1 = Calculate(10, 2, (x, y) => x + y);
        double r2 = Calculate(10, 2, (x, y) => x * y);
        double r3 = Calculate(10, 2, (x, y) => (double)x / y);
        double r4 = Calculate(10, 2, (x, y) => Math.Pow(x, y));
        Console.WriteLine(r1);
        Console.WriteLine(r2);
        Console.WriteLine(r3);
        Console.WriteLine(r4);

        //задание 2
        CalcDelegate op1 = GetOperation(1);
        Console.WriteLine(op1(5, 5));
        CalcDelegate opErr = GetOperation(10);

        //задание 3
        Operation opMulticast = PrintNum;
        opMulticast += PrintSq;
        opMulticast += AddTen;
        opMulticast(5);

        //задание 4
        Step stepMulticast = AddFive;
        stepMulticast += MulTwo;
        stepMulticast += SubThree;
        int refVal = 10;
        stepMulticast(ref refVal);
        Console.WriteLine(refVal);

        //задание 5
        Professor prof = new Professor();
        prof.myDelegate = ProfOp1;
        prof.myDelegate += ProfOp2;
        prof.Run(10);

        //задание 6
        Repeat(3, RegMethod);
        Repeat(2, () => Console.WriteLine("лямбда"));

        //задание 7
        Console.WriteLine(Execute(DoubleMethod, 5));
        Console.WriteLine(Execute(x => x * x, 5));
        Console.WriteLine(Execute(ExtraMethod, 5));

        //задание 8
        Console.WriteLine(CheckNumber(10, CheckEven));
        Console.WriteLine(CheckNumber(-5, CheckPositive));
    }
}
