using System;
class Program
{static void Main()
    {
        //1 Arithmetic Operations
        //read first number
        int a = int.Parse(Console.ReadLine()!);
        // read second number
        int b = int.Parse(Console.ReadLine()!);
        //show results
        Console.WriteLine(a + b);
        Console.WriteLine(a - b);
        Console.WriteLine(a * b);
        // check zero
        if (b != 0)
        {
            Console.WriteLine(a / b);
        }
        else
        {
            Console.WriteLine("Cannot divide by zero");
        }
        ////2 Simple Question

        ////write a question
        //Console.WriteLine("How are you?");
        ////read user's answer
        //string answer = Console.ReadLine()!;
        ////show result
        //Console.WriteLine("You are " + answer);

        ////3. Working with char

        ////after user type string(text) convert text into a single character, store in the variable first, second, third
        //char first = char.Parse(Console.ReadLine()!);
        //char second = char.Parse(Console.ReadLine()!);
        //char third = char.Parse(Console.ReadLine()!);
        ////displays the values stored in the variables
        //Console.WriteLine("You entered " + first + ", " + second + ", " + third);

        ////4. Boolean Expression

        ////read first number
        //int c = int.Parse(Console.ReadLine()!);
        ////read second number
        //int d = int.Parse(Console.ReadLine()!);
        ////verify conditions
        //bool bothPositive = c > 0 && d > 0;
        ////show results
        //Console.WriteLine(bothPositive);

        ////5. Square Calculations

        ////read entered data
        //int e = int.Parse(Console.ReadLine()!);
        ////calculate area
        //int area = e * e;
        ////calculate perimeter
        //int perimeter = 4 * e;
        ////show results
        //Console.WriteLine(area);
        //Console.WriteLine(perimeter);

        ////6. Name and Age Interaction

        ////declare a value
        //string name;
        //int age;
        //// show the question
        //Console.WriteLine("What is your name?");
        ////read the name
        //name = Console.ReadLine()!;
        //// show the question
        //Console.WriteLine("How old are you, " + name + "?");
        ////read the age
        //age = int.Parse(Console.ReadLine()!);
        ////show results
        //Console.WriteLine("Name: " + name);
        //Console.WriteLine("Age: " + age);

        ////7. Circle Calculations

        ////read the entered data about radius
        //double r = double.Parse(Console.ReadLine()!);
        ////calculate the circle length
        //double l = 2 * Math.PI * r;
        ////calculate the circle area
        //double s = Math.PI * r * r;
        ////calculate ball area
        //double v = 4.0 / 3 * Math.PI * r * r * r;
        ////show results
        //Console.WriteLine(l);
        //Console.WriteLine(s);
        //Console.WriteLine(v);
    }
}
