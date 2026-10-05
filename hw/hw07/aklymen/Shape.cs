namespace hw07
{
    abstract class Shape : IComparable<Shape>
    {
        private string name;

        public string Name
        {
            get
            {
                return name;
            }
        }

        public Shape(string name)
        {
            this.name = name;
        }

        public abstract double Area();

        public abstract double Perimeter();

        public int CompareTo(Shape other)
        {
            return Area().CompareTo(other.Area());
        }
    }

}
