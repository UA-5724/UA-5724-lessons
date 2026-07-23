namespace ConsoleApp1
{
    internal class Program
    {

        class ReadConsoleException : Exception
        {
            public ReadConsoleException(string message) : base(message)
            {
            }
        }
        class ReadConsole
        {
            public static int ReadInts(string prompt)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();
                try
                {
                    int result = int.Parse(input);
                    if (result == 0)
                    {
                        throw new ReadConsoleException("Zero is not allowed.");
                    }
                    return result;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                    return ReadInts(prompt);
                }
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.Message);
                //    Console.WriteLine(ex.StackTrace);
                //    return ReadInts(prompt);
                //}
            }
        }
        static void Main(string[] args)
        {
            int a;
            int b;

            //try
            //{
            //    Console.WriteLine("Enter a=");
            //    a = int.Parse(Console.ReadLine());
            //    Console.WriteLine("Enter b=");
            //    b = int.Parse(Console.ReadLine());
            //    int c = a / b;
            //    Console.WriteLine($"c = {c}");
            //}

            //catch (DivideByZeroException err)
            //{
            //    Console.WriteLine($"Error: Division by zero is not allowed. {err.Message}");
            //}

            //catch (FormatException err)
            //{
            //    Console.WriteLine($"Error: Please enter valid integers. {err.Message}");
            //}
            //catch (Exception err)
            //{
            //    Console.WriteLine($"Error: {err.Message}");
            //}
            //finally
            //{
            //    Console.WriteLine("Execution completed.");
            //}
            //Console.WriteLine("Press any key to exit...");
            //try
            //{
            //    a = ReadConsole.ReadInts("Enter a=");
            //    b = ReadConsole.ReadInts("Enter b=");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Error: {ex.Message}");
            //    return;
            //}


            //int c = a / b;
            //Console.WriteLine($"c = {c}");

            //string path = @"C:\data\envi\temp\text1.txt";
            ////string path = "C:\\data\\envi\\temp";
            //FileInfo fileInfo = new FileInfo(path);
            //fileInfo.Create();

            StreamReader reader = new StreamReader("file.txt");
            string line;
            line = reader.ReadLine();
            while (line != null)
            {
                // Do something with the line.
                string[] parts = line.Split(',');
                for (int i = 0; i < parts.Length; i++)
                {
                    Console.Write(parts[i]);
                    Console.Write("\t");
                }
                Console.WriteLine();
                line = reader.ReadLine();
            }
            //while ((line = reader.ReadLine()) != null)
            //{
            //    // Do something with the line.
            //    string[] parts = line.Split(',');
            //    for (int i = 0; i < parts.Length; i++)
            //    {
            //        Console.Write(parts[i]);
            //        Console.Write("\t");
            //    }
            //    Console.WriteLine();
            //}
            reader.Close();


            //StreamWriter writer = new StreamWriter("file.txt", true);
            //writer.WriteLine("New line added to the file.");

            //writer.Close();

            using (StreamWriter writer = new StreamWriter("file.txt", true))
            {
                writer.WriteLine("New line added to the file.");
            }
        }

    }
}








