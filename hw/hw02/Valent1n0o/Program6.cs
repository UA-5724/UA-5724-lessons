using System;

namespace hw2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name;
            int age;

            Console.WriteLine("What is your name?");
            name = Console.ReadLine();

            Console.WriteLine($"How old are you, {name}?");
            age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Name: " + name);
            Console.WriteLine("Age: " + age);

            Console.ReadKey();
        }
    }
}