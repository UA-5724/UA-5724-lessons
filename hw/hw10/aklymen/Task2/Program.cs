using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace hw10.Task2
{
    class Program
    {
        static void Main()
        {

            Console.Write("Enter file name: ");
            string fileName = Console.ReadLine() ?? "text.txt";

            try
            {
                string[] lines = File.ReadAllLines(fileName);


                // Count characters in each line

                Console.WriteLine();
                Console.WriteLine("Number of characters in each line:");

                for (int index = 0; index < lines.Length; index++)
                {
                    Console.WriteLine(
                        $"Line {index + 1}: {lines[index].Length} characters");
                }


                // Find longest line

                string longestLine = lines
                    .OrderByDescending(line => line.Length)
                    .FirstOrDefault();

                if (longestLine != null)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Longest line: {longestLine}");
                    Console.WriteLine($"Length: {longestLine.Length}");
                }


                // Find shortest line

                string shortestLine = lines
                    .OrderBy(line => line.Length)
                    .FirstOrDefault();

                if (shortestLine != null)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Shortest line: {shortestLine}");
                    Console.WriteLine($"Length: {shortestLine.Length}");
                }


                // Find lines containing the word "var"

                Console.WriteLine();
                Console.WriteLine("Lines containing the word 'var':");

                foreach (string line in lines)
                {
                    if (Regex.IsMatch(line, @"\bvar\b"))
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File was not found.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"File error: {ex.Message}");
            }

            Console.WriteLine();
        }
    }
}