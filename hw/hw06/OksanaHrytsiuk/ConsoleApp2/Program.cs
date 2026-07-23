using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> myColl = new List<int>();

        Console.WriteLine("Enter 10 integers:");

        for (int i = 0; i < 10; i++)
        {
            myColl.Add(int.Parse(Console.ReadLine()));
        }

        // 1. Find positions of -10
        Console.WriteLine("\nPositions of -10:");

        for (int i = 0; i < myColl.Count; i++)
        {
            if (myColl[i] == -10)
            {
                Console.WriteLine(i);
            }
        }

        // 2. Remove elements greater than 20
        myColl.RemoveAll(x => x > 20);

        Console.WriteLine("\nAfter removing numbers > 20:");

        foreach (int item in myColl)
        {
            Console.Write(item + " ");
        }

        // 3. Insert new elements
        myColl.Insert(2, 1);
        myColl.Insert(5, -4);

        if (myColl.Count >= 8)
        {
            myColl.Insert(8, -3);
        }
        else
        {
            myColl.Add(-3);
        }

        Console.WriteLine("\n\nAfter inserting:");

        foreach (int item in myColl)
        {
            Console.Write(item + " ");
        }

        // 4. Sort
        myColl.Sort();

        Console.WriteLine("\n\nSorted:");

        foreach (int item in myColl)
        {
            Console.Write(item + " ");
        }
    }
}