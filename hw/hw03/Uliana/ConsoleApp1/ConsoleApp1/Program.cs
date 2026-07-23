//Console.WriteLine("HW#3");
namespace ConsoleApp1
{
 
    internal class Programm
    {
        static void Main()
        {
            Main1();
            Main2();
            Main3();
            Main4();
            Main5();
            Main6();
            Main7();
            Main8();
            Main9();
        }
        //Task#1
        static void Main1()
           {
               Console.WriteLine("Enter 1st number");
               float a = float.Parse(Console.ReadLine());
               Console.WriteLine("Enter 2d number");
               float b = float.Parse(Console.ReadLine());
               Console.WriteLine("Enter 3d number");
               float c = float.Parse(Console.ReadLine());
               string range = (a >= -5 && a <= 5) && (b >= -5 && b <= 5) && (c >= -5 && c <= 5) ? "all numbers belong to the range [-5; 5]" : "at least one number is out of range [-5; 5]";
               Console.WriteLine($"{range}");
           }
        //Task#2
        static void Main2()
        {
            Console.WriteLine("Enter 1st number");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter 2d number");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter 3d number");
            int c = int.Parse(Console.ReadLine());
            int max = Math.Max(a, Math.Max(b, c));
            Console.WriteLine($"Maximum value is {max}");
            int min = Math.Min(a, Math.Min(b, c));
            Console.WriteLine($"Minimum value is {min}");
        }
        //Task#3
        enum HTTPError { BadRequest = 400, Unauthorized = 401, PaymentRequired = 402, Forbidden = 403, NotFound = 404, MethodNotAllowed = 405 };

        static void Main3()
        {
            Console.WriteLine("Enter staus code");
            int http = int.Parse(Console.ReadLine());
            HTTPError httpcode = (HTTPError)http;
            Console.WriteLine($" {httpcode} - {(int)http}");
        }
        //Task#4
       struct Dog
        {
            public string name;
            public string mark;
            public int age;

        }
        static void Main4()
        {
            Dog dog1 = new Dog();
            {
                dog1.mark = "Rough Collie";
                dog1.name = "Lassie";
                dog1.age = 3;
            }
            Console.WriteLine($"dog name is {dog1.name},mark {dog1.mark},age {dog1.age}");
        }
      //Task#5
        static void Main5()
        {
            Console.WriteLine("Entter day number");
            int day = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter month number");
            int month = int.Parse(Console.ReadLine());
            string validDate = (day >= 1 && day <= 31) && (month >= 1 && month <= 12) ? "Entered number valid, can represent a valid day and month" : "Entered number invalid, can not represent a valid day and month";
            Console.WriteLine(validDate);
        }
      //Task#6
        static void Main6()
        {
            Console.WriteLine("Enter Enter a number with at least two decimal places");
            double n = double.Parse(Console.ReadLine());
            int firstDigit = (int)(n * 10) % 10;
            int secondDigit = (int)(n * 100) % 10;
            Console.WriteLine($"sum of  first two digits after the decimal point = {firstDigit + secondDigit}");
        }
      //Task#7
        static void Main7()
        {
            Console.WriteLine("Enter the current time (in 0-24 format)");
            int h = int.Parse(Console.ReadLine());
            string greeting = (h >= 6 && h <= 11)  ? "Good morning!" : (h >= 12 && h <= 17) ? "Good afternoon!" : (h >= 18 && h <= 22) ? "Good evening!" : "Good night!";
            Console.WriteLine($"{greeting}");
        }
        //Task#8
        enum TestCaseStatus { Pass = 1, Failed = 2, Blocked = 3, WP = 4, Unexecuted = 5 }
        static void Main8()
        {

            TestCaseStatus status = TestCaseStatus.Pass;
            int test1Status = (int)status;
            Console.WriteLine($"Test Case {(int)status} - {status}");
        }
        //Task#9
        struct RGB
        {
            public int red;
            public int green;
            public int blue;

        }
        static void Main9()
        {
            RGB blackcolor = new RGB ();
            {
                blackcolor.red = 0;
                blackcolor.green = 0;
                blackcolor.blue = 0;
            }
            Console.WriteLine($"Black color in RGB is ({blackcolor.red},{blackcolor.green},{blackcolor.blue})");
            RGB whitecolor = new RGB();
            {
                whitecolor.red = 255;
                whitecolor.green = 255;
                whitecolor.blue = 255;
            }
            Console.WriteLine($"White color in RGB is ({whitecolor.red},{whitecolor.green},{whitecolor.blue})");
        }
    }
}
