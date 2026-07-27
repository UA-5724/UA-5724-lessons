using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Open the source file for reading
            StreamReader reader = new StreamReader("data.txt");

            // Open (or create) the destination file for writing
            StreamWriter writer = new StreamWriter("rez.txt");

            string? line;

            // Read the file line by line
            while ((line = reader.ReadLine()) != null)
            {
                // Write each line into the new file
                writer.WriteLine(line);
            }

            reader.Close();
            writer.Close();

            Console.WriteLine("File copied successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
