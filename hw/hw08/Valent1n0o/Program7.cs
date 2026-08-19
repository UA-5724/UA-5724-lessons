using System;
using System.Collections.Generic;
using System.IO;

namespace hw08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputFile = "phones.txt";
            string phonesOnlyFile = "Phones.txt";
            string updatedFile = "New.txt";

            Dictionary<string, string> PhoneBook =
                new Dictionary<string, string>();

            try
            {
                string[] lines = File.ReadAllLines(inputFile);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(
                        new[] { ' ', '\t' },
                        2,
                        StringSplitOptions.RemoveEmptyEntries
                    );

                    if (parts.Length == 2)
                    {
                        string name = parts[0];
                        string phone = parts[1];

                        PhoneBook[name] = phone;
                    }
                }

                using (StreamWriter writer =
                       new StreamWriter(phonesOnlyFile))
                {
                    foreach (string phone in PhoneBook.Values)
                    {
                        writer.WriteLine(phone);
                    }
                }

                Console.Write("Enter name to search: ");
                string searchName =
                    Console.ReadLine() ?? string.Empty;

                if (PhoneBook.TryGetValue(
                        searchName,
                        out string? phoneNumber))
                {
                    Console.WriteLine(
                        $"Phone number: {phoneNumber}"
                    );
                }
                else
                {
                    Console.WriteLine("Name not found.");
                }

                Dictionary<string, string> updatedPhoneBook =
                    new Dictionary<string, string>();

                foreach (KeyValuePair<string, string> person
                         in PhoneBook)
                {
                    string updatedPhone =
                        UpdatePhoneFormat(person.Value);

                    updatedPhoneBook[person.Key] =
                        updatedPhone;
                }

                using (StreamWriter writer =
                       new StreamWriter(updatedFile))
                {
                    foreach (KeyValuePair<string, string> person
                             in updatedPhoneBook)
                    {
                        writer.WriteLine(
                            $"{person.Key} {person.Value}"
                        );
                    }
                }

                Console.WriteLine(
                    "Updated phone book saved to New.txt."
                );
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine(
                    "Error: phones.txt was not found."
                );
            }
            catch (IOException ex)
            {
                Console.WriteLine(
                    $"File error: {ex.Message}"
                );
            }
        }

        static string UpdatePhoneFormat(string phone)
        {
            string digits = phone
                .Replace("+", "")
                .Replace("-", "")
                .Replace("(", "")
                .Replace(")", "")
                .Replace(" ", "");

            if (digits.Length == 10)
            {
                return $"+38{digits}";
            }

            if (digits.Length == 12 &&
                digits.StartsWith("38"))
            {
                return $"+{digits}";
            }

            return phone;
        }
    }
}