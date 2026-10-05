namespace HW6
{
    internal class Builder : IDeveloper, IComparable
    {
        private string tool;

        public Builder(string tool)
        {
            this.tool = tool;
        }

        public string Tool
        {
            get { return tool; }
        }

        public void Create()
        {
            Console.WriteLine("The builder builds a house with a " + tool);
        }

        public void Destroy()
        {
            Console.WriteLine("The builder destroys the house with a " + tool);
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
