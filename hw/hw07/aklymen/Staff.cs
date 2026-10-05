namespace hw07
{
    class Staff : Person, IComparable<Staff>
    {
        private double salary;

        public double Salary
        {
            get
            {
                return salary;
            }
        }

        public Staff()
        {
            salary = 0;
        }

        public Staff(string name, double salary)
            : base(name)
        {
            this.salary = salary;
        }

        public int CompareTo(Staff other)
        {
            return salary.CompareTo(other.salary);
        }

        public override string ToString()
        {
            return $"Name: {Name}, Salary: {salary}";
        }
    }

}
