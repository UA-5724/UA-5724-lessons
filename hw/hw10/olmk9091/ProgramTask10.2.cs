using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        try
        {
            // Read all lines from the file into an array
            string[] lines = File.ReadAllLines("text.txt");

            // Check if the file is empty
            if (lines.Length == 0)
            {
                Console.WriteLine("The file is empty.");
                return;
            }

            Console.WriteLine("Number of characters in each line:");

            // Display each line and its number of characters
            foreach (string line in lines)
            {
                Console.WriteLine(
                    $"{line} -> {line.Length} characters");
            }

            // Find the longest line using LINQ
            string longestLine = lines
                .OrderByDescending(line => line.Length)
                .First();

            // Find the shortest line using LINQ
            string shortestLine = lines
                .OrderBy(line => line.Length)
                .First();

            Console.WriteLine("\nLongest line:");
            Console.WriteLine(longestLine);

            Console.WriteLine("\nShortest line:");
            Console.WriteLine(shortestLine);

            // Find lines that contain the whole word "var"
            var linesWithVar = lines
                .Where(line =>
                    Regex.IsMatch(line, @"\bvar\b"));

            Console.WriteLine("\nLines containing the word 'var':");

            // Display all matching lines
            foreach (string line in linesWithVar)
            {
                Console.WriteLine(line);
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error: text.txt was not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}