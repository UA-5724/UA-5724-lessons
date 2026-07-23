using System;

namespace hw3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int day, month;
            bool isValid = false;

            Console.Write("Enter day: ");
            day = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter month: ");
            month = Convert.ToInt32(Console.ReadLine());

            if (month >= 1 && month <= 12)
            {
                if ((month == 1 || month == 3 || month == 5 ||
                     month == 7 || month == 8 || month == 10 ||
                     month == 12) && day >= 1 && day <= 31)
                {
                    isValid = true;
                }
                else if ((month == 4 || month == 6 ||
                          month == 9 || month == 11) &&
                          day >= 1 && day <= 30)
                {
                    isValid = true;
                }
                else if (month == 2 && day >= 1 && day <= 28)
                {
                    isValid = true;
                }
            }

            Console.WriteLine("Valid date: " + isValid);

            Console.ReadKey();
        }
    }
}