namespace HW4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
            Task6();
            Task7();
            Task8();
            Task9();
            Task10();
        }

        static void Task1()
        {
            Console.WriteLine("Task 1: Count characters 'a', 'o', 'i', 'e'");
            Console.Write("Enter a string: ");
            string str = Console.ReadLine();

            char[] letters = { 'a', 'o', 'i', 'e' };
            int[] counts = new int[letters.Length];

            foreach (char symbol in str)
            {
                char lower = char.ToLower(symbol);
                for (int i = 0; i < letters.Length; i++)
                {
                    if (lower == letters[i])
                    {
                        counts[i]++;
                    }
                }
            }

            for (int i = 0; i < letters.Length; i++)
            {
                Console.WriteLine("'" + letters[i] + "' = " + counts[i]);
            }
            Console.WriteLine();
        }

        static void Task2()
        {
            Console.WriteLine("Task 2: Number of days in a month");
            int month = ReadIntInRange("Enter the month number (1-12): ", 1, 12);

            int days;
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    days = 31;
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    days = 30;
                    break;
                default:
                    days = 28;
                    break;
            }

            Console.WriteLine("Month " + month + " has " + days + " days");
            Console.WriteLine();
        }

        static void Task3()
        {
            Console.WriteLine("Task 3: Sum of the first 5 or product of the last 5 numbers");
            int[] numbers = new int[10];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = ReadInt("Number " + (i + 1) + ": ");
            }

            bool firstFivePositive = true;
            for (int i = 0; i < 5; i++)
            {
                if (numbers[i] <= 0)
                {
                    firstFivePositive = false;
                }
            }

            if (firstFivePositive)
            {
                int sum = 0;
                for (int i = 0; i < 5; i++)
                {
                    sum += numbers[i];
                }
                Console.WriteLine("The first 5 numbers are positive, their sum = " + sum);
            }
            else
            {
                long product = 1;
                for (int i = 5; i < 10; i++)
                {
                    product *= numbers[i];
                }
                Console.WriteLine("Not all of the first 5 numbers are positive, the product of the last 5 = " + product);
            }
            Console.WriteLine();
        }

        static void Task4()
        {
            Console.WriteLine("Task 4: Numbers divisible by 3 in the range [a..b]");
            int a = ReadInt("Enter a: ");
            int b = ReadInt("Enter b: ");

            if (a > b)
            {
                int temp = a;
                a = b;
                b = temp;
            }

            int count = 0;
            for (int i = a; i <= b; i++)
            {
                if (i % 3 == 0)
                {
                    count++;
                }
            }

            Console.WriteLine("In the range [" + a + ".." + b + "] there are " + count + " numbers divisible by 3");
            Console.WriteLine();
        }

        static void Task5()
        {
            Console.WriteLine("Task 5: Every second character of a string");
            Console.Write("Enter a string: ");
            string text = Console.ReadLine();

            string result = "";
            for (int i = 1; i < text.Length; i += 2)
            {
                result += text[i];
            }

            Console.WriteLine("Every second character: " + result);
            Console.WriteLine();
        }

        static void Task6()
        {
            Console.WriteLine("Task 6: Price of a drink");
            Console.Write("Enter the name of the drink (coffee, tea, juice, water): ");
            string drink = Console.ReadLine().ToLower();

            switch (drink)
            {
                case "coffee":
                    Console.WriteLine("Drink: coffee, price: 45 UAH");
                    break;
                case "tea":
                    Console.WriteLine("Drink: tea, price: 30 UAH");
                    break;
                case "juice":
                    Console.WriteLine("Drink: juice, price: 25 UAH");
                    break;
                case "water":
                    Console.WriteLine("Drink: water, price: 15 UAH");
                    break;
                default:
                    Console.WriteLine("We do not have such a drink");
                    break;
            }
            Console.WriteLine();
        }

        static void Task7()
        {
            Console.WriteLine("Task 7: Average of positive numbers");
            int sum = 0;
            int count = 0;

            while (true)
            {
                int number = ReadInt("Enter a number (a negative number stops the input): ");
                if (number < 0)
                {
                    break;
                }
                sum += number;
                count++;
            }

            if (count == 0)
            {
                Console.WriteLine("No positive numbers were entered");
            }
            else
            {
                double average = (double)sum / count;
                Console.WriteLine("Sum = " + sum + ", quantity = " + count + ", average = " + average);
            }
            Console.WriteLine();
        }

        static void Task8()
        {
            Console.WriteLine("Task 8: Leap year");
            int year = ReadInt("Enter the year: ");

            bool isLeap = (year % 4 == 0 && year % 100 != 0) || year % 400 == 0;

            if (isLeap)
            {
                Console.WriteLine(year + " is a leap year");
            }
            else
            {
                Console.WriteLine(year + " is not a leap year");
            }
            Console.WriteLine();
        }

        static void Task9()
        {
            Console.WriteLine("Task 9: Sum of the digits of a number");
            int number = ReadInt("Enter an integer number: ");

            int rest = Math.Abs(number);
            int sum = 0;
            do
            {
                sum += rest % 10;
                rest /= 10;
            }
            while (rest > 0);

            Console.WriteLine("The sum of the digits of the number " + number + " = " + sum);
            Console.WriteLine();
        }

        static void Task10()
        {
            Console.WriteLine("Task 10: Only odd digits");
            int number = ReadInt("Enter an integer number: ");

            int rest = Math.Abs(number);
            bool onlyOdd = true;
            do
            {
                int digit = rest % 10;
                if (digit % 2 == 0)
                {
                    onlyOdd = false;
                }
                rest /= 10;
            }
            while (rest > 0);

            Console.WriteLine("The number " + number + " consists of odd digits only: " + onlyOdd);
        }

        static int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                int value;
                if (int.TryParse(Console.ReadLine(), out value))
                {
                    return value;
                }
                Console.WriteLine("This is not a whole number, try again");
            }
        }

        static int ReadIntInRange(string message, int min, int max)
        {
            while (true)
            {
                int value = ReadInt(message);
                if (value >= min && value <= max)
                {
                    return value;
                }
                Console.WriteLine("The number must be from " + min + " to " + max);
            }
        }
    }
}
