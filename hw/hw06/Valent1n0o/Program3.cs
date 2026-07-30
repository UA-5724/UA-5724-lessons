using System;
using System.Collections.Generic;

namespace hw06
{
    interface IDeveloper
    {
        string Tool { get; set; }

        void Create();
        void Destroy();
    }

    class Programmer : IDeveloper, IComparable<Programmer>
    {
        private string language;

        public string Tool
        {
            get { return language; }
            set { language = value; }
        }

        public Programmer(string language)
        {
            this.language = language;
        }

        public void Create()
        {
            Console.WriteLine(
                $"Programmer creates software using {language}."
            );
        }

        public void Destroy()
        {
            Console.WriteLine(
                $"Programmer removes software written in {language}."
            );
        }

        public int CompareTo(Programmer? other)
        {
            if (other is null)
            {
                return 1;
            }

            return string.Compare(
                Tool,
                other.Tool,
                StringComparison.OrdinalIgnoreCase
            );
        }

        public override string ToString()
        {
            return $"Programmer: {Tool}";
        }
    }

    class Builder : IDeveloper, IComparable<Builder>
    {
        private string tool;

        public string Tool
        {
            get { return tool; }
            set { tool = value; }
        }

        public Builder(string tool)
        {
            this.tool = tool;
        }

        public void Create()
        {
            Console.WriteLine(
                $"Builder creates a building using {tool}."
            );
        }

        public void Destroy()
        {
            Console.WriteLine(
                $"Builder destroys a structure using {tool}."
            );
        }

        public int CompareTo(Builder? other)
        {
            if (other is null)
            {
                return 1;
            }

            return string.Compare(
                Tool,
                other.Tool,
                StringComparison.OrdinalIgnoreCase
            );
        }

        public override string ToString()
        {
            return $"Builder: {Tool}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<IDeveloper> developers = new List<IDeveloper>
            {
                new Programmer("C++++"),
                new Programmer("Pascal"),
                new Builder("Mjollnir"),
                new Builder("JackHammer")
            };

            Console.WriteLine("Developers:");

            foreach (IDeveloper developer in developers)
            {
                developer.Create();
                developer.Destroy();
                Console.WriteLine();
            }

            developers.Sort(
                (first, second) => string.Compare(
                    first.Tool,
                    second.Tool,
                    StringComparison.OrdinalIgnoreCase
                )
            );

            Console.WriteLine("Sorted developers:");

            foreach (IDeveloper developer in developers)
            {
                Console.WriteLine(
                    $"{developer.GetType().Name}: {developer.Tool}"
                );
            }
        }
    }
}