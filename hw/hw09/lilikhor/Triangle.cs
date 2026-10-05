using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_9._1
{
    public class Triangle
    {
        private readonly Point vertex1;
        private readonly Point vertex2;
        private readonly Point vertex3;

        public Triangle()
            : this(new Point(0, 0), new Point(1, 0), new Point(0, 1))
        {
        }

        public Triangle(Point vertex1, Point vertex2, Point vertex3)
        {
            if (vertex1 == null)
                throw new ArgumentNullException(nameof(vertex1));

            if (vertex2 == null)
                throw new ArgumentNullException(nameof(vertex2));

            if (vertex3 == null)
                throw new ArgumentNullException(nameof(vertex3));

            if (AreCollinear(vertex1, vertex2, vertex3))
                throw new ArgumentException("Points cannot be collinear.");

            // Composition: Triangle owns its own Points
            this.vertex1 = new Point(vertex1.X, vertex1.Y);
            this.vertex2 = new Point(vertex2.X, vertex2.Y);
            this.vertex3 = new Point(vertex3.X, vertex3.Y);
        }

        public double Distance(Point a, Point b)
        {
            if (a == null)
                throw new ArgumentNullException(nameof(a));

            if (b == null)
                throw new ArgumentNullException(nameof(b));

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
            double a = Distance(vertex1, vertex2);
            double b = Distance(vertex2, vertex3);
            double c = Distance(vertex3, vertex1);

            double semiPerimeter = Perimeter() / 2;

            return Math.Sqrt(
                semiPerimeter *
                (semiPerimeter - a) *
                (semiPerimeter - b) *
                (semiPerimeter - c)
            );
        }

        public Point GetVertex1()
        {
            return new Point(vertex1.X, vertex1.Y);
        }

        public Point GetVertex2()
        {
            return new Point(vertex2.X, vertex2.Y);
        }

        public Point GetVertex3()
        {
            return new Point(vertex3.X, vertex3.Y);
        }

        public Point GetClosestVertexToOrigin()
        {
            Point origin = new Point(0, 0);

            Point[] vertices =
            {
            vertex1,
            vertex2,
            vertex3
        };

            return vertices
                .OrderBy(point => point.DistanceTo(origin))
                .First();
        }

        public void Print()
        {
            Console.WriteLine($"Triangle: {vertex1}, {vertex2}, {vertex3}");
            Console.WriteLine($"Perimeter: {Perimeter():F2}");
            Console.WriteLine($"Area: {Area():F2}");
        }

        private static bool AreCollinear(Point a, Point b, Point c)
        {
            double area =
                a.X * (b.Y - c.Y) +
                b.X * (c.Y - a.Y) +
                c.X * (a.Y - b.Y);

            return Math.Abs(area) < 0.0000001;
        }
    }
}
