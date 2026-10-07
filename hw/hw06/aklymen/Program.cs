namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            // 1. Interface IFlyable
            Console.WriteLine("IFlyable");

            List<IFlyable> items = new List<IFlyable>()
        {
            new Bird("Eagle", true),
            new Bird("Penguin", false),
            new Bird("Sparrow", true),
            new Plane("Boeing", 10000),
            new Plane("Airbus", 12000)
        };

            foreach (IFlyable item in items)
            {
                item.Fly();
            }

            Console.WriteLine();


            // 2. Collections
            Console.WriteLine("Collections");

            List<int> myColl = new List<int>();

            for (int index = 0; index < 10; index++)
            {
                Console.Write($"Enter integer {index + 1}: ");
                myColl.Add(int.Parse(Console.ReadLine()));
            }


            // Find positions of -10
            Console.WriteLine();
            Console.WriteLine("Positions of -10:");

            for (int index = 0; index < myColl.Count; index++)
            {
                if (myColl[index] == -10)
                {
                    Console.WriteLine(index);
                }
            }


            // Remove elements greater than 20
            for (int index = myColl.Count - 1; index >= 0; index--)
            {
                if (myColl[index] > 20)
                {
                    myColl.RemoveAt(index);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Collection after removing elements greater than 20:");

            foreach (int number in myColl)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();


            // Insert new elements
            myColl.Insert(2, 1);
            myColl.Insert(8, -3);
            myColl.Insert(5, -4);

            Console.WriteLine();
            Console.WriteLine("Collection after inserting elements:");

            foreach (int number in myColl)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();


            // Sort collection
            myColl.Sort();

            Console.WriteLine();
            Console.WriteLine("Sorted collection:");

            foreach (int number in myColl)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();
            Console.WriteLine();


            // 3. Interface IDeveloper
            Console.WriteLine("IDeveloper");

            List<IDeveloper> developers = new List<IDeveloper>()
        {
            new Programmer("C#"),
            new Programmer("Python"),
            new Builder("Hammer"),
            new Builder("Drill")
        };

            foreach (IDeveloper developer in developers)
            {
                developer.Create();
                developer.Destroy();
            }


            // Sort developers
            developers.Sort();

            Console.WriteLine();
            Console.WriteLine("Sorted developers:");

            foreach (IDeveloper developer in developers)
            {
                Console.WriteLine(developer.Tool);
            }

            Console.WriteLine();


            // 4. Dictionary
            Console.WriteLine("Dictionary");

            Dictionary<uint, string> persons = new Dictionary<uint, string>();

            for (int index = 0; index < 7; index++)
            {
                Console.Write($"Enter ID for person {index + 1}: ");
                uint id = uint.Parse(Console.ReadLine());

                Console.Write("Enter name: ");
                string name = Console.ReadLine() ?? "";

                persons.Add(id, name);
            }

            Console.WriteLine();
            Console.Write("Enter ID: ");
            uint searchId = uint.Parse(Console.ReadLine());

            if (persons.ContainsKey(searchId))
            {
                Console.WriteLine($"Name: {persons[searchId]}");
            }
            else
            {
                Console.WriteLine("ID not found.");
            }
        }
    }
}