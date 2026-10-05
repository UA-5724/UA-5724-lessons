namespace HW10
{
    public class Square : Shape
    {
        private double side;

        public Square(string name, double side) : base(name)
        {
            this.side = side;
        }

        public double Side
        {
            get { return side; }
            set { side = value; }
        }

        public override double Area()
        {
            return side * side;
        }

        public override double Perimeter()
        {
            return 4 * side;
        }
    }
}
