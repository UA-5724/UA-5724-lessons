using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Programmer : IDeveloper
    {
        private string language;

        public string Tool
        {
            get
            {
                return language;
            }
        }

        public Programmer(string language)
        {
            this.language = language;
        }

        public void Create()
        {
            Console.WriteLine($"Programmer creates with {language}.");
        }

        public void Destroy()
        {
            Console.WriteLine($"Programmer destroys with {language}.");
        }

        public int CompareTo(IDeveloper other)
        {
            return Tool.CompareTo(other.Tool);
        }
    }
}
