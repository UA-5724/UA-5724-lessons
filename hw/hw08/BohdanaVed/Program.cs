namespace HW8
{
    internal class Program
    {
        static string diskPath = @"D:\";

        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
            Task6();
            Task7();
        }

        static void Task1()
        {
            Console.WriteLine("Task 1: Division of two integer numbers");

            try
            {
                Console.Write("Enter the first number: ");
                int a = int.Parse(Console.ReadLine());

                Console.Write("Enter the second number: ");
                int b = int.Parse(Console.ReadLine());

                Console.WriteLine("The result of the division is " + Div(a, b));
            }
            catch (DivideByZeroException exception)
            {
                Console.WriteLine("It is impossible to divide by zero: " + exception.Message);
            }
            catch (FormatException exception)
            {
                Console.WriteLine("This is not a whole number: " + exception.Message);
            }
            finally
            {
                Console.WriteLine("Task 1 is finished");
                Console.WriteLine();
            }
        }

        static int Div(int a, int b)
        {
            return a / b;
        }

        static void Task2()
        {
            Console.WriteLine("Task 2: Division of two double numbers");

            try
            {
                Console.Write("Enter the first number: ");
                double a = double.Parse(Console.ReadLine());

                Console.Write("Enter the second number: ");
                double b = double.Parse(Console.ReadLine());

                Console.WriteLine("The result of the division is " + DivDouble(a, b));
            }
            catch (DivisionByZeroException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (FormatException exception)
            {
                Console.WriteLine("This is not a number: " + exception.Message);
            }

            Console.WriteLine();
        }

        static double DivDouble(double a, double b)
        {
            if (b == 0)
            {
                throw new DivisionByZeroException("It is impossible to divide " + a + " by zero");
            }

            return a / b;
        }

        static void Task3()
        {
            Console.WriteLine("Task 3: Ten numbers 1 < a1 < a2 < ... < a10 < 100");

            int[] numbers = new int[10];
            int start = 2;

            for (int i = 0; i < numbers.Length; i++)
            {
                int end = 99 - (numbers.Length - 1 - i);

                while (true)
                {
                    try
                    {
                        Console.Write("Enter the number " + (i + 1) + " from the range [" + start + ".." + end + "]: ");
                        numbers[i] = ReadNumber(start, end);
                        break;
                    }
                    catch (NumberOutOfRangeException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("This is not a whole number");
                    }
                }

                start = numbers[i] + 1;
            }

            Console.WriteLine("The entered numbers: " + string.Join(", ", numbers));
            Console.WriteLine();
        }

        static int ReadNumber(int start, int end)
        {
            int number = int.Parse(Console.ReadLine());

            if (number < start || number > end)
            {
                throw new NumberOutOfRangeException("The number must be from " + start + " to " + end);
            }

            return number;
        }

        static void Task4()
        {
            Console.WriteLine("Task 4: Reading and writing files");

            try
            {
                using (StreamReader reader = new StreamReader("data.txt"))
                using (StreamWriter writer = new StreamWriter("rez.txt"))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        writer.WriteLine(line);
                        line = reader.ReadLine();
                    }
                }

                Console.WriteLine("data.txt was copied to " + Path.GetFullPath("rez.txt") + " with StreamReader and StreamWriter");
            }
            catch (FileNotFoundException exception)
            {
                Console.WriteLine("The file was not found: " + exception.Message);
            }
            catch (IOException exception)
            {
                Console.WriteLine("An error while working with the file: " + exception.Message);
            }

            try
            {
                string text = File.ReadAllText("data.txt");
                File.WriteAllText("rez2.txt", text);

                Console.WriteLine("data.txt was copied to " + Path.GetFullPath("rez2.txt") + " with File.ReadAllText and File.WriteAllText");
            }
            catch (FileNotFoundException exception)
            {
                Console.WriteLine("The file was not found: " + exception.Message);
            }
            catch (IOException exception)
            {
                Console.WriteLine("An error while working with the file: " + exception.Message);
            }

            Console.WriteLine();
        }

        static void Task5()
        {
            Console.WriteLine("Task 5: Information about the files and the directories of " + diskPath);

            try
            {
                List<string> lines = new List<string>();

                foreach (string directory in Directory.GetDirectories(diskPath))
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(directory);
                    lines.Add(directoryInfo.Name + " - directory");
                }

                foreach (string file in Directory.GetFiles(diskPath))
                {
                    FileInfo fileInfo = new FileInfo(file);
                    lines.Add(fileInfo.Name + " - file, size: " + fileInfo.Length + " bytes");
                }

                File.WriteAllLines("DirectoryC.txt", lines);

                Console.WriteLine(lines.Count + " records were saved to " + Path.GetFullPath("DirectoryC.txt"));
            }
            catch (DirectoryNotFoundException exception)
            {
                Console.WriteLine("The directory was not found: " + exception.Message);
            }
            catch (UnauthorizedAccessException exception)
            {
                Console.WriteLine("There is no access to the directory: " + exception.Message);
            }
            catch (IOException exception)
            {
                Console.WriteLine("An error while working with the directory: " + exception.Message);
            }

            Console.WriteLine();
        }

        static void Task6()
        {
            Console.WriteLine("Task 6: The content of the txt files of " + diskPath);

            try
            {
                string[] files = Directory.GetFiles(diskPath, "*.txt");

                if (files.Length == 0)
                {
                    Console.WriteLine("There are no txt files in " + diskPath);
                }

                foreach (string file in files)
                {
                    Console.WriteLine("The file " + file + ":");

                    try
                    {
                        Console.WriteLine(File.ReadAllText(file));
                    }
                    catch (UnauthorizedAccessException exception)
                    {
                        Console.WriteLine("There is no access to the file: " + exception.Message);
                    }
                    catch (IOException exception)
                    {
                        Console.WriteLine("It is impossible to read the file: " + exception.Message);
                    }
                }
            }
            catch (DirectoryNotFoundException exception)
            {
                Console.WriteLine("The directory was not found: " + exception.Message);
            }
            catch (UnauthorizedAccessException exception)
            {
                Console.WriteLine("There is no access to the directory: " + exception.Message);
            }

            Console.WriteLine();
        }

        static void Task7()
        {
            Console.WriteLine("Task 7: PhoneBook");

            Dictionary<string, string> phoneBook = new Dictionary<string, string>();

            try
            {
                string[] lines = File.ReadAllLines("phones.txt");

                foreach (string line in lines)
                {
                    if (phoneBook.Count == 9)
                    {
                        break;
                    }

                    string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length < 2)
                    {
                        continue;
                    }

                    phoneBook[parts[0]] = parts[1];
                }
            }
            catch (FileNotFoundException exception)
            {
                Console.WriteLine("The file was not found: " + exception.Message);
                return;
            }
            catch (IOException exception)
            {
                Console.WriteLine("An error while working with the file: " + exception.Message);
                return;
            }

            Console.WriteLine(phoneBook.Count + " pairs were read from phones.txt");

            try
            {
                File.WriteAllLines("PhonesOnly.txt", phoneBook.Values);
                Console.WriteLine("The phone numbers were saved to " + Path.GetFullPath("PhonesOnly.txt"));
            }
            catch (IOException exception)
            {
                Console.WriteLine("An error while working with the file: " + exception.Message);
            }

            Console.Write("Enter the name you are looking for: ");
            string name = Console.ReadLine();

            if (phoneBook.ContainsKey(name))
            {
                Console.WriteLine("The phone number of " + name + " is " + phoneBook[name]);
            }
            else
            {
                Console.WriteLine("There is no such name in the phone book");
            }

            List<string> newLines = new List<string>();
            foreach (KeyValuePair<string, string> pair in phoneBook)
            {
                string phone = pair.Value;

                if (phone.StartsWith("80"))
                {
                    phone = "+3" + phone;
                }

                newLines.Add(pair.Key + " " + phone);
            }

            try
            {
                File.WriteAllLines("New.txt", newLines);
                Console.WriteLine("The updated phone numbers were saved to " + Path.GetFullPath("New.txt"));
            }
            catch (IOException exception)
            {
                Console.WriteLine("An error while working with the file: " + exception.Message);
            }
        }
    }
}
