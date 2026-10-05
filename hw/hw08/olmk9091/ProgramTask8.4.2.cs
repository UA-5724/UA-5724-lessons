using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Read the entire file into one string
            string text = File.ReadAllText("data.txt");

            // Write the entire string into another file
            File.WriteAllText("rez.txt", text);

            Console.WriteLine("File copied successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
