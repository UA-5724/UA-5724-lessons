namespace HW7
{
    internal class Teacher : Staff
    {
        private string subject;

        public Teacher(string name, string subject, double salary) : base(name, salary)
        {
            this.subject = subject;
        }

        public string Subject
        {
            get { return subject; }
        }

        public override void Print()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return "Teacher, name: " + Name + ", subject: " + subject + ", salary: " + Salary;
        }
    }
}
