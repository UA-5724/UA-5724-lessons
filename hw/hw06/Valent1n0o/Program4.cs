using System;
using System.Collections.Generic;

namespace hw06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int personsCount = 7;

            Dictionary<uint, string> persons =
                new Dictionary<uint, string>();

            Console.WriteLine("Enter data for 7 persons:");

            for (int i = 0; i < personsCount; i++)
            {
                Console.WriteLine($"\nPerson {i + 1}");

                uint id;

                while (true)
                {
                    Console.Write("Enter ID: ");

                    if (!uint.TryParse(Console.ReadLine(), out id))
                    {
                        Console.WriteLine(
                            "Invalid ID. Enter a positive integer."
                        );

                        continue;
                    }

                    if (persons.ContainsKey(id))
                    {
                        Console.WriteLine(
                            "This ID already exists. Enter another ID."
                        );

                        continue;
                    }

                    break;
                }

                Console.Write("Enter name: ");
                string name = Console.ReadLine() ?? string.Empty;

                persons.Add(id, name);
            }

            Console.WriteLine("\nAll persons:");

            foreach (KeyValuePair<uint, string> person in persons)
            {
                Console.WriteLine(
                    $"ID: {person.Key}, Name: {person.Value}"
                );
            }

            Console.Write("\nEnter ID to search: ");

            if (!uint.TryParse(Console.ReadLine(), out uint searchId))
            {
                Console.WriteLine("Invalid ID format.");
                return;
            }

            if (persons.TryGetValue(searchId, out string? personName))
            {
                Console.WriteLine($"Person found: {personName}");
            }
            else
            {
                Console.WriteLine("ID not found.");
            }
        }
    }
}