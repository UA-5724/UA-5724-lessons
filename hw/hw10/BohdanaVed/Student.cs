namespace HW10
{
    public class Student
    {
        private string name;
        private List<int> marks;

        public Student()
        {
            marks = new List<int>();
        }

        public Student(string name)
        {
            this.name = name;
            marks = new List<int>();
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public List<int> Marks
        {
            get { return marks; }
            set { marks = value; }
        }

        public event MyDel MarkChange;

        public void AddMark(int mark)
        {
            marks.Add(mark);

            if (MarkChange != null)
            {
                MarkChange(mark);
            }
        }

        public override string ToString()
        {
            return "Student " + name + ", marks: " + string.Join(", ", marks);
        }
    }
}
