using System;

namespace hw09
{
    public class Triangle
    {
        private Point vertex1;
        private Point vertex2;
        private Point vertex3;

        // дефолтний конструктор
        public Triangle()
        {
            vertex1 = new Point(0, 0);
            vertex2 = new Point(1, 0);
            vertex3 = new Point(0, 1);
        }

        // триточковий конструктор
        public Triangle(Point point1, Point point2, Point point3)
        {
            vertex1 = new Point(point1.X, point1.Y);
            vertex2 = new Point(point2.X, point2.Y);
            vertex3 = new Point(point3.X, point3.Y);
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

            double semiPerimeter =
                (side1 + side2 + side3) / 2;

            return Math.Sqrt(
                semiPerimeter *
                (semiPerimeter - side1) *
                (semiPerimeter - side2) *
                (semiPerimeter - side3)
            );
        }
        public double DistanceToClosestVertex(Point point)
        {
            double distance1 = vertex1.DistanceTo(point);
            double distance2 = vertex2.DistanceTo(point);
            double distance3 = vertex3.DistanceTo(point);

            return Math.Min(
                distance1,
                Math.Min(distance2, distance3)
            );
        }

        public void Print()
        {
            Console.WriteLine(
                $"Triangle: {vertex1}, {vertex2}, {vertex3}"
            );

            Console.WriteLine(
                $"Perimeter: {Perimeter():F2}"
            );

            Console.WriteLine(
                $"Area: {Area():F2}"
            );
        }
    }
}