namespace hw07
{
    class Program
    {
        static void Main()
        {
            // Part 1. Person, Staff, Teacher, Developer

            List<Person> people = new List<Person>()
        {
            new Person("John"),
            new Teacher("Alice", "Math", 2500),
            new Teacher("Kate", "English", 2700),
            new Developer("Bob", "Senior", 4000),
            new Developer("Mike", "Junior", 2000),
            new Person("Tom")
        };


            // Print all people
            Console.WriteLine("All people:");

            foreach (Person person in people)
            {
                person.Print();
            }

            Console.WriteLine();


            // Search by name
            Console.Write("Enter name to search: ");
            string searchName = Console.ReadLine() ?? "";

            foreach (Person person in people)
            {
                if (person.Name == searchName)
                {
                    person.Print();
                }
            }

            Console.WriteLine();


            // Sort by name
            people.Sort();

            Console.WriteLine("People sorted by name:");

            foreach (Person person in people)
            {
                person.Print();
            }

            Console.WriteLine();


            // Save result to file
            using (StreamWriter writer = new StreamWriter("output.txt"))
            {
                foreach (Person person in people)
                {
                    writer.WriteLine(person);
                }
            }

            Console.WriteLine("People saved to output.txt.");
            Console.WriteLine();


            // Employees list
            List<Staff> employees = new List<Staff>();

            foreach (Person person in people)
            {
                if (person is Staff)
                {
                    employees.Add((Staff)person);
                }
            }


            // Sort employees by salary
            employees.Sort();

            Console.WriteLine("Employees sorted by salary:");

            foreach (Staff employee in employees)
            {
                employee.Print();
            }

            Console.WriteLine();


            // Part 2. Shapes

            List<Shape> shapes = new List<Shape>()
        {
            new Circle("Circle1", 3),
            new Square("Square1", 4),
            new Circle("Circle2", 5),
            new Square("Square2", 2)
        };

            Operator.GetInfo(shapes);

            Console.WriteLine();

            Operator.GetLargestPerimeter(shapes);

            Console.WriteLine();


            Operator.Sort(shapes);
        }
    }
   
}