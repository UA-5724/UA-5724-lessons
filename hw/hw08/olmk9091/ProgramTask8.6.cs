using System;
using System.IO;

class Program
{
    // Read all .txt files from the current directory
    // and then process all nested directories
    static void ReadTextFiles(string directoryPath)
    {
        try
        {
            // Get all files from the current directory
            string[] files = Directory.GetFiles(directoryPath);

            foreach (string file in files)
            {
                // Process only .txt files
                if (file.EndsWith(
                    ".txt",
                    StringComparison.OrdinalIgnoreCase)) // fineds notes.txt and NOTES.TXT
                {
                    try
                    {
                        Console.WriteLine($"File: {file}");

                        // Read the entire file
                        string text = File.ReadAllText(file);

                        // Display the file content
                        Console.WriteLine(text);

                        // Separate the content of different files
                        Console.WriteLine("----------------------");
                    }
                    catch (UnauthorizedAccessException)
                    {
                        // Continue if access to this file is denied
                        Console.WriteLine($"Access denied to file: {file}");
                    }
                    catch (Exception ex)
                    {
                        // Continue if another error occurs while reading the file
                        Console.WriteLine(
                            $"Could not read file: {file}");

                        Console.WriteLine(
                            $"Error: {ex.Message}");
                    }
                }
            }

            // Get all nested directories
            string[] subdirectories =
                Directory.GetDirectories(directoryPath);

            foreach (string subdirectory in subdirectories)
            {
                // Call the same method for each nested directory
                ReadTextFiles(subdirectory);
            }
        }
        catch (UnauthorizedAccessException)
        {
            // Skip this directory and continue with other directories
            Console.WriteLine(
                $"Access denied to directory: {directoryPath}");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine(
                $"Directory not found: {directoryPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                $"Could not process directory: {directoryPath}");

            Console.WriteLine(
                $"Error: {ex.Message}");
        }
    }

    static void Main()
    {
        string rootDirectory = @"D:\";

        try
        {
            // Check whether disk D exists
            if (!Directory.Exists(rootDirectory))
            {
                Console.WriteLine("Disk D: was not found.");
                return;
            }

            // Start the recursive search from disk D
            ReadTextFiles(rootDirectory);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }
}
