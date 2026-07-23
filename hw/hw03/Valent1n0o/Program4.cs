using System;

namespace hw3
{
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

    internal class Program
    {
        static void Main(string[] args)
        {
            Dog myDog;

            Console.Write("Enter dog name: ");
            myDog.name = Console.ReadLine();

            Console.Write("Enter dog mark: ");
            myDog.mark = Console.ReadLine();

            Console.Write("Enter dog age: ");
            myDog.age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(myDog.ToString());

            Console.ReadKey();
        }
    }
}