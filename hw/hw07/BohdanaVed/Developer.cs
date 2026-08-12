namespace HW7
{
    internal class Developer : Staff
    {
        private string level;

        public Developer(string name, string level, double salary) : base(name, salary)
        {
            this.level = level;
        }

        public string Level
        {
            get { return level; }
        }

        public override void Print()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return "Developer, name: " + Name + ", level: " + level + ", salary: " + Salary;
        }
    }
}
