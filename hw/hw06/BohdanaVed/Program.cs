namespace HW6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();
        }

        static void Task1()
        {
            Console.WriteLine("Task 6.1: Interface IFlyable");

            List<IFlyable> items = new List<IFlyable>()
            {
                new Bird("Eagle", true),
                new Bird("Penguin", false),
                new Plane("Boeing", 10000),
                new Plane("Airbus", 12000)
            };

            foreach (IFlyable item in items)
            {
                item.Fly();
            }

            Console.WriteLine();
        }

        static void Task2()
        {
            Console.WriteLine("Task 6.2: Collection of 10 numbers");

            List<int> myColl = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                myColl.Add(ReadInt("Number " + (i + 1) + ": "));
            }

            Console.WriteLine("The collection: " + string.Join(", ", myColl));

            Console.WriteLine("Positions of the element -10:");
            bool found = false;
            for (int i = 0; i < myColl.Count; i++)
            {
                if (myColl[i] == -10)
                {
                    Console.WriteLine("position " + i);
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("The element -10 was not found");
            }

            for (int i = myColl.Count - 1; i >= 0; i--)
            {
                if (myColl[i] > 20)
                {
                    myColl.RemoveAt(i);
                }
            }

            Console.WriteLine("The collection without the elements greater than 20: " + string.Join(", ", myColl));

            Insert(myColl, 1, 2);
            Insert(myColl, -3, 8);
            Insert(myColl, -4, 5);

            Console.WriteLine("The collection with the new elements: " + string.Join(", ", myColl));

            myColl.Sort();

            Console.WriteLine("The sorted collection: " + string.Join(", ", myColl));
            Console.WriteLine();
        }

        static void Task3()
        {
            Console.WriteLine("Task 6.3: Interface IDeveloper");

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

            developers.Sort();

            Console.WriteLine("The developers sorted by their tool:");
            foreach (IDeveloper developer in developers)
            {
                Console.WriteLine(developer.Tool);
            }

            Console.WriteLine();
        }

        static void Task4()
        {
            Console.WriteLine("Task 6.4: Dictionary of persons");

            Dictionary<uint, string> persons = new Dictionary<uint, string>();

            while (persons.Count < 7)
            {
                Console.Write("Enter the ID and the name (for example 1 John): ");
                string[] parts = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                uint id;
                if (parts.Length < 2 || !uint.TryParse(parts[0], out id))
                {
                    Console.WriteLine("Wrong input, try again");
                    continue;
                }

                if (persons.ContainsKey(id))
                {
                    Console.WriteLine("Such an ID already exists, try again");
                    continue;
                }

                persons.Add(id, parts[1]);
            }

            Console.Write("Enter the ID you are looking for: ");
            uint searchId;
            while (!uint.TryParse(Console.ReadLine(), out searchId))
            {
                Console.Write("This is not a correct ID, enter it again: ");
            }

            if (persons.ContainsKey(searchId))
            {
                Console.WriteLine("The name is " + persons[searchId]);
            }
            else
            {
                Console.WriteLine("There is no person with the ID " + searchId);
            }
        }

        static void Insert(List<int> collection, int value, int position)
        {
            if (position > collection.Count)
            {
                position = collection.Count;
            }

            collection.Insert(position, value);
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
    }
}
