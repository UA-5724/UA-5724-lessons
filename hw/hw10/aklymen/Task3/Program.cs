namespace hw10.Task3
{
    class Program
    {
        static void Main()
        {
            Student student = new Student("Anastasiia");
            Parent parent = new Parent();
            Accountancy accountancy = new Accountancy();

            student.MarkChange += parent.OnMarkChange;
            student.MarkChange += accountancy.PayingFellowship;


            student.AddMark(5);
            student.AddMark(4);
            student.AddMark(3);
            student.AddMark(2);

            Console.WriteLine();
        }
    }
}