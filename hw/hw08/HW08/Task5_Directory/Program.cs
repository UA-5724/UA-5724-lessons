using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Path to the disk
        string path = @"C:\";
        string outputFile = "DirectoryC.txt";

        try
        {
            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                // Get all directories
                foreach (string directory in Directory.GetDirectories(path))
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(directory);

                    writer.WriteLine($"Name: {dirInfo.Name}");
                    writer.WriteLine("Type: Directory");
                    writer.WriteLine();
                }

                // Get all files
                foreach (string file in Directory.GetFiles(path))
                {
                    FileInfo fileInfo = new FileInfo(file);

                    writer.WriteLine($"Name: {fileInfo.Name}");
                    writer.WriteLine("Type: File");
                    writer.WriteLine($"Size: {fileInfo.Length} bytes");
                    writer.WriteLine();
                }
            }

            Console.WriteLine("Directory information saved successfully.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Error: Access denied.");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Error: Directory not found.");
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