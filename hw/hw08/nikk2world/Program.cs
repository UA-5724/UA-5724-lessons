using System.Globalization;
using System.Text.RegularExpressions;

class Program
{
    // Input files live in Data/, results are written to Output/.
    // Separate folders are needed because Windows file names are case-insensitive:
    // "phones.txt" (input) and "Phones.txt" (output) would be the same file otherwise.
    const string DataDir = "Data";
    const string OutputDir = "Output";
    const string DefaultDisk = @"D:\";

    static void Main()
    {
        Directory.CreateDirectory(OutputDir);

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("1 - Division of int numbers (Div)");
            Console.WriteLine("2 - Division of double numbers with custom exception");
            Console.WriteLine("3 - Read 10 numbers 1 < a1 < ... < a10 < 100");
            Console.WriteLine("4 - Copy data.txt to rez.txt");
            Console.WriteLine("5 - Directory information to DirectoryC.txt");
            Console.WriteLine("6 - Print content of .txt files");
            Console.WriteLine("7 - PhoneBook");
            Console.WriteLine("0 - Exit");
            Console.Write("Choose task: ");

            string? choice = Console.ReadLine();

            // End of input stream (e.g. input redirected from a file)
            if (choice is null || choice.Trim() == "0")
                return;

            Console.WriteLine();

            switch (choice.Trim())
            {
                case "1": Task1(); break;
                case "2": Task2(); break;
                case "3": Task3(); break;
                case "4": Task4(); break;
                case "5": Task5(); break;
                case "6": Task6(); break;
                case "7": Task7(); break;
                default:
                    Console.WriteLine("Unknown task number.");
                    break;
            }
        }
    }

    // ---------- Task 1 ----------

    static int Div(int a, int b)
    {
        // Integer division by zero throws DivideByZeroException automatically
        return a / b;
    }

    static void Task1()
    {
        try
        {
            Console.Write("Enter a: ");
            int a = int.Parse(Console.ReadLine() ?? string.Empty);

            Console.Write("Enter b: ");
            int b = int.Parse(Console.ReadLine() ?? string.Empty);

            Console.WriteLine($"{a} / {b} = {Div(a, b)}");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Error: division by zero.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: invalid number format.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Error: number is too big or too small for int.");
        }
    }

    // ---------- Task 2 ----------

    static double DivDouble(double a, double b)
    {
        // Double division by zero does not throw (it returns Infinity or NaN),
        // so the exception is thrown explicitly
        if (b == 0)
            throw new DivisionByZeroException("Division by zero is not allowed.");

        return a / b;
    }

    static void Task2()
    {
        try
        {
            double a = ParseDouble("Enter a: ");
            double b = ParseDouble("Enter b: ");

            Console.WriteLine($"{a} / {b} = {DivDouble(a, b)}");
        }
        catch (DivisionByZeroException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: invalid number format.");
        }
    }

    static double ParseDouble(string message)
    {
        Console.Write(message);
        string input = (Console.ReadLine() ?? string.Empty).Replace(',', '.');

        // Throws FormatException if the input is not a number
        return double.Parse(input, NumberStyles.Float, CultureInfo.InvariantCulture);
    }

    // ---------- Task 3 ----------

    static int ReadNumber(int start, int end)
    {
        string input = (Console.ReadLine() ?? string.Empty).Trim();

        if (!int.TryParse(input, out int number))
            throw new NotANumberException(input);

        if (number < start || number > end)
            throw new NumberOutOfRangeException(number, start, end);

        return number;
    }

    static void Task3()
    {
        const int count = 10;
        int[] numbers = new int[count];
        int previous = 1;

        for (int i = 0; i < count; i++)
        {
            // Every next number must be greater than the previous one
            // and leave enough room for the remaining numbers below 100
            int start = previous + 1;
            int end = 99 - (count - 1 - i);

            while (true)
            {
                Console.Write($"Enter a{i + 1} in range [{start}...{end}]: ");

                try
                {
                    numbers[i] = ReadNumber(start, end);
                    break;
                }
                catch (NotANumberException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (NumberOutOfRangeException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            previous = numbers[i];
        }

        Console.WriteLine($"Numbers: {string.Join(" < ", numbers)}");
    }

    // ---------- Task 4 ----------

    static void Task4()
    {
        string source = Path.Combine(DataDir, "data.txt");
        string target = Path.Combine(OutputDir, "rez.txt");

        Console.WriteLine("4.1 StreamReader / StreamWriter:");
        CopyWithStreams(source, target);

        Console.WriteLine("4.2 File.ReadAllText / File.WriteAllText:");
        CopyWithFile(source, target);
    }

    static void CopyWithStreams(string source, string target)
    {
        StreamReader? reader = null;
        StreamWriter? writer = null;

        try
        {
            reader = new StreamReader(source);
            writer = new StreamWriter(target);

            string? line;
            int lines = 0;

            // Read and write line by line
            while ((line = reader.ReadLine()) != null)
            {
                writer.WriteLine(line);
                lines++;
            }

            Console.WriteLine($"Copied {lines} lines to {target}");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Error: file {source} not found.");
        }
        catch (DirectoryNotFoundException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"Error: access denied. {ex.Message}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"I/O error: {ex.Message}");
        }
        finally
        {
            // Streams are closed even if an exception occurred
            reader?.Dispose();
            writer?.Dispose();
        }
    }

    static void CopyWithFile(string source, string target)
    {
        try
        {
            string text = File.ReadAllText(source);
            File.WriteAllText(target, text);

            Console.WriteLine($"Copied {text.Length} characters to {target}");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Error: file {source} not found.");
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"Error: access denied. {ex.Message}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"I/O error: {ex.Message}");
        }
    }

    // ---------- Task 5 ----------

    static string ReadRootPath()
    {
        Console.Write($"Enter path (press Enter for {DefaultDisk}): ");
        string input = (Console.ReadLine() ?? string.Empty).Trim();

        return input.Length == 0 ? DefaultDisk : input;
    }

    static void Task5()
    {
        string root = ReadRootPath();
        string target = Path.Combine(OutputDir, "DirectoryC.txt");

        if (!Directory.Exists(root))
        {
            Console.WriteLine($"Error: directory {root} does not exist.");
            return;
        }

        try
        {
            using StreamWriter writer = new StreamWriter(target);

            int total = WriteDirectoryInfo(root, writer);

            Console.WriteLine($"Information about {total} items saved to {target}");
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"Error: access denied. {ex.Message}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"I/O error: {ex.Message}");
        }
    }

    // Walks the directory tree and returns the number of written items.
    // Folders without access are skipped, so one protected folder
    // (e.g. "System Volume Information") does not stop the whole scan.
    static int WriteDirectoryInfo(string directory, StreamWriter writer)
    {
        int count = 0;
        string[] files;
        string[] directories;

        try
        {
            files = Directory.GetFiles(directory);
            directories = Directory.GetDirectories(directory);
        }
        catch (UnauthorizedAccessException)
        {
            writer.WriteLine($"{directory} | Directory | access denied");
            return 0;
        }
        catch (IOException ex)
        {
            writer.WriteLine($"{directory} | Directory | error: {ex.Message}");
            return 0;
        }

        foreach (string file in files)
        {
            try
            {
                long size = new FileInfo(file).Length;
                writer.WriteLine($"{file} | File | {size} bytes");
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                writer.WriteLine($"{file} | File | size unavailable");
            }

            count++;
        }

        foreach (string subdirectory in directories)
        {
            writer.WriteLine($"{subdirectory} | Directory |");
            count++;
            count += WriteDirectoryInfo(subdirectory, writer);
        }

        return count;
    }

    // ---------- Task 6 ----------

    static void Task6()
    {
        string root = ReadRootPath();

        string[] txtFiles;

        try
        {
            // Only .txt files from the root folder of the disk
            txtFiles = Directory.GetFiles(root, "*.txt");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine($"Error: directory {root} does not exist.");
            return;
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"Error: access denied. {ex.Message}");
            return;
        }
        catch (IOException ex)
        {
            Console.WriteLine($"I/O error: {ex.Message}");
            return;
        }

        if (txtFiles.Length == 0)
        {
            Console.WriteLine($"No .txt files found in {root}");
            return;
        }

        foreach (string file in txtFiles)
        {
            Console.WriteLine($"----- {file} -----");

            try
            {
                Console.WriteLine(File.ReadAllText(file));
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                Console.WriteLine($"Cannot read file: {ex.Message}");
            }
        }
    }

    // ---------- Task 7 ----------

    static void Task7()
    {
        Dictionary<string, string> phoneBook;

        // 7.1 Read pairs from phones.txt and save only numbers to Phones.txt
        try
        {
            phoneBook = ReadPhoneBook(Path.Combine(DataDir, "phones.txt"), 9);

            string phonesFile = Path.Combine(OutputDir, "Phones.txt");
            File.WriteAllLines(phonesFile, phoneBook.Values);

            Console.WriteLine($"Read {phoneBook.Count} records. Phone numbers saved to {phonesFile}");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error: file phones.txt not found.");
            return;
        }
        catch (IOException ex)
        {
            Console.WriteLine($"I/O error: {ex.Message}");
            return;
        }

        foreach (var pair in phoneBook)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }

        // 7.2 Search by name
        Console.Write("\nEnter name: ");
        string name = (Console.ReadLine() ?? string.Empty).Trim();

        if (phoneBook.TryGetValue(name, out string? phone))
            Console.WriteLine($"Phone number: {phone}");
        else
            Console.WriteLine($"Name \"{name}\" not found.");

        // 7.3 Change format 80######### -> +380#########
        var updated = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        foreach (var pair in phoneBook)
        {
            updated[pair.Key] = Regex.Replace(pair.Value, @"^80(\d{9})$", "+380$1");
        }

        try
        {
            string newFile = Path.Combine(OutputDir, "New.txt");
            File.WriteAllLines(newFile, updated.Select(p => $"{p.Key};{p.Value}"));

            Console.WriteLine($"\nUpdated phone book saved to {newFile}:");
            foreach (var pair in updated)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"I/O error: {ex.Message}");
        }
    }

    // Reads up to maxCount lines in format "Name;Phone"
    static Dictionary<string, string> ReadPhoneBook(string path, int maxCount)
    {
        // Name search should not depend on letter case
        var phoneBook = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        using StreamReader reader = new StreamReader(path);

        string? line;
        int lineNumber = 0;

        while (phoneBook.Count < maxCount && (line = reader.ReadLine()) != null)
        {
            lineNumber++;

            string[] parts = line.Split(';');

            if (parts.Length != 2 || parts[0].Trim().Length == 0 || parts[1].Trim().Length == 0)
            {
                Console.WriteLine($"Line {lineNumber} skipped: wrong format \"{line}\"");
                continue;
            }

            phoneBook[parts[0].Trim()] = parts[1].Trim();
        }

        return phoneBook;
    }
}
