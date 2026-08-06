using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Read the entire content of the file
            string content = File.ReadAllText("data.txt");

            // Write the content into another file
            File.WriteAllText("rez.txt", content);

            Console.WriteLine("File copied successfully.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error: data.txt was not found.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"I/O Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Program finished.");
        }
    }
}