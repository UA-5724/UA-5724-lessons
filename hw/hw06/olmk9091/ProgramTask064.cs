using System;
class Program
{
    static void Main()
    {
        // create a dictionary
        Dictionary<uint, string> persons = new Dictionary<uint, string>();
        // read 7 ID-name pairs
        for (int i = 0; i < 7; i++)
        {
            uint id = uint.Parse(Console.ReadLine()!);

            string name = Console.ReadLine()!;

            persons.Add(id, name);
        }
        // ask the user to enter an ID
        Console.Write("Enter ID: ");

        uint searchId = uint.Parse(Console.ReadLine()!);
        // check if the ID exists
        if (persons.ContainsKey(searchId))
        {
            // display the corresponding name
            Console.WriteLine(persons[searchId]);
        }
        else
        {
            // display a message if the ID is not found
            Console.WriteLine("ID not found.");
        }
    }
}
