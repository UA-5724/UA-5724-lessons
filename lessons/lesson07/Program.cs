namespace ConsoleApp1
{

    interface IIntroducible
    {
        void Introduce();
    }

    interface IWorkable
    {
        void Work();
    }
    abstract class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person(string Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }
        public void Introduce()
        {
            Console.WriteLine($"Hello, my name is {Name} and I am {Age} years old.");
        }

        public virtual void Speak()
        {
            Console.WriteLine($"{Name} is speaking.");
        }
        //public abstract void Voice(); // Abstract method to be implemented by derived classes
    }

    class Student : Person, IIntroducible, IWorkable
    {
        public string School { get; set; }
        public Student(string name, int age, string school) : base(name, age)
        {
            School = school;
        }
        public void Study()
        {
            Console.WriteLine($"{Name} is studying at {School}.");
        }

        public void Introduce()
        {
            //Console.WriteLine($"Hello, my name is {Name}, I am {Age} years old and I study at {School}.");
            base.Introduce();
            //Study();
            this.Study();
            Console.WriteLine("I am a student at " + School + ".");
            // this.Introduce(); // This would cause infinite recursion
        }
        public void Work()
        {
            Console.WriteLine($"{Name} is working on assignments.");
        }
        public override void Speak()
        {
            Console.WriteLine($"{Name} is speaking as a student.");
        }
    }

    class Staff : Person
    {
        public string Position { get; set; }
        public Staff(string name, int age, string position) : base(name, age)
        {
            Position = position;
        }
        public void Work()
        {
            Console.WriteLine($"{Name} is working as a {Position}.");
        }
    }

    class Teacher : Staff
    {
        public string Subject { get; set; }
        public Teacher(string name, int age, string position, string subject) : base(name, age, position)
        {
            Subject = subject;
        }
        public void Teach()
        {
            Console.WriteLine($"{Name} is teaching {Subject}.");
        }
    }

    class Developer : Staff
    {
        public string ProgrammingLanguage { get; set; }
        public Developer(string name, int age, string position, string programmingLanguage) : base(name, age, position)
        {
            ProgrammingLanguage = programmingLanguage;
        }
        public void Code()
        {
            Console.WriteLine($"{Name} is coding in {ProgrammingLanguage}.");
        }
    }

    class TechnicalWriter
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public string Expertise { get; set; }
        public TechnicalWriter(string name, int age, string position, string expertise)
        {
            Name = name;
            Age = age;
            Position = position;
            Expertise = expertise;
        }
        public void Introduce()
        {
            Console.WriteLine($"Hello, my name is {Name} and I am {Age} years old.");
        }
        public void Work()
        {
            Console.WriteLine($"{Name} is working as a {Position}.");
        }
        public void WriteDocumentation()
        {
            Console.WriteLine($"{Name} is writing documentation on {Expertise}.");
        }
    }

    class TechnicalWriterIn : Staff
    {
        public string Expertise { get; set; }
        public TechnicalWriterIn(string name, int age, string position, string expertise) : base(name, age, position)
        {
            Expertise = expertise;
        }
        public void WriteDocumentation()
        {
            Console.WriteLine($"{Name} is writing documentation on {Expertise}.");
        }

    }






    internal class Program
    {
        static void Main(string[] args)
        {

            //Person person = new Person("Alice", 30);
            //person.Introduce();
            //Console.WriteLine($"person: {person.Name}, Age: {person.Age}");

            Student student = new Student("Bob", 20, "XYZ University");
            student.Introduce();
            student.Study();
            Console.WriteLine($"student: {student.Name}, Age: {student.Age}, School: {student.School}");

            Staff staff = new Staff("Charlie", 40, "Manager");
            staff.Introduce();
            staff.Work();
            Console.WriteLine($"staff: {staff.Name}, Age: {staff.Age}, Position: {staff.Position}");

            Teacher teacher = new Teacher("David", 35, "Teacher", "Mathematics");
            teacher.Introduce();
            teacher.Work();
            teacher.Teach();

            Developer developer = new Developer("Eve", 28, "Developer", "C#");
            developer.Introduce();
            developer.Work();
            developer.Code();

            TechnicalWriter technicalWriter = new TechnicalWriter("Frank", 32, "Technical Writer", "Software Documentation");
            technicalWriter.Introduce();
            technicalWriter.Work();
            technicalWriter.WriteDocumentation();

            TechnicalWriterIn technicalWriterIn = new TechnicalWriterIn("Grace", 29, "Technical Writer", "API Documentation");
            technicalWriterIn.Introduce();
            technicalWriterIn.Work();
            technicalWriterIn.WriteDocumentation();


            Console.WriteLine("Hello, World!");
        }
    }
}
