using System;
using System.IO;

class Program
{
    static void Main()
    {
        string path = @"D:\";
        string outputFile = "DirectoryC.txt";

        try
        {
            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                writer.WriteLine("=== DIRECTORIES ===");

                try
                {
                    string[] directories = Directory.GetDirectories(path);

                    foreach (string directory in directories)
                    {
                        DirectoryInfo info = new DirectoryInfo(directory);

                        writer.WriteLine(
                            $"Name: {info.Name} | " +
                            $"Type: Directory");
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    writer.WriteLine("Access denied while reading directories.");
                }

                writer.WriteLine();
                writer.WriteLine("=== FILES ===");

                try
                {
                    string[] files = Directory.GetFiles(path);

                    foreach (string file in files)
                    {
                        FileInfo info = new FileInfo(file);

                        writer.WriteLine(
                            $"Name: {info.Name} | " +
                            $"Type: File | " +
                            $"Size: {info.Length} bytes");
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    writer.WriteLine("Access denied while reading files.");
                }

                Console.WriteLine(
                    $"Directory information saved to {outputFile}.");
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
            Console.WriteLine("Directory operation finished.");
        }
    }
}
