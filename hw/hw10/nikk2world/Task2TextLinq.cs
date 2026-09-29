using System.Text.RegularExpressions;

// Task 2: Text Processing & LINQ
//
// IEnumerable vs IQueryable:
// - IEnumerable<T> runs LINQ in memory: every Where/Select is a C# delegate
//   executed over objects that are already loaded (like the lines below).
// - IQueryable<T> keeps the query as an expression tree, and a provider
//   (e.g. Entity Framework) translates it into another language such as SQL.
//   Filtering then happens on the database side, and only the result is loaded.
// For an array of strings read from a file IEnumerable is the right choice.

static class Task2TextLinq
{
    // \b is a word boundary: matches "var x", but not "variable" or "invariant"
    private static readonly Regex VarWord = new Regex(@"\bvar\b");

    public static void Run(string inputFile)
    {
        string[] lines;

        try
        {
            lines = File.ReadAllLines(inputFile);
        }
        catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
        {
            Console.WriteLine($"Cannot read {inputFile}: {ex.Message}");
            return;
        }

        if (lines.Length == 0)
        {
            Console.WriteLine("The file is empty.");
            return;
        }

        // 1-2. Number of characters in every line
        Console.WriteLine($"File {inputFile} has {lines.Length} lines:");
        for (int i = 0; i < lines.Length; i++)
        {
            Console.WriteLine($"{i + 1,3}: {lines[i].Length,3} chars");
        }

        // 3. Longest and shortest lines. Empty lines are skipped,
        // otherwise any blank line would always be the shortest one.
        var nonEmpty = lines.Where(l => l.Trim().Length > 0).ToList();

        string longest = nonEmpty.MaxBy(l => l.Length) ?? string.Empty;
        string shortest = nonEmpty.MinBy(l => l.Length) ?? string.Empty;

        Console.WriteLine($"\nLongest line ({longest.Length} chars): {longest.Trim()}");
        Console.WriteLine($"Shortest line ({shortest.Length} chars): {shortest.Trim()}");

        // 4. Lines that contain the word "var" (LINQ + Regex)
        var varLines = lines
            .Select((text, index) => new { Number = index + 1, Text = text })
            .Where(line => VarWord.IsMatch(line.Text))
            .ToList();

        Console.WriteLine($"\nLines with word \"var\" ({varLines.Count}):");
        foreach (var line in varLines)
        {
            Console.WriteLine($"{line.Number,3}: {line.Text.Trim()}");
        }
    }
}
