using System;
using System.IO;

namespace hw08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = @"C:\Users\vmurad\source\repos\ConsoleApp9\ConsoleApp9\bin\Debug\net8.0\";

            try
            {
                string[] textFiles =
                    Directory.GetFiles(directoryPath, "*.txt");

                if (textFiles.Length == 0)
                {
                    Console.WriteLine(
                        $"No .txt files found in {directoryPath}"
                    );

                    return;
                }

                foreach (string file in textFiles)
                {
                    Console.WriteLine(
                        $"\n===== {Path.GetFileName(file)} ====="
                    );

                    try
                    {
                        string content = File.ReadAllText(file);

                        Console.WriteLine(content);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        Console.WriteLine(
                            $"Access denied: {file}"
                        );
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine(
                            $"Cannot read file: {ex.Message}"
                        );
                    }
                }
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine(
                    $"Directory {directoryPath} was not found."
                );
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine(
                    $"Access to {directoryPath} is denied."
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