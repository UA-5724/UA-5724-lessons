using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        // Store names and phone numbers as key-value pairs
        Dictionary<string, string> PhoneBook =
            new Dictionary<string, string>();

        try
        {
            // Read all lines from the source file
            string[] lines = File.ReadAllLines("phones.txt");

            // Read exactly 9 name-phone pairs
            for (int i = 0; i < 9; i++)
            {
                // Split each line into name and phone number
                string[] parts = lines[i].Split(
                    ' ',
                    StringSplitOptions.RemoveEmptyEntries);

                // Check that the line contains both name and phone number
                if (parts.Length < 2)
                {
                    throw new FormatException(
                        $"Invalid format in line {i + 1}.");
                }

                string name = parts[0];
                string phoneNumber = parts[1];

                // Add the pair to the phone book
                PhoneBook.Add(name, phoneNumber);
            }

            // Save only phone numbers into Phones.txt
            File.WriteAllLines(
                "Phones.txt",
                PhoneBook.Values);

            Console.WriteLine(
                "Phone numbers were saved to Phones.txt.");

            // Ask the user to enter a name
            Console.Write("\nEnter name: ");
            string searchName = Console.ReadLine() ?? "";

            // Search for the phone number by name
            if (PhoneBook.ContainsKey(searchName))
            {
                Console.WriteLine(
                    $"Phone number: {PhoneBook[searchName]}");
            }
            else
            {
                Console.WriteLine("Name not found.");
            }

            // Store updated name-phone pairs
            List<string> updatedData = new List<string>();

            foreach (KeyValuePair<string, string> entry in PhoneBook)
            {
                string phone = entry.Value;
                string updatedPhone = phone;

                // Replace the starting 80 with +380
                if (phone.StartsWith("80"))
                {
                    updatedPhone = "+380" + phone.Substring(2);
                }

                // Save the updated pair as one line
                updatedData.Add(
                    $"{entry.Key} {updatedPhone}");
            }

            // Save updated phone book into New.txt
            File.WriteAllLines(
                "New.txt",
                updatedData);

            Console.WriteLine(
                "Updated phone book was saved to New.txt.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine(
                "Error: phones.txt was not found.");
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine(
                "Error: phones.txt contains fewer than 9 lines.");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Format error: {ex.Message}");
        }
        catch (ArgumentException)
        {
            Console.WriteLine(
                "Error: duplicate names are not allowed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
