namespace HW5
{
    internal class Person
    {
        private string name;
        private DateTime birthYear;

        public Person()
        {
            name = "unknown";
            birthYear = new DateTime(2000, 1, 1);
        }

        public Person(string name, DateTime birthYear)
        {
            this.name = name;
            this.birthYear = birthYear;
        }

        public string Name
        {
            get { return name; }
        }

        public DateTime BirthYear
        {
            get { return birthYear; }
        }

        public int Age()
        {
            return DateTime.Now.Year - birthYear.Year;
        }

        public void Input()
        {
            Console.Write("Enter the name: ");
            name = Console.ReadLine();

            int year;
            Console.Write("Enter the year of birth: ");
            while (!int.TryParse(Console.ReadLine(), out year) || year < 1900 || year > DateTime.Now.Year)
            {
                Console.Write("Wrong year, enter it again (1900-" + DateTime.Now.Year + "): ");
            }

            birthYear = new DateTime(year, 1, 1);
        }

        public void ChangeName(string newName)
        {
            name = newName;
        }

        public override string ToString()
        {
            return "Name: " + name + ", year of birth: " + birthYear.Year + ", age: " + Age();
        }

        public void Output()
        {
            Console.WriteLine(ToString());
        }

        public static bool operator ==(Person a, Person b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return false;
            }

            return a.name == b.name;
        }

        public static bool operator !=(Person a, Person b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            return this == obj as Person;
        }

        public override int GetHashCode()
        {
            return name == null ? 0 : name.GetHashCode();
        }
    }
}
