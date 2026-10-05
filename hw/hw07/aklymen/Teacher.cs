namespace hw07
{
    class Teacher : Staff
    {
        private string subject;

        public Teacher(string name, string subject, double salary)
            : base(name, salary)
        {
            this.subject = subject;
        }

        public override void Print()
        {
            Console.WriteLine(
                $"Teacher: {Name}, Subject: {subject}, Salary: {Salary}");
        }
    }

}
