using System;

class Program
{
    static void Main()
    {
        int task = ReadInt("Choose task (1-10): ");

        switch (task)
        {
            case 1: Task1(); break;
            case 2: Task2(); break;
            case 3: Task3(); break;
            case 4: Task4(); break;
            case 5: Task5(); break;
            case 6: Task6(); break;
            case 7: Task7(); break;
            case 8: Task8(); break;
            case 9: Task9(); break;
            case 10: Task10(); break;
            default:
                Console.WriteLine("Invalid task number.");
                break;
        }
    }

    static void Task1()
    {
        Console.Write("Enter text: ");
        string str = Console.ReadLine() ?? "";

        int countA = 0, countO = 0, countI = 0, countE = 0;

        foreach (char c in str.ToLower())
        {
            switch (c)
            {
                case 'a': countA++; break;
                case 'o': countO++; break;
                case 'i': countI++; break;
                case 'e': countE++; break;
            }
        }

        Console.WriteLine($"A: {countA}");
        Console.WriteLine($"O: {countO}");
        Console.WriteLine($"I: {countI}");
        Console.WriteLine($"E: {countE}");
    }

    static void Task2()
    {
        Console.Write("Enter month number (1-12): ");

        if (int.TryParse(Console.ReadLine(), out int month))
        {
            int days;

            switch (month)
            {
                case 2: days = 28; break;
                case 4:
                case 6:
                case 9:
                case 11: days = 30; break;
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12: days = 31; break;
                default:
                    Console.WriteLine("Invalid month.");
                    return;
            }

            Console.WriteLine($"Days: {days}");
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }

    static void Task3()
    {
        int[] numbers = new int[10];

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write($"Number {i + 1}: ");
            while (!int.TryParse(Console.ReadLine(), out numbers[i]))
            {
                Console.Write("Invalid number. Try again: ");
            }
        }

        bool allPositive = true;

        for (int i = 0; i < 5; i++)
        {
            if (numbers[i] <= 0)
            {
                allPositive = false;
                break;
            }
        }

        if (allPositive)
        {
            int sum = 0;
            for (int i = 0; i < 5; i++)
                sum += numbers[i];

            Console.WriteLine($"Sum = {sum}");
        }
        else
        {
            // long: product of 5 ints easily overflows int
            long product = 1;
            for (int i = 5; i < 10; i++)
                product *= numbers[i];

            Console.WriteLine($"Product = {product}");
        }
    }

    static void Task4()
    {
        int a = ReadInt("Enter a: ");
        int b = ReadInt("Enter b: ");

        // Range [5..1] is the same as [1..5]
        if (a > b)
        {
            (a, b) = (b, a);
        }

        int count = 0;

        // long: i++ would overflow when b == int.MaxValue
        for (long i = a; i <= b; i++)
        {
            if (i % 3 == 0)
                count++;
        }

        Console.WriteLine($"Count = {count}");
    }

    static void Task5()
    {
        Console.Write("Enter text: ");
        string text = Console.ReadLine() ?? "";

        for (int i = 1; i < text.Length; i += 2)
        {
            Console.Write(text[i]);
        }

        Console.WriteLine();
    }

    static void Task6()
    {
        Console.Write("Enter drink: ");
        string drink = (Console.ReadLine() ?? "").ToLower();

        switch (drink)
        {
            case "coffee":
                Console.WriteLine("Drink: Coffee");
                Console.WriteLine("Price: 80");
                break;
            case "tea":
                Console.WriteLine("Drink: Tea");
                Console.WriteLine("Price: 50");
                break;
            case "juice":
                Console.WriteLine("Drink: Juice");
                Console.WriteLine("Price: 60");
                break;
            case "water":
                Console.WriteLine("Drink: Water");
                Console.WriteLine("Price: 30");
                break;
            default:
                Console.WriteLine("Unknown drink.");
                break;
        }
    }

    static void Task7()
    {
        int sum = 0;
        int count = 0;

        while (true)
        {
            Console.Write("Enter number: ");

            if (!int.TryParse(Console.ReadLine(), out int number))
            {
                Console.WriteLine("Invalid input.");
                continue;
            }

            if (number < 0)
                break;

            sum += number;
            count++;
        }

        if (count > 0)
        {
            double average = (double)sum / count;
            Console.WriteLine($"Average = {average}");
        }
        else
        {
            Console.WriteLine("No positive numbers entered.");
        }
    }

    static void Task8()
    {
        int year = ReadInt("Enter year: ");

        bool isLeapYear =
            (year % 4 == 0 && year % 100 != 0) ||
            (year % 400 == 0);

        Console.WriteLine(isLeapYear);
    }

    static void Task9()
    {
        // long: Math.Abs(int.MinValue) does not fit into int
        long number = Math.Abs((long)ReadInt("Enter integer: "));

        long sum = 0;

        while (number > 0)
        {
            sum += number % 10;
            number /= 10;
        }

        Console.WriteLine($"Sum of digits = {sum}");
    }

    static void Task10()
    {
        long number = Math.Abs((long)ReadInt("Enter integer: "));

        bool onlyOdd = true;

        while (number > 0)
        {
            long digit = number % 10;

            if (digit % 2 == 0)
            {
                onlyOdd = false;
                break;
            }

            number /= 10;
        }

        Console.WriteLine(onlyOdd);
    }

    static int ReadInt(string message)
    {
        Console.Write(message);

        int value;
        while (!int.TryParse(Console.ReadLine(), out value))
        {
            Console.Write("Invalid number. Try again: ");
        }

        return value;
    }
}