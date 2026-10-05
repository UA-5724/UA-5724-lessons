string fileName = "input.txt";

if (!File.Exists(fileName))
{
    Console.WriteLine($"File '{fileName}' was not found.");
    return;
}

// Read all lines into an array
string[] lines = File.ReadAllLines(fileName);

Console.WriteLine($"Number of lines: {lines.Length}");
Console.WriteLine();

// Count characters in every line
Console.WriteLine("Characters in each line:");

for (int i = 0; i < lines.Length; i++)
{
    Console.WriteLine($"Line {i + 1}: {lines[i].Length} characters");
}

Console.WriteLine();

// Longest line
string longestLine = lines
    .OrderByDescending(line => line.Length)
    .FirstOrDefault() ?? "";

Console.WriteLine("Longest line:");
Console.WriteLine(longestLine);
Console.WriteLine($"Length: {longestLine.Length}");

Console.WriteLine();

// Shortest line
string shortestLine = lines
    .OrderBy(line => line.Length)
    .FirstOrDefault() ?? "";

Console.WriteLine("Shortest line:");
Console.WriteLine(shortestLine);
Console.WriteLine($"Length: {shortestLine.Length}");

Console.WriteLine();

// Lines containing the word "var"
var varLines = lines
    .Where(line =>
        System.Text.RegularExpressions.Regex.IsMatch(
            line,
            @"\bvar\b"
        ))
    .ToList();

Console.WriteLine("Lines containing the word 'var':");

foreach (string line in varLines)
{
    Console.WriteLine(line);
}
