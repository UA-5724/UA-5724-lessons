using System;
class Program
{
    interface IDeveloper
    {
        string Tool { get; }

        void Create();

        void Destroy();
    }
    class Programmer : IDeveloper, IComparable<IDeveloper>
    {
        // programmer field
        private string language = "";
        // constructor with parameters
        public Programmer(string language)
        {
            this.language = language;
        }
        // developer tool
        public string Tool
        {
            get
            {
                return language;
            }
        }
        public int CompareTo(IDeveloper? other)
        {
            if (other == null)
            {
                return 1;
            }

            int result = GetType().Name.CompareTo(other.GetType().Name);

            if (result == 0)
            {
                return Tool.CompareTo(other.Tool);
            }

            return result;
        }
        // create software
        public void Create()
        {
            Console.WriteLine($"Programmer writes {language} code.");
        }
        // remove software
        public void Destroy()
        {
            Console.WriteLine("Programmer deletes code.");
        }
    }
    class Builder : IDeveloper, IComparable<IDeveloper>
    {
        // builder field
        private string tool = "";
        public Builder(string tool)
        {
            this.tool = tool;
        }
        public string Tool
        {
            get
            {
                return tool;
            }
        }
        public int CompareTo(IDeveloper? other)
        {
            if (other == null)
            {
                return 1;
            }

            int result = GetType().Name.CompareTo(other.GetType().Name);

            if (result == 0)
            {
                return Tool.CompareTo(other.Tool);
            }

            return result;
        }
        public void Create()
        {
            Console.WriteLine($"Builder creates using {tool}.");
        }
        public void Destroy()
        {
            Console.WriteLine("Builder demolishes the building.");
        }
    }
    
    static void Main()
    {
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
        developers.Sort((a, b) =>
        {
            // compare by developer type
            int result = a.GetType().Name.CompareTo(b.GetType().Name);
            // if types are equal, compare by tool
            if (result == 0)
            {
                return a.Tool.CompareTo(b.Tool);
            }

            return result;
        });
    }
}
