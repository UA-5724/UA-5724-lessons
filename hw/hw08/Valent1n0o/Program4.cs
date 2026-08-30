using System;
using System.IO;

namespace hw08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputFile = "data.txt";
            string resultFile1 = "res1.txt";
            string resultFile2 = "res2.txt";

            try
            {
                // Method 1: StreamReader and StreamWriter
                using (StreamReader reader = new StreamReader(inputFile))
                using (StreamWriter writer = new StreamWriter(resultFile1))
                {
                    string? line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        writer.WriteLine(line);
                    }
                }

                Console.WriteLine(
                    "Method 1 completed. Data saved to res1.txt."
                );

                // Method 2: File class
                string text = File.ReadAllText(inputFile);

                File.WriteAllText(resultFile2, text);

                Console.WriteLine(
                    "Method 2 completed. Data saved to res2.txt."
                );
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine(
                    "Error: data.txt was not found."
                );
            }
            catch (IOException ex)
            {
                Console.WriteLine(
                    $"File error: {ex.Message}"
                );
            }
        }
    }
}