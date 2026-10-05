using System;
using System.IO;

namespace hw08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = @"C:\";
            string outputFile = "Directory.txt";

            try
            {
                using StreamWriter writer = new StreamWriter(outputFile);

                writer.WriteLine($"Information about {directoryPath}");
                writer.WriteLine();

                string[] directories = Directory.GetDirectories(directoryPath);

                foreach (string directory in directories)
                {
                    DirectoryInfo directoryInfo =
                        new DirectoryInfo(directory);

                    writer.WriteLine(
                        $"Name: {directoryInfo.Name}, Type: Directory"
                    );
                }

                string[] files = Directory.GetFiles(directoryPath);

                foreach (string file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);

                    writer.WriteLine(
                        $"Name: {fileInfo.Name}, " +
                        $"Type: File, " +
                        $"Size: {fileInfo.Length} bytes"
                    );
                }

                Console.WriteLine(
                    "Directory information was saved to Directory.txt."
                );
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine(
                    "Error: Access to the directory is denied."
                );
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine(
                    $"Error: Directory {directoryPath} was not found."
                );
            }
            catch (IOException ex)
            {
                Console.WriteLine(
                    $"File system error: {ex.Message}"
                );
            }
        }
    }
}