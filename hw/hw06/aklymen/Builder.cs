namespace ConsoleApp1
{
    class Builder : IDeveloper
    {
        private string tool;

        public string Tool
        {
            get
            {
                return tool;
            }
        }

        public Builder(string tool)
        {
            this.tool = tool;
        }

        public void Create()
        {
            Console.WriteLine($"Builder creates with {tool}.");
        }

        public void Destroy()
        {
            Console.WriteLine($"Builder destroys with {tool}.");
        }

        public int CompareTo(IDeveloper other)
        {
            return Tool.CompareTo(other.Tool);
        }
    }
}
