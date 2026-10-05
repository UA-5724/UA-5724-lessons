using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        Dictionary<string, string> PhoneBook =
            new Dictionary<string, string>(
                StringComparer.OrdinalIgnoreCase);

        // =========================
        // 7.1 READ PHONEBOOK
        // =========================

        try
        {
            using (StreamReader reader = new StreamReader("phones.txt"))
            {
                for (int i = 0; i < 9; i++)
                {
                    string line = reader.ReadLine();

                    if (string.IsNullOrWhiteSpace(line))
                    {
                        Console.WriteLine(
                            $"Line {i + 1} is empty.");
                        continue;
                    }

                    // Split line into Name and PhoneNumber
                    string[] parts = line.Split(
                        new[] { ' ', '\t' },
                        StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length < 2)
                    {
                        Console.WriteLine(
                            $"Invalid line: {line}");
                        continue;
                    }

                    string name = parts[0];
                    string phone = parts[1];

                    PhoneBook[name] = phone;
                }
            }

            // Save only phone numbers
            using (StreamWriter writer =
                   new StreamWriter("Phones.txt"))
            {
                foreach (string phone in PhoneBook.Values)
                {
                    writer.WriteLine(phone);
                }
            }

            Console.WriteLine(
                "Phone numbers saved to Phones.txt.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine(
                "Error: phones.txt was not found.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Error: access denied.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"File error: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("PhoneBook reading finished.");
        }


        // =========================
        // 7.2 SEARCH BY NAME
        // =========================

        Console.Write("\nEnter a name to search: ");
        string searchName = Console.ReadLine();

        if (PhoneBook.TryGetValue(searchName, out string phoneNumber))
        {
            Console.WriteLine(
                $"Phone number: {phoneNumber}");
        }
        else
        {
            Console.WriteLine("This person is not in PhoneBook.");
        }


        // =========================
        // 7.3 UPDATE PHONE FORMAT
        // =========================

        try
        {
            using (StreamWriter writer =
                   new StreamWriter("New.txt"))
            {
                foreach (KeyValuePair<string, string> pair
                         in PhoneBook)
                {
                    string newPhone = pair.Value;

                    // 80######### -> +380#########
                    if (newPhone.StartsWith("80"))
                    {
                        newPhone = "+380" + newPhone.Substring(2);
                    }

                    writer.WriteLine(
                        $"{pair.Key} {newPhone}");
                }
            }

            Console.WriteLine(
                "Updated phonebook saved to New.txt.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Error: access denied.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"File error: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Phone format update finished.");
        }
    }
}