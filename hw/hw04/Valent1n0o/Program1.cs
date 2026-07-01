using System;

namespace hw4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter string: ");
            string s = Console.ReadLine().ToLower();

            int count = 0;

            foreach (char ch in s)
            {
                if (ch == 'a' || ch == 'b' || ch == 'c')
                {
                    count++;
                }
            }

            Console.WriteLine("Count of a, b, c characters = " + count);

            Console.ReadKey();
        }
    }
}