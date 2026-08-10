using System;
using System.Globalization;

class Program
{
    enum HTTPError
    {
        BadRequest = 400,
        Unauthorized = 401,
        PaymentRequired = 402,
        Forbidden = 403,
        NotFound = 404
    }

    enum TestCaseStatus
    {
        Pass,
        Fail,
        Blocked,
        WP,
        Unexecuted
    }

    struct Dog
    {
        public string Name;
        public string Mark;
        public int Age;

        public override string ToString()
        {
            return $"Name: {Name}, Mark: {Mark}, Age: {Age}";
        }
    }

    struct RGB
    {
        public byte Red;
        public byte Green;
        public byte Blue;

        public RGB(byte red, byte green, byte blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        public override string ToString()
        {
            return $"RGB({Red}, {Green}, {Blue})";
        }
    }

    static void Main()
    {
        Console.WriteLine("===== Task 1. Float Numbers in Range =====");

        float number1 = ReadFloat("Enter first float number: ");
        float number2 = ReadFloat("Enter second float number: ");
        float number3 = ReadFloat("Enter third float number: ");

        bool allInRange =
            number1 >= -5 && number1 <= 5 &&
            number2 >= -5 && number2 <= 5 &&
            number3 >= -5 && number3 <= 5;

        Console.WriteLine($"All numbers belong to the range [-5; 5]: {allInRange}");

        Console.WriteLine("\n===== Task 2. Max and Min of Integers =====");

        int integer1 = ReadInt("Enter first integer: ");
        int integer2 = ReadInt("Enter second integer: ");
        int integer3 = ReadInt("Enter third integer: ");

        int maximum = Math.Max(integer1, Math.Max(integer2, integer3));
        int minimum = Math.Min(integer1, Math.Min(integer2, integer3));

        Console.WriteLine($"Maximum value: {maximum}");
        Console.WriteLine($"Minimum value: {minimum}");

        Console.WriteLine("\n===== Task 3. HTTP Error Enum =====");

        int errorCode = ReadInt("Enter HTTP error code: ");

        if (Enum.IsDefined(typeof(HTTPError), errorCode))
        {
            HTTPError error = (HTTPError)errorCode;
            Console.WriteLine($"HTTP error: {error}");
        }
        else
        {
            Console.WriteLine("Unknown HTTP error code.");
        }

        Console.WriteLine("\n===== Task 4. Struct Dog =====");

        Dog myDog = new Dog();

        Console.Write("Enter dog name: ");
        myDog.Name = Console.ReadLine() ?? string.Empty;

        Console.Write("Enter dog mark/breed: ");
        myDog.Mark = Console.ReadLine() ?? string.Empty;

        myDog.Age = ReadInt("Enter dog age: ");

        Console.WriteLine(myDog.ToString());

        Console.WriteLine("\n===== Task 5. Valid Date Check =====");

        int day = ReadInt("Enter day: ");
        int month = ReadInt("Enter month: ");

        bool isValidDate = IsValidDayAndMonth(day, month);

        Console.WriteLine($"Can these numbers represent a valid date: {isValidDate}");

        Console.WriteLine("\n===== Task 6. Sum of First Two Digits After Decimal Point =====");

        double decimalNumber = ReadDouble("Enter a double number: ");

        double absoluteNumber = Math.Abs(decimalNumber);
        int firstDigit = (int)(absoluteNumber * 10) % 10;
        int secondDigit = (int)(absoluteNumber * 100) % 10;
        int digitsSum = firstDigit + secondDigit;

        Console.WriteLine($"{firstDigit} + {secondDigit} = {digitsSum}");

        Console.WriteLine("\n===== Task 7. Greeting by Hour =====");

        int hour;

        do
        {
            hour = ReadInt("Enter hour from 0 to 23: ");

            if (hour < 0 || hour > 23)
            {
                Console.WriteLine("Hour must be between 0 and 23.");
            }
        }
        while (hour < 0 || hour > 23);

        if (hour >= 6 && hour <= 11)
        {
            Console.WriteLine("Good morning!");
        }
        else if (hour >= 12 && hour <= 17)
        {
            Console.WriteLine("Good afternoon!");
        }
        else if (hour >= 18 && hour <= 22)
        {
            Console.WriteLine("Good evening!");
        }
        else
        {
            Console.WriteLine("Good night!");
        }

        Console.WriteLine("\n===== Task 8. Test Case Status Enum =====");

        TestCaseStatus test1Status = TestCaseStatus.Pass;

        Console.WriteLine($"Test 1 status: {test1Status}");

        Console.WriteLine("\n===== Task 9. Struct RGB =====");

        RGB white = new RGB(255, 255, 255);
        RGB black = new RGB(0, 0, 0);

        Console.WriteLine($"White color: {white}");
        Console.WriteLine($"Black color: {black}");

        Console.WriteLine("\nAll tasks are completed.");
        Console.WriteLine("Press any key to close the application.");
        Console.ReadKey();
    }

    static int ReadInt(string message)
    {
        int value;

        while (true)
        {
            Console.Write(message);

            if (int.TryParse(Console.ReadLine(), out value))
            {
                return value;
            }

            Console.WriteLine("Invalid input. Please enter an integer.");
        }
    }

    static float ReadFloat(string message)
    {
        float value;

        while (true)
        {
            Console.Write(message);
            string input = Console.ReadLine() ?? string.Empty;

            input = input.Replace(',', '.');

            if (float.TryParse(
                input,
                NumberStyles.Float,
                CultureInfo.InvariantCulture,
                out value))
            {
                return value;
            }

            Console.WriteLine("Invalid input. Please enter a float number.");
        }
    }

    static double ReadDouble(string message)
    {
        double value;

        while (true)
        {
            Console.Write(message);
            string input = Console.ReadLine() ?? string.Empty;

            input = input.Replace(',', '.');

            if (double.TryParse(
                input,
                NumberStyles.Float,
                CultureInfo.InvariantCulture,
                out value))
            {
                return value;
            }

            Console.WriteLine("Invalid input. Please enter a double number.");
        }
    }

    static bool IsValidDayAndMonth(int day, int month)
    {
        if (month < 1 || month > 12)
        {
            return false;
        }

        int daysInMonth;

        switch (month)
        {
            case 2:
                daysInMonth = 28;
                break;

            case 4:
            case 6:
            case 9:
            case 11:
                daysInMonth = 30;
                break;

            default:
                daysInMonth = 31;
                break;
        }

        return day >= 1 && day <= daysInMonth;
    }
}