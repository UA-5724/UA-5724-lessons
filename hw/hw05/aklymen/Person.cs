namespace hw05
{

    class Person
    {
        private string name;
        private DateTime birthYear;

        // Properties
        public string Name
        {
            get
            {
                return name;
            }
        }

        public DateTime BirthYear
        {
            get
            {
                return birthYear;
            }
        }

        // Default constructor
        public Person()
        {
            name = "";
            birthYear = DateTime.Now;
        }

        // Constructor with parameters
        public Person(string name, DateTime birthYear)
        {
            this.name = name;
            this.birthYear = birthYear;
        }

        // Age
        public int Age()
        {
            int age = DateTime.Now.Year - birthYear.Year;

            if (DateTime.Now < birthYear.AddYears(age))
            {
                age--;
            }

            return age;
        }

        // Input
        public void Input()
        {
            Console.Write("Enter name: ");
            name = Console.ReadLine() ?? "";

            Console.Write("Enter birth date (yyyy-MM-dd): ");
            birthYear = DateTime.Parse(Console.ReadLine());
        }

        // ChangeName
        public void ChangeName()
        {
            name = "Very Young";
        }

        // ToString
        public override string ToString()
        {
            return $"Name: {name}, Age: {Age()}";
        }

        // Output
        public void Output()
        {
            Console.WriteLine(ToString());
        }

        // Operator ==
        public static bool operator ==(Person a, Person b)
        {
            if (a == null && b == null)
            {
                return true;
            }

            if (a == null || b == null)
            {
                return false;
            }

            return a.name == b.name;
        }

        // Operator !=
        public static bool operator !=(Person a, Person b)
        {
            return !(a == b);
        }

        // Equals
        public override bool Equals(object obj)
        {
            if (obj is Person)
            {
                Person other = (Person)obj;
                return this == other;
            }

            return false;
        }

        // GetHashCode
        public override int GetHashCode()
        {
            return name.GetHashCode();
        }
    }
}
