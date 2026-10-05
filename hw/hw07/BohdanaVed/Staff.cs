namespace HW7
{
    internal class Staff : Person
    {
        private double salary;

        public Staff(string name, double salary) : base(name)
        {
            this.salary = salary;
        }

        public double Salary
        {
            get { return salary; }
        }

        public override void Print()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return "Staff, name: " + Name + ", salary: " + salary;
        }
    }
}
