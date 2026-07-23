using System;

namespace ConsoleTasks
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
        public string name;
        public string mark;
        public int age;

        public override string ToString()
        {
            return $"Name: {name}, Breed: {mark}, Age: {age}";
        }
    }

    struct RGB
    {
        public byte red;
        public byte green;
        public byte blue;

        public RGB(byte r, byte g, byte b)
        {
            red = r;
            green = g;
            blue = b;
        }

        public override string ToString()
        {
            return $"({red}, {green}, {blue})";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // ==========================
            // Task 1. Float Numbers in Range
            // ==========================
            Console.WriteLine("Task 1");
            float f1 = float.Parse(Console.ReadLine());
            float f2 = float.Parse(Console.ReadLine());
            float f3 = float.Parse(Console.ReadLine());

            bool inRange =
                (f1 >= -5 && f1 <= 5) &&
                (f2 >= -5 && f2 <= 5) &&
                (f3 >= -5 && f3 <= 5);

            Console.WriteLine(inRange);

            // ==========================
            // Task 2. Max and Min
            // ==========================
            Console.WriteLine("\nTask 2");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            Console.WriteLine("Maximum: " + Math.Max(a, Math.Max(b, c)));
            Console.WriteLine("Minimum: " + Math.Min(a, Math.Min(b, c)));

            // ==========================
            // Task 3. HTTP Error Enum
            // ==========================
            Console.WriteLine("\nTask 3");
            int errorCode = int.Parse(Console.ReadLine());

            if (Enum.IsDefined(typeof(HTTPError), errorCode))
                Console.WriteLine((HTTPError)errorCode);
            else
                Console.WriteLine("Unknown HTTP Error");

            // ==========================
            // Task 4. Struct Dog
            // ==========================
            Console.WriteLine("\nTask 4");
            Dog myDog = new Dog();

            myDog.name = Console.ReadLine();
            myDog.mark = Console.ReadLine();
            myDog.age = int.Parse(Console.ReadLine());

            Console.WriteLine(myDog);

            // ==========================
            // Task 5. Valid Date Check
            // ==========================
            Console.WriteLine("\nTask 5");
            int day = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());

            bool valid = false;

            if (month >= 1 && month <= 12)
            {
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

                valid = day >= 1 && day <= daysInMonth;
            }

            Console.WriteLine(valid);

            // ==========================
            // Task 6. Sum of First Two Decimal Digits
            // ==========================
            Console.WriteLine("\nTask 6");
            double number = double.Parse(Console.ReadLine());

            number = Math.Abs(number);

            int firstDigit = (int)(number * 10) % 10;
            int secondDigit = (int)(number * 100) % 10;

            Console.WriteLine($"{firstDigit} + {secondDigit} = {firstDigit + secondDigit}");

            // ==========================
            // Task 7. Greeting by Hour
            // ==========================
            Console.WriteLine("\nTask 7");
            int h = int.Parse(Console.ReadLine());

            if (h >= 6 && h <= 11)
                Console.WriteLine("Good morning!");
            else if (h >= 12 && h <= 17)
                Console.WriteLine("Good afternoon!");
            else if (h >= 18 && h <= 22)
                Console.WriteLine("Good evening!");
            else if ((h >= 23 && h <= 23) || (h >= 0 && h <= 5))
                Console.WriteLine("Good night!");
            else
                Console.WriteLine("Invalid hour");

            // ==========================
            // Task 8. Test Case Status Enum
            // ==========================
            Console.WriteLine("\nTask 8");
            TestCaseStatus test1Status = TestCaseStatus.Pass;
            Console.WriteLine(test1Status);

            // ==========================
            // Task 9. Struct RGB
            // ==========================
            Console.WriteLine("\nTask 9");
            RGB white = new RGB(255, 255, 255);
            RGB black = new RGB(0, 0, 0);

            Console.WriteLine("White: " + white);
            Console.WriteLine("Black: " + black);
        }
    }
}