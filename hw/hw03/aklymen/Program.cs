class Program
{
    static void Main()
    {
        // 1. Float Numbers in Range
        Console.Write("Enter 1st float number: ");
        float first = float.Parse(Console.ReadLine());

        Console.Write("Enter 2nd float number: ");
        float second = float.Parse(Console.ReadLine());

        Console.Write("Enter 3rd float number: ");
        float third = float.Parse(Console.ReadLine());

        bool allInRange =
            first >= -5 && first <= 5 &&
            second >= -5 && second <= 5 &&
            third >= -5 && third <= 5;

        Console.WriteLine($"Belong to range [-5; 5]: {allInRange}");
        Console.WriteLine();


        // 2. Max and Min of Integers
        Console.Write("Enter 1st integer: ");
        int int1 = int.Parse(Console.ReadLine());

        Console.Write("Enter 2nd integer: ");
        int int2 = int.Parse(Console.ReadLine());

        Console.Write("Enter 3rd integer: ");
        int int3 = int.Parse(Console.ReadLine());

        int max = Math.Max(int1, Math.Max(int2, int3));
        int min = Math.Min(int1, Math.Min(int2, int3));

        Console.WriteLine($"Maximum value: {max}");
        Console.WriteLine($"Minimum value: {min}");
        Console.WriteLine();


        // 3. HTTP Error Enum
        Console.Write("Enter HTTP error code: ");
        int errorCode = int.Parse(Console.ReadLine());

        if (Enum.IsDefined(typeof(HTTPError), errorCode))
        {
            HTTPError error = (HTTPError)errorCode;
            Console.WriteLine($"HTTP Error: {error}");
        }
        else
        {
            Console.WriteLine("Unknown error!");
        }

        Console.WriteLine();


        // 4. Struct Dog
        Dog myDog = new Dog();

        Console.Write("Dog's name: ");
        myDog.Name = Console.ReadLine();

        Console.Write("Dog's mark: ");
        myDog.Mark = Console.ReadLine();

        Console.Write("Dog's age: ");
        myDog.Age = int.Parse(Console.ReadLine());

        Console.WriteLine("Dog information:");
        Console.WriteLine(myDog);
        Console.WriteLine();


        // 5. Valid Date Check
        Console.Write("Enter day: ");
        int day = int.Parse(Console.ReadLine());

        Console.Write("Enter month: ");
        int month = int.Parse(Console.ReadLine());

        bool validDate = false;

        if (month >= 1 && month <= 12)
        {
            int[] daysInMonth =
            {
                31, 28, 31, 30, 31, 30,
                31, 31, 30, 31, 30, 31
            };

            validDate = day >= 1 && day <= daysInMonth[month - 1];
        }

        Console.WriteLine($"Valid date: {validDate}");
        Console.WriteLine();


        // 6. Sum of First Two Digits After Decimal Point
        Console.Write("Enter a double number: ");
        double value = double.Parse(Console.ReadLine());

        value = Math.Abs(value);

        int firstDigit = (int)(value * 10) % 10;
        int secondDigit = (int)(value * 100) % 10;

        Console.WriteLine($"{firstDigit} + {secondDigit} = {firstDigit + secondDigit}");
        Console.WriteLine();


        // 7. Greeting by Hour
        Console.Write("Enter hour (0-23): ");
        int hour = int.Parse(Console.ReadLine());

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
        else if (hour >= 0 && hour <= 23)
        {
            Console.WriteLine("Good night!");
        }
        else
        {
            Console.WriteLine("Invalid hour!");
        }

        Console.WriteLine();


        // 8. Test Case Status Enum
        TestCaseStatus test1Status = TestCaseStatus.Pass;

        Console.WriteLine($"Test 1 status: {test1Status}");
        Console.WriteLine();


        // 9. Struct RGB
        RGB white = new RGB
        {
            Red = 255,
            Green = 255,
            Blue = 255
        };

        RGB black = new RGB
        {
            Red = 0,
            Green = 0,
            Blue = 0
        };

        Console.WriteLine($"White in RGB: {white}");
        Console.WriteLine($"Black in RGB: {black}");
    }
}


// 3. HTTP Error Enum
enum HTTPError
{
    BadRequest = 400,
    Unauthorized = 401,
    PaymentRequired = 402,
    Forbidden = 403,
    NotFound = 404
}


// 4. Struct Dog
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


// 8. Test Case Status Enum
enum TestCaseStatus
{
    Pass,
    Fail,
    Blocked,
    WP,
    Unexecuted
}


// 9. Struct RGB
struct RGB
{
    public byte Red;
    public byte Green;
    public byte Blue;

    public override string ToString()
    {
        return $"({Red}, {Green}, {Blue})";
    }
}