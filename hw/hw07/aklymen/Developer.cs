namespace hw07
{
    class Developer : Staff
    {
        private string level;

        public Developer(string name, string level, double salary)
            : base(name, salary)
        {
            this.level = level;
        }

        public override void Print()
        {
            Console.WriteLine(
                $"Developer: {Name}, Level: {level}, Salary: {Salary}");
        }
    }

}
