namespace HW6
{
    internal class Programmer : IDeveloper, IComparable
    {
        private string language;

        public Programmer(string language)
        {
            this.language = language;
        }

        public string Tool
        {
            get { return language; }
        }

        public void Create()
        {
            Console.WriteLine("The programmer writes a program in " + language);
        }

        public void Destroy()
        {
            Console.WriteLine("The programmer deletes the program written in " + language);
        }

        public int CompareTo(object obj)
        {
            IDeveloper other = obj as IDeveloper;
            if (other == null)
            {
                return 1;
            }

            return string.Compare(Tool, other.Tool);
        }
    }
}
