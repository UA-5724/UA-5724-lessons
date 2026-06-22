namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1️. Arithmetic Operations
            // Read values
            Console.Write("Enter a: ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Enter b: ");
            int b = int.Parse(Console.ReadLine());

            // Arithmetic operations
            int sum = a + b;
            int difference = a - b;
            int product = a * b;
            double quotient = (double)a / b;

            // Output results
            Console.WriteLine($"\na + b = {sum}");
            Console.WriteLine($"a - b = {difference}");
            Console.WriteLine($"a * b = {product}");
            Console.WriteLine($"a / b = {quotient}");

       
            
            // 2. Simple Question
            Console.WriteLine("How are you?");
            string answer = Console.ReadLine();
            Console.WriteLine($"You are {answer}");

            Console.WriteLine();

            
            
            // 3. Working with char
            Console.Write("Enter first character: ");
            char ch1 = char.Parse(Console.ReadLine());

            Console.Write("Enter second character: ");
            char ch2 = char.Parse(Console.ReadLine());

            Console.Write("Enter third character: ");
            char ch3 = char.Parse(Console.ReadLine());

            Console.WriteLine($"You entered {ch1}, {ch2}, {ch3}");

            Console.WriteLine();

            
            
            // 4. Boolean Expression
            Console.Write("Enter first integer: ");
            int num1 = int.Parse(Console.ReadLine());

            Console.Write("Enter second integer: ");
            int num2 = int.Parse(Console.ReadLine());

            bool bothPositive = num1 > 0 && num2 > 0;

            Console.WriteLine($"Both numbers are positive: {bothPositive}");

            Console.WriteLine();

            
            
            // 5. Square Calculations
            Console.Write("Enter the side of the square: ");
            int a1 = int.Parse(Console.ReadLine());

            int area = a1 * a1;
            int perimeter = 4 * a1;

            Console.WriteLine($"Area = {area}");
            Console.WriteLine($"Perimeter = {perimeter}");

            Console.WriteLine();

            
            
            // 6. Name and Age Interaction
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();

            Console.WriteLine($"How old are you, {name}?");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Age: {age}");

            Console.WriteLine();

            
            
            // 7. Circle Calculations
            Console.Write("Enter the radius of the circle: ");
            double r = double.Parse(Console.ReadLine());

            double l = 2 * Math.PI * r;
            double s = Math.PI * r * r;
            double v = (4.0 / 3.0) * Math.PI * r * r * r;

            Console.WriteLine($"Length = {l:F2}");
            Console.WriteLine($"Area = {s:F2}");
            Console.WriteLine($"Volume = {v:F2}");
        }
    }
}
