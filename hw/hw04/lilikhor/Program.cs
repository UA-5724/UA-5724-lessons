using System;

class Program
{
    static void Main(string[] args)
    {
        // Task 1
        Console.Write("Enter a string: ");
        string str = Console.ReadLine();

        int vowelCount = 0;

        foreach (char c in str.ToLower())
        {
            if (c == 'a' || c == 'o' || c == 'i' || c == 'e')
            {
                vowelCount++;
            }
        }

        Console.WriteLine($"Count: {vowelCount}");


        // Task 2
        int month;

        do
        {
            Console.Write("Enter month number (1-12): ");
        } while (!int.TryParse(Console.ReadLine(), out month) || month < 1 || month > 12);

        int[] daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        Console.WriteLine($"Days: {daysInMonth[month - 1]}");


        // Task 3
        int[] numbers = new int[10];

        for (int i = 0; i < numbers.Length; i++)
        {
            while (!int.TryParse(Console.ReadLine(), out numbers[i]))
            {
                Console.Write("Invalid. Enter again: ");
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
            int firstSum = 0;

            for (int i = 0; i < 5; i++)
                firstSum += numbers[i];

            Console.WriteLine(firstSum);
        }
        else
        {
            int lastProduct = 1;

            for (int i = 5; i < 10; i++)
                lastProduct *= numbers[i];

            Console.WriteLine(lastProduct);
        }


        // Task 4
        int rangeStart;
        int rangeEnd;

        while (!int.TryParse(Console.ReadLine(), out rangeStart))
            Console.Write("Enter again: ");

        while (!int.TryParse(Console.ReadLine(), out rangeEnd))
            Console.Write("Enter again: ");

        if (rangeStart > rangeEnd)
        {
            int temp = rangeStart;
            rangeStart = rangeEnd;
            rangeEnd = temp;
        }

        int divisibleCount = 0;

        for (int i = rangeStart; i <= rangeEnd; i++)
        {
            if (i % 3 == 0)
                divisibleCount++;
        }

        Console.WriteLine(divisibleCount);


        // Task 5 
        Console.Write("Enter text: ");
        string text = Console.ReadLine();

        for (int i = 1; i < text.Length; i += 2)
        {
            Console.Write(text[i]);
        }

        Console.WriteLine();


        // Task 6 
        Console.Write("Enter drink: ");
        string drink = Console.ReadLine().ToLower();

        switch (drink)
        {
            case "coffee":
                Console.WriteLine("Coffee");
                Console.WriteLine("Price: 50");
                break;

            case "tea":
                Console.WriteLine("Tea");
                Console.WriteLine("Price: 30");
                break;

            case "juice":
                Console.WriteLine("Juice");
                Console.WriteLine("Price: 45");
                break;

            case "water":
                Console.WriteLine("Water");
                Console.WriteLine("Price: 20");
                break;

            default:
                Console.WriteLine("Unknown drink");
                break;
        }


        // Task 7 
        int averageSum = 0;
        int positiveCount = 0;

        while (true)
        {
            int currentNumber;

            while (!int.TryParse(Console.ReadLine(), out currentNumber))
            {
                Console.Write("Enter again: ");
            }

            if (currentNumber < 0)
                break;

            averageSum += currentNumber;
            positiveCount++;
        }

        if (positiveCount > 0)
        {
            Console.WriteLine((double)averageSum / positiveCount);
        }
        else
        {
            Console.WriteLine("No positive numbers.");
        }


        // Task 8
        int year;

        while (!int.TryParse(Console.ReadLine(), out year))
        {
            Console.Write("Enter again: ");
        }

        bool leapYear = (year % 4 == 0 && year % 100 != 0) || year % 400 == 0;

        Console.WriteLine(leapYear);


        // Task 9 
        int digitNumber;

        while (!int.TryParse(Console.ReadLine(), out digitNumber))
        {
            Console.Write("Enter again: ");
        }

        digitNumber = Math.Abs(digitNumber);

        int digitSum = 0;

        while (digitNumber > 0)
        {
            digitSum += digitNumber % 10;
            digitNumber /= 10;
        }

        Console.WriteLine(digitSum);


        // Task 10 
        int oddNumber;

        while (!int.TryParse(Console.ReadLine(), out oddNumber))
        {
            Console.Write("Enter again: ");
        }

        oddNumber = Math.Abs(oddNumber);

        bool onlyOdd = oddNumber != 0;

        while (oddNumber > 0)
        {
            if ((oddNumber % 10) % 2 == 0)
            {
                onlyOdd = false;
                break;
            }

            oddNumber /= 10;
        }

        Console.WriteLine(onlyOdd);
    }
}