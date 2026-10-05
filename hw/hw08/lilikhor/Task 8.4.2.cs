using System;
using System.IO;

class Program
{
    static void Main()
    {
        string sourceFile = "data.txt";
        string destinationFile = "rez.txt";

        try
        {
            // Read the entire file at once
            string content = File.ReadAllText(sourceFile);

            // Write the content to another file
            File.WriteAllText(destinationFile, content);

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
            Console.WriteLine("File operation finished.");
        }
    }
}