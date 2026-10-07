class Program
{
    static void Main()
    {
        // 1. Division with Exception Handling

        try
        {
            Console.Write("Enter first integer: ");
            int firstNumber = int.Parse(Console.ReadLine());

            Console.Write("Enter second integer: ");
            int secondNumber = int.Parse(Console.ReadLine());

            int result = Div(firstNumber, secondNumber);

            Console.WriteLine($"Result: {result}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input!");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Cannot divide by zero!");
        }
        finally
        {
            Console.WriteLine("Division finished.");
        }

        Console.WriteLine();


        // 2. Throwing Custom Exception

        try
        {
            Console.Write("Enter first double number: ");
            double firstDouble = double.Parse(Console.ReadLine());

            Console.Write("Enter second double number: ");
            double secondDouble = double.Parse(Console.ReadLine());

            double result = DivideDouble(firstDouble, secondDouble);

            Console.WriteLine($"Result: {result}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input!");
        }
        catch (DivisionException ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("Double division finished.");
        }

        Console.WriteLine();


        // 3. Validate Input Range

        int[] numbers = new int[10];

        for (int index = 0; index < 10; index++)
        {
            while (true)
            {
                try
                {
                    int start;

                    if (index == 0)
                    {
                        start = 2;
                    }
                    else
                    {
                        start = numbers[index - 1] + 1;
                    }

                    numbers[index] = ReadNumber(start, 99);

                    break;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        Console.WriteLine();
        Console.WriteLine("Numbers:");

        foreach (int number in numbers)
        {
            Console.Write(number + " ");
        }

        Console.WriteLine();
        Console.WriteLine();


        // 4. File Read & Write

        // 4.1 StreamReader and StreamWriter

        try
        {
            using (StreamReader reader = new StreamReader("data.txt"))
            using (StreamWriter writer = new StreamWriter("rez.txt"))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    writer.WriteLine(line);
                }
            }

            Console.WriteLine("Data was copied to rez.txt.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("data.txt was not found.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Access denied.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"File error: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("File copying finished.");
        }


        // 4.2 File.WriteAllText

        try
        {
            string text = File.ReadAllText("data.txt");

            File.WriteAllText("rez.txt", text);

            Console.WriteLine("Data was copied using File.WriteAllText.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("data.txt was not found.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Access denied.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"File error: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("File task finished.");
        }

        Console.WriteLine();


        // 5. Directory Information

        try
        {
            using (StreamWriter writer = new StreamWriter("DirectoryC.txt"))
            {
                string[] directories = Directory.GetDirectories(
                    @"D:\",
                    "*",
                    SearchOption.AllDirectories);

                string[] files = Directory.GetFiles(
                    @"D:\",
                    "*",
                    SearchOption.AllDirectories);

                foreach (string directory in directories)
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(directory);

                    writer.WriteLine(
                        $"Name: {directoryInfo.Name}, Type: Directory");
                }

                foreach (string file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);

                    writer.WriteLine(
                        $"Name: {fileInfo.Name}, Type: File, Size: {fileInfo.Length} bytes");
                }
            }

            Console.WriteLine("Directory information saved to DirectoryC.txt.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Access denied.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Directory error: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Directory task finished.");
        }

        Console.WriteLine();


        // 6. Read Only .txt Files

        try
        {
            string[] txtFiles = Directory.GetFiles(
                @"D:\",
                "*.txt",
                SearchOption.AllDirectories);

            foreach (string file in txtFiles)
            {
                Console.WriteLine();
                Console.WriteLine($"File: {file}");

                string text = File.ReadAllText(file);

                Console.WriteLine(text);
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Access denied.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"File error: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("TXT file task finished.");
        }

        Console.WriteLine();


        // 7. PhoneBook with Dictionary

        Dictionary<string, string> PhoneBook =
            new Dictionary<string, string>();


        // 7.1 Read & Write

        try
        {
            using (StreamReader reader = new StreamReader("phones.txt"))
            {
                for (int index = 0; index < 9; index++)
                {
                    string line = reader.ReadLine();

                    if (line == null)
                    {
                        break;
                    }

                    string[] parts = line.Split(' ');

                    if (parts.Length >= 2)
                    {
                        string name = parts[0];
                        string phoneNumber = parts[1];

                        PhoneBook[name] = phoneNumber;
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter("Phones.txt"))
            {
                foreach (string phoneNumber in PhoneBook.Values)
                {
                    writer.WriteLine(phoneNumber);
                }
            }

            Console.WriteLine("Phone numbers saved to Phones.txt.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("phones.txt was not found.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Access denied.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"File error: {ex.Message}");
        }


        // 7.2 Search

        Console.WriteLine();
        Console.Write("Enter name: ");
        string searchName = Console.ReadLine() ?? "";

        if (PhoneBook.ContainsKey(searchName))
        {
            Console.WriteLine($"Phone: {PhoneBook[searchName]}");
        }
        else
        {
            Console.WriteLine("Name not found.");
        }


        // 7.3 Format Update

        try
        {
            using (StreamWriter writer = new StreamWriter("New.txt"))
            {
                foreach (KeyValuePair<string, string> person in PhoneBook)
                {
                    string phoneNumber = person.Value;

                    if (phoneNumber.StartsWith("80"))
                    {
                        phoneNumber = "+380" + phoneNumber.Substring(2);
                    }

                    writer.WriteLine($"{person.Key} {phoneNumber}");
                }
            }

            Console.WriteLine("Updated phone numbers saved to New.txt.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Access denied.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"File error: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("PhoneBook task finished.");
        }
    }


    // 1. Div

    static int Div(int firstNumber, int secondNumber)
    {
        return firstNumber / secondNumber;
    }


    // 2. Divide double numbers

    static double DivideDouble(double firstNumber, double secondNumber)
    {
        if (secondNumber == 0)
        {
            throw new DivisionException("Cannot divide by zero!");
        }

        return firstNumber / secondNumber;
    }


    // 3. Read number in range

    static int ReadNumber(int start, int end)
    {
        Console.Write($"Enter number from {start} to {end}: ");

        int number = int.Parse(Console.ReadLine());

        if (number < start || number > end)
        {
            throw new ArgumentOutOfRangeException(
                $"Number must be between {start} and {end}!");
        }

        return number;
    }
}


// Custom Exception

class DivisionException : Exception
{
    public DivisionException(string message)
        : base(message)
    {
    }
}