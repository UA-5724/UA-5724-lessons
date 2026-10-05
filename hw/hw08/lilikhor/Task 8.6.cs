using System;
using System.IO;

class Program
{
    static void Main()
    {
        string path = @"D:\";

        try
        {
            // Get only TXT files
            string[] files = Directory.GetFiles(
                path,
                "*.txt",
                SearchOption.TopDirectoryOnly);

            foreach (string file in files)
            {
                Console.WriteLine($"\n=== {file} ===");

                try
                {
                    string content = File.ReadAllText(file);

                    Console.WriteLine(content);
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("Access denied.");
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"Cannot read file: {ex.Message}");
                }
            }
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Error: D:\\ was not found.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Error: access denied.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"File system error: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("\nReading TXT files finished.");
        }
    }
}