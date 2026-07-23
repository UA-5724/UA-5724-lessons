using System;
class Program
{
    static void Main()
    {
        //create a collection of integers
        List<int> myColl = new List<int>();
        //read 10 integers from the console
        for (int i = 0; i < 10; i++)
        {
            //add each number to the collection
            myColl.Add(int.Parse(Console.ReadLine()!));
        }

        Console.WriteLine("Positions of -10:");

        //find positions of -10
        for (int i = 0; i < myColl.Count; i++)
        {
            //check every element in the collection
            if (myColl[i] == -10)
            {
                Console.WriteLine(i);
            }
        }
        //remove elements greater than 20
        myColl.RemoveAll(x => x > 20);

        Console.WriteLine("Collection after removing elements:");

        //display the updated collection
        foreach (int number in myColl)
        {
            Console.WriteLine(number);
        }
        //insert new elements into the collection
        myColl.Insert(8, -3);
        myColl.Insert(5, -4);
        myColl.Insert(2, 1);

        Console.WriteLine("Collection after inserting elements:");

        //display the updated collection
        foreach (int number in myColl)
        {
            Console.WriteLine(number);
        }
        //sort collection in ascending order
        myColl.Sort();

        Console.WriteLine("Sorted collection:");

        //display the sorted collection
        foreach (int number in myColl)
        {
            Console.WriteLine(number);
        }
    }
}
