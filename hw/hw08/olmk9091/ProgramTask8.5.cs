using System;
using System.IO;

class Program
{
    // Write information about a directory and all its contents
    static void WriteDirectoryInfo(string directoryPath, StreamWriter writer)
    {
        try
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);

            // Write information about the current directory
            writer.WriteLine($"Name: {directoryInfo.Name}");
            writer.WriteLine("Type: Directory");
            writer.WriteLine($"Path: {directoryInfo.FullName}");
            writer.WriteLine();

            // Get all files from the current directory
            string[] files = Directory.GetFiles(directoryPath);

            foreach (string filePath in files)
            {
                try
                {
                    // Get information about the current file
                    FileInfo fileInfo = new FileInfo(filePath);

                    writer.WriteLine($"Name: {fileInfo.Name}");
                    writer.WriteLine("Type: File");
                    writer.WriteLine($"Size: {fileInfo.Length} bytes");
                    writer.WriteLine($"Path: {fileInfo.FullName}");
                    writer.WriteLine();
                }
                catch (Exception ex)
                {
                    writer.WriteLine($"Could not read file: {filePath}");
                    writer.WriteLine($"Error: {ex.Message}");
                    writer.WriteLine();
                }
            }

            // Get all subdirectories from the current directory
            string[] subdirectories = Directory.GetDirectories(directoryPath);

            foreach (string subdirectory in subdirectories)
            {
                // Call the same method for every nested directory
                WriteDirectoryInfo(subdirectory, writer);
            }
        }
        catch (UnauthorizedAccessException)
        {
            // Continue working even if access to one directory is denied
            writer.WriteLine($"Access denied: {directoryPath}");
            writer.WriteLine();
        }
        catch (Exception ex)
        {
            writer.WriteLine($"Could not read directory: {directoryPath}");
            writer.WriteLine($"Error: {ex.Message}");
            writer.WriteLine();
        }
    }

    static void Main()
    {
        string rootPath = @"D:\";
        string outputFile = "DirectoryC.txt";

        try
        {
            // Create the output file and start scanning disk D
            using StreamWriter writer = new StreamWriter(outputFile);

            WriteDirectoryInfo(rootPath, writer);

            Console.WriteLine(
                $"Directory information was saved to {outputFile}.");
        }
        catch (DriveNotFoundException)
        {
            Console.WriteLine("Disk D: was not found.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Access to the output file was denied.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
