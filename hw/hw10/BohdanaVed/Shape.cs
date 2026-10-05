namespace HW10
{
    public abstract class Shape : IComparable<Shape>
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

        public override string ToString()
        {
            return Name + ": area = " + Math.Round(Area(), 2) + ", perimeter = " + Math.Round(Perimeter(), 2);
        }
    }
}
