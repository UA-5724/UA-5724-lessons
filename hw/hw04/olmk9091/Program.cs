using System;
using System.ComponentModel.Design;

class Program
{
    static void Main()
    {
        //Task 1 read a string str
        //read input in console
        string str = Console.ReadLine()!;
        //counter for matching characters
        int count = 0;
        //check each character in the string
        foreach (char ch in str)
        {
            //check characters (lowercase and uppercase)
            if (ch == 'a' || ch == 'a' ||
                ch == 'o' || ch == 'o' ||
                ch == 'i' || ch == 'i' ||
                ch == 'e' || ch == 'e')
            {
                //increase counter
                count++;
            }
        }
        //show total count
        Console.WriteLine(count);
        //Task 2 
        //read month number
        int month = int.Parse(Console.ReadLine()!);
        //check if the number is 2 - febtuary
        if (month == 2)
        {
            Console.WriteLine(28);
        }
        //check if the month has 30 days
        else if (month == 4 ||
                month == 6 ||
                month == 9 ||
                month == 11)
        {
            Console.WriteLine(30);
        }
        //all others month have 31
        else
        {
            Console.WriteLine(31);
        }
        //Task 3
        //store 10numbers
        int[] numbers = new int[10];
        //read 10 integer
        for (int i = 0; i < 10; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine()!);
        }
        //check if the first 5 numbers are possitive
        bool allpositive = true;
        for (int i = 0; i < 5; i++)
        {
            if (numbers[i] <= 0)
            {
                allpositive = false;
            }
        }
        //calculate result
        if (allpositive)
        {
            int sum = 0;
            for (int i = 0; i < 5; i++)
            {
                sum = sum + numbers[i];
            }
            Console.WriteLine(sum);
        }
        else
        {
            int product = 1;
            for (int i = 5; i < 10; i++)
            {
                product = product * numbers[i];
            }
            Console.WriteLine(product);
        }
        //Task 4
        //read range boundaries
        int a = int.Parse(Console.ReadLine()!);
        int b = int.Parse(Console.ReadLine()!);
        //counter for numbers divisible by 3
        int count2 = 0;
        //check every number in the range
        for (int i = a; i <= b; i++)
        {
            if (i % 3 == 0)
            {
                count2++;
            }
        }
        Console.WriteLine(count2);
        //Task 5
        //read entered into console value
        string text = Console.ReadLine()!;
        //print every 2nd character
        for (int i = 1; i < text.Length; i = i + 2)
        {
            Console.WriteLine(text[i]);
        }
        //Task 6
        //read entered into console drink name
        string drink = Console.ReadLine()!;
        //check drink type and show drink price
        switch (drink)
        {
            case "coffee":
                Console.WriteLine("Drink: coffee");
                Console.WriteLine("Price: 2.50");
                break;
            case "tea":
                Console.WriteLine("Drink: tea");
                Console.WriteLine("Price: 2.00");
                break;
            case "juice":
                Console.WriteLine("Drink: juice");
                Console.WriteLine("Price: 3.00");
                break;
            case "water":
                Console.WriteLine("Drink: water");
                Console.WriteLine("Price: 1.00");
                break;
            default:
                Console.WriteLine("Unknown drink");
                break;
        }
        //Task 7
        //store sum of positive numbers
        int sum2 = 0;
        // count positive numbers
        int count3 = 0;
        //read 1st number
        int number2 = int.Parse(Console.ReadLine()!);
        //verify positive numbers
        while (number2 > 0)
        {
            sum2 = sum2 + number2;
            count3++;
            number2 = int.Parse(Console.ReadLine()!);
        }
        //check if there where positive number
        if (count3 > 0)
        {
            //calculate arithmetic average
            double avarage = (double)sum2 / count3;
            //show result
            Console.WriteLine(avarage);
        }
        //Task 8
        //read the year
        int year = int.Parse(Console.ReadLine()!);
        //check if it's a leap year
        if ((year % 4 == 0 && year % 100 != 0) ||
            year % 400 == 0)
        {
            Console.WriteLine("Leap Year");
        }
        else
        {
            Console.WriteLine("Not a Leap Year");
        }
        //Task 9
        //read entered number
        int number3 = int.Parse(Console.ReadLine()!);
        //store sum of digits
        int sum3 = 0;
        //process all digits
        while (number3 > 0)
        {
            //extract last digit
            int digit = number3 % 10;
            //add digit to the sum
            sum3 = sum3 + digit;
            //remove last digit
            number3 = number3 / 10;
        }
        Console.WriteLine(sum3);
        //Task 10
        //read entered number
        int number4 = int.Parse(Console.ReadLine()!);
        //assume all digits are odd
        bool onlyOdd = true;
        //check each digit
        while (number4 > 0)
        {
            //extract last digit
            int digit = number4 % 10;
            //check if digit is even
            if (digit % 2 == 0)
            {
                onlyOdd = false;
            }
            //remove last digit
            number4 = number4 / 10;
        }
        Console.WriteLine(onlyOdd);
    }
}
