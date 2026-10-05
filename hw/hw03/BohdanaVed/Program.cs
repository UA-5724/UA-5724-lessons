namespace HW3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task 1: Float numbers in range [-5; 5]");
            float n1 = ReadFloat("Enter first number: ");
            float n2 = ReadFloat("Enter second number: ");
            float n3 = ReadFloat("Enter third number: ");

            if (n1 >= -5 && n1 <= 5 && n2 >= -5 && n2 <= 5 && n3 >= -5 && n3 <= 5)
            {
                Console.WriteLine("All numbers are in range [-5; 5]");
            }
            else
            {
                Console.WriteLine("Not all numbers are in range [-5; 5]");
            }
            Console.WriteLine();

            Console.WriteLine("Task 2: Max and Min of integers");
            int a = ReadInt("Enter first integer: ");
            int b = ReadInt("Enter second integer: ");
            int c = ReadInt("Enter third integer: ");

            int max = a;
            if (b > max) max = b;
            if (c > max) max = c;

            int min = a;
            if (b < min) min = b;
            if (c < min) min = c;

            Console.WriteLine("Max = " + max);
            Console.WriteLine("Min = " + min);
            Console.WriteLine();

            Console.WriteLine("Task 3: HTTP error enum");
            int code = ReadInt("Enter HTTP error code: ");
            HTTPError error = (HTTPError)code;
            Console.WriteLine("Error name: " + error);
            Console.WriteLine();

            Console.WriteLine("Task 4: Dog struct");
            Dog myDog;
            Console.Write("Enter dog name: ");
            myDog.name = Console.ReadLine();
            Console.Write("Enter dog mark: ");
            myDog.mark = Console.ReadLine();
            myDog.age = ReadInt("Enter dog age: ");
            Console.WriteLine(myDog.ToString());
            Console.WriteLine();

            Console.WriteLine("Task 5: Valid day and month");
            int day = ReadInt("Enter day: ");
            int month = ReadInt("Enter month: ");

            bool valid = false;
            if (month >= 1 && month <= 12)
            {
                if (month == 2)
                {
                    if (day >= 1 && day <= 28) valid = true;
                }
                else if (month == 4 || month == 6 || month == 9 || month == 11)
                {
                    if (day >= 1 && day <= 30) valid = true;
                }
                else
                {
                    if (day >= 1 && day <= 31) valid = true;
                }
            }

            if (valid)
            {
                Console.WriteLine("Valid day and month");
            }
            else
            {
                Console.WriteLine("Not valid day and month");
            }
            Console.WriteLine();

            Console.WriteLine("Task 6: Sum of first two digits after decimal point");
            double value = ReadDouble("Enter a double number: ");
            string number = value.ToString();
            int dotIndex = number.IndexOf('.');

            int firstDigit = 0;
            if (dotIndex >= 0 && dotIndex + 1 < number.Length)
            {
                firstDigit = number[dotIndex + 1] - '0';
            }

            int secondDigit = 0;
            if (dotIndex >= 0 && dotIndex + 2 < number.Length)
            {
                secondDigit = number[dotIndex + 2] - '0';
            }
            Console.WriteLine(firstDigit + " + " + secondDigit + " = " + (firstDigit + secondDigit));
            Console.WriteLine();

            Console.WriteLine("Task 7: Greeting by hour");
            int h = ReadInt("Enter the hour (0-23): ");
            if (h >= 6 && h <= 11)
            {
                Console.WriteLine("Good morning!");
            }
            else if (h >= 12 && h <= 17)
            {
                Console.WriteLine("Good afternoon!");
            }
            else if (h >= 18 && h <= 22)
            {
                Console.WriteLine("Good evening!");
            }
            else
            {
                Console.WriteLine("Good night!");
            }
            Console.WriteLine();

            Console.WriteLine("Task 8: Test case status enum");
            TestCaseStatus test1Status = TestCaseStatus.Pass;
            Console.WriteLine("test1Status = " + test1Status);
            Console.WriteLine();

            Console.WriteLine("Task 9: RGB struct");
            RGB white;
            white.red = 255;
            white.green = 255;
            white.blue = 255;

            RGB black;
            black.red = 0;
            black.green = 0;
            black.blue = 0;

            Console.WriteLine("White: " + white.red + ", " + white.green + ", " + white.blue);
            Console.WriteLine("Black: " + black.red + ", " + black.green + ", " + black.blue);
        }

        static int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                int value;
                if (int.TryParse(Console.ReadLine(), out value))
                {
                    return value;
                }

                Console.WriteLine("This is not a whole number, try again");
            }
        }

        static float ReadFloat(string message)
        {
            while (true)
            {
                Console.Write(message);
                float value;
                if (float.TryParse(Console.ReadLine(), out value))
                {
                    return value;
                }

                Console.WriteLine("This is not a number, try again");
            }
        }

        static double ReadDouble(string message)
        {
            while (true)
            {
                Console.Write(message);
                double value;
                if (double.TryParse(Console.ReadLine(), out value))
                {
                    return value;
                }

                Console.WriteLine("This is not a number, try again");
            }
        }
    }

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
            return "Name: " + name + ", Mark: " + mark + ", Age: " + age;
        }
    }

    struct RGB
    {
        public byte red;
        public byte green;
        public byte blue;
    }
}
