namespace HW9
{
    public class Triangle
    {
        private readonly Point vertex1;
        private readonly Point vertex2;
        private readonly Point vertex3;

        public Triangle()
        {
            vertex1 = new Point(0, 0);
            vertex2 = new Point(1, 0);
            vertex3 = new Point(0, 1);
        }

        public Triangle(Point a, Point b, Point c)
        {
            if (a == null)
            {
                throw new ArgumentNullException(nameof(a));
            }

            if (b == null)
            {
                throw new ArgumentNullException(nameof(b));
            }

            if (c == null)
            {
                throw new ArgumentNullException(nameof(c));
            }

            if (AreCollinear(a, b, c))
            {
                throw new ArgumentException("The points " + a + " " + b + " " + c + " are collinear");
            }

            vertex1 = new Point(a.X, a.Y);
            vertex2 = new Point(b.X, b.Y);
            vertex3 = new Point(c.X, c.Y);
        }

        public Point Vertex1
        {
            get { return vertex1; }
        }

        public Point Vertex2
        {
            get { return vertex2; }
        }

        public Point Vertex3
        {
            get { return vertex3; }
        }

        public double Distance(Point a, Point b)
        {
            if (a == null)
            {
                throw new ArgumentNullException(nameof(a));
            }

            if (b == null)
            {
                throw new ArgumentNullException(nameof(b));
            }

            return a.DistanceTo(b);
        }

        public double Perimeter()
        {
            return Distance(vertex1, vertex2) + Distance(vertex2, vertex3) + Distance(vertex3, vertex1);
        }

        public double Area()
        {
            double a = Distance(vertex1, vertex2);
            double b = Distance(vertex2, vertex3);
            double c = Distance(vertex3, vertex1);
            double p = (a + b + c) / 2;
            double square = p * (p - a) * (p - b) * (p - c);

            if (square <= 0)
            {
                return 0;
            }

            return Math.Sqrt(square);
        }

        public double DistanceToOrigin()
        {
            Point origin = new Point(0, 0);
            double first = vertex1.DistanceTo(origin);
            double second = vertex2.DistanceTo(origin);
            double third = vertex3.DistanceTo(origin);

            return Math.Min(first, Math.Min(second, third));
        }

        public void Print()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return "Triangle " + vertex1 + " " + vertex2 + " " + vertex3
                + ", perimeter = " + Math.Round(Perimeter(), 2)
                + ", area = " + Math.Round(Area(), 2);
        }

        private static bool AreCollinear(Point a, Point b, Point c)
        {
            double doubledArea = (b.X - a.X) * (c.Y - a.Y) - (c.X - a.X) * (b.Y - a.Y);

            return Math.Abs(doubledArea) < 0.0000000001;
        }
    }
}
