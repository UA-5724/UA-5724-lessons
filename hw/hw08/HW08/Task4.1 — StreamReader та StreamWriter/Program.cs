using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Open files for reading and writing
            using (StreamReader reader = new StreamReader("data.txt"))
            using (StreamWriter writer = new StreamWriter("rez.txt"))
            {
                string line;

                // Read file line by line
                while ((line = reader.ReadLine()) != null)
                {
                    writer.WriteLine(line);
                }
            }

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