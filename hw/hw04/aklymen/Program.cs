class Program
{
    static void Main()
    {
        // 1. Count characters
        Console.Write("Enter a string: ");
        string str = Console.ReadLine() ?? "";

        int aCount = 0;
        int oCount = 0;
        int iCount = 0;
        int eCount = 0;

        foreach (char character in str)
        {
            switch (char.ToLower(character))
            {
                case 'a':
                    aCount++;
                    break;

                case 'o':
                    oCount++;
                    break;

                case 'i':
                    iCount++;
                    break;

                case 'e':
                    eCount++;
                    break;
            }
        }

        Console.WriteLine($"a: {aCount}");
        Console.WriteLine($"o: {oCount}");
        Console.WriteLine($"i: {iCount}");
        Console.WriteLine($"e: {eCount}");
        Console.WriteLine();


        // 2. Number of days in a month
        Console.Write("Enter month number (1-12): ");
        int month = int.Parse(Console.ReadLine());

        switch (month)
        {
            case 1:
            case 3:
            case 5:
            case 7:
            case 8:
            case 10:
            case 12:
                Console.WriteLine("31 days");
                break;

            case 4:
            case 6:
            case 9:
            case 11:
                Console.WriteLine("30 days");
                break;

            case 2:
                Console.WriteLine("28 days");
                break;

            default:
                Console.WriteLine("Invalid month!");
                break;
        }

        Console.WriteLine();


        // 3. Sum of first 5 or product of last 5
        int[] numbers = new int[10];

        for (int index = 0; index < 10; index++)
        {
            Console.Write($"Enter {index + 1}st integer: ");
            numbers[index] = int.Parse(Console.ReadLine());
        }

        bool firstFivePositive = true;

        for (int index = 0; index < 5; index++)
        {
            if (numbers[index] <= 0)
            {
                firstFivePositive = false;
                break;
            }
        }

        if (firstFivePositive)
        {
            int sum2 = 0;

            for (int index = 0; index < 5; index++)
            {
                sum2 += numbers[index];
            }

            Console.WriteLine($"Sum of first 5 numbers: {sum2}");
        }
        else
        {
            int product = 1;

            for (int index = 5; index < 10; index++)
            {
                product *= numbers[index];
            }

            Console.WriteLine($"Product of last 5 numbers: {product}");
        }

        Console.WriteLine();


        // 4. Count numbers divisible by 3
        Console.Write("Enter a: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Enter b: ");
        int b = int.Parse(Console.ReadLine());

        int count = 0;

        if (a > b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        for (int number1 = a; number1 <= b; number1++)
        {
            if (number1 % 3 == 0)
            {
                count++;
            }
        }

        Console.WriteLine($"Numbers divisible by 3: {count}");
        Console.WriteLine();


        // 5. Print every second character
        Console.Write("Enter text: ");
        string text = Console.ReadLine() ?? "";

        Console.Write("Every second character: ");

        for (int index = 1; index < text.Length; index += 2)
        {
            Console.Write(text[index]);
        }

        Console.WriteLine();
        Console.WriteLine();


        // 6. Drink name and price
        Console.Write("Enter drink name: ");
        string drink = (Console.ReadLine() ?? "").ToLower();

        switch (drink)
        {
            case "coffee":
                Console.WriteLine("Drink: Coffee");
                Console.WriteLine("Price: $3.50");
                break;

            case "tea":
                Console.WriteLine("Drink: Tea");
                Console.WriteLine("Price: $2.50");
                break;

            case "juice":
                Console.WriteLine("Drink: Juice");
                Console.WriteLine("Price: $3.00");
                break;

            case "water":
                Console.WriteLine("Drink: Water");
                Console.WriteLine("Price: $1.50");
                break;

            default:
                Console.WriteLine("Unknown drink!");
                break;
        }

        Console.WriteLine();


        // 7. Average of positive numbers
        int sum = 0;
        int positiveCount = 0;
        int number;

        do
        {
            Console.Write("Enter positive integer (negative number to stop): ");
            number = int.Parse(Console.ReadLine());

            if (number > 0)
            {
                sum += number;
                positiveCount++;
            }

        } while (number >= 0);

        if (positiveCount > 0)
        {
            double average = (double)sum / positiveCount;
            Console.WriteLine($"Arithmetic average: {average}");
        }
        else
        {
            Console.WriteLine("No positive numbers entered.");
        }

        Console.WriteLine();


        // 8. Leap year
        Console.Write("Enter year: ");
        int year = int.Parse(Console.ReadLine());

        bool isLeapYear =
            year % 400 == 0 ||
            year % 4 == 0 && year % 100 != 0;

        Console.WriteLine($"Leap year: {isLeapYear}");
        Console.WriteLine();


        // 9. Sum of digits
        Console.Write("Enter integer number: ");
        int digitNumber = int.Parse(Console.ReadLine());

        digitNumber = Math.Abs(digitNumber);

        int digitSum = 0;

        while (digitNumber > 0)
        {
            digitSum += digitNumber % 10;
            digitNumber /= 10;
        }

        Console.WriteLine($"Sum of digits: {digitSum}");
        Console.WriteLine();


        // 10. Check if number contains only odd digits
        Console.Write("Enter integer number: ");
        int oddNumber = int.Parse(Console.ReadLine());

        oddNumber = Math.Abs(oddNumber);

        bool onlyOddDigits = true;

        while (oddNumber > 0)
        {
            int digit = oddNumber % 10;

            if (digit % 2 == 0)
            {
                onlyOddDigits = false;
                break;
            }

            oddNumber /= 10;
        }

        Console.WriteLine($"Contains only odd digits: {onlyOddDigits}");
    }
}