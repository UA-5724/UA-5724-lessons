using System;

class Program
{
    static void Main()
    {
        //// Task 1
        //string str = Console.ReadLine();

        //int countA = 0;
        //int countO = 0;
        //int countI = 0;
        //int countE = 0;

        //foreach (char c in str)
        //{
        //    switch (c)
        //    {
        //        case 'a':
        //        case 'A':
        //            countA++;
        //            break;

        //        case 'o':
        //        case 'O':
        //            countO++;
        //            break;

        //        case 'i':
        //        case 'I':
        //            countI++;
        //            break;

        //        case 'e':
        //        case 'E':
        //            countE++;
        //            break;
        //    }
        //}

        //Console.WriteLine("a: " + countA);
        //Console.WriteLine("o: " + countO);
        //Console.WriteLine("i: " + countI);
        //Console.WriteLine("e: " + countE);


        // Task 2
        //Console.Write("Enter month number (1-12): ");
        //int month = Convert.ToInt32(Console.ReadLine());

        //switch (month)
        //{
        //    case 1:
        //        Console.WriteLine("31 days");
        //        break;
        //    case 2:
        //        Console.WriteLine("28 days");
        //        break;
        //    case 3:
        //        Console.WriteLine("31 days");
        //        break;
        //    case 4:
        //        Console.WriteLine("30 days");
        //        break;
        //    case 5:
        //        Console.WriteLine("31 days");
        //        break;
        //    case 6:
        //        Console.WriteLine("30 days");
        //        break;
        //    case 7:
        //        Console.WriteLine("31 days");
        //        break;
        //    case 8:
        //        Console.WriteLine("31 days");
        //        break;
        //    case 9:
        //        Console.WriteLine("30 days");
        //        break;
        //    case 10:
        //        Console.WriteLine("31 days");
        //        break;
        //    case 11:
        //        Console.WriteLine("30 days");
        //        break;
        //    case 12:
        //        Console.WriteLine("31 days");
        //        break;
        //    default:
        //        Console.WriteLine("Invalid month number");
        //        break;
        //}


        // Task 3
        //int[] numbers = new int[10];

        //Console.WriteLine("Enter 10 integer numbers:");

        //for (int i = 0; i < 10; i++)
        //{
        //    numbers[i] = Convert.ToInt32(Console.ReadLine());
        //}

        //bool allPositive = true;

        //for (int i = 0; i < 5; i++)
        //{
        //    if (numbers[i] <= 0)
        //    {
        //        allPositive = false;
        //        break;
        //    }
        //}

        //if (allPositive)
        //{
        //    int sum = 0;

        //    for (int i = 0; i < 5; i++)
        //    {
        //        sum += numbers[i];
        //    }

        //    Console.WriteLine("Sum = " + sum);
        //}
        //else
        //{
        //    int product = 1;

        //    for (int i = 5; i < 10; i++)
        //    {
        //        product *= numbers[i];
        //    }

        //    Console.WriteLine("Product = " + product);
        //}


        //// Task 4
        //Console.Write("Enter first number: ");
        //int a = Convert.ToInt32(Console.ReadLine());

        //Console.Write("Enter second number: ");
        //int b = Convert.ToInt32(Console.ReadLine());

        //int count = 0;

        //for (int i = a; i <= b; i++)
        //{
        //    if (i % 3 == 0)
        //    {
        //        count++;
        //    }
        //}

        //Console.WriteLine("Count = " + count);


        //// Task 5
        //Console.Write("Enter text: ");
        //string text = Console.ReadLine();

        //for (int i = 1; i < text.Length; i += 2)
        //{
        //    Console.Write(text[i]);
        //}

        // Task 6
        //Console.Write("Enter drink name: ");
        //string drink = Console.ReadLine();

        //switch (drink)
        //{
        //    case "coffee":
        //        Console.WriteLine("Drink: Coffee");
        //        Console.WriteLine("Price: $3");
        //        break;

        //    case "tea":
        //        Console.WriteLine("Drink: Tea");
        //        Console.WriteLine("Price: $2");
        //        break;

        //    case "juice":
        //        Console.WriteLine("Drink: Juice");
        //        Console.WriteLine("Price: $4");
        //        break;

        //    case "water":
        //        Console.WriteLine("Drink: Water");
        //        Console.WriteLine("Price: $1");
        //        break;

        //    default:
        //        Console.WriteLine("Drink not found");
        //        break;
        //}


        // Task 7
        //int sum = 0;
        //int count = 0;

        //Console.WriteLine("Enter positive numbers (negative number to stop):");

        //int number = Convert.ToInt32(Console.ReadLine());

        //while (number >= 0)
        //{
        //    sum += number;
        //    count++;

        //    number = Convert.ToInt32(Console.ReadLine());
        //}

        //double average = (double)sum / count;

        //Console.WriteLine("Average = " + average);


        // Task 8
        //Console.Write("Enter year: ");
        //int year = Convert.ToInt32(Console.ReadLine());

        //if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
        //{
        //    Console.WriteLine("Leap year");
        //}
        //else
        //{
        //    Console.WriteLine("Not leap year");
        //}


        // Task 9
        //Console.Write("Enter an integer: ");
        //int number = Convert.ToInt32(Console.ReadLine());

        //int sum = 0;

        //while (number != 0)
        //{
        //    sum += number % 10;
        //    number /= 10;
        //}

        //Console.WriteLine("Sum of digits = " + sum);


        // Task 10
        Console.Write("Enter an integer: ");
        int number = Convert.ToInt32(Console.ReadLine());

        bool allOdd = true;

        while (number != 0)
        {
            int digit = number % 10;

            if (digit % 2 == 0)
            {
                allOdd = false;
                break;
            }

            number /= 10;
        }

        Console.WriteLine(allOdd);
    }
}