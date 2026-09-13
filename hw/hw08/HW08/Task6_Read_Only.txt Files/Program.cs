using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Path to the Documents folder
        string path = Environment.GetFolderPath(
            Environment.SpecialFolder.MyDocuments);

        try
        {
            // Get all .txt files from the selected folder
            string[] txtFiles = Directory.GetFiles(path, "*.txt");

            if (txtFiles.Length == 0)
            {
                Console.WriteLine("No .txt files were found.");
                return;
            }

            // Print the content of each .txt file
            foreach (string file in txtFiles)
            {
                Console.WriteLine($"File: {Path.GetFileName(file)}");
                Console.WriteLine("--------------------------------");

                string content = File.ReadAllText(file);

                Console.WriteLine(content);
                Console.WriteLine();
            }
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Error: Directory not found.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Error: Access denied.");
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