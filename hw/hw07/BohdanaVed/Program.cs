namespace HW7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PeopleTask();
            ShapesTask();
        }

        static void PeopleTask()
        {
            Console.WriteLine("Task 1: Person, Staff, Teacher, Developer");

            List<Person> people = new List<Person>
            {
                new Person("John"),
                new Teacher("Alice", "Math", 18000),
                new Developer("Bob", "Senior", 60000),
                new Teacher("Diana", "History", 16000),
                new Developer("Eva", "Junior", 25000)
            };

            Console.WriteLine("All the people:");
            foreach (Person person in people)
            {
                person.Print();
            }

            Console.WriteLine();
            Console.Write("Enter the name you are looking for: ");
            string name = Console.ReadLine();

            Person found = people.FirstOrDefault(person => person.Name == name);
            if (found != null)
            {
                Console.WriteLine("The person was found:");
                found.Print();
            }
            else
            {
                Console.WriteLine("There is no person with the name " + name);
            }

            List<Person> sortedByName = people.OrderBy(person => person.Name).ToList();

            Console.WriteLine();
            Console.WriteLine("The people sorted by name:");
            foreach (Person person in sortedByName)
            {
                person.Print();
            }

            string fileName = "output.txt";
            File.WriteAllLines(fileName, sortedByName.Select(person => person.ToString()));
            Console.WriteLine("The sorted list was saved to the file " + Path.GetFullPath(fileName));

            List<Staff> employees = people.OfType<Staff>().ToList();

            Console.WriteLine();
            Console.WriteLine("The employees sorted by salary:");
            foreach (Staff employee in employees.OrderBy(employee => employee.Salary))
            {
                employee.Print();
            }

            Console.WriteLine();
        }

        static void ShapesTask()
        {
            Console.WriteLine("Task 2: Shapes");

            List<Shape> shapes = new List<Shape>
            {
                new Circle("Circle1", 3),
                new Square("Square1", 4),
                new Circle("Circle2", 5),
                new Square("Square2", 2)
            };

            Operator.GetInfo(shapes);
            Operator.GetLargestPerimeter(shapes);
            Operator.Sort(shapes);
        }
    }
}
