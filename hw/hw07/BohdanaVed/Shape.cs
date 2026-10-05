namespace HW7
{
    internal abstract class Shape : IComparable<Shape>
    {
        private string name;

        public Shape(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }

        public abstract double Area();

        public abstract double Perimeter();

        public int CompareTo(Shape other)
        {
            if (other == null)
            {
                return 1;
            }

            return Area().CompareTo(other.Area());
        }
    }
}
