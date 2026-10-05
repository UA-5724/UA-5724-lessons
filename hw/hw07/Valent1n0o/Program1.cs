using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace hw07
{
    class Person
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Person(string name)
        {
            this.name = name;
        }

        public virtual void Print()
        {
            Console.WriteLine($"Person: {Name}");
        }

        public override string ToString()
        {
            return $"Person: {Name}";
        }
    }

    class Staff : Person
    {
        private double salary;

        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public Staff(string name, double salary)
            : base(name)
        {
            this.salary = salary;
        }

        public override void Print()
        {
            Console.WriteLine(
                $"Staff: {Name}, Salary: {Salary:F2}"
            );
        }

        public override string ToString()
        {
            return $"Staff: {Name}, Salary: {Salary:F2}";
        }
    }

    class Teacher : Staff
    {
        private string subject;

        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        public Teacher(string name, string subject, double salary)
            : base(name, salary)
        {
            this.subject = subject;
        }

        public override void Print()
        {
            Console.WriteLine(
                $"Teacher: {Name}, Subject: {Subject}, Salary: {Salary:F2}"
            );
        }

        public override string ToString()
        {
            return $"Teacher: {Name}, Subject: {Subject}, Salary: {Salary:F2}";
        }
    }

    class Developer : Staff
    {
        private string level;

        public string Level
        {
            get { return level; }
            set { level = value; }
        }

        public Developer(string name, string level, double salary)
            : base(name, salary)
        {
            this.level = level;
        }

        public override void Print()
        {
            Console.WriteLine(
                $"Developer: {Name}, Level: {Level}, Salary: {Salary:F2}"
            );
        }

        public override string ToString()
        {
            return $"Developer: {Name}, Level: {Level}, Salary: {Salary:F2}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>
            {
                new Person("Ivan"),
                new Teacher("Gorpyna", "Math", 400),
                new Developer("Myron", "Senior", 4000),
                new Teacher("Hanna", "Physics", 700),
                new Developer("Myhaylo", "Junior", 12000)
            };

            Console.WriteLine("All people:");

            foreach (Person person in people)
            {
                person.Print();
            }

            Console.Write("\nEnter name to search: ");
            string searchName = Console.ReadLine() ?? string.Empty;

            Person? foundPerson = people.FirstOrDefault(
                person => person.Name.Equals(
                    searchName,
                    StringComparison.OrdinalIgnoreCase
                )
            );

            if (foundPerson != null)
            {
                Console.WriteLine("\nPerson found:");
                foundPerson.Print();
            }
            else
            {
                Console.WriteLine("\nPerson not found.");
            }

            List<Person> sortedPeople = people
                .OrderBy(person => person.Name)
                .ToList();

            Console.WriteLine("\nSorted by name:");

            foreach (Person person in sortedPeople)
            {
                person.Print();
            }

            File.WriteAllLines(
                "output.txt",
                sortedPeople.Select(person => person.ToString())
            );

            Console.WriteLine("\nSorted data saved to output.txt");

            List<Staff> employees = people
                .OfType<Staff>()
                .ToList();

            List<Staff> sortedEmployees = employees
                .OrderBy(employee => employee.Salary)
                .ToList();

            Console.WriteLine("\nEmployees sorted by salary:");

            foreach (Staff employee in sortedEmployees)
            {
                employee.Print();
            }
        }
    }
}