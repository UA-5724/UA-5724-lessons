namespace hw10.Task3
{
    class Student
    {
        public string Name { get; set; }

        public List<int> Marks { get; set; }

        public event MyDel MarkChange;

        public Student()
        {
            Name = "";
            Marks = new List<int>();
        }

        public Student(string name)
        {
            Name = name;
            Marks = new List<int>();
        }

        public void AddMark(int mark)
        {
            Marks.Add(mark);

            if (MarkChange != null)
            {
                MarkChange(mark);
            }
        }
    }
    public delegate void MyDel(int m);
}