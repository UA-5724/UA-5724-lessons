namespace hw09
{
    class Triangle
    {
        private Point vertex1;
        private Point vertex2;
        private Point vertex3;


        public Triangle()
        {
            vertex1 = new Point(0, 0);
            vertex2 = new Point(1, 0);
            vertex3 = new Point(0, 1);
        }


        public Triangle(Point vertex1, Point vertex2, Point vertex3)
        {
            if (IsCollinear(vertex1, vertex2, vertex3))
            {
                throw new ArgumentException("Points cannot be collinear.");
            }

            this.vertex1 = vertex1;
            this.vertex2 = vertex2;
            this.vertex3 = vertex3;
        }


        public double Distance(Point a, Point b)
        {
            return a.DistanceTo(b);
        }


        public double Perimeter()
        {
            double side1 = Distance(vertex1, vertex2);
            double side2 = Distance(vertex2, vertex3);
            double side3 = Distance(vertex3, vertex1);

            return side1 + side2 + side3;
        }


        public double Area()
        {
            double side1 = Distance(vertex1, vertex2);
            double side2 = Distance(vertex2, vertex3);
            double side3 = Distance(vertex3, vertex1);

            double semiPerimeter = Perimeter() / 2;

            return Math.Sqrt(
                semiPerimeter *
                (semiPerimeter - side1) *
                (semiPerimeter - side2) *
                (semiPerimeter - side3));
        }


        public void Print()
        {
            Console.WriteLine($"Vertex 1: {vertex1}");
            Console.WriteLine($"Vertex 2: {vertex2}");
            Console.WriteLine($"Vertex 3: {vertex3}");
            Console.WriteLine($"Perimeter: {Perimeter():F2}");
            Console.WriteLine($"Area: {Area():F2}");
        }


        public Point GetClosestVertexToOrigin()
        {
            Point origin = new Point(0, 0);

            double distance1 = vertex1.DistanceTo(origin);
            double distance2 = vertex2.DistanceTo(origin);
            double distance3 = vertex3.DistanceTo(origin);

            if (distance1 <= distance2 && distance1 <= distance3)
            {
                return vertex1;
            }

            if (distance2 <= distance1 && distance2 <= distance3)
            {
                return vertex2;
            }

            return vertex3;
        }


        public double GetClosestVertexDistance()
        {
            Point origin = new Point(0, 0);

            double distance1 = vertex1.DistanceTo(origin);
            double distance2 = vertex2.DistanceTo(origin);
            double distance3 = vertex3.DistanceTo(origin);

            return Math.Min(distance1, Math.Min(distance2, distance3));
        }


        private bool IsCollinear(Point a, Point b, Point c)
        {
            double result =
                (b.X - a.X) * (c.Y - a.Y) -
                (b.Y - a.Y) * (c.X - a.X);

            return result == 0;
        }
    }

}
