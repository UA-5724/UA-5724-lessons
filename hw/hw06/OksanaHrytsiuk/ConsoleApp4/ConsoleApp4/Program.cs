using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<uint, string> persons = new Dictionary<uint, string>();

        Console.WriteLine("Enter 7 pairs (ID Name):");

        for (int i = 0; i < 7; i++)
        {
            Console.Write("ID: ");
            uint id = uint.Parse(Console.ReadLine());

            Console.Write("Name: ");
            string name = Console.ReadLine();

            persons.Add(id, name);
        }

        Console.Write("\nEnter ID to search: ");
        uint searchId = uint.Parse(Console.ReadLine());

        if (persons.ContainsKey(searchId))
        {
            Console.WriteLine("Name: " + persons[searchId]);
        }
        else
        {
            Console.WriteLine("ID not found.");
        }

        Console.ReadKey();
    }
}
