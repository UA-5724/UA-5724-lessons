using System;
using System.ComponentModel.Design;
using System.Xml.Linq;
enum HTTPError {
    BadRequest = 400,
    Unauthorized = 401,
    PaymentRequired = 402,
    Forbidden = 403,
    NotFound = 404
}
enum TestCaseStatus { 
    Pass,
    Fails,
    Blocked,
    WP,
    Unexecuted
}
//define a structure to store dog information
struct Dog
{
    public string name;
    public string mark;
    public int age;
    //return dog info as a formatted string
    public override string ToString() 
    {
        return $"Name: {name}, Mark: {mark}, Age: {age}";
    }
}
struct RGB
{
    public byte red;
    public byte green;
    public byte blue;
    //return color info as a formated string
    public override string ToString()
    {
        return $"({red}, {green}, {blue})";
    }
}
class Program
{
    static void Main()
    {
        //Task 1 float numbers in range
        //read data from console
        float a = float.Parse(Console.ReadLine()!);
        float b = float.Parse(Console.ReadLine()!);
        float c = float.Parse(Console.ReadLine()!);
        //check that the numbers are in the range
        bool result =
            a >= -5 && a <= 5 &&
            b >= -5 && b <= 5 &&
            c >= -5 && c <= 5;
        //show result
        Console.WriteLine(result);
        // Task2 max and min of integers
        //read data from console
        int d = int.Parse(Console.ReadLine()!);
        int e = int.Parse(Console.ReadLine()!);
        int f = int.Parse(Console.ReadLine()!);
        //assume that d is max value and assume that d is min value
        int max = d;
        int min = d;
        //varify whether  e is max
        if (e > max)
        {
            max = e;
        }
        //varify whether f is max
        if (f > max)
        {
            max = f;
        }
        //varify whether  e is min
        if (e < min)
        {
            min = e;
        }
        //varify whether f is min
        if (f < min)
        {
            min = f;
        }
        //show max and min value
        Console.WriteLine(max);
        Console.WriteLine(min);
        //Task3 HTTP Error Enum
        {
            //read entered error code
            int errorCode = int.Parse(Console.ReadLine()!);
            //convert entered number to enum
            HTTPError error = (HTTPError)errorCode;
            //display name of error
            Console.WriteLine(error);
        }
        //Task 4 Struct Dog
        //create a Gog object
        Dog myDog = new Dog();
        //read dog info from console
        myDog.name = Console.ReadLine()!;
        myDog.mark = Console.ReadLine()!;
        myDog.age = int.Parse(Console.ReadLine()!);
        //show dog info
        Console.WriteLine(myDog.ToString());
        //Task 5 Valid Date Check
        //read data from console
        int day = int.Parse(Console.ReadLine()!);
        int month = int.Parse(Console.ReadLine()!);
        //declare variable
        bool Result = false;
        if (month == 1 && day >= 1 && day <= 31)
        {
            Result = true;
        }
        Console.WriteLine(Result);
        //Task 6 Sum of First Two Digits After Decimal Point
        //read double number from console
        double number = double.Parse(Console.ReadLine()!);
        //extract first digit after decimal point
        int firstDigit = (int)(number * 10) % 10;
        //extract second digit after decimal point
        int secondDigit = (int)(number * 100) % 10;
        //calculate sum of digits
        int sum = firstDigit + secondDigit;
        //show calculated sum
        Console.WriteLine(sum);
        //Task 7 Greeting by Hour
        //read hour value entered into console
        int h = int.Parse(Console.ReadLine()!);
        //varify time range and show greeting
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
        //Task 8 Test Case Status Enum
        //declare variable and assign value
        TestCaseStatus test1Status = TestCaseStatus.Pass;
        Console.WriteLine(test1Status);
        //Task 8 Struct RGB
        //create white color
        RGB white = new RGB();
        white.red = 255;
        white.green = 255;
        white.blue = 255;
        //create black color
        RGB black = new RGB();
        black.red = 255;
        black.green = 255;
        black.blue = 255;
        //show color values
        Console.WriteLine($"White: {white.red}, {white.green}, {white.blue}");
        Console.WriteLine($"Black: {black.red}, {black.green}, {black.blue}");
    }
}
