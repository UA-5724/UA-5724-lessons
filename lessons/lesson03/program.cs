namespace ConsoleApp1
{
    enum Days { Sun = 5, Mon = 6, Tue = 30, Wed = 40, Thu = 41, Fri = 42, Sat = 16 };

    struct User
    {
        public string Name;
        public int Age;
        public string Email;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            //Console.WriteLine("This is a C# 12.0 feature demonstration.");
            //String name = "Liubomyr";
            //int age = 40;
            //Console.WriteLine($"My name is {name} and I am {age} years old.");
            //Console.WriteLine("My name is {0} and I am {1} years old.", name, age);
            //Console.WriteLine("Currency format: {0:C}", 5555.5812);
            //Console.WriteLine("Datetime format: {0:d}, {0:t}", DateTime.Now);
            //Console.WriteLine("Float format (3 digits after point): {0:F3}", 1234.56789);
            //Console.WriteLine("Float format (3 digits after point): {0:F3}", 1234);
            //Console.WriteLine("Numerical format: {0:N1}", 5555.5812);
            //Console.WriteLine("16-X format: {0:X}", 5555);
            //// Variable names in C# are case-sensitive, so 'a' and 'A' are different variables.
            //// 'a' is a variable with a value of 0, while 'A' is a variable with a value of 10.
            ///* In C#, variable names are case-sensitive, which means that 'a' and 'A' are considered different variables.
            // *  bvkdjs
            //*/
            //int a = 0; // This is a variable named 'a' with a value of 0.
            //int A = 10;
            //Console.WriteLine("a = {0}, A = {1}", a, A);
            //int x = 5;
            //int y = 10;
            //Console.WriteLine("Before swapping: x = {0}, y = {1}", x, y);
            //Console.WriteLine("{0} + {1} = {2}", x, y, x + y);
            //Console.WriteLine("{0} - {1} = {2}", x, y, x - y);
            //byte a = 1;
            //int b = 100;
            //long c = 1000000000;
            //Console.WriteLine(a);
            //Console.WriteLine(b);
            //Console.WriteLine(c);
            //b = (int)c;
            //Console.WriteLine(b);
            //int myA, MyA, mYA;
            //int for_;
            //Console.WriteLine(mYA);

            //int a = 5;
            //Console.WriteLine($"a = {a}");
            //Console.WriteLine($"a++ = {a++}");
            //Console.WriteLine(a);
            //Console.WriteLine($"++a = {++a}");
            //Console.WriteLine(a);

            //a = 3;
            //int b = 7;
            //Console.WriteLine($"b / a = {b / a}");
            //Console.WriteLine($"b % a = {b % a}");

            //int a = int.Parse(Console.ReadLine());

            //string answer = (a < 0) ? "negative" : "positive";
            //Console.WriteLine($"The number is {answer}");
            //answer = (a < 0) ? "negative" : (a > 0) ? "positive" : "zero";
            //Console.WriteLine($"The number is {answer}");
            //Main1();
            //Main2();

            //Days today = Days.Mon;
            //int dayNumber = (int)today;
            //Console.WriteLine("{0} is day number #{1}.", today, dayNumber);

            User user1 = new User();
            user1.Name = "Liubomyr";
            user1.Age = 40;
            user1.Email = "liubomyr@example.com";
            Console.WriteLine(user1.Name);
            Console.WriteLine(user1.Age);
            Console.WriteLine(user1.Email);
            User user2 = new User
            {
                Name = "Alice",
                Age = 30,
                Email = "alice@example.com"
            };
            Console.WriteLine(user2.Name);
            Console.WriteLine(user2.Age);
            Console.WriteLine(user2.Email);
        }
        //static void Main1()
        //{
        //    int a = int.Parse(Console.ReadLine());
        //    string answer = (a < 0) ? "negative" : "positive";
        //    Console.WriteLine($"The number is {answer}");
        //    answer = (a < 0) ? "negative" : (a > 0) ? "positive" : "zero";
        //    Console.WriteLine($"The number is {answer}");
        //}

        //static void Main2()

        //{

        //    int a;
        //    Console.WriteLine("Beenits uncno:");

        //    a = Convert.ToInt32(Console.ReadLine());

        //    Console.WriteLine(a % 2 == 0 ? "Yncno napHe" : "4ucno HenapHe");
        //    Console.ReadLine();
        //}

    }
}








