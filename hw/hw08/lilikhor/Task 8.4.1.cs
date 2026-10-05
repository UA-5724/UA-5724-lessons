using System;
using System.IO;

class Program
{
    static void Main()
    {
        string sourceFile = "data.txt";
        string destinationFile = "rez.txt";

        StreamReader reader = null;
        StreamWriter writer = null;

        try
        {
            reader = new StreamReader(sourceFile);
            writer = new StreamWriter(destinationFile);

            string line;

            // Read the source file line by line
            while ((line = reader.ReadLine()) != null)
            {
                writer.WriteLine(line);
            }

            Console.WriteLine("File copied successfully.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error: data.txt was not found.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Error: access denied.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"File error: {ex.Message}");
        }
        finally
        {
            // Always close the files
            reader?.Close();
            writer?.Close();

            Console.WriteLine("File operation finished.");
        }
    }
}