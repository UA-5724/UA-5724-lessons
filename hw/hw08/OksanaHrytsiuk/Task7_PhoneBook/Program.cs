using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        Dictionary<string, string> phoneBook =
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        string inputFile = "phones.txt";
        string outputDirectory = "Output";
        string phonesOutputFile = Path.Combine(outputDirectory, "Phones.txt");
        string updatedOutputFile = Path.Combine(outputDirectory, "New.txt");

        try
        {
            // Create a separate directory for result files.
            Directory.CreateDirectory(outputDirectory);

            // Read names and phone numbers from phones.txt.
            string[] lines = File.ReadAllLines(inputFile);

            foreach (string line in lines)
            {
                string[] parts = line.Split(
                    ' ',
                    StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length != 2)
                {
                    Console.WriteLine($"Invalid line: {line}");
                    continue;
                }

                string name = parts[0].Trim();
                string phoneNumber = parts[1].Trim();

                phoneBook[name] = phoneNumber;
            }

            // 7.1: Save only phone numbers into Output/Phones.txt.
            File.WriteAllLines(phonesOutputFile, phoneBook.Values);

            Console.WriteLine("Phone numbers saved successfully.");

            // 7.2: Search for a phone number by name.
            Console.Write("Enter a name: ");
            string nameToSearch = (Console.ReadLine() ?? string.Empty).Trim();

            if (phoneBook.TryGetValue(nameToSearch, out string? foundPhone))
            {
                Console.WriteLine($"Phone number: {foundPhone}");
            }
            else
            {
                Console.WriteLine("Name not found.");
            }

            // 7.3: Update phone-number format and save into Output/New.txt.
            using (StreamWriter writer = new StreamWriter(updatedOutputFile))
            {
                foreach (KeyValuePair<string, string> contact in phoneBook)
                {
                    string updatedPhone = contact.Value;

                    // 80######### -> +380#########
                    if (updatedPhone.StartsWith("80"))
                    {
                        updatedPhone = "+3" + updatedPhone;
                    }

                    writer.WriteLine($"{contact.Key} {updatedPhone}");
                }
            }

            Console.WriteLine("Updated phone book saved successfully.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error: phones.txt was not found.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Error: Access denied.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"I/O Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Program finished.");
        }
    }
}