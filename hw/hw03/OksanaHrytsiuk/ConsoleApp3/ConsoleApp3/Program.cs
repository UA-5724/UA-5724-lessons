using System;
enum HTTPError
{
    BadRequest = 400,
    Unauthorized = 401,
    PaymentRequired = 402,
    Forbidden = 403,
    NotFound = 404
}
struct Dog
{
    public string name;
    public string mark;
    public int age;

    public override string ToString()
    {
        return $"Name: {name}, Mark: {mark}, Age: {age}";
    }
}
enum TestCaseStatus
{
    Pass,
    Fail,
    Blocked,
    WP,
    Unexecuted
}
struct RGB
{
    public byte red;
    public byte green;
    public byte blue;
}
class Program
{
    static void Main()
    {
        //task 1. Float Numbers in Range
        /*
        float num1 = float.Parse(Console.ReadLine());
        float num2 = float.Parse(Console.ReadLine());
        float num3 = float.Parse(Console.ReadLine());

        bool inRange =
            num1 >= -5 && num1 <= 5 &&
            num2 >= -5 && num2 <= 5 &&
            num3 >= -5 && num3 <= 5;

        Console.WriteLine(inRange);
        */

        //task 2. Max and Min of Integers
        /*
        int num1 = int.Parse(Console.ReadLine());
        int num2 = int.Parse(Console.ReadLine());
        int num3 = int.Parse(Console.ReadLine());

        int max = Math.Max(num1, Math.Max(num2, num3));
        int min = Math.Min(num1, Math.Min(num2, num3));

        Console.WriteLine(max);
        Console.WriteLine(min);
        */

        //task 3. HTTP Error Enum
        /*
        int code = int.Parse(Console.ReadLine());

        HTTPError error = (HTTPError)code;

        Console.WriteLine(error);
        */

        //task 4. Struct Dog
        /*
        Dog myDog;

        myDog.name = Console.ReadLine();
        myDog.mark = Console.ReadLine();
        myDog.age = int.Parse(Console.ReadLine());

        Console.WriteLine(myDog.ToString());
        */

        //task 5. Valid Date Check
        /*
        int day = int.Parse(Console.ReadLine());
        int month = int.Parse(Console.ReadLine());

        bool isValid = false;

        if (month >= 1 && month <= 12)
        {
            if ((month == 1 || month == 3 || month == 5 || month == 7 ||
                 month == 8 || month == 10 || month == 12) &&
                 day >= 1 && day <= 31)
            {
                isValid = true;
            }
            else if ((month == 4 || month == 6 || month == 9 || month == 11) &&
                     day >= 1 && day <= 30)
            {
                isValid = true;
            }
            else if (month == 2 && day >= 1 && day <= 28)
            {
                isValid = true;
            }
        }

        Console.WriteLine(isValid);
        */

        //task 6. Sum of First Two Digits After Decimal Point
        /*
        double number = double.Parse(Console.ReadLine());

        int firstDigit = (int)(number * 10) % 10;
        int secondDigit = (int)(number * 100) % 10;

        Console.WriteLine(firstDigit + secondDigit);
        */

        //task 7. Greeting by Hour
        /*
        int h = int.Parse(Console.ReadLine());

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
        else if ((h >= 23 && h <= 23) || (h >= 0 && h <= 5))
        {
            Console.WriteLine("Good night!");
        }
        */

        //task 8. Test Case Status Enum
        /*
        TestCaseStatus test1Status = TestCaseStatus.Pass;

        Console.WriteLine(test1Status);
        */

        //task 9. Struct RGB
        RGB white = new RGB();
        white.red = 255;
        white.green = 255;
        white.blue = 255;

        RGB black = new RGB();
        black.red = 0;
        black.green = 0;
        black.blue = 0;

        Console.WriteLine($"White: ({white.red}, {white.green}, {white.blue})");
        Console.WriteLine($"Black: ({black.red}, {black.green}, {black.blue})");
    }
}