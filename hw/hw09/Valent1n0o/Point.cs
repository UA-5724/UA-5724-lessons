using System;

namespace hw09
{
    public class Point
    {
        private double x;
        private double y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double X
        {
            get { return x; }
        }

        public double Y
        {
            get { return y; }
        }

        public double DistanceTo(Point other)
        {
            double deltaX = other.x - x;
            double deltaY = other.y - y;

            return Math.Sqrt(
                deltaX * deltaX +
                deltaY * deltaY
            );
        }

        public override string ToString()
        {
            return $"({x},{y})";
        }
    }
}