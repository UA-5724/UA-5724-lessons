using System;

namespace hw05
{
    internal class Person
    {
        private string name;
        private int birthYear;

        public string Name
        {
            get { return name; }
        }

        public int BirthYear
        {
            get { return birthYear; }
        }

        public Person()
        {
            name = string.Empty;
            birthYear = DateTime.Now.Year;
        }

        public Person(string name, int birthYear)
        {
            this.name = name;
            this.birthYear = birthYear;
        }

        public int Age()
        {
            return DateTime.Now.Year - birthYear;
        }

        public void Input()
        {
            Console.Write("Enter name: ");
            name = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter birth year: ");

            while (!int.TryParse(Console.ReadLine(), out birthYear) ||
                   birthYear < 1900 ||
                   birthYear > DateTime.Now.Year)
            {
                Console.Write("Invalid year. Try again: ");
            }
        }

        public void ChangeName(string newName)
        {
            name = newName;
        }

        public void Output()
        {
            Console.WriteLine(ToString());
        }

        public static bool operator ==(Person? p1, Person? p2)
        {
            if (ReferenceEquals(p1, p2))
                return true;

            if (p1 is null || p2 is null)
                return false;

            return p1.name.Equals(p2.name,
                StringComparison.OrdinalIgnoreCase);
        }

        public static bool operator !=(Person? p1, Person? p2)
        {
            return !(p1 == p2);
        }

        public override bool Equals(object? obj)
        {
            return obj is Person other && this == other;
        }

        public override int GetHashCode()
        {
            return StringComparer.OrdinalIgnoreCase.GetHashCode(name);
        }

        public override string ToString()
        {
            return $"Name: {name}, Birth Year: {birthYear}, Age: {Age()}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            const int personCount = 6;

            Person[] people = new Person[personCount];

            for (int i = 0; i < people.Length; i++)
            {
                Console.WriteLine($"\nPerson {i + 1}");

                people[i] = new Person();
                people[i].Input();
            }

            Console.WriteLine("\nEntered people:");

            foreach (Person person in people)
            {
                Console.WriteLine($"Name: {person.Name}, Age: {person.Age()}");
            }

            foreach (Person person in people)
            {
                if (person.Age() < 16)
                {
                    person.ChangeName("Very Young");
                }
            }

            Console.WriteLine("\nUpdated information:");

            foreach (Person person in people)
            {
                person.Output();
            }

            Console.WriteLine("\nPeople with the same names:");

            bool found = false;

            for (int i = 0; i < people.Length; i++)
            {
                for (int j = i + 1; j < people.Length; j++)
                {
                    if (people[i] == people[j])
                    {
                        Console.WriteLine(
                            $"Person {i + 1} and Person {j + 1}: {people[i].Name}"
                        );

                        found = true;
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine("No people with the same names.");
            }
        }
    }
}